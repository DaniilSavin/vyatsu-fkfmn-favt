package zxc;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Element;
import org.jsoup.nodes.*;
import org.jsoup.select.Elements;

import java.io.IOException;

public class Parcer
{

    public static void main(String[] args) throws IOException
    {
        Document doc = Jsoup.connect("https://ekvus-kirov.ru/truppa/").get();

        Elements elements = doc.select("div>p>a");
        elements.attr("href=");
        for (Element element : elements)
        {
            System.out.println(element);
        }
    }
}
