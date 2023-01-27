package com.example.voiceassistent;

import org.jetbrains.annotations.NotNull;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;
import org.jsoup.select.Elements;

import java.io.IOException;
import java.lang.annotation.Documented;
import java.util.ArrayList;
import java.util.List;

public class ParsingHtmlService {
    private static final String URL = "http://mirkosmosa.ru/holiday/2021";

    public static String getHoliday(@NotNull String date) throws IOException {
        String[] sParts = date.split("[/.\\s+]");
        int[] iParts = new int[sParts.length];
        for (int i = 0; i < sParts.length; i++) {
            iParts[i] = Integer.parseInt(sParts[i]);
        }
        Document document = Jsoup.connect(URL).get();
        Elements div = document.select("#holiday_calend > div:nth-child(" + iParts[1] + ")>div>div:nth-child("
                + iParts[0] + ")" + " > div.month_cel_date + div.month_cel > ul.holiday_month_day_holiday > li > a[href]");
        List<String> str = new ArrayList<>();
        for (Element e : div) {
            str.add(e.text());
        }
        if (str.size() != 0) {
            return str.toString().replaceAll("\\[|\\]", "").replace(",", "\n");
        } else {
            return "Праздника нет";
        }
    }
}


