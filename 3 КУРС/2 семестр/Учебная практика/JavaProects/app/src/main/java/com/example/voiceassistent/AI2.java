package com.example.voiceassistent;

import android.annotation.SuppressLint;
import android.os.AsyncTask;
import android.os.Build;

import androidx.annotation.RequiresApi;
import androidx.core.util.Consumer;

import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.GregorianCalendar;
import java.util.HashMap;
import java.util.LinkedHashMap ;
import java.util.List;
import java.util.Locale;
import java.util.Map;
import java.util.Date;
import java.util.concurrent.TimeUnit;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class AI2 {
    static Map<String, String> answer = new LinkedHashMap<String, String>();
    static String time = "!";
    String weather = "!";
    static SimpleDateFormat dayFormat = new SimpleDateFormat("dd/MM/YYYY");
    public static void set()
    {
        answer.put("привет", "Привет"); //0
        answer.put("как дела", "Не плохо"); //1
        answer.put("чем занимаешься", "Отвечаю на вопросы"); //2
        answer.put("hi", "Hi"); //3
        answer.put("how are you", "Not bad"); //4
        answer.put("what are you doing", "Answering questions"); //5
        answer.put("что делаешь", "Отвечаю на вопросы"); //6
    }
    public static String[] ArrayOfQuestions = {
            "погода в городе",
            "привет",
            "как дела",
            "что делаешь",
            "чем занимаешься",
            "hello",
            "hi",
            "здравствуйте",
            "который час",
            "какой день недели",
            "какой сегодня день",
            "сколько дней до"



    };
    public static String[] ArrayOfBadAnswers = {
            "Ой, что?",
            "Я не уверена..",
            "Я не знаю.",
            "Не поняла вас..",

    };
    public static String[] ArrayOfHello = {
            "Привет",
            "Здравствуйте",

    };
    public static String[] ArrayOfWYD = {
            "Отвечаю на вопросы :)",
            "Ожидаю.",

    };
    public static String[] ArrayOfHAY = {
            "Отлично :)",
            "Нормально.",

    };
    public static Map<String, String[]> QuestionAndAnswer = new HashMap<>();
    public static void FillMap() {
        QuestionAndAnswer.put("Я еще не знаю этого :(", ArrayOfBadAnswers);
        QuestionAndAnswer.put("привет", ArrayOfHello);
        QuestionAndAnswer.put("hello", ArrayOfHello);
        QuestionAndAnswer.put("hi", ArrayOfHello);
        QuestionAndAnswer.put("здравствуйте", ArrayOfHello);
        QuestionAndAnswer.put("что делаешь", ArrayOfWYD);
        QuestionAndAnswer.put("как дела", ArrayOfHAY);
    }
    public static boolean check(String text)
    {
        boolean f=false;
        String ans="";
        if (text.toLowerCase().contains("привет")){

        }




        return f;
    }

    @SuppressLint("StaticFieldLeak")
    public static void get(String question, final Consumer<String> callback) throws ParseException, IOException {
        set();
        FillMap();
        //if (!check(question))
        {
            ArrayList<String> answers = new ArrayList<>();
            List keys = new ArrayList(answer.keySet());
            for (int i = 0; i < answer.size(); ++i) {
                if (question.toLowerCase().contains("какой сегодня день") || question.toLowerCase().contains("дата")) {
                    date();
                    callback.accept("Сегодня " + time);
                    break;
                } else if (question.toLowerCase().contains("день недели")) {
                    dayOfWeek();
                    callback.accept("Сегодня" + time);
                    break;
                } else if (question.toLowerCase().contains("час")) {
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
                } else if (question.toLowerCase().contains("врем")) {
                    timeNow();
                    callback.accept("Сейчас " + time);
                    break;
                } else if (question.toLowerCase().contains("дней до")) {
                    timeToDate(question);
                    if (time.equals("0"))
                    {
                        callback.accept("Этот день уже наступил");
                        break;
                    } else {
                        callback.accept("До этой даты " + time + " дня/дней");
                        break;
                    }
                } else
                    //if (answer.containsKey(question.toLowerCase()))
                    if (question.matches("(?i).*" + keys.get(i) + ".*"))
                    {
                    callback.accept(answer.get(keys.get(i)));
                    break;
                } else
                    {
                    try {
                        Pattern cityPattern = Pattern.compile("погода в городе (\\p{L}+)", Pattern.CASE_INSENSITIVE);
                        Pattern numberPattern = Pattern.compile("(\\p{Digit}+) в строку", Pattern.CASE_INSENSITIVE);
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
                        if (matcher.find()) {
                            String number = matcher.group(1);
                            NumberToString.getNumber(number, s -> {
                                if (s != null)
                                    callback.accept(s);
                                else
                                    callback.accept("Нельзя");
                            });
                            break;
                        }
                    } catch (Exception e) {
                        callback.accept("Не получается узнать :(");
                        break;
                    }
                    if (question.toLowerCase().contains("праздник")) {
                        String finalText = question;
                        String date = getDate(finalText);
                        new AsyncTask<String, Integer, Void>() {
                            protected Void doInBackground(String... strings) {
                                try {
                                    answers.add(ParsingHtmlService.getHoliday(date));
                                } catch (IOException e) {
                                    e.printStackTrace();
                                }
                                return null;
                            }

                            @Override
                            protected void onPostExecute(Void aVoid) {
                                super.onPostExecute(aVoid);
                                callback.accept(String.join(", ", answers));
                            }
                        }.execute(date.split(","));
                        break;
                    } else if (question.toLowerCase().contains("совет")) {
                        AdviceToString.getAdvice(" ", s -> {
                            if (s != null) {
                                callback.accept(s);
                            } else
                                callback.accept("Нельзя");
                        });
                        break;
                    } else if (question.toLowerCase().contains("курс криптовалюты")) {
                        new AsyncTask<String, Integer, Void>() {
                            protected Void doInBackground(String... strings) {
                                try {
                                    answers.add(ParsingHtmlService.getCryptoCurrencyExchangeRate());
                                } catch (IOException e) {
                                    e.printStackTrace();
                                }
                                return null;
                            }

                            @Override
                            protected void onPostExecute(Void aVoid) {
                                super.onPostExecute(aVoid);
                                callback.accept(String.join(", ", answers));
                            }
                        }.execute();
                        break;
                    } else if (question.toLowerCase().contains("создатель")) {
                        callback.accept("SAVIN DANIIL");
                    } else {
                        callback.accept("Вопрос понял. Думаю...");
                        //break;
                    }
                }


            }
        }
    }

    @SuppressLint("SimpleDateFormat")
   // @RequiresApi(api = Build.VERSION_CODES.O)
    static String getDate(String text) throws ParseException {
        LocalDateTime ldt;
        DateTimeFormatter format1 = DateTimeFormatter.ofPattern("dd/MM/yyyy", Locale.ENGLISH);
        if (text.contains("вчера")) {
            ldt = LocalDateTime.now().minusDays(1);
            return format1.format(ldt);
        } else {
            if (text.contains("завтра")) {
                ldt = LocalDateTime.now().plusDays(1);
                return format1.format(ldt);
            } else {
                if (text.contains("сегодня"))
                    return dayFormat.format(new Date());
                else {
                    String nextDate;
                    dayFormat = new SimpleDateFormat("dd/MM/yyyy");
                    String regex = "(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d";
                    Date date1 = null;
                    Pattern pattern = Pattern.compile(regex);
                    Matcher matcher = pattern.matcher(text);
                    if (matcher.find())
                        date1 = new SimpleDateFormat("dd/MM/yyyy").parse(matcher.group());
                    nextDate = dayFormat.format(date1);
                    return nextDate;
                }
            }
        }
    }


    private static void date() {
        Calendar calendar = new GregorianCalendar();
        time = String.valueOf(calendar.get(Calendar.DAY_OF_MONTH)) + "." + String.valueOf(calendar.get(Calendar.MONTH) + 1) + "." + String.valueOf(calendar.get(Calendar.YEAR));
    }

    private static void timeNow() {
        Calendar calendar = new GregorianCalendar();
        time = String.valueOf(calendar.get(Calendar.HOUR_OF_DAY)) + ":" + String.valueOf(calendar.get(Calendar.MINUTE));
    }


    private static void hour() {
        Calendar calendar = new GregorianCalendar();
        int temp = calendar.get(Calendar.HOUR_OF_DAY);
        time = String.valueOf(temp);
    }

    private static void dayOfWeek() {
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

    private static void timeToDate(String date) {
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
