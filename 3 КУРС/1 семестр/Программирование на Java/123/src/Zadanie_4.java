import java.util.Random;
import java.util.Scanner;
import java.util.Arrays;
import java.util.List;

public class Zadanie_4 {
    public static void main(String[] args) {
        Random rand=new Random();
        int size=35999;
        Integer [] arr1=new Integer[size];
        Integer [] count=new Integer[size];
        Arrays.fill(count, 0);
        for (int i=0; i<size; i++)
        {
            arr1[i]=(rand.nextInt(6)+1)+(rand.nextInt(6)+1);
        }
        List<Integer> list = Arrays.asList(arr1);
        int n;
        for (int j = 0; j < list.size(); j++)
        {
            n = list.get(j);
            count[n]++;
        }
        int max=0;
        int pos=-1;
        for (int i=0; i<count.length;i++ )
        {
            if (max<count[i])
            {
                max=count[i];
                pos=i;
            }
        }
        System.out.println("Число "+pos+" встретилось "+max+" раз(а).");
    }
}
