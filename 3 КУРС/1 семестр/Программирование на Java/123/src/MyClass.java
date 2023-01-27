
import java.util.Scanner;
public class MyClass {
    public static void main(String[]args){
       System.out.println("Введите число: ");
       Scanner inp=new Scanner (System.in);
       int x=inp.nextInt();
       String str="ноутбук";

       if (x==0)
       {
           System.out.println("exit");
           System.exit(0);
       }
       if (x%10 == 1)
       {
           if (x%100==11)
           {
               System.out.println(x+" "+str+"ов");
               System.exit(0);
           }
           System.out.println(x+" "+str);
           System.exit(0);
       }
       if (x%10>1 && x%10<=4)
       {
           if (x%100>10 && x%10!=4 && x%100<20)
           {
               System.out.println(x+" "+str+"ов");
               System.exit(0);
           }
           System.out.println(x+" "+str+"a");
           System.exit(0);
       }else
       {
           System.out.println(x+" "+str+"ов");
           System.exit(0);
       }
    }
}
