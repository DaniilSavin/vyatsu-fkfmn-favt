package com.example.voiceassistent

import android.annotation.SuppressLint
import android.os.AsyncTask
import android.util.Log
import java.io.IOException
import java.text.DateFormat
import java.text.ParseException
import java.text.SimpleDateFormat
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter
import java.util.*
import java.util.concurrent.TimeUnit
import java.util.regex.Pattern
import java.util.function.Consumer

object AI {
    var time = "!"
    var ans = ""
    var `is` = false
    var date = Date()
    var currentDate = Date()
    var dayFormat = SimpleDateFormat("dd/MM/YYYY")
    var dateToTest = arrayOf(
            "-1",
            "-1",
            "-1")
    var dateToExam = arrayOf(
            "-1",
            "-1",
            "-1")
    var ArrayOfQuestions = arrayOf(
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
    )
    var ArrayOfBadAnswers = arrayOf(
            "Ой, что?",
            "Я не уверен..",
            "Я не знаю.",
            "Не понял вас..")
    var ArrayOfHello = arrayOf(
            "Привет",
            "Здравствуйте")
    var ArrayOfWYD = arrayOf(
            "Отвечаю на вопросы :)",
            "Ожидаю.")
    var ArrayOfHAY = arrayOf(
            "Отлично :)",
            "Нормально.")
    var QuestionAndAnswer: MutableMap<String, Array<String>> = HashMap()
    fun FillMap() {
        QuestionAndAnswer["Я еще не знаю этого :("] = ArrayOfBadAnswers
        QuestionAndAnswer["привет"] = ArrayOfHello
        QuestionAndAnswer["hello"] = ArrayOfHello
        QuestionAndAnswer["hi"] = ArrayOfHello
        QuestionAndAnswer["здравствуйте"] = ArrayOfHello
        QuestionAndAnswer["что делаешь"] = ArrayOfWYD
        QuestionAndAnswer["как дела"] = ArrayOfHAY
    }

    var year: Int? = null
    var month: Int? = null
    var day: Int? = null
    var questionn = ""

