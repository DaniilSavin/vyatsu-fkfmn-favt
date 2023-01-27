import javafx.application.Application;
import org.omg.CORBA.Environment;

import java.util.Scanner;
import java.lang.String;

public class Zadanie_2 {
    public static void main(String[] args) {
        System.out.println("Введите строку: ");
        Scanner inp=new Scanner(System.in);
        String str=inp.nextLine();
        System.out.println("Размер строки: "+str.length());
        System.out.println("Введите размер для отсечения: ");
        int size =inp.nextInt();

        if (size>str.length())
        {
            System.out.println("Вы ввели размер превышающий размер строки.");
            System.exit(0);
        }
        str=truncate(str, size);
        System.out.println(str);
    }
    public static String truncate(String str, int size)
    {
        StringBuilder ans= new StringBuilder(new String());
        char[] cA = str.toCharArray();
        boolean checked=false;
        for (int i=0; i<size; i++)
        {
            if (cA[i]==' ' && size!=str.length() )
            {
                ans.append("...");
                checked=true;
            }
            else
            ans.append(cA[i]);

        }
        if (!checked && size!=str.length()) ans.append("...");
        return ans.toString();
    }
}
