package com.example.voiceassistent

import org.jsoup.Jsoup
import java.io.IOException
import java.util.*

object ParsingHtmlService {
    private const val URL = "http://mirkosmosa.ru/holiday/2021"
    private const val URL2 = "https://ru.investing.com/crypto/"
    @Throws(IOException::class)
    fun getHoliday(date: String): String {
        val reg = Regex("[/.\\s+]")
        val sParts = date.split(reg).toTypedArray()
        val iParts = IntArray(sParts.size)
        for (i in sParts.indices) {
            iParts[i] = sParts[i].toInt()
        }
        val document = Jsoup.connect(URL).get()
        val div = document.select("#holiday_calend > div:nth-child(" + iParts[1] + ")>div>div:nth-child("
                + iParts[0] + ")" + " > div.month_cel_date + div.month_cel > ul.holiday_month_day_holiday > li > a[href]")
        val str: MutableList<String> = ArrayList()
        for (e in div) {
            str.add(e.text())
        }
        return if (str.size != 0) {
            str.toString().replace("\\[|\\]".toRegex(), "").replace(",", "\n")
        } else {
            "Праздника нет"
        }
    }

    @get:Throws(IOException::class)
    val cryptoCurrencyExchangeRate: String
        get() {
            val document = Jsoup.connect(URL2).get()
            val str = StringBuilder()
            val elements = document.select("tr[i]")
            for (element in elements) {
                str.append(element.getElementsByClass("left bold elp name cryptoName first js-currency-name")
                        .select("a[href]").text())
                        .append(" ")
                        .append(element.getElementsByClass("left noWrap elp symb js-currency-symbol").text())
                        .append(" - ")
                        .append(element.getElementsByClass("price js-currency-price").select("a[href]").text())
                        .append("$\n")
            }
            return str.toString()
        }
}