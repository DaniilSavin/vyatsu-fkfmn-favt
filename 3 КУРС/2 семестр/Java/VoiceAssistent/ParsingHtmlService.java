package com.example.voiceassistent;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;
import java.sql.Array;
import java.util.ArrayList;

public class ParsingHtmlService {
    private static String URL = "http://mirkosmosa.ru/holiday/2021";

    public static String getHoliday(String[] date) throws IOException {
        Boolean print = false;
        StringBuilder answer = new StringBuilder("");
        Document document = Jsoup.connect(URL).get();
        Element body = document.body();
        //Elements day = document.select("div.next_phase");
        Elements months = document.select("div.holiday_month").not("h3.div_center");
        for (Element m: months) {
            Elements day = m.select("div.next_phase");
            for(Element e :day)
                if (e.select("div.month_cel_date > span").text().contentEquals(date[0])) {
                    ArrayList<String> holidayDate =  new ArrayList<String>();
                    holidayDate.add(e.select("div.month_cel_date > span").text());
                    ArrayList<String> holidayDay =  new ArrayList<String>();
                    holidayDay.add(e.select("div > span.day_week").text());
                    ArrayList<String> holidays =  new ArrayList<String>();
                    Elements temp = e.select("li");
                    for (Element t: temp
                    ) {
                        holidays.add(t.text());
                    }
                    if (print==false) {
                        if (holidays.isEmpty()==true) {
                            answer.append("В этот день нет праздников");
                            System.out.println("В этот день нет праздников");
                            return answer.toString();
                        }
                        else {
                            for (int i=0; i<holidayDate.size();++i){
                                answer.append(holidayDate.get(i));
                                answer.append("\n");
                                answer.append(holidayDay.get(i));
                                answer.append("\n");
                            }
                            for(int i =0; i<holidays.size();++i){
                                answer.append(holidays.get(i));
                                answer.append("\n");
                            }
                            //System.out.println(holidayDate);
                            //System.out.println(holidayDay);
                            //System.out.println(holidays);
                            print=true;
                            return answer.toString();
                        }
                    }
                }
        }
        return answer.toString();
    }
}