    //public static Calendar t2;
    @JvmStatic
    @Throws(ParseException::class)
    fun getAnswer(question: String, callback: Consumer<String?>) {

        // Форматирование времени как "день.месяц.год"
        var question = question
        val dateFormat: DateFormat = SimpleDateFormat("dd.MM.yyyy", Locale.getDefault())
        val dateText = dateFormat.format(currentDate)
        // Форматирование времени как "часы:минуты:секунды"
        val timeFormat: DateFormat = SimpleDateFormat("HH:mm:ss", Locale.getDefault())
        val timeText = timeFormat.format(currentDate)
        val c = Calendar.getInstance()
        c.firstDayOfWeek = 2
        c.time = currentDate
        val dayOfWeek = c[Calendar.DAY_OF_WEEK]
        FillMap()
        var x = false
        val answers = ArrayList<String>()
        val answer: Array<String>
        //String ans="";
        questionn = question.toLowerCase(Locale.ROOT)
        while (true) {
            if ((questionn == "y" || questionn == "n") && fll == 3) {
                ans = getDateFromSmthg(questionn)
                if (questionn == "y") {
                    fll = 4
                } else {
                    fll = 0
                    fll2 = false
                    k = 0
                    //questionn="exit";
                    j = 0
                }
                //return ans;
                callback.accept(ans)
                x = true
                break
            }
            if (fll == 4) {
                //return getDateFromSmthg(questionn);
                timeToDate("сколько дней до " + questionn)
                for (i in dateToTest.indices) {
                    if (dateToTest[i] == "-1") {
                        dateToTest[i] = questionn
                        break
                    }
                }
                questionn = "exit"
                if (time == "0") {
                    callback.accept("Этот день уже наступил")
                    break
                } else {
                    val n = time.toInt()
                    var day = ""
                    day = if (n % 10 == 1) {
                        " день"
                    } else {
                        if (n % 10 > 1 && n % 10 < 5) {
                            " дня"
                        } else {
                            " дней"
                        }
                    }
                    callback.accept("До этой даты " + time + day)
                    fll = 0
                    fll2 = false
                    k = 0
                    j = 0
                    break
                }
            }
            fll = 0
            fll2 = false
            k = 0
            j = 0
            break
        }
        questionn = getQuestion(questionn)
        var r:String = "[-+]?d+"

        if (questionn.matches(r.toRegex())) {
            if (time == "0") {
                callback.accept("Этот день уже наступил")
                //break;
            } else {
                val n = time.toInt()
                var day = ""
                day = if (n % 10 == 1) {
                    " день"
                } else {
                    if (n % 10 > 1 && n % 10 < 5) {
                        " дня"
                    } else {
                        " дней"
                    }
                }
                callback.accept("До этой даты " + time + day)
                x = true
                questionn = "exit"
            }
        }
        val rand = Random()
        if (!x) {
            while (true)
            {
                if (!`is`) {
                    if (QuestionAndAnswer.containsKey(questionn)) {
                        answer = Objects.requireNonNull(QuestionAndAnswer[questionn])!!
                        ans = answer[rand.nextInt(answer.size)]
                        callback.accept(ans)
                        break
                    } else {
                        if (questionn.contains("который час") || question.contains("время")) {
                            currentDate = Date();
                            ans = timeFormat.format(currentDate)
                            callback.accept(ans)
                            break
                        } else {
                            if (questionn.contains("какой день недели")) {
                                ans = getDayOfWeek(dayOfWeek)
                                callback.accept(ans)
                                break
                            } else {
                                if (questionn.contains("какой сегодня день")) {
                                    ans = Integer.toString(dayOfWeek - 1)
                                    callback.accept(ans)
                                    break
                                } else {
                                    if (questionn.contains("сколько дней до")) {
                                        if (!questionn.contains("зачет") && !questionn.contains("зачёт")) {
                                            timeToDate(questionn)
                                        }
                                        if (time == "0") {
                                            callback.accept("Этот день уже наступил")
                                            break
                                        } else {
                                            val n = time.toInt()
                                            var day = ""
                                            day = if (n % 10 == 1) {
                                                " день"
                                            } else {
                                                if (n % 10 > 1 && n % 10 < 5) {
                                                    " дня"
                                                } else {
                                                    " дней"
                                                }
                                            }
                                            callback.accept("До этой даты " + time + day)
                                            break
                                        }
                                    } else {
                                        if (questionn.contains("Дата не найдена. Вы желаете добавить? (Y/N)")) {
                                            ans = questionn
                                            fll = 3
                                            callback.accept(ans)
                                            // questionn="";
                                            break
                                        } else {
                                            if (questionn.contains("addOrNo")) {
                                                ans = addDateOrNo
                                                if (fll != 0) {
                                                    fll = 4
                                                }
                                                callback.accept(ans)

                                                // addDateOrNo=question.toLowerCase();
                                                //  questionn="";
                                                break
                                            } else {
                                                if (questionn.contains("exit")) {
                                                    question = ""
                                                    questionn = ""
                                                    fll = 0
                                                    fll2 = false
                                                    k = 0
                                                    break
                                                }
                                                // if (questionn.contains("погода в городе"))
                                                run {
                                                    while (true) {
                                                        try {
                                                            val cityPattern = Pattern.compile(
                                                                "погода в городе (\\p{L}+)",
                                                                Pattern.CASE_INSENSITIVE
                                                            )
                                                            val numberPattern = Pattern.compile(
                                                                "(\\p{Digit}+) в строку",
                                                                Pattern.CASE_INSENSITIVE
                                                            )
                                                            var matcher = cityPattern.matcher(questionn)
                                                            if (matcher.find()) {
                                                                val cityName = matcher.group(1)
                                                                ForecastToString.getForecast(
                                                                    cityName,
                                                                    Consumer<String?> { s ->
                                                                        if (s != null)
                                                                            answers.add(s)
                                                                        Log.i("WEATHER", "AI: $s")
                                                                        callback.accept(
                                                                            java.lang.String.join(
                                                                                ", ",
                                                                                answers
                                                                            )
                                                                        )
                                                                    })
                                                                break
                                                            }
                                                            matcher = numberPattern.matcher(questionn)
                                                            if (matcher.find()) {
                                                                val number = matcher.group(1)
                                                                NumberToString.getNumber(
                                                                    number,
                                                                    Consumer<String?> { s ->
                                                                        if (s != null) {
                                                                            answers.add(s)
                                                                        }
                                                                        Log.i("WEATHER", "AI: $s")
                                                                        callback.accept(
                                                                            java.lang.String.join(
                                                                                ", ",
                                                                                answers
                                                                            )
                                                                        )
                                                                    })
                                                                break
                                                            }
                                                        } catch (e: Exception) {
                                                            callback.accept("Не получается узнать :(")
                                                            break
                                                        }
                                                        if (questionn.toLowerCase().contains("праздник")) {
                                                            val finalText = question
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
                                                                    callback.accept(
                                                                        java.lang.String.join(
                                                                            ", ",
                                                                            answers
                                                                        )
                                                                    )
                                                                }

                                                            }.execute(*date.split(",").toTypedArray())
                                                            break
                                                        } else
                                                            if (questionn.toLowerCase().contains("совет")) {
                                                                AdviceToString.getAdvice(" ") { s: String? ->
                                                                    if (s != null) {
                                                                        callback.accept(s)
                                                                    } else callback.accept("Нельзя")
                                                                }
                                                                break
                                                            } else
                                                                if (questionn.toLowerCase()
                                                                        .contains("курс криптовалюты")
                                                                ) {
                                                                    object : AsyncTask<String?, Int?, Void?>() {
                                                                        protected override fun doInBackground(vararg params: String?): Void? {
                                                                            try {
                                                                                answers.add(ParsingHtmlService.cryptoCurrencyExchangeRate)
                                                                            } catch (e: IOException) {
                                                                                e.printStackTrace()
                                                                            }
                                                                            return null
                                                                        }

                                                                        override fun onPostExecute(aVoid: Void?) {
                                                                            super.onPostExecute(aVoid)
                                                                            callback.accept(
                                                                                java.lang.String.join(
                                                                                    ", ",
                                                                                    answers
                                                                                )
                                                                            )
                                                                        }
                                                                    }.execute()
                                                                    break
                                                                } else
                                                                    if (questionn.toLowerCase().contains("создатель")) {
                                                                        callback.accept("SAVIN DANIIL")
                                                                        break
                                                                    } else {
                                                                        callback.accept("Вопрос понял. Думаю...")
                                                                        question = ""
                                                                        questionn = ""
                                                                        break
                                                                    }
                                                    }
                                                    // break
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                } else {
                    callback.accept(ans)
                    break
                }
                break
            }
        }
    }

    private fun timeToDate(date: String) {
        var date = date
        val newDate: Array<String>
        var temp = date.replace("сколько дней до ", "")
        temp = temp.replace(" ", "")
        temp = temp.replace("?", "")
        newDate = temp.split("\\.").toTypedArray()
        val calendar1: Calendar = GregorianCalendar()
        val calendar2: Calendar = GregorianCalendar(newDate[2].toInt(), newDate[1].toInt() - 1, newDate[0].toInt())
        val temp1 = calendar1.timeInMillis
        val temp2 = calendar2.timeInMillis
        val timeLeft: Long
        if (calendar1.before(calendar2)) {
            timeLeft = Math.abs(temp2 - temp1)
            TimeUnit.MILLISECONDS.toDays(timeLeft)
            time = (TimeUnit.MILLISECONDS.toDays(timeLeft) + 1).toString()
        } else time = "0"
        fll = 0
        fll2 = false
        j = 0
        date = ""
    }

    fun getQuestion(text: String): String {
        var i = 0
        val fl = false
        var question = text
        if (!easterEgg(text)) {
            while (i < ArrayOfQuestions.size) {
                if (text.contains("сколько дней до")) {
                    if (text.contains("зачет") || text.contains("экзамен") || text.contains("зачёт")) {
                        question = getDateFromSmthg(text)
                        break
                    }
                } else {
                    if (text.contains(ArrayOfQuestions[i]) /*ArrayOfQuestions[i].contains(text)*/ && (text.length >= ArrayOfQuestions[i].length || text.length == ArrayOfQuestions[i].length - 1)) {
                        question = if (!text.contains("погода в городе") && !text.contains("в строку")) {
                            ArrayOfQuestions[i]
                        } else {
                            text
                        }
                        break
                    }
                }
                i++
            }
        } else {
            return ans
        }
        return question
    }

    var fll = 0
    var addDateOrNo = ""
    lateinit var str: Array<String>
    var strr = ""
    var j = 0
    var k = 0
    var fll2 = false
    fun getDateFromSmthg(date: String): String {
        if (fll == 0) {
            str = date.split(" ").toTypedArray()
            strr = str[str.size - 1]
        }
        if (strr.contains("зачет") || strr.contains("зачёт")) {
            if (fll == 0) {
                while (j < dateToTest.size) {
                    if (dateToTest[j] != "-1") {
                        //Calendar tt= getdate(dateToTest[j]);
                        // ans=getDifference(tt);
                        timeToDate(dateToTest[j])
                        addDateOrNo = time
                        fll = 0
                        fll2 = false
                        k = 0
                        //fll2=true; fll=4;
                        break
                    } else {
                        if (dateToTest[j] == "-1" && j == dateToTest.size - 1) {
                            fll = 1
                        }
                    }
                    j++
                }
            }
            if (fll == 1) {
                addDateOrNo = "Дата не найдена. Вы желаете добавить? (Y/N)"
            }
            if (fll == 3) {
                if (date == "y") {
                    addDateOrNo = "Введите дату: дд.мм.гггг"
                } else {
                    if (date == "n") {
                        addDateOrNo = "Хорошо. Закрываю вопрос."
                        questionn = "exit"
                    } else {
                        addDateOrNo = "Error"
                    }
                    //questionn = "addOrNo";
                    fll = 0
                }
            }
            if (fll == 4) {
                if (!fll2) {
                    if (j != 0) {
                        dateToTest[j - 1] = date
                    } else {
                        dateToTest[j] = date
                    }
                }
                val tt = getdate(date)
                //addDateOrNo = getDifference(tt)
                fll = 0
                fll2 = false
                j = 0
            }
        }
        if (strr.contains("экзамен")) {
            if (fll == 0) {
                while (k < dateToExam.size) {
                    if (dateToExam[k] != "-1") {
                        //addDateOrNo = getDate(dateToExam[k]).toString();
                        //Calendar tt= getdate(dateToExam[k]);
                        // ans=getDifference(tt);
                        fll = 0
                        fll2 = false
                        k = 0
                        //fll2=true; fll=4;
                        break
                    } else {
                        if (dateToExam[k] == "-1" && k == dateToExam.size - 1) {
                            fll = 1
                        }
                    }
                    k++
                }
            }
            if (fll == 1) {
                addDateOrNo = "Дата не найдена. Вы желаете добавить? (Y/N)"
            }
            if (fll == 3) {
                if (date == "y") {
                    addDateOrNo = "Введите дату через пробелы: дд мм гггг"
                    questionn = "addOrNo"
                } else {
                    if (date == "n") {
                        addDateOrNo = "Хорошо. Закрываю вопрос."
                    } else {
                        addDateOrNo = "Error"
                    }
                    questionn = "addOrNo"
                    fll = 0
                }
            }
            if (fll == 4) {
                if (!fll2) {
                    if (k != 0) {
                        dateToExam[k - 1] = date
                    } else {
                        dateToExam[k] = date
                    }
                }
                val tt = getdate(date)
                //addDateOrNo = getDifference(tt)
                fll = 0
                fll2 = false
                k = 0
            }
        }

        // Calendar t2 = Calendar.getInstance();
        // t2.set(year, month - 1, day);
        return addDateOrNo
    }

    @SuppressLint("SimpleDateFormat") // @RequiresApi(api = Build.VERSION_CODES.O)
    @Throws(ParseException::class)
    fun getDate(text: String): String {
        val ldt: LocalDateTime
        val format1 = DateTimeFormatter.ofPattern("dd/MM/yyyy", Locale.ENGLISH)
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
                    dayFormat = SimpleDateFormat("dd/MM/yyyy")
                    val regex = "(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\\d\\d"
                    var date1: Date? = null
                    val pattern = Pattern.compile(regex)
                    val matcher = pattern.matcher(text)
                    if (matcher.find()) date1 = SimpleDateFormat("dd/MM/yyyy").parse(matcher.group())
                    nextDate = dayFormat.format(date1)
                    nextDate
                }
            }
        }
    }

    fun getdate(date1: String): Calendar {
        val str = date1.split(" ").toTypedArray()
        year = str[str.size - 1].toInt()
        month = str[str.size - 2].toInt()
        day = str[str.size - 3].toInt()
        val t2 = Calendar.getInstance()
        t2[year!!, month!! - 1] = day!!
        return t2
    }

    fun getDayOfWeek(dayOfWeek: Int): String {
        return if (dayOfWeek == 1) {
            ans = "Воскресенье"
            ans
        } else {
            if (dayOfWeek == 2) {
                ans = "Понедельник"
                ans
            } else {
                if (dayOfWeek == 3) {
                    ans = "Вторник"
                    ans
                } else {
                    if (dayOfWeek == 4) {
                        ans = "Среда"
                        ans
                    } else {
                        if (dayOfWeek == 5) {
                            ans = "Четверг"
                            ans
                        } else {
                            if (dayOfWeek == 6) {
                                ans = "Пятница"
                                ans
                            } else {
                                if (dayOfWeek == 7) {
                                    ans = "Суббота"
                                    ans
                                } else {
                                    ans = "Error 412"
                                    ans
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    fun easterEgg(question: String): Boolean {
        ans = "eE"
        if (question == "гг" || question == "gg") //easter egg
        {
            ans = "wp"
            `is` = true
        } else {
            if (question == "andrew") {
                ans = "feed"
                `is` = true
            } else {
                if (question == "pasha mohov" || question == "паша мохов" || question == "п м" || question == "p m") {
                    ans = "PASHA PUDGE MOHOV aka PASHA MOCHOV"
                    `is` = true
                } else {
                    ans = "Not found."
                    `is` = false
                }
            }
        }
        return `is`
    }
}