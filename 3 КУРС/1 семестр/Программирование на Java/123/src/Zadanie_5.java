import java.util.Arrays;
import java.util.Random;
import java.util.Collections;
import java.util.Scanner;
public class Zadanie_5
{
    private static int m;
    private static int n;

    public static void main(String[] args)
    {
        m=5; n=5;
        Integer[][] arr = new Integer[m][n];
        Random rand=new Random();
        for (int i=0; i<m; i++)
        {
            for (int j=0; j<n; j++)
            {
                arr[i][j]=rand.nextInt(9) + 1;
            }
        }



        System.out.println("До сортировки:");
        display(arr);

        for (int i=0; i<m; i++)
        {
            Arrays.sort(arr[i]);
        }
        System.out.println("По возрастанию:");
        display(arr);
        System.out.println("По убыванию:");
        sortDown(arr);
         /*int[] arr2 = new int[m * n];
        int[] arr3= new int [m];
        int k = 0, p=0, b=0, g=0, h=0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                arr2[k] = arr[i][j];
                arr3[p]=arr2[k];
                k++;p++;
            }
            Arrays.sort(arr3);
            for ( ; h<m && b<p; h++)
            {
                for (g=0; g < n; g++)
                {
                    arr[h][g] = arr3[b];
                    b++;
                }
            }
            p=0; b=0;
        }*/

        display(arr);

    }

    private static void display(Integer [][]arr)
    {
        for (int i=0; i<m; i++)
        {
            for (int j=0; j<n; j++)
            {
                System.out.print(arr[i][j]+" ");
            }
            System.out.println();
        }
    }

    private static void sortDown(Integer [][]arr)
    {
        for (int i=0; i<m; i++)
        {
            Arrays.sort(arr[i], Collections.reverseOrder());
        }
    }
}
