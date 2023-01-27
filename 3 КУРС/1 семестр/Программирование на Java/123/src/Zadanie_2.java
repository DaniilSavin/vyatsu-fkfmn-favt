import sun.rmi.server.InactiveGroupException;

import java.util.Random;
import java.util.Scanner;
import java.math.BigInteger;
public class Zadanie_2
{
    public static void main(String[] args)
    {
        System.out.println("Введите размер числа: ");
        Scanner inp = new Scanner(System.in);
        int n = inp.nextInt();
        String str1 = "", str2 = "", str3 = "";
        //int number2=0;
        int count = 0;
        Random rand = new Random();
        Integer sum = 0;
        for (int i = 0; i < n / 2; i++)
        {
            count = 0;
            System.out.println("Первый игрок: ");
            Scanner inp1 = new Scanner(System.in);
            str1 = inp1.next();
            Integer str = Integer.parseInt(str1);
            while (str > 0) {
                str /= 10;
                count++;
            }
            if (count != 1) {
                System.out.println("Вы ввели неоднозначное число.");
                System.exit(0);
            }

            sum+=str;
            sum+=Integer.parseInt(String.valueOf(rand.nextInt(9) + 1));


            //System.out.println("Компьютер ввел: " + str2);
        }
        if (sum%9==0)
        {
            System.out.println("Победил компьютер. sum= "+sum+" ");
        }
        else
        {
            System.out.println("Проиграл компьютер. sum= "+sum+" ");
        }

    }
}
