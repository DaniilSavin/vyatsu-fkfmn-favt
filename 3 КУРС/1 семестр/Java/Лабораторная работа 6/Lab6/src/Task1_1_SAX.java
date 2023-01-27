import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;
import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParser;
import javax.xml.parsers.SAXParserFactory;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;

public class Task1_1_SAX
{

    public static ArrayList<Employee> employees = new ArrayList<>();
    public static void main(String[] args) throws ParserConfigurationException, SAXException, IOException
    {
        SearchingXMLHandler2 handler = new SearchingXMLHandler2("supply");
        SAXParserFactory factory = SAXParserFactory.newInstance();
        SAXParser parser = factory.newSAXParser();
        parser.parse(new File("D:\\ВУЗ\\3 КУРС\\Java\\Лабораторная работа 6\\Lab6\\src\\xml_task1.xml"), handler);
    }
}
class Employee
{
    private String name;
    private String job;

    public Employee(String name, String job)
    {
        this.name = name;
        this.job = job;
    }
    public String getName() {
        return name;
    }
    public String getJob() {
        return job;
    }
}
class SearchingXMLHandler2 extends DefaultHandler
{
    private boolean isEntered;
    private String element;

    public SearchingXMLHandler2(String element)
    {
        this.element = element;

    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException
    {
        if (qName.equals(element))
            isEntered = true;

        if (isEntered)
        {
            //System.out.println(String.format("Найден элемент <%s>, его атрибуты:", qName));
            int length = attributes.getLength();
            for(int i = 0; i < length; i++)
                System.out.println(String.format(/*"Имя атрибута: %s, его значение: %s", attributes.getQName(i), */attributes.getValue(i)));
        }
    }
    public void endElement(String uri, String localName, String qName) throws SAXException
    {
        if (qName.equals(element))
            isEntered = false;
    }
}
