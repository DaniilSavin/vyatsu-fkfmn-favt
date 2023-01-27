import javax.print.DocFlavor;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FilenameFilter;
import java.io.IOException;
import java.nio.file.*;
import java.nio.file.attribute.BasicFileAttributes;
import java.util.InputMismatchException;
import java.util.Scanner;


public class WorkingDirectory
{
    private static WorkingDirectory instance;
    String directoryName;

    private WorkingDirectory(String directoryName)
    {
        this.directoryName = directoryName;
    }

    public static WorkingDirectory getInstance(String directoryName)
    {
        if (instance == null)
            instance = new WorkingDirectory(directoryName);
        return instance;
    }
    public static String WorkDirOut(String directoryName) throws Exception
    {
        String dirname = "Laboratornaya_3";
        File f1 = new File(directoryName);
        if (f1.isDirectory())
        {
            String s[] = f1.list();
            for ( int i=0; i < s.length; i++)
            {
                File f = new File( s[i]+ "\n");
                System.out.println(s[i]);
            }
        }
        else
            throw new Exception("Файл не является каталогом");
        return directoryName;

    }

    public static String GetParentName(String directoryName)
    {
        File f1 = new File(directoryName);
        System.out.print(f1.getParentFile().getName() + " ");
        return directoryName;
    }
    public static String GetParent(String directoryName)
    {
        File f1 = new File(directoryName);
        return f1.getParent();
    }

    public static String GetListOfFolders (String directoryName) throws IOException {
        File f1 = new File(directoryName);
        Path parent = Paths.get(directoryName);
        Files.walkFileTree(parent,new SimpleFileVisitor<Path>() {

            @Override
            public FileVisitResult preVisitDirectory(Path dir, BasicFileAttributes attrs) throws IOException {
                int count = dir.getNameCount() - parent.getNameCount() + 1;
                count += dir.getFileName().toString().length();
                String text = String.format("%" + count + "s", dir.getFileName());
                text = text.replaceAll("[\\s]", " ");
                System.out.println(text);
                return FileVisitResult.CONTINUE;
            }
        });
        return directoryName;
    }

    public static String Exist (String directoryName)
    {
        System.out.print("Введите имя каталога: ");
        Scanner inp = new Scanner(System.in);
        String name = inp.nextLine();
        File f1 = new File(name);
        if (f1.exists())
            System.out.println("Файл существует ");
        else
            System.out.println("Файл не существует ");
        return  directoryName;
    }
    public static String NewFolder(String directoryName) throws IOException {
        File f1 = new File(directoryName);
        System.out.print("Введите имя нового каталога: ");
        Scanner inp = new Scanner(System.in);
        String name = inp.nextLine();
        File folder = new File(directoryName +
                File.separator + name);
        if (!folder.exists())
            folder.mkdir();
        directoryName = "D/test/Laboratornaya_3/"+name;
        return directoryName;
    }

    public static String DeleteFolders (String directoryName)throws IOException
    {
        File f1 = new File(directoryName);
        String directoryName2 = f1.getParent();
        if (f1.isDirectory())
        {
            for (File c : f1.listFiles())
            {
                c.delete();
            }
        }
        if (!f1.delete())
            throw new FileNotFoundException("Не удалось удалить" + f1);
        System.out.println("Текущая директория: " + directoryName2);
        return directoryName2;
    }
    public static String GetFiles (String directoryName)
    {
        System.out.print("Введите тип расширения (например .txt) ");
        Scanner inp = new Scanner(System.in);
        String filter = inp.nextLine();
        File directory = new File(directoryName);
        String[] myFiles = directory.list(new FilenameFilter() {
            public boolean accept(File directory, String fileName) {
                if(fileName.endsWith(filter))
                {
                    System.out.print(fileName);
                }
                return fileName.endsWith(filter);
            }
        });
        return directoryName;
    }
    public static void main(String[] args) throws Exception {
        String directoryName = "D:\\test\\Laboratornaya_3";
        WorkingDirectory dir = new WorkingDirectory(directoryName);
        System.out.println("Выберите метод:");
        System.out.println("1.Вывести содержимое каталога \n2.Вывести имя родительского каталога \n3.Перейти к родительскому каталогу со сменой имени \n"+
                "4.Вывод иерархического списка всех подкаталогов, вложенных в данный \n5.Проверка существования каталога с заданным именем в заданной директории  \n"+
                "6.Создание нового каталога в текущем и переход к нему \n7.Удаление всех подкаталогов вложенных в данный \n8.Вывод списка файлов определенного формата \n" +
                "0 - выход");
        Scanner inp = new Scanner(System.in);
        int n = inp.nextInt();
        do {

            switch (n) {
                case 1:
                    WorkDirOut(directoryName);
                    System.out.print("Выберите следующее действие: ");
                    n = inp.nextInt();
                    break;
                case 2:
                    GetParentName(directoryName);
                    System.out.print("Выберите следующее действие: ");
                    n = inp.nextInt();
                    break;
                case 3:
                    directoryName = GetParent(directoryName);
                    System.out.println("Текущая директория: " + directoryName);
                    System.out.print("Выберите следующее действие: ");
                    n = inp.nextInt();
                    break;
                case 4:
                    GetListOfFolders(directoryName);
                    System.out.print("Выберите следующее действие: ");
                    n = inp.nextInt();
                    break;
                case 5:
                    Exist(directoryName);
                    System.out.print("Выберите следующее действие: ");
                    n = inp.nextInt();
                    break;
                case 6:
                    NewFolder(directoryName);
                    System.out.println("Текущая директория: " + directoryName);
                    System.out.print("Выберите следующее действие: ");
                    n = inp.nextInt();
                    break;
                case 7:
                    directoryName = DeleteFolders(directoryName);
                    System.out.print("Выберите следующее действие: ");
                    n = inp.nextInt();
                    break;
                case 8:
                    GetFiles(directoryName);
                    System.out.print("Выберите следующее действие: ");
                    n = inp.nextInt();
                    break;
                default:
                    throw new Exception("Неверный ввод");
            }
        } while(n != 0);
    }
}