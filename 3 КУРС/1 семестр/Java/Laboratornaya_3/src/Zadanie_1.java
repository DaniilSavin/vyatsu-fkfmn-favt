import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;


public class Zadanie_1 {
    public static String[] Name = new String[50];
    public static Integer[] Points = {65, 65, 65, 65, 65, 65};
    public static String[] Subject = {"Математика", "Русский язык", "Информатика", "Английский язык", "Обществознание", "История"};

    public static void main(String[] args) {
        String fileName = "input.txt";
        FileToString(fileName);


    }

    public static void ReadString(StringBuilder str) {
        char[] s = new char[str.length()];
        ArrayList<String> st = new ArrayList<String>();
        for (int i = 0; i < str.length(); i++) {
            s[i] = str.toString().charAt(i);
            st.add(i, s.toString());
        }


        Integer[] p = new Integer[Subject.length];
        for (int l = 0; l < p.length; l++) {
            p[l] = 0;
        }
        String sub = new String();
        Boolean fl = false;
        Boolean fl2=false;
        int n = 0;
        int i = 0;
        for (; i < s.length; i++) {

            while (s[i] != ':') {
                Name[n] = String.valueOf(s[i]);
                i++;
                n++;
            }
            if (s[i] == ':') {
                i++;
            }
            while (s[i] != '\n' || s[i + 1] != '_') {

                while (s[i] != '-') {
                    if (s[i] != '\n' && s[i] != '\r') {
                        sub += String.valueOf(s[i]);
                    }
                    i++;
                }
                if (s[i] == '-') {
                    i++;
                }
                int j = 0;
                while (s[i] != '\r') {
                    fl2=false;
                    if (Subject[j].equals(sub))
                    {
                        fl2=false;
                        if (Character.isDigit(s[i]) && Character.isDigit(s[i+1]) && Character.isDigit(s[i+2]) )
                        {
                            fl2=true;
                        }
                        if (!fl2)
                        {
                            p[j] = Integer.parseInt(String.valueOf(s[i]) + String.valueOf(s[i + 1]));
                            i += 2;
                            sub = "";
                        }
                        if (fl2)
                        {
                            p[j] = Integer.parseInt(String.valueOf(s[i]) + String.valueOf(s[i + 1])+String.valueOf(s[i + 2]));
                            i += 3;
                            sub = "";
                            fl2=false;
                        }
                    }
                    j++;
                }
                i++;
            }
            StringBuilder message = new StringBuilder();
            CheckProf(message, p);
            WriteFile(message);
            i += 3;
            n = 0;
            for (int h=0; h<Name.length; h++)
            {
                Name[h]="";
            }

        }
    }

    public static void CheckProf(StringBuilder message, Integer[] p)
    {
        if (p[0] >= Points[0] && p[1] >= Points[1] && p[2] >= Points[2]) //математика русский инфоматика
        {
            message.append("Какая-то специальность\n");
        }
        if (p[0] >= Points[0] && p[1] >= Points[1] && p[3] >= Points[3]) //математика русский английский
        {
            message.append("Какая-то специальность 2\n");
        }
        if (p[0] >= Points[0] && p[1] >= Points[1] && p[4] >= Points[4]) //математика русский обществознание
        {
            message.append("Какая-то специальность 3\n");
        }
        if (p[0] >= Points[0] && p[1] >= Points[1] && p[5] >= Points[5]) //математика русский история
        {
            message.append("Какая-то специальность 4\n");
        }
        for (int i=0; i<p.length; i++)
        {
            p[i]=0;
        }


    }

    public static void WriteFile(StringBuilder message)
    {
        String filename=new String();
        for (int i=0; i<Name.length; i++)
        {
            if (Name[i]!=null) {
                filename += Name[i];
            }
        }
        filename+=".txt";
        try(FileWriter writer = new FileWriter(filename, false))
        {
            // запись всей строки
            writer.write(message.toString());
            writer.flush();
        }
        catch(IOException ex){

            System.out.println(ex.getMessage());
        }
    }

    public static void FileToString(String fileName)
    {
        StringBuilder str=new StringBuilder();
        try(FileReader reader = new FileReader(fileName))
        {
            // читаем посимвольно
            int c;
            while((c=reader.read())!=-1)
            {
                str.append((char)c);
            }
        }
        catch(IOException ex){

            System.out.println(ex.getMessage());
        }
        ReadString(str);
    }

}
