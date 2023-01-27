package com.example.voiceassistent;

import android.content.Context;
import android.os.Bundle;
import android.speech.tts.TextToSpeech;
import android.view.View;
import android.view.WindowManager;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import androidx.appcompat.app.AppCompatActivity;

import org.apache.commons.lang3.StringUtils;

import java.util.Locale;

public class MainActivity extends AppCompatActivity
{
   public static int i=0;
    protected Button sendButton;
    protected EditText questionText;
    protected TextView chatWindow;
    protected TextToSpeech textToSpeech;
    protected String[] mess=new String[]{};
    boolean fl=false;
    String opt ="";
    String sym="> ";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_main);
        sendButton = findViewById(R.id.sendButton);
        questionText = findViewById(R.id.questionField);
        chatWindow = findViewById(R.id.chatWindow);
        textToSpeech = new TextToSpeech(getApplicationContext(), new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int i) {
                if (i != TextToSpeech.ERROR) {
                    textToSpeech.setPitch(0.6f);
                    textToSpeech.setLanguage(new Locale("ru"));
                }

            }
        });

        sendButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onSend();
            }
        });
        //onSaveInstanceState(savedInstanceState);

        //super.onRestoreInstanceState(savedInstanceState);


    }
    protected void onSend()
    {
        String text = questionText.getText().toString();

        if (!StringUtils.isBlank(text))
        {
            String answer = AI.getAnswer(text);
            if (!AI.is) {
                textToSpeech.speak(answer, TextToSpeech.QUEUE_FLUSH, null, null);
            }
            if (fl)
            {
                opt = "\n";
            }
            chatWindow.append(opt + sym + text + "\n"+sym + answer);
           // mess[i]= String.valueOf(chatWindow);
            fl = true;
            i++;
        }
        //getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
        //questionText.clearFocus();
        hideKeyboard();
        questionText.setText(null);

    }
    protected void hideKeyboard()
    {
        View view = this.getCurrentFocus();
        if (view != null)
        {
            InputMethodManager imm = (InputMethodManager) getSystemService(Context.INPUT_METHOD_SERVICE);
            imm.hideSoftInputFromWindow(view.getWindowToken(), 0);
        }
    }
    @Override
    protected void onSaveInstanceState (Bundle outState){
        super.onSaveInstanceState(outState);
        outState.putStringArray("messageArray", mess);
    }

}