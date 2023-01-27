package com.example.kotlinapp

import android.annotation.SuppressLint
import android.os.AsyncTask
import android.os.Build
import android.util.Log
import androidx.annotation.RequiresApi
import com.example.kotlinapp.CovidAPI.CovidToString
import com.example.kotlinapp.CurrencyAPI.CurrencyToString
import com.example.kotlinapp.NumberConversionAPI.NumberToString
import com.example.kotlinapp.ParsingService.ParsingFilmService
import com.example.kotlinapp.ParsingService.ParsingHtmlService
import com.example.kotlinapp.WeatherAPI.ForecastToString
import java.io.IOException
import java.text.ParseException
import java.text.SimpleDateFormat
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter
import java.util.*
import java.util.function.Consumer
import java.util.regex.Pattern


object AI {
    var hashMap: MutableMap<String, String> =
        HashMap()
    var dayFormat = SimpleDateFormat("dd/MM/YYYY")
    var currDate: String = dayFormat.format(Date())
    var timeFormat = SimpleDateFormat("HH:mm:ss")
    var currTime = timeFormat.format(Date())
    var dayFormat2 = SimpleDateFormat("EEEE")
    /*fun DictionaryFill(hashMap: MutableMap<*, *>) {
        hashMap["привет"] = "Привет!"
        hashMap["как дела"] = "Неплохо"
        hashMap["чем занимаешься"] = "Отвечаю на вопросы"
    }*/

    @RequiresApi(api = Build.VERSION_CODES.O)
    @Throws(ParseException::class)
    fun getDate(text: String): String {
        val ldt: LocalDateTime
        val format1 =
            DateTimeFormatter.ofPattern("dd/MM/YYYY", Locale.ENGLISH)
        return if (text.contains("вчера")) {
            ldt = LocalDateTime.now().minusDays(1)
            format1.format(ldt)
        } else {
            if (text.contains("завтра")) {
                ldt = LocalDateTime.now().plusDays(1)
                format1.format(ldt)
            } else {
                if (text.contains("сегодня")) dayFormat.format(Date()) else {
                    val nextDate: String
                    dayFormat = SimpleDateFormat("dd/MM/YYYY")
                    val regex =
                        "(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d"
                    var date1: Date? = null
                    val pattern = Pattern.compile(regex)
                    val matcher = pattern.matcher(text)
                    if (matcher.find()) date1 =
                        SimpleDateFormat("dd/MM/yyyy").parse(matcher.group())
                    nextDate = dayFormat.format(date1)
                    nextDate
                }
            }
        }
    }

    fun firstUpperCase(word: String?): String? {
        return if (word == null || word.isEmpty()) "" else word.substring(0, 1)
            .toUpperCase() + word.substring(1) //или return word;
    }


