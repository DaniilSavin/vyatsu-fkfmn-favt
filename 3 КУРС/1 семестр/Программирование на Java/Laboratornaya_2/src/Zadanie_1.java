import java.util.Scanner;
import java.lang.String;
import java.util.Arrays;
public class Zadanie_1 {
    public static String[] a={"a","A","b","B","v","V","g","G","d","D","e","E","e","E","zh","Zh","z","Z","i","I","i","I","k","K","l","L","m","M","n","N","o","O",
            "p","P","r","R","s","S","t","T","u","U","f","F","h","H","c","C","ch","Ch","sh","Sh","sh","Sh","","" ,"i","I","","" ,"e","E","yu","Yu","ya","Ya"};
    public static String[] a2={"а","А","б","Б","в", "В","г","Г","д","Д","е","Е","ё", "Ё","ж", "Ж","з","З","и","И","й","Й","к","К","л","Л","м","М","н","Н","о","О",
            "п","П","р","Р","с","С","т","Т","у","У","ф","Ф","х","Х","ц","Ц","ч","Ч" ,"ш","Ш" ,"щ","Щ" ,"ь","Ь","ы","Ы","ъ","Ъ","э","Э","ю","Ю", "я","Я" };

    public static void main(String[] args)
    {
        System.out.println("Введите строку: ");
        Scanner inp=new Scanner(System.in);
        String str=inp.nextLine();
        System.out.println("Введите разделитель: ");
        char c=inp.next().charAt(0);
        str=transliteration(str, c);
        System.out.println(str);

    }
    public static String transliteration(String str, char c)
    {
        char[] strArray = str.toCharArray();
        for (int i=0; i<strArray.length; i++)
        {
            String[] s=new String[1];
            s[0]= String.valueOf(strArray[i]);
            for (int j=0; j<a.length; j++)
            {
                if (s[0].equals(a2[j]))
                {
                    strArray[i]=a[j].charAt(0);
                    break;
                }
                if (s[0].equals(" "))
                {
                    strArray[i]=c;
                }

            }
        }
        String ans=new String();
        for (int i=0;i<strArray.length;i++)
        {
            ans+=strArray[i];
        }
        return ans;
    }

}
