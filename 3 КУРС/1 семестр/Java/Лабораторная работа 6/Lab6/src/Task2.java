import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.xml.sax.SAXException;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.*;
import javax.xml.transform.dom.DOMSource;
import javax.xml.transform.stream.StreamResult;
import java.io.File;
import java.io.IOException;

public class Task2
{
    public static void main(String[] args) throws ParserConfigurationException, TransformerException, IOException, SAXException
    {
        DocumentBuilderFactory factory1 = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder = factory1.newDocumentBuilder();
        //Document document = builder.parse(new File("D:\\ВУЗ\\3 КУРС\\Java\\Lab6\\src\\xml_task1.xml"));


        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        factory.setNamespaceAware(true);
        Document doc = factory.newDocumentBuilder().newDocument();

        Element root = doc.createElement("supply");
        doc.appendChild(root);

        Element item1 = doc.createElement("rooms");
        item1.setAttribute("count", "2");
        root.appendChild(item1);

        Element item2 = doc.createElement("flat");
        item2.setAttribute("region_name", "Ленинский");
        item2.setAttribute("square", "49.2");
        item2.setAttribute("kitchen", "12.6");
        item2.setAttribute("housing_part", "30.6");
        item1.appendChild(item2);

        Element item3 = doc.createElement("rooms");
        item2.appendChild(item3);
        Element item4 = doc.createElement("room");
        item4.setAttribute("square", "19.1");
        item3.appendChild(item4);
        Element item5 = doc.createElement("room");
        item5.setAttribute("square", "31.7");
        item3.appendChild(item5);

        Element seller = doc.createElement("seller");
        seller.setAttribute("tel", "+7922-154-10-11");
        seller.setAttribute("title", "Иванов Александр");
        item2.appendChild(seller);

        Element item6 = doc.createElement("rooms");
        item6.setAttribute("count", "1");
        root.appendChild(item6);

        Element item7 = doc.createElement("flat");
        item7.setAttribute("region_name", "Октябрьский");
        item7.setAttribute("square", "32.2");
        item7.setAttribute("kitchen", "9.9");
        item7.setAttribute("housing_part", "18.6");
        item6.appendChild(item7);

        Element item8 = doc.createElement("rooms");
        item7.appendChild(item8);

        Element item9 = doc.createElement("room");
        item9.setAttribute("square", "18.7");
        item8.appendChild(item9);

        Element seller2 = doc.createElement("seller");
        seller2.setAttribute("tel", "+7922-154-10-11");
        seller2.setAttribute("title", "Петров Олег");
        item7.appendChild(seller2);

        TransformerFactory transformerFactory = TransformerFactory.newInstance();
        Transformer transformer = transformerFactory.newTransformer();
        transformer.setOutputProperty(OutputKeys.INDENT, "yes");
        DOMSource source = new DOMSource(doc);
        StreamResult file = new StreamResult(new File("D:\\ВУЗ\\3 КУРС\\Java\\Lab6\\src\\xml_task2.xml"));
        transformer.transform(source, file);
    }
}
