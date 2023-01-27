import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class Ex2 {
    public static void main(String[] args) throws IOException {
        String strURL = "https://okko.tv/subscription/63827";
        Document document = Jsoup.connect(strURL)
                .userAgent("Chrome/88.0.4324.150")
                .referrer("https://google.com/")
                .timeout(1000*10).get();

        String s = null;
        Elements elements = document.select("span._1ITUw");
        Elements elements2 = document.select("a[href^=\"/movie/\"]");
        List<String> str = new ArrayList<>();
        for (Element e: elements) {
            str.add(e.text());
        }
        int i = 0;
            for (Element e2: elements2)
            {

                System.out.println(str.get(i));
                s = e2.absUrl("href");
                Document document2 = Jsoup.connect(s).get();
                Elements elements3 = document2.select("p");
                e2 = elements3.get(0);
                System.out.println(e2.text());
                i++;
            }
        }
    }
