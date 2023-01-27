import java.util.Scanner;
import java.util.Random;

public class MyClass2 {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.println("Введите n");
        int n = in.nextInt();
        String str1 = "";
        int k = 0;
        int min = 0;
        int max = 9;
        int diff = max - min;
        while (k < n)
        {
            int num = in.nextInt();
            str1 += num;
            k++;

            Random random = new Random();
            int i = random.nextInt(diff + 1);
            if (k < n) {
                str1 += i;
            }
            k++;
        }
        int num = Integer.parseInt(str1);
        System.out.println(num);
        if (num % 9 == 0 && n % 2 != 0)
        {
            System.out.println("Первый победил");
        }

        if (num % 9 == 0 && n % 2 == 0)
        {
            System.out.println("Второй победил");
        }

        if (num % 9 != 0 && n % 2 != 0)
        {
            System.out.println("Первый проиграл");
        }

        if (num % 9 != 0 && n % 2 == 0)
        {
            System.out.println("Второй проиграл");
        }
    }
}
