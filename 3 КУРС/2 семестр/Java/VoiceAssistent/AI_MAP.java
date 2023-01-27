package com.example.voiceassistent;

import android.annotation.SuppressLint;
import android.os.AsyncTask;

import androidx.core.util.Consumer;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.TimeUnit;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class AI_MAP {
    Map<String, String> answer = new LinkedHashMap<String, String>();
    String time = "!";
    String weather = "!";

    public void set() {
        answer.put("Привет", "Привет"); //0
        answer.put("Как дела", "Не плохо"); //1
        answer.put("Чем занимаешься", "Отвечаю на вопросы"); //2
        answer.put("Hi", "Hi"); //3
        answer.put("How are you", "Not bad"); //4
        answer.put("What are you doing", "Answering questions"); //5

    }

    @SuppressLint("StaticFieldLeak")
    public void get(String question, final Consumer<String> callback) {
        set();
        List keys = new ArrayList(answer.keySet());
        for (int i = 0; i < answer.size(); ++i) {
            if (question.toLowerCase().contains("какой сегодня день") || question.toLowerCase().contains("дата")) {
                date();
                callback.accept("Сегодня " + time);
                break;
            }
            else if (question.toLowerCase().contains("день недели")) {
                dayOfWeek();
                callback.accept("Сегодня" + time);
                break;
            }
            else if (question.toLowerCase().contains("час")) {
                hour();
                if (time.equals("1") || time.equals("13")) {
                    callback.accept("Сейчас " + time + "час");
                    break;
                } else if (time.equals("2") || time.equals("3") || time.equals("4") || time.equals("14") || time.equals("15") || time.equals("16")) {
                    callback.accept("Сейчас " + time + " часа");
                    break;
                } else {
                    callback.accept("Сейчас " + time + " часов");
                    break;
                }
            }
            else if (question.toLowerCase().contains("врем")) {
                timeNow();
                callback.accept("Сейчас " + time);
                break;
            }
            else if (question.toLowerCase().contains("дней до")) {
                timeToDate(question);
                if (time.equals("0")) {
                    callback.accept("Этот день уже наступил");
                    break;
                } else {
                    callback.accept("До этой даты " + time + " дня/дней");
                    break;
                }
            }
            else if (question.matches("(?i).*" + keys.get(i) + ".*")) { callback.accept(answer.get(keys.get(i))); break;}
            else {
                try {
                    Pattern cityPattern = Pattern.compile("погода в городе (\\p{L}+)", Pattern.CASE_INSENSITIVE);
                    Pattern numberPattern = Pattern.compile("(\\p{Digit}+) в строку", Pattern.CASE_INSENSITIVE);
                    Pattern holidayPattern = Pattern.compile("праздники *", Pattern.CASE_INSENSITIVE);
                    Matcher matcher = cityPattern.matcher(question);
                    if (matcher.find()) {
                        String cityName = matcher.group(1);
                        ForecastToString.getForecast(cityName, s -> {
                            if (s != null)
                                callback.accept(s);
                            else
                                callback.accept("Нет такого города");
                        });
                        break;
                    }
                    matcher = numberPattern.matcher(question);
                    if (matcher.find()){
                        String number=matcher.group(1);
                        NumberToString.getNumber(number, s -> {
                            if (s != null)
                                callback.accept(s);
                            else
                                callback.accept("Нельзя");
                        });
                        break;
                    }
                    matcher = holidayPattern.matcher(question);
                    if (matcher.find()){
                        StringBuilder temp=new StringBuilder();
                        String data=matcher.group(1);
                        Pattern checkdate1=Pattern.compile("(\\d{1,2}(\\.|-)\\d{1,2})");
                        matcher=checkdate1.matcher(data);
                        if (matcher.find()) {
                            String[] ar = data.split(".|-");
                            if (ar[0].matches("01")) temp.append("1");
                            if (ar[0].matches("02")) temp.append("2");
                            if (ar[0].matches("03")) temp.append("3");
                            if (ar[0].matches("04")) temp.append("4");
                            if (ar[0].matches("05")) temp.append("5");
                            if (ar[0].matches("06")) temp.append("6");
                            if (ar[0].matches("07")) temp.append("7");
                            if (ar[0].matches("08")) temp.append("8");
                            if (ar[0].matches("09")) temp.append("9");
                            else temp.append(ar[0]+" ");
                            if (ar[1].matches("1")) temp.append("января");
                            else if (ar[1].matches("2")) temp.append("февраля");
                            else if (ar[1].matches("3")) temp.append("марта");
                            else if (ar[1].matches("4")) temp.append("апреля");
                            else if (ar[1].matches("5")) temp.append("мая");
                            else if (ar[1].matches("6")) temp.append("июня");
                            else if (ar[1].matches("7")) temp.append("июля");
                            else if (ar[1].matches("8")) temp.append("августа");
                            else if (ar[1].matches("9")) temp.append("сентября");
                            else if (ar[1].matches("02")) temp.append("февраля");
                            else if (ar[1].matches("03")) temp.append("марта");
                            else if (ar[1].matches("04")) temp.append("апреля");
                            else if (ar[1].matches("05")) temp.append("мая");
                            else if (ar[1].matches("06")) temp.append("июня");
                            else if (ar[1].matches("07")) temp.append("июля");
                            else if (ar[1].matches("08")) temp.append("августа");
                            else if (ar[1].matches("09")) temp.append("сентября");
                            else if (ar[1].matches("10")) temp.append("октября");
                            else if (ar[1].matches("11")) temp.append("ноября");
                            else if (ar[1].matches("12")) temp.append("декабря");
                            temp.append(" 2021");
                        }
                        Pattern checkdate2=Pattern.compile("(\\d{1,2} ((янв)|(фев)|(мар)|(апр)|(мая)|(июн)|(июл)|(авг)|(сен)|(окт)|(ноя)|(дек)))");
                        matcher=checkdate2.matcher(data);
                        if (matcher.find()){
                            String[] ar = data.split(" ");
                            if (ar[0].matches("01")) temp.append("1");
                            if (ar[0].matches("02")) temp.append("2");
                            if (ar[0].matches("03")) temp.append("3");
                            if (ar[0].matches("04")) temp.append("4");
                            if (ar[0].matches("05")) temp.append("5");
                            if (ar[0].matches("06")) temp.append("6");
                            if (ar[0].matches("07")) temp.append("7");
                            if (ar[0].matches("08")) temp.append("8");
                            if (ar[0].matches("09")) temp.append("9");
                            else temp.append(ar[0]+" ");
                            if (ar[1].matches("янв")) temp.append("января");
                            else if (ar[1].matches("фев")) temp.append("февраля");
                            else if (ar[1].matches("мар")) temp.append("марта");
                            else if (ar[1].matches("апр")) temp.append("апреля");
                            else if (ar[1].matches("мая")) temp.append("мая");
                            else if (ar[1].matches("июн")) temp.append("июня");
                            else if (ar[1].matches("июл")) temp.append("июля");
                            else if (ar[1].matches("авг")) temp.append("августа");
                            else if (ar[1].matches("сен")) temp.append("сентября");
                            else if (ar[1].matches("окт")) temp.append("октября");
                            else if (ar[1].matches("ноя")) temp.append("ноября");
                            else if (ar[1].matches("дек")) temp.append("декабря");
                            temp.append(" 2021");
                        }
                        if (data.matches("сегодня")) {
                            date();
                            String[] ar = time.split(".");
                            if (ar[0].matches("01")) temp.append("1");
                            if (ar[0].matches("02")) temp.append("2");
                            if (ar[0].matches("03")) temp.append("3");
                            if (ar[0].matches("04")) temp.append("4");
                            if (ar[0].matches("05")) temp.append("5");
                            if (ar[0].matches("06")) temp.append("6");
                            if (ar[0].matches("07")) temp.append("7");
                            if (ar[0].matches("08")) temp.append("8");
                            if (ar[0].matches("09")) temp.append("9");
                            else temp.append(ar[0] + " ");
                            if (ar[1].matches("1")) temp.append("января");
                            else if (ar[1].matches("2")) temp.append("февраля");
                            else if (ar[1].matches("3")) temp.append("марта");
                            else if (ar[1].matches("4")) temp.append("апреля");
                            else if (ar[1].matches("5")) temp.append("мая");
                            else if (ar[1].matches("6")) temp.append("июня");
                            else if (ar[1].matches("7")) temp.append("июля");
                            else if (ar[1].matches("8")) temp.append("августа");
                            else if (ar[1].matches("9")) temp.append("сентября");
                            else if (ar[1].matches("02")) temp.append("февраля");
                            else if (ar[1].matches("03")) temp.append("марта");
                            else if (ar[1].matches("04")) temp.append("апреля");
                            else if (ar[1].matches("05")) temp.append("мая");
                            else if (ar[1].matches("06")) temp.append("июня");
                            else if (ar[1].matches("07")) temp.append("июля");
                            else if (ar[1].matches("08")) temp.append("августа");
                            else if (ar[1].matches("09")) temp.append("сентября");
                            else if (ar[1].matches("10")) temp.append("октября");
                            else if (ar[1].matches("11")) temp.append("ноября");
                            else if (ar[1].matches("12")) temp.append("декабря");
                            temp.append(" "+ ar[2]);
                        }
                        final String[] ans = {""};
                        final String[] date = {""};
                        new AsyncTask<String,Integer,Void>(){

                            @Override
                            protected Void doInBackground(String... strings) {
                                try {
                                    ans[0] = ParsingHtmlService.getHoliday(date);
                                } catch (IOException e) {
                                    e.printStackTrace();
                                }
                                return null;
                            }

                            @Override
                            protected void onPostExecute(Void aVoid) {
                                callback.accept(ans[0]);
                            }
                        };

                    }
                }
                catch (Exception e) {
                    callback.accept("Не получается узнать :(");
                    break;
                }
            }
        }
        //callback.accept("Вопрос понял. Думаю...");
    }

    private void date() {
        Calendar calendar = new GregorianCalendar();
        time = String.valueOf(calendar.get(Calendar.DAY_OF_MONTH)) + "." + String.valueOf(calendar.get(Calendar.MONTH) + 1) + "." + String.valueOf(calendar.get(Calendar.YEAR));
    }

    private void timeNow() {
        Calendar calendar = new GregorianCalendar();
        time = String.valueOf(calendar.get(Calendar.HOUR_OF_DAY)) + ":" + String.valueOf(calendar.get(Calendar.MINUTE));
    }
    

    private void hour() {
        Calendar calendar = new GregorianCalendar();
        int temp = calendar.get(Calendar.HOUR_OF_DAY);
        time = String.valueOf(temp);
    }

    private void dayOfWeek() {
        Calendar calendar = new GregorianCalendar();
        int temp = calendar.get(Calendar.DAY_OF_WEEK);
        if (temp == 1) time = "воскресенье";
        else if (temp == 2) time = "понедельник";
        else if (temp == 3) time = "вторник";
        else if (temp == 4) time = "среда";
        else if (temp == 5) time = "четверг";
        else if (temp == 6) time = "пятница";
        else if (temp == 7) time = "суббота";
    }

    private void timeToDate(String date) {
        String[] newDate;
        String temp = date.replace("дней до ", "");
        temp = temp.replace(" ", "");
        temp = temp.replace("?", "");
        newDate = temp.split("\\.");
        Calendar calendar1 = new GregorianCalendar();
        Calendar calendar2 = new GregorianCalendar(Integer.parseInt(newDate[2]), Integer.parseInt(newDate[1])-1, Integer.parseInt(newDate[0]));
        long temp1 = calendar1.getTimeInMillis();
        long temp2 = calendar2.getTimeInMillis();
        long timeLeft;
        if (calendar1.before(calendar2)) {
            timeLeft = Math.abs(temp2 - temp1);
            TimeUnit.MILLISECONDS.toDays(timeLeft);
            time = String.valueOf(TimeUnit.MILLISECONDS.toDays(timeLeft) + 1);
        }
        else time = "0";
    }
}
