import java.util.Scanner;
import java.util.Random;

public class MyClass3 {
    public static void main(String[] args) {
        int min = 1;
        int max = 6;
        int diff = max - min;
        int k1 = 0;
        for (int j = 1; j <= 36000; j++) {
            Random random = new Random();
            int i = random.nextInt(diff + 1);
            int h = random.nextInt(diff + 1);
            int num = i + h;
            if (num == 7) {
                k1++;
            }
            System.out.println(num);
        }
        System.out.println(k1);
    }
}
