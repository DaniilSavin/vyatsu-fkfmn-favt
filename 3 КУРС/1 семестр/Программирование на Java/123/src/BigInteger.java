import java.util.Random;
import java.util.Scanner;


public class BigInteger {
    public static void main(String[] args) {
        System.out.println("Введите размер числа: ");
        Scanner inp = new Scanner(System.in);
        int n = inp.nextInt();
        String str1 = "", str2 = "", str3 = "";
        //int number2=0;
        int count = 0;
        Random rand = new Random();
        java.math.BigInteger sum = java.math.BigInteger.valueOf(0), sum2 = java.math.BigInteger.valueOf(0);
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
            java.math.BigInteger zxc= java.math.BigInteger.valueOf(str);

            sum=sum.multiply(zxc);

            str2 = String.valueOf(rand.nextInt(9) + 1);
            zxc= java.math.BigInteger.valueOf(Integer.parseInt(str2));
            sum=sum.multiply(zxc);
            System.out.println("Компьютер ввел: " + str2);
        }
        java.math.BigInteger num= java.math.BigInteger.valueOf(7);
        if (sum.mod(num)== java.math.BigInteger.valueOf(0))
        {
            System.out.println("\nПобедил компьютер.");
        }
        else
        {
            System.out.println("\nКомпьютер проиграл.");
        }

    }
}