    @SuppressLint("NewApi")
    @RequiresApi(api = Build.VERSION_CODES.N)
    @Throws(ParseException::class, IOException::class)
    fun getAnswer(text: String, callback: Consumer<String>) {
        var text = text
                //AI.DictionaryFill(hashMap)
        val result: String? = null
        val answers = ArrayList<String>()
        val entries = ArrayList<Map.Entry<*, *>>(hashMap.entries)
        text = text.toLowerCase()
        /* for (HashMap.Entry entry : entries)
        {*/if (text.contains("сколько времени") || text.contains("время")) {
            timeFormat = SimpleDateFormat("HH:mm:ss")
            currTime = timeFormat.format(Date())
            answers.add("Сейчас - " + currTime)
            callback.accept(java.lang.String.join(", ", answers /*hashMap.get(entry.getKey()))*/))
        }
        if (text.contains("какой сегодня день") || text.contains("дата")) {
            dayFormat = SimpleDateFormat("dd/MM/YYYY")
            currDate = dayFormat.format(Date())
            answers.add("Сегодня - " + currDate)
            callback.accept(java.lang.String.join(", ", answers /*hashMap.get(entry.getKey()))*/))
        }
        if (text.contains("какой день недели") || text.contains("день недели")) {
            dayFormat2 = SimpleDateFormat("EEEE")
            val calendar: Calendar = GregorianCalendar(TimeZone.getTimeZone(currDate))
            answers.add("Сегодня - " + dayFormat2.format(calendar.time))
            callback.accept(java.lang.String.join(", ", answers /*hashMap.get(entry.getKey()))*/))
        }
        if (text.contains("сколько дней до") || text.contains("дней до") || text.contains("сколько до")) {
            val nextDate: String
            dayFormat = SimpleDateFormat("dd/MM/YYYY")
            val regex = "(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d"
            var date1: Date? = null
            var date2: Date? = null
            val pattern = Pattern.compile(regex)
            val matcher = pattern.matcher(text)
            date2 = SimpleDateFormat("dd/MM/yyyy").parse(currDate)
            if (matcher.find()) {
                date1 = SimpleDateFormat("dd/MM/yyyy").parse(matcher.group())
            } else answers.add("Дата не найдена")
            try {
            } catch (e: Exception) {
                e.printStackTrace()
            }
            val difference = date1!!.time - date2.time
            val days = difference / (24 * 60 * 60 * 1000)
            currDate = dayFormat.format(Date())
            nextDate = dayFormat.format(date1)
            answers.add("Дней от " + currDate + " до " + nextDate + " = " + days)
            callback.accept(java.lang.String.join(", ", answers /*hashMap.get(entry.getKey()))*/))
        }
        if (text.contains("переведи число") || text.contains("переведи")) {
            val numPattern = Pattern.compile("переведи число ([0-9]+)", Pattern.CASE_INSENSITIVE)
            val matcher = numPattern.matcher(text)
            if (matcher.find()) {
                val number = matcher.group(1)
                NumberToString.getNumString(Integer.valueOf(number), Consumer<String?> { s ->
                    if (s != null) {
                        answers.add(s)
                    }
                    Log.i("WEATHER", "AI: $s")
                    callback.accept(java.lang.String.join(", ", answers))
                })
            }
        }
        if (text.contains("погода в городе")) {
            val cityPattern = Pattern.compile("погода в городе (\\p{L}+)", Pattern.CASE_INSENSITIVE)
            val matcher = cityPattern.matcher(text)
            if (matcher.find()) {
                val cityName = matcher.group(1)
                ForecastToString.getForecast(cityName, Consumer<String?> { s ->
                    if (s != null) {
                        answers.add(s)
                    }
                    Log.i("WEATHER", "AI: $s")
                    callback.accept(
                        java.lang.String.join(
                            ", ",
                            answers /*hashMap.get(entry.getKey()))*/
                        )
                    )
                })
                //return "Не знаю я, какая там погода у вас в городе "+cityName;
            }
        }


        if (text.contains("ковид в стране"))
        {
            val numPattern = Pattern.compile("ковид в стране (\\p{L}+)", Pattern.CASE_INSENSITIVE)
            val matcher = numPattern.matcher(text)
            if (matcher.find())
            {
                val country = matcher.group(1)
                CovidToString.getCovidString(AI.firstUpperCase(country), Consumer<String?> { s ->
                    if (s != null) {
                        answers.add(s)
                    }
                    callback.accept(java.lang.String.join(", ", answers))
                })
            }
        }



        if (text.contains("курс валюты"))
        {

            CurrencyToString.getCurrencyString(Consumer<String?> { s->
                if (s!= null) {
                    answers.add(s)
                }
                    callback.accept(java.lang.String.join(", ", answers))
                })
        }





        if (text.contains("фильмы")) {
            val finalText = text
            object : AsyncTask<String?, Int?, Void?>() {
                override fun doInBackground(vararg params: String?): Void? {
                    try {
                        answers.add(ParsingFilmService.getFilm(finalText))
                    } catch (e: IOException) {
                        e.printStackTrace()
                    }
                    return null
                }

                override fun onPostExecute(aVoid: Void?) {
                    super.onPostExecute(aVoid)
                    callback.accept(java.lang.String.join(", ", answers))
                }
            }.execute(*finalText.split(",").toTypedArray())
        }

        if (text.contains("праздник")) {
            val finalText = text
            val date = getDate(finalText)
            object : AsyncTask<String?, Int?, Void?>() {
                override fun doInBackground(vararg params: String?): Void? {
                    try {
                        answers.add(ParsingHtmlService.getHoliday(date))
                    } catch (e: IOException) {
                        e.printStackTrace()
                    }
                    return null
                }

                override fun onPostExecute(aVoid: Void?) {
                    super.onPostExecute(aVoid)
                    callback.accept(java.lang.String.join(", ", answers))
                }


            }.execute(*date.split(",").toTypedArray())

             /*Observable.fromCallable(new Callable <Object>() {
                 @Override
                 public Object call() {
                     try {
                         answers.add(ParsingHtmlService.getHoliday(date));
                         return answers;
                     } catch (IOException e) {
                         e.printStackTrace();
                     }
                     return null;
                 }
             })
                    .subscribeOn(Schedulers.io())
                    .observeOn(AndroidSchedulers.mainThread())
                    .subscribe((result2) -> {
                        callback.accept(String.join(", ", answers));
                    });

            Observable.fromCallable( Callable <Object> {
                @Override
                Object call() {
                    try {
                        answers.add(ParsingHtmlService.getHoliday(date));
                        return answers;
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                    return null;
                }
            })*/
        }
    }
}