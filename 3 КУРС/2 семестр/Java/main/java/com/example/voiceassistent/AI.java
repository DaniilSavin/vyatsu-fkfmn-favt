package com.example.voiceassistent;

import com.example.voiceassistent.R;
import java.lang.String;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class AI {
    static String getAnswer(String question){
        String answer="Вопрос понял. Думаю...";
        if (question.matches("(?i).*" + "Привет" + ".*")) answer="Привет";
        if (question.matches("(?i).*" + "Как дела" + ".*")) answer="Не плохо";
        if (question.matches("(?i).*" + "Чем занимаешься" + ".*")) answer="Отвечаю на вопросы";
        return answer;
    }
}


