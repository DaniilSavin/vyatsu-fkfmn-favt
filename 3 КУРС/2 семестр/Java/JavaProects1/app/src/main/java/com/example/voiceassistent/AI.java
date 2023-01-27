package com.example.voiceassistent;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.*;

public class AI {
    public static String ans = "";
    public static boolean is = false;
    public static Date date = new Date();
    public static Date currentDate = new Date();
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
            "привет",
            "как дела?",
            "что делаешь?",
            "чем занимаешься?",
            "hello",
            "hi",
            "здравствуйте",
            "который час?",
            "какой день недели?",
            "какой сегодня день?",
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
        QuestionAndAnswer.put("что делаешь?", ArrayOfWYD);
        QuestionAndAnswer.put("как дела?", ArrayOfHAY);
    }


    public static Integer year;
    public static Integer month;
    public static Integer day;
    public static String questionn="";

    //public static Calendar t2;
    public static String getAnswer(String question) {

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
        String[] answer;
        //String ans="";
        questionn = question.toLowerCase(Locale.ROOT);
        if ((questionn.equals("y")||questionn.equals("n")) && fll==3)
        {

            ans= getDateFromSmthg(questionn);
            fll=4;
            return ans;
        }
        if (fll==4)
        {
            return getDateFromSmthg(questionn);
        }
        questionn = getQuestion(questionn);
        Random rand = new Random();

        if (!is)
        {
            if (QuestionAndAnswer.containsKey(questionn))
            {
                answer = Objects.requireNonNull(QuestionAndAnswer.get(question));
                ans = answer[rand.nextInt(answer.length)];
            } else
                {
                if (questionn.indexOf("который час?") != -1)
                {
                    ans = timeText;
                } else
                    {
                    if (questionn.indexOf("какой день недели?") != -1)
                    {
                        ans = getDayOfWeek(dayOfWeek);

                    } else
                        {
                        if (questionn.indexOf("какой сегодня день?") != -1)
                        {
                            ans = Integer.toString(dayOfWeek - 1);
                        } else
                            {
                            if (questionn.indexOf("сколько дней до") != -1)
                            {
                                //ans=question;
                            }else
                            {
                                if (questionn.contains("Дата не найдена. Вы желаете добавить? (Y/N)"))
                                {
                                    ans=questionn;
                                    fll=3;

                                }else
                                {
                                    if (questionn.contains("addOrNo"))
                                    {
                                        ans=addDateOrNo;
                                        if (fll!=0)
                                        {
                                            fll=4;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }



       /* switch (question)
        {
            case "":
            case " ":
                answer="Empty message";
                break;
            case "привет":
                answer="Привет";
                break;
            case "как дела?":
                answer="Не плохо";
                break;
            case "чем занимаешься?":
            case "что делаешь?":
                answer="Отвечаю на вопросы";
                break;
            case "Я еще не знаю этого :(":
                answer=ArrayOfBadAnswers[rand.nextInt(ArrayOfBadAnswers.length)];
                break;

        }*/
        return ans;
    }

    public static String getQuestion(String text)
    {
        int i = 0;
        boolean fl = false;
        String question = "Я еще не знаю этого :(";
        if (!easterEgg(text))
        {
            for (; i < ArrayOfQuestions.length; i++)
            {
                if (text.contains("сколько дней до"))
                {
                    if (text.contains("зачет") || text.contains("экзамен"))
                    {
                        question=getDateFromSmthg(text);
                        break;
                    }else
                    {
                        Calendar t3 = getDate(text);
                        ans = getDifference(t3);
                        return ans;
                    }
                } else
                    {
                    if (ArrayOfQuestions[i].contains(text) && (text.length() >= ArrayOfQuestions[i].length() || text.length() == ArrayOfQuestions[i].length() - 1))
                    {
                        question = ArrayOfQuestions[i];
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

        if (strr.contains("зачет"))
        {
            if (fll==0)
            {
                for (; j < dateToTest.length; j++)
                {
                    if (!dateToTest[j].equals("-1"))
                    {
                        Calendar tt= getDate(dateToExam[k]);
                        ans=getDifference(tt);
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
                    if (j!=0)
                    {
                        dateToTest[j - 1] = date;
                    }
                    else
                    {
                        dateToTest[j]=date;
                    }

                }
                Calendar tt= getDate(date);
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
                        Calendar tt= getDate(dateToExam[k]);
                        ans=getDifference(tt);
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
                Calendar tt= getDate(date);
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



    public static Calendar getDate(String date1) {
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



