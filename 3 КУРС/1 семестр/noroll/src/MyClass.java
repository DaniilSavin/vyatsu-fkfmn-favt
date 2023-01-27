import java.util.Scanner;

public class MyClass {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        System.out.println("Введите кол-во ноутбуков: ");
        int num = in.nextInt();
        int numr;
        numr = num % 10;

        if (numr == 1) {
            System.out.println("Вы купили " + num + " ноутбук.");

        } else if (numr >= 2 && numr <= 4) {
            System.out.println("Вы купили " + num + " ноутбука.");

        } else if (numr >= 5 && numr <= 9 || numr == 0) {
            System.out.println("Вы купили " + num + " ноутбуков.");

        }

    }
}
