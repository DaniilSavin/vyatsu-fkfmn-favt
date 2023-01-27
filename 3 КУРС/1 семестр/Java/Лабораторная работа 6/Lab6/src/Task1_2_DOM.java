import org.w3c.dom.Document;
import org.w3c.dom.NamedNodeMap;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParserFactory;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Task1_2_DOM
{
    public static void main(String[] args) throws Exception
    {
        System.out.print("Введите название района: ");
        String reg = new Scanner(System.in).nextLine();
        ArrayList<Flat> domFlats = new ArrayList<>();
        Document document;
        document = DocumentBuilderFactory.newInstance().newDocumentBuilder().parse(new File("D:\\ВУЗ\\3 КУРС\\Java\\Лабораторная работа 6\\Lab6\\src\\xml_task1.xml"));
        DOMSearch domSearch = new DOMSearch(document);
        domFlats = domSearch.getFlats(reg);
        printFlats(domFlats);

    }

    public static void printFlats(ArrayList<Flat> flats)
    {
        for (Flat f : flats)
            System.out.println(f.toString());
    }
}

class DOMSearch
{
    private Document document;
    private ArrayList<Flat> flats = new ArrayList<>();
    private ArrayList<Float> rooms;
    private Map<String, String> seller;

    public DOMSearch(Document document) {
        this.document = document;
    }

    private String getParentNodeValue(Node node, int count, String name){
        while (count != 0){
            count--;
            node = node.getParentNode();
        }
        NamedNodeMap attributes = node.getAttributes();
        for (int i = 0; i < attributes.getLength(); ++i){
            if (attributes.item(i).getNodeName() == name)
                return attributes.getNamedItem(name).getNodeValue();
        }
        return "";

    }

    public ArrayList<Flat> getFlats(String reg) throws Exception {
        if (document.equals(null))
            throw new Exception();
        flats.clear();
        rooms = new ArrayList<>();
        seller = new HashMap<>();

        NodeList matchedElementsList = document.getElementsByTagName("flat");


        for (int i = 0; i < matchedElementsList.getLength(); ++i) {
            String regionName, streetName;
            int id = 0;
            float square = 0,
                    kitchen = 0,
                    housingpart = 0;

            Node foundedElement = matchedElementsList.item(i);
            regionName = getParentNodeValue(foundedElement, 1, "name");

            if (reg == "" || reg.toLowerCase().equals(regionName.toLowerCase())) { //проверка на нужный район
                streetName = getParentNodeValue(foundedElement, 1, "name");

                NamedNodeMap attributes = foundedElement.getAttributes();
                for (int k = 0; k < attributes.getLength(); ++k) {
                    switch (attributes.item(k).getNodeName()) {
                        case "id":
                            id = Integer.parseInt(attributes.item(k).getNodeValue());
                            break;
                        case "count":
                            break;
                        case "square":
                            square = Float.parseFloat(attributes.item(k).getNodeValue());
                            break;
                        case "kitchen":
                            kitchen = Float.parseFloat(attributes.item(k).getNodeValue());
                            break;
                        case "housingpart":
                            housingpart = Float.parseFloat(attributes.item(k).getNodeValue());
                            break;
                    }

                }

                if (foundedElement.hasChildNodes())
                    nElement(foundedElement.getChildNodes());

                flats.add(new Flat(regionName, streetName, id, square, kitchen, housingpart, rooms, seller));
                clear();
            }
        }
        return flats;
    }

    private void clear() {
        rooms.clear();
        seller.clear();

    }

