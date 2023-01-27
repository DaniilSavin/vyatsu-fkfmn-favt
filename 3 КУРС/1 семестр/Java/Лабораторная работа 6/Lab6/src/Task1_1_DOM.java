import org.w3c.dom.Document;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import java.io.File;
import java.io.IOException;

public class Task1_1_DOM
{
    public static void main(String[] args) throws ParserConfigurationException, IOException, SAXException
    {
        Node foundedElement = null;
        String newElement = "supply";
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder = factory.newDocumentBuilder();
        Document document = builder.parse(new File("D:\\ВУЗ\\3 КУРС\\Java\\Лабораторная работа 6\\Lab6\\src\\xml_task1.xml"));
        NodeList matchedElementsList = document.getElementsByTagName(newElement);
        if (matchedElementsList.getLength() == 0)
            System.out.println("Тег " + newElement + " не был найден в файле.");
        else
            foundedElement = matchedElementsList.item(0);
        if (foundedElement.hasChildNodes())
            printInfoAboutAllChildNodes(foundedElement.getChildNodes());

    }
    private static void printInfoAboutAllChildNodes(NodeList list)
    {
        for (int i = 0; i < list.getLength(); i++)
        {
            Node node = list.item(i);
            // У элементов есть два вида узлов - другие элементы или текстовая информация. Потому нужно разбирать две ситуации отдельно.
            if (node.getNodeType() == Node.TEXT_NODE) {
                // Фильтрация информации, так как начальные и конечные пробелы и переносы строк не нужны. Это не информация.
                String textInformation = node.getNodeValue().replace("\n", "").trim();

                if(!textInformation.isEmpty()) {
                    System.out.print("Площадь комнаты: " + node.getNodeValue().trim()+"\n");
                }
            }
            // Если это не текст, а элемент, то его нужно обрабатывать как элемент.
            else
                {
                //System.out.println("Найден элемент: " + node.getNodeName() + ", его атрибуты:");
                // Получение атрибутов
                NamedNodeMap attributes = node.getAttributes();
                // Вывод информации о полученных атрибутах.
                for (int k = 0; k < attributes.getLength(); k++)
                {
                    System.out.println(attributes.item(k).getNodeValue());
                }
            }
            // Если у данного элемента еще остались узлы, то вывести всю информацию обо всех его узлах.
            if (node.hasChildNodes())
                printInfoAboutAllChildNodes(node.getChildNodes());
        }
    }
}

