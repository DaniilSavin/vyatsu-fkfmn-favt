import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Ex4
{
    public static void main(String[] args) throws IOException
    {
        Document document = Jsoup.connect("https://cdsvyatka.com/kirov/map").get();
        Elements elements = document.select("img.leaflet-marker-icon leaflet-zoom-animated leaflet-interactive > title");
        List<String> str = new ArrayList<>();
        for (Element e : elements)
        {
            String s = e.absUrl("title");
            str.add(s);
            str.add("\n");
        }
        System.out.println(elements);
    }
}
