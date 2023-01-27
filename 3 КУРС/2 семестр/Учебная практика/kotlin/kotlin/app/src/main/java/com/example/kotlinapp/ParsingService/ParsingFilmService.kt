package com.example.kotlinapp.ParsingService

import org.jsoup.Jsoup
import org.jsoup.select.Elements
import java.io.IOException
import java.util.*

object ParsingFilmService {

    private const val URL = "https://www.film.ru/online/year/"
    @Throws(IOException::class)

    fun getFilm(date: String): String
    {
        val reg = Regex("[\\s+]")
        var div: Elements? = null
        val sParts = date.split(reg).toTypedArray()
        val iParts = arrayOfNulls<String>(sParts.size)
        for (i in sParts.indices)
            iParts[i] = sParts[i]
        val document = Jsoup.connect(URL + iParts[1]).get()
        val str: MutableList<String> = ArrayList()
        for (i in 1..5) {
            div = document.select("#movies_list > div:nth-child(1) > a:nth-child($i) > strong")
            if (div.isEmpty())
                break
            else
                str.add("""${div.text()}.""".trimIndent()
            )
        }
        return if (str.size != 0) str.toString().replace("^\\[|\\]$".toRegex(), "").replace(",", "")
        else
            "Нет данных по этому году"
    }
}