package com.example.voiceassistent;

import android.annotation.SuppressLint;
import android.os.AsyncTask;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.io.IOException;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.concurrent.TimeUnit;
import java.util.regex.Matcher;
import java.util.regex.Pattern;
import androidx.core.util.Consumer;

public class AI {
    static String time = "!";
    public static String ans = "";
    public static boolean is = false;
    public static Date date = new Date();
    public static Date currentDate = new Date();
    static SimpleDateFormat dayFormat = new SimpleDateFormat("dd/MM/YYYY");
    public static String[] dateToTest=
            {
                   "-1",
                    "-1",
                    "-1",
            };
    public static String[] dateToExam=
            {
                    "-1",
                    "-1",
                    "-1",
            };
    public static String[] ArrayOfQuestions = {
            "совет",
            "курс криптовалюты",
            "в строку",
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
            "Я не уверен..",
            "Я не знаю.",
            "Не понял вас..",

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


    public static Integer year;
    public static Integer month;
    public static Integer day;
    public static String questionn="";

    //public static Calendar t2;
    public static void getAnswer(String question, final Consumer<String> callback) throws ParseException {

        // Форматирование времени как "день.месяц.год"
        DateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy", Locale.getDefault());
        String dateText = dateFormat.format(currentDate);
        // Форматирование времени как "часы:минуты:секунды"
        DateFormat timeFormat = new SimpleDateFormat("HH:mm:ss", Locale.getDefault());
        String timeText = timeFormat.format(currentDate);

        Calendar c = Calendar.getInstance();
        c.setFirstDayOfWeek(2);
        c.setTime(currentDate);
        int dayOfWeek = c.get(Calendar.DAY_OF_WEEK);

        FillMap();

boolean x=false;
        ArrayList<String> answers = new ArrayList<>();

        String[] answer;
        //String ans="";
        questionn = question.toLowerCase(Locale.ROOT);
        while(true) {
            if ((questionn.equals("y") || questionn.equals("n")) && fll == 3) {

                ans = getDateFromSmthg(questionn);
                if (questionn.equals("y")) {
                    fll = 4;
                }
                else
                {
                    fll=0;
                    fll2=false; k=0;
                    //questionn="exit";
                    j=0;

                }
                //return ans;
                callback.accept(ans);
                x=true;
                break;
            }
            if (fll == 4)
            {
                //return getDateFromSmthg(questionn);
                timeToDate("сколько дней до "+questionn);
                for (int i=0; i<dateToTest.length; i++)
                {
                    if (dateToTest[i].equals("-1"))
                    {
                        dateToTest[i]=questionn;
                        break;
                    }
                }
                questionn="exit";
                if (time.equals("0"))
                {
                    callback.accept("Этот день уже наступил");
                    break;
                } else
                    {
                    int n=Integer.parseInt(time);
                    String day="";
                    if (n%10==1)
                    {
                        day=" день";
                    }
                    else
                    {
                        if (n%10>1 && n%10<5)
                        {
                            day=" дня";
                        }
                        else
                        {
                            day=" дней";
                        }
                    }
                    callback.accept("До этой даты " + time + day);
                        fll=0;
                        fll2=false; k=0; j=0;
                    break;
                }
            }
            fll=0;
            fll2=false; k=0; j=0;
            break;
        }
        questionn = getQuestion(questionn);
        if (questionn.matches("[-+]?\\d+"))
        {
            if (time.equals("0"))
            {
                callback.accept("Этот день уже наступил");
                //break;
            } else {
                int n=Integer.parseInt(time);
                String day="";
                if (n%10==1)
                {
                    day=" день";
                }
                else
                {
                    if (n%10>1 && n%10<5)
                    {
                        day=" дня";
                    }
                    else
                    {
                        day=" дней";
                    }
                }
                callback.accept("До этой даты " + time + day);
                x=true;
                questionn="exit";
            }
        }

        Random rand = new Random();
        if (!x) {

            while (true) {

                if (!is) {

                    if (QuestionAndAnswer.containsKey(questionn)) {
                        answer = Objects.requireNonNull(QuestionAndAnswer.get(questionn));
                        ans = answer[rand.nextInt(answer.length)];
                        callback.accept(ans);
                        break;
                    } else {
                        if (questionn.contains("который час") || question.contains("время")) {
                            ans = timeText;
                            callback.accept(ans);
                            break;
                        } else {
                            if (questionn.contains("какой день недели")) {
                                ans = getDayOfWeek(dayOfWeek);
                                callback.accept(ans);
                                break;

                            } else {
                                if (questionn.contains("какой сегодня день")) {
                                    ans = Integer.toString(dayOfWeek - 1);
                                    callback.accept(ans);
                                    break;
                                } else {
                                    if (questionn.contains("сколько дней до")) {
                                        if (!questionn.contains("зачет") && !questionn.contains("зачёт")) {
                                            timeToDate(questionn);
                                        }

                                        if (time.equals("0")) {
                                            callback.accept("Этот день уже наступил");
                                            break;
                                        } else {
                                            int n = Integer.parseInt(time);
                                            String day = "";
                                            if (n % 10 == 1) {
                                                day = " день";
                                            } else {
                                                if (n % 10 > 1 && n % 10 < 5) {
                                                    day = " дня";
                                                } else {
                                                    day = " дней";
                                                }
                                            }
                                            callback.accept("До этой даты " + time + day);
                                            break;
                                        }
                                    } else {
                                        if (questionn.contains("Дата не найдена. Вы желаете добавить? (Y/N)")) {
                                            ans = questionn;
                                            fll = 3;
                                            callback.accept(ans);
                                            // questionn="";
                                            break;

                                        } else {
                                            if (questionn.contains("addOrNo")) {
                                                ans = addDateOrNo;
                                                if (fll != 0) {
                                                    fll = 4;
                                                }
                                                callback.accept(ans);

                                                // addDateOrNo=question.toLowerCase();
                                                //  questionn="";
                                                break;
                                            } else {
                                                if (questionn.contains("exit")) {
                                                    question = "";
                                                    questionn = "";
                                                    fll = 0;
                                                    fll2 = false;
                                                    k = 0;
                                                    break;
                                                }
                                                // if (questionn.contains("погода в городе"))
                                                {
                                                    while (true) {

                                                            try {
                                                                Pattern cityPattern = Pattern.compile("погода в городе (\\p{L}+)", Pattern.CASE_INSENSITIVE);
                                                                Pattern numberPattern = Pattern.compile("(\\p{Digit}+) в строку", Pattern.CASE_INSENSITIVE);
                                                                Matcher matcher = cityPattern.matcher(questionn);
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
                                                                matcher = numberPattern.matcher(questionn);
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
                                                        if (questionn.toLowerCase().contains("праздник")) {
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
                                                        } else if (questionn.toLowerCase().contains("совет")) {
                                                            AdviceToString.getAdvice(" ", s -> {
                                                                if (s != null) {
                                                                    callback.accept(s);
                                                                } else
                                                                    callback.accept("Нельзя");
                                                            });
                                                            break;
                                                        } else if (questionn.toLowerCase().contains("курс криптовалюты")) {
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
                                                        } else if (questionn.toLowerCase().contains("создатель")) {
                                                            callback.accept("SAVIN DANIIL");
                                                            break;
                                                        } else {
                                                            callback.accept("Вопрос понял. Думаю...");
                                                            question = "";
                                                            questionn = "";
                                                            break;
                                                        }

                                                    }
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                } else {
                    callback.accept(ans);
                    break;
                }
            }
        }
    }

    private static void timeToDate(String date) {
        String[] newDate;
        String temp = date.replace("сколько дней до ", "");
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
        fll=0; fll2=false; j=0; date="";
    }

    public static String getQuestion(String text)
    {
        int i = 0;
        boolean fl = false;
        String question = text;
        if (!easterEgg(text))
        {
            for (; i < ArrayOfQuestions.length; i++)
            {
                if (text.contains("сколько дней до"))
                {
                    if (text.contains("зачет") || text.contains("экзамен") || text.contains("зачёт"))
                    {
                        question=getDateFromSmthg(text);

                        break;
                    }

                } else
                    {
                    if (text.contains(ArrayOfQuestions[i])/*ArrayOfQuestions[i].contains(text)*/ && (text.length() >= ArrayOfQuestions[i].length() || text.length() == ArrayOfQuestions[i].length() - 1))
                    {
                        if (!text.contains("погода в городе")) {
                            question = ArrayOfQuestions[i];
                        }
                        else
                        {
                            question=text;
                        }
                        break;
                    }
                }

            }
        } else
        {
            return ans;
        }
        return question;
    }
    public static int fll=0;
    public static String addDateOrNo="";
    public static String[] str;
    public static String strr="";
    public static int j=0; public static int k=0;
    public static boolean fll2=false;

    public static String getDateFromSmthg(String date)
    {

        if (fll==0)
        {
             str = date.split(" ");
             strr = str[str.length - 1];

        }

        if (strr.contains("зачет") || strr.contains("зачёт"))
        {
            if (fll==0)
            {
                for (; j < dateToTest.length; j++)
                {
                    if (!dateToTest[j].equals("-1"))
                    {
                        //Calendar tt= getdate(dateToTest[j]);
                       // ans=getDifference(tt);
                        timeToDate(dateToTest[j]);
                        addDateOrNo=time;
                        fll=0;
                        fll2=false;
                        k=0;
                        //fll2=true; fll=4;
                        break;
                    } else
                    {
                        if (dateToTest[j].equals("-1") && j == dateToTest.length - 1)
                        {
                            fll = 1;
                        }
                    }
                }
            }
            if (fll==1)
            {
                addDateOrNo="Дата не найдена. Вы желаете добавить? (Y/N)";

            }
            if(fll==3)
            {
                if (date.equals("y"))
                {
                    addDateOrNo="Введите дату: дд.мм.гггг";

                }
                else
                {
                    if (date.equals("n"))
                    {
                        addDateOrNo = "Хорошо. Закрываю вопрос.";
                        questionn="exit";
                    }else
                    {
                        addDateOrNo="Error";
                    }
                    //questionn = "addOrNo";
                    fll = 0;
                }

            }
            if (fll==4)
            {
                if (!fll2)
                {
                    if (j!=0)
                    {
                        dateToTest[j - 1] = date;
                    }
                    else
                    {
                        dateToTest[j]=date;
                    }

                }
                Calendar tt= getdate(date);
                addDateOrNo=getDifference(tt);
                fll=0; fll2=false; j=0;
            }

        }
        if (strr.contains("экзамен"))
        {
            if (fll==0)
            {
                for (; k < dateToExam.length; k++)
                {
                    if (!dateToExam[k].equals("-1"))
                    {
                        //addDateOrNo = getDate(dateToExam[k]).toString();
                        //Calendar tt= getdate(dateToExam[k]);
                       // ans=getDifference(tt);
                        fll=0;
                        fll2=false;
                        k=0;
                        //fll2=true; fll=4;
                        break;
                    } else
                    {
                        if (dateToExam[k].equals("-1") && k == dateToExam.length - 1)
                        {
                            fll = 1;
                        }
                    }
                }
            }
            if (fll==1)
            {
                addDateOrNo="Дата не найдена. Вы желаете добавить? (Y/N)";
            }
            if(fll==3)
            {
                if (date.equals("y"))
                {
                    addDateOrNo="Введите дату через пробелы: дд мм гггг";
                    questionn="addOrNo";
                }
                else
                {
                    if (date.equals("n"))
                    {
                        addDateOrNo = "Хорошо. Закрываю вопрос.";
                    }else
                    {
                        addDateOrNo="Error";
                    }
                    questionn = "addOrNo";
                    fll = 0;
                }

            }
            if (fll==4)
            {
                if (!fll2)
                {
                    if (k!=0)
                    {
                        dateToExam[k - 1] = date;
                    }
                    else
                    {
                        dateToExam[k]=date;
                    }
                }
                Calendar tt= getdate(date);
                addDateOrNo=getDifference(tt);
                fll=0;
                fll2=false;
                k=0;
            }

        }

       // Calendar t2 = Calendar.getInstance();
       // t2.set(year, month - 1, day);
        return addDateOrNo;
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

    public static Calendar getdate(String date1) {
        String[] str = date1.split(" ");
        year = Integer.parseInt((str[str.length - 1]));
        month = Integer.parseInt((str[str.length - 2]));
        day = Integer.parseInt((str[str.length - 3]));

        Calendar t2 = Calendar.getInstance();
        t2.set(year, month - 1, day);
        return t2;
    }

    public static String getDifference(Calendar t2) {
        // Calendar t2=new GregorianCalendar(2020, 12, 12);
        Calendar t1 = Calendar.getInstance();
        StringBuilder result = new StringBuilder("");
        Integer[] res = new Integer[3];
        /*result.append */
        res[0] = (t1.get(Calendar.YEAR) > t2.get(Calendar.YEAR) ? t1.get(Calendar.YEAR) - t2.get(Calendar.YEAR) : t2.get(Calendar.YEAR) - t1.get(Calendar.YEAR));
        //result.append(":");
        /*result.append*/
        res[1] = (t1.get(Calendar.MONTH) > t2.get(Calendar.MONTH) ? t1.get(Calendar.MONTH) - t2.get(Calendar.MONTH)
                : t2.get(Calendar.MONTH) - t1.get(Calendar.MONTH));
        // result.append(":");
        /*result.append*/
        res[2] = (t1.get(Calendar.DATE) > t2.get(Calendar.DATE) ? t1.get(Calendar.DATE) - t2.get(Calendar.DATE)
                : t2.get(Calendar.DATE) - t1.get(Calendar.DATE));

        String string = "";
        if (res[0] != 0) {
            //string+=Integer.toString(res[0]*365);
            int x = res[0], z, y;
            z = 10;
            y = 100;
            if (x % z == 1 && x != 11 && x != 111) {
                string += Integer.toString(res[0]) + " год ";
            } else {
                if (x % z > 1 && x % z < 5 && x != 12 && x != 13 && x != 14) {
                    string += Integer.toString(res[0]) + " года ";
                } else {
                    if (x % z > 4 || x % z == 0 && x >= 11 && x <= 20 && x >= 111 && x >= 120) {
                        string += Integer.toString(res[0]) + " лет ";
                    }

                }
            }
        }
        if (res[1] != 0) {
            int x = res[1];

            if (x % 10 == 1) {
                string += Integer.toString(res[1]) + " месяц ";
            } else {
                if (x % 10 > 1 && x % 10 < 5) {
                    string += Integer.toString(res[1]) + " месяца ";
                } else {
                    if (x % 10 > 4 || x>4) {
                        string += Integer.toString(res[1]) + " месяцев ";
                    }
                }
            }
        }

        if (res[2] != 0) {
           int x = res[2];

            if (x % 10 == 1 && x!=11)
            {
                string += Integer.toString(res[2]) + " день ";
            } else
                {
                if (x % 10 > 1 && x % 10 < 5)
                {
                    string += Integer.toString(res[2]) + " дня ";
                } else
                    {
                    if (x % 10 > 6 || x==11)
                    {
                        string += Integer.toString(res[2]) + " дней ";
                    }
                }
            }
        }


        return string;
    }


    public static String getDayOfWeek(int dayOfWeek) {
        if (dayOfWeek == 1) {
            ans = "Воскресенье";
            return ans;
        } else {
            if (dayOfWeek == 2) {
                ans = "Понедельник";
                return ans;
            } else {
                if (dayOfWeek == 3) {
                    ans = "Вторник";
                    return ans;
                } else {
                    if (dayOfWeek == 4) {
                        ans = "Среда";
                        return ans;
                    } else {
                        if (dayOfWeek == 5) {
                            ans = "Четверг";
                            return ans;
                        } else {
                            if (dayOfWeek == 6) {
                                ans = "Пятница";
                                return ans;
                            } else {
                                if (dayOfWeek == 7) {
                                    ans = "Суббота";
                                    return ans;
                                } else {
                                    ans = "Error 412";
                                    return ans;
                                }
                            }
                        }
                    }
                }
            }
        }
    }


    public static boolean easterEgg(@org.jetbrains.annotations.NotNull String question) {
        ans = "eE";

        if (question.equals("гг") || question.equals("gg")) //easter egg
        {
            ans = "wp";
            is = true;
        } else {
            if (question.equals("andrew")) {
                ans = "feed";
                is = true;
            } else {
                if (question.equals("pasha mohov") || question.equals("паша мохов") || question.equals("п м") || question.equals("p m")) {
                    ans = "PASHA PUDGE MOHOV aka PASHA MOCHOV";
                    is = true;
                } else {
                    ans = "Not found.";
                    is = false;
                }
            }
        }
        return is;
    }
}



