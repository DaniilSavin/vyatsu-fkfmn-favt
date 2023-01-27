package Pyatnashki;

import javax.swing.*;
import java.util.Random;

public class Pyatnashki
{
    public static int counter=0;
    public static int[][] field;

    public static void generate(int[][]numbers)
    {
        field=numbers;
        Random generator = new Random();
        int[] invariants = new int[16];
        do
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    field[i][j] = 0;
                    invariants[i * 4 + j] = 0;
                }
            }
            for (int i = 1; i < 16; i++)
            {
                int k, l;
                do
                {
                    k = generator.nextInt(4);
                    l = generator.nextInt(4);
                }
                while (field[k][l] != 0);
                field[k][l] = i;
                invariants[k * 4 + l] = i;
            }
        }
        while (!canBeSolved(invariants));
    }
    public static boolean canBeSolved(int[] invariants) {
        int sum = 0;
        for (int i = 0; i < 16; i++)
        {
            if (invariants[i] == 0)
            {
                sum += i / 4;
                continue;
            }
            for (int j = i + 1; j < 16; j++)
            {
                if (invariants[j] < invariants[i])
                    sum ++;
            }
        }
        System.out.println(sum % 2 == 0);
        return sum % 2 == 0;
    }

    public static boolean checkWin()
    {
        boolean status = true;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (i == 3 && j > 2)
                    break;
                if (field[i][j] != i * 4 + j + 1)
                {
                    status = false;
                }
            }
        }
        return status;
    }

    public static void change(int num)
    {

        int i = 0, j = 0;
        for (int k = 0; k < 4; k++)
        {
            for (int l = 0; l < 4; l++)
            {
                if (field[k][l] == num)
                {
                    i = k;
                    j = l;
                }
            }
        }
        if (i > 0)
        {
            if (field[i - 1][j] == 0)
            {
                field[i - 1][j] = num;
                field[i][j] = 0;
            }
        }
        if (i < 3)
        {
            if (field[i + 1][j] == 0)
            {
                field[i + 1][j] = num;
                field[i][j] = 0;
            }
        }
        if (j > 0)
        {
            if (field[i][j - 1] == 0)
            {
                field[i][j - 1] = num;
                field[i][j] = 0;
            }
        }
        if (j < 3)
        {
            if (field[i][j + 1] == 0)
            {
                field[i][j + 1] = num;
                field[i][j] = 0;
            }
        }
        GUI2.repaintField(field);
        if (checkWin())
        {
            JOptionPane.showMessageDialog(null, "YOU WIN!", "Congratulations", JOptionPane.INFORMATION_MESSAGE);
            generate(field);
            GUI2.repaintField(field);
        }

        counter++;
        GUI2.setCount();
    }


    public static void Cancel()
    {
        if (counter >0)
          {
              GUI2.restore();
              field=GUI2.numbers;
              GUI2.repaintField(field);
              counter--;
              GUI2.setCount();
          }
          else
          {
              JOptionPane.showMessageDialog(null, "Вы не сделали ход.", "Ошибка", JOptionPane.INFORMATION_MESSAGE);
          }

    }

}