    private void nElement(NodeList list){
        for (int i = 0; i < list.getLength(); i++) {
            Node node = list.item(i);
            switch (node.getNodeName()){

                case "room":
                    String textInformation = node.getChildNodes().item(0).getNodeValue().replace("\n", "").trim();
                    if (!textInformation.isEmpty())
                        rooms.add(Float.parseFloat(node.getChildNodes().item(0).getNodeValue()));
                    break;

                case "seller":
                    NamedNodeMap attributes = node.getAttributes();
                    String title = "", tel = "";
                    for (int k = 0; k < attributes.getLength(); k++) {
                        switch (attributes.item(k).getNodeName()){
                            case "title":
                                title = attributes.item(k).getNodeValue();
                                break;
                            case "tel":
                                tel = attributes.item(k).getNodeValue();
                                break;
                        }
                    }
                    seller.put(title, tel);
                    break;
            }

            if (node.hasChildNodes())
                nElement(node.getChildNodes());
        }
    }
}

































    /*public static void main(String[] args) throws ParserConfigurationException, IOException, SAXException
    {
        Node foundedElement = null;
        String newElement = "supply";
        Scanner in = new Scanner(System.in);
        System.out.print("Введите название района: ");
        String attribute = in.nextLine();
        DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
        DocumentBuilder builder = factory.newDocumentBuilder();
        Document document = builder.parse(new File("G:\\java\\Lab6\\src\\xml_task1.xml"));
        NodeList matchedElementsList = document.getElementsByTagName(newElement);
        //System.out.println(matchedElementsList.item(0).getAttributes().item(0).getNodeValue());
            if (matchedElementsList.getLength() == 0)
                System.out.println("Тег " + newElement + " не был найден в файле.");
            else
                foundedElement = matchedElementsList.item(0);
        if (foundedElement.hasChildNodes())
            printInfoAboutAllChildNodes(foundedElement.getChildNodes(), attribute);
    }
    private static void printInfoAboutAllChildNodes(NodeList list, String attribute)
    {
        for (int i = 0; i < list.getLength(); i++)
        {

            Node node = list.item(i);
            String regionName = getParentNodeValue(node, 2, "name");
            if (attribute.toLowerCase().equals(regionName.toLowerCase()))
            {
                if (node.getNodeType() == Node.TEXT_NODE) {
                    String textInformation = node.getNodeValue().replace("\n", "").trim();
                    if (!textInformation.isEmpty()) {
                        System.out.print("Площадь комнаты: " + node.getNodeValue());
                    }
                } else {
                    System.out.println("Найден элемент: " + node.getNodeName() + ", его атрибуты:");
                    NamedNodeMap attributes = node.getAttributes();
                    for (int k = 0; k < attributes.getLength(); k++) {
                        System.out.println(attributes.item(k).getNodeValue());
                    }

                }
                //Если у данного элемента еще остались узлы, то вывести всю информацию обо всех его узлах.
                if (node.hasChildNodes())
                    printInfoAboutAllChildNodes2(node.getChildNodes());
            }
        }
    }

    private static void printInfoAboutAllChildNodes2(NodeList list)
    {
        for (int i = 0; i < list.getLength(); i++)
        {
            Node node = list.item(i);
            // У элементов есть два вида узлов - другие элементы или текстовая информация. Потому нужно разбирать две ситуации отдельно.
            if (node.getNodeType() == Node.TEXT_NODE) {
                // Фильтрация информации, так как начальные и конечные пробелы и переносы строк не нужны. Это не информация.
                String textInformation = node.getNodeValue().replace("\n", "").trim();

                if(!textInformation.isEmpty()) {
                    System.out.print("Площадь комнаты: " + node.getNodeValue());
                }
            }
            // Если это не текст, а элемент, то его нужно обрабатывать как элемент.
            else
            {
                //System.out.println("Найден элемент: " + node.getNodeName() + ", его атрибуты:");
                // Получение атрибутов
                NamedNodeMap attributes = node.getAttributes();
                // Вывод информации о полученных атрибутах.
                for (int k = 0; k < attributes.getLength(); k++) {
                    System.out.println(attributes.item(k).getNodeValue());
                }
            }
            // Если у данного элемента еще остались узлы, то вывести всю информацию обо всех его узлах.
            if (node.hasChildNodes())
                printInfoAboutAllChildNodes2(node.getChildNodes());
        }
    }
    static private String getParentNodeValue(Node node, int count, String name)
    {
       *//* while (count != 0){
            count--;
            node = node.getParentNode();
        }*//*
        NodeList node1 = node.getChildNodes();
        node = node.getParentNode();
        NamedNodeMap attributes = node.getAttributes();
        for (int i = 0; i < attributes.getLength(); ++i){
            if (attributes.item(i).getNodeName() == name)
                return attributes.getNamedItem(name).getNodeValue();
        }
        return "";
        //if (name.equals(node.getNodeName()))
        //node.getAttributes().getNamedItem(name).getNodeValue();

        //regionName = foundedElement.getParentNode().getParentNode().getAttributes().item(0).getNodeValue();
        //streetName = foundedElement.getParentNode().getAttributes().item(0).getNodeValue();

    }*/

