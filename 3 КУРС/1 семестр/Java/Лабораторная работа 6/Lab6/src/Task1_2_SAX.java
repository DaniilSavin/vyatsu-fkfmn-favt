import org.w3c.dom.Document;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.DefaultHandler;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.parsers.SAXParserFactory;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class Task1_2_SAX
{
    public static void main(String[] args) throws ParserConfigurationException, SAXException, IOException {
        System.out.print("Введите название района: ");
        String reg = new Scanner(System.in).nextLine();
        ArrayList<Flat> saxFlats = new ArrayList<>();
        Document document;
        SAXSearch saxSearch = new SAXSearch(reg);
        SAXParserFactory.newInstance().newSAXParser().parse(new File("D:\\ВУЗ\\3 КУРС\\Java\\Лабораторная работа 6\\Lab6\\src\\xml_task1.xml"), saxSearch);
        saxFlats = saxSearch.getFlats(reg);
        printFlats(saxFlats);

    }

    public static void printFlats(ArrayList<Flat> flats){
        for (Flat f : flats)
            System.out.println(f.toString());
    }
}

class SAXSearch extends DefaultHandler
{
    private ArrayList<Flat> flats ;
    private ArrayList<Float> rooms ;
    private Map<String, String> seller ;
    private String regionName, streetName;
    private int id;
    private float square, kitchen, housingpart ;
    private String lastElementName, reg;
    private boolean up;

    public SAXSearch(String reg) {
        this.reg = reg;
    }

    @Override
    public void startDocument() throws SAXException {
        flats = new ArrayList<>();
        rooms = new ArrayList<>();
        seller = new HashMap<>();
        regionName = ""; streetName = "";
        id = 0;square = 0;kitchen = 0;housingpart = 0;
        up = false;
    }
    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {

        lastElementName = qName;
        if (qName.equals("region")) {
            if ((attributes.getValue("name") != null))
                regionName = attributes.getValue("name");
            up = reg.toLowerCase().equals(regionName.toLowerCase()) || reg == "";
        }
        else if (up) {

            if (qName.equals("street")) {
                if ((attributes.getValue("name") != null))
                    streetName = attributes.getValue("name");
            } else if (qName.equals("flat")) {
                if ((attributes.getValue("id") != null))
                    id = Integer.parseInt(attributes.getValue("id"));
                if ((attributes.getValue("square") != null))
                    square = Float.parseFloat(attributes.getValue("square"));
                if ((attributes.getValue("kitchen") != null))
                    kitchen = Float.parseFloat(attributes.getValue("kitchen"));
                if ((attributes.getValue("housingpart") != null))
                    housingpart = Float.parseFloat(attributes.getValue("housingpart"));

            } else if (qName.equals("seller")) {
                String tel = "", title = "";
                if ((attributes.getValue("tel") != null))
                    tel = attributes.getValue("tel");
                if ((attributes.getValue("title") != null))
                    title = attributes.getValue("title");
                seller.put(title, tel);
            }
        }

    }


    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {

        if (qName.equals("flat") && up){
            Flat flat = new Flat(regionName, streetName, id, square, kitchen, housingpart, rooms, seller);
            flats.add(flat);
            clear();
        }
        else if (qName.equals("region")){
            regionName = "";
        }
        else if (qName.equals("street")){
            streetName = "";
        }

    }
    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
        String information = new String(ch, start, length);

        information = information.replace("\n", "").trim();
        if (!information.isEmpty() && up)
        {
            if (lastElementName.equals("room"))
                rooms.add(Float.parseFloat(information));
        }
    }

    private void clear() {
        rooms.clear();
        seller.clear();
        id = 0;
        square = 0;
        housingpart = 0;
        kitchen = 0;
    }

    public ArrayList<Flat> getFlats(String reg) {
        return flats;
    }
}

