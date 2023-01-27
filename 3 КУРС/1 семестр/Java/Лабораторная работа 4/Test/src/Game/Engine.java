package Game;

import com.sun.xml.internal.bind.v2.runtime.RuntimeUtil;

import javax.swing.*;
import java.util.Random;

public class Engine
{
    public static int i=0, j=0, k=0;
    public static int bull=0, cow=0;
    public static int[] pn=new int[4];
    public static int[] vl=new int [4];
    public static int[] tn= {-1, -1, -1, -1};
    public static int plannedNum=0;

    public static void addValue(int val)
    {
        tn=valToArray(val);
        if (val<=9999 && val>=1000 && checkCoincidence2() && GUI.count<100)
        {
            vl=valToArray(val);
            GUI.count++;
            GUI.data[i][0] = String.valueOf(GUI.count);
            GUI.data[i][1] = String.valueOf(val);
            tn[0]=-1; tn[1]=-1; tn[2]=-1; tn[3]=-1;
            if (!check())
            {
                GUI.data[i][2] = String.valueOf(bull);
                GUI.data[i][3] = String.valueOf(cow);
                i++;
            }
            else
            {
                GUI.win();
            }
        }
        else
        {
            JOptionPane.showMessageDialog(null, "Вы ввели неверное значение или превысили размеры таблицы!", "Ошибка", JOptionPane.INFORMATION_MESSAGE);
        }

    }
    public static boolean check()
    {
        bull=0; cow=0;
        boolean c=false;
        for (int i=0; i<4; i++)
        {
            for (int j=0; j<4; j++)
            {
                if (pn[i]==vl[j] && i!=j)
                {
                    cow++;
                }
                else
                {
                    if (pn[i]==vl[j] && i==j)
                    {
                        bull++;
                    }
                }
            }
        }
        if (bull==4 && cow==0)
        {

            c=true;
        }
        return c;
    }

    public static int[] valToArray(int val)
    {
        int[] mas=new int[4];
        mas[3] = val % 10;
        val /= 10;
        mas[2] = val % 10;
        val /= 10;
        mas[1] = val % 10;
        val /= 10;
        mas[0] = val % 10;
        return mas;
    }

    public static void setPlannedNumber()
    {
        Random rand = new Random();
        int t = rand.nextInt(10);
        pn[0] = t;
        tn[0] = t;
        for (int i = 1; i < 4; i++)
        {
            t = rand.nextInt(10);
            if (checkCoincidence(t))
            {
                tn[i] = t;
                pn[i] = t;
            } else
            {
                if (i > 0)
                {
                    i--;
                } else i = 0;
                t = rand.nextInt(10);
            }
        }
        plannedNum=pn[0]*1000+pn[1]*100+pn[2]*10+pn[3];
    }

    public static boolean checkCoincidence(int v)
    {
        boolean res = true;
        for (int i = 0; i < 4; i++)
        {
            if (v == tn[i])
            {
                res = false;
            }
        }
        return res;
    }
    public static boolean checkCoincidence2()
    {

        boolean res = true;
        for (int i = 3; i >= 0; i--)
        {
            for (int j=i-1; j>=0; j--)
            {
                if (tn[i] == tn[j])
                {
                    res = false;
                }
            }
        }
        return res;
    }

}
