package com.javacodeexamples.libraries.jsoup;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.URL;

public class Ex3
{
    private static String IMAGE_DESTINATION_FOLDER = "D:\\ВУЗ\\ВУЗ\\3 КУРС\\1 семестр\\Java\\Lab7\\images";
    public static void main(String[] args) throws IOException
    {

        //replace it with your URL
        String strURL = "https://okko.tv/subscription/63827";

        //connect to the website and get the document
        Document document = Jsoup
                .connect(strURL)
                .userAgent("Chrome/88.0.4324.150")
                .timeout(10 * 1000)
                .get();

        //select all img tags
        //Elements elements = document.select("span._1ITUw");
        Elements elements2 = document.select("a[href^=\"/movie/\"]");
       // Elements imageElements = elements2.select("img");

        //iterate over each image
        for(Element imageElement : elements2){

            //make sure to get the absolute URL using abs: prefix
            String strImageURL = imageElement.attr("abs:src");

            //download image one by one
            downloadImage(strImageURL);
        }
    }

    private static void downloadImage(String strImageURL)
    {
        //get file name from image path
        String strImageName =
                strImageURL.substring( strImageURL.lastIndexOf("/") + 1 );
        System.out.println("Saving: " + strImageName + ", from: " + strImageURL);

        try {
            //open the stream from URL
            URL urlImage = new URL(strImageURL);
            InputStream in = urlImage.openStream();
            byte[] buffer = new byte[4096];
            int n = -1;
            OutputStream os =
                    new FileOutputStream( IMAGE_DESTINATION_FOLDER + "/" + strImageName );
            //write bytes to the output stream
            while ( (n = in.read(buffer)) != -1 ){
                os.write(buffer, 0, n);
            }
            //close the stream
            os.close();
            System.out.println("Image saved");

        } catch (IOException e)
        {
            e.printStackTrace();
        }

    }
}