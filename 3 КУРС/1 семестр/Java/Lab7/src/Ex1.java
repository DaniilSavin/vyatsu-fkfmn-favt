import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class Ex1
{
    public static void main(String[] args) throws IOException
    {
        Scanner in = new Scanner(System.in);
        System.out.print("Введите запрос: ");
        String s1 = in.nextLine();
        System.out.print("Введите количество ссылок: ");
        int num = in.nextInt();
        System.out.println(Search(s1, num));

    }

    static List Search(String s1, int num) throws IOException
    {
        Document document = Jsoup.connect("https://www.google.com/search?q=”" + s1 + "”&num=" + num + "/").get();
        Elements elements = document.select("div.yuRUbf > a[href^=\"https://\"]");
        List<String> str = new ArrayList<>();
        for (Element e : elements)
        {
            String s = e.absUrl("href");
            str.add(s);
            str.add("\n");
        }
        return str;
    }
}
