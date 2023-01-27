package com.example.voiceassistent;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.util.Consumer;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.os.Bundle;
import android.os.Parcelable;
import android.speech.tts.TextToSpeech;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.content.Context;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

public class MainActivity extends AppCompatActivity {

    protected Button sendButton;
    protected EditText questionText;
    protected TextView chatWindow;
    TextToSpeech textToSpeech;
    protected RecyclerView chatMessageList;
    protected MessageListAdapter messageListAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        setContentView(R.layout.activity_main);
        messageListAdapter = new MessageListAdapter();
        chatMessageList=findViewById(R.id.chatMessageList);
        chatMessageList.setLayoutManager(new LinearLayoutManager(this));
        chatMessageList.setAdapter(messageListAdapter);
        super.onCreate(savedInstanceState);
        sendButton = findViewById(R.id.sendButton);
        questionText = findViewById(R.id.questionField);
        textToSpeech = new TextToSpeech(this, new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                if (status == TextToSpeech.SUCCESS) {
                    textToSpeech.setLanguage(new Locale("ru"));
                }
                else chatWindow.append("Can't text to speech");
            }
        });
        sendButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onSend();
            }
        });
    }
    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        String[] messageList= new String[messageListAdapter.messageList.size()];
        String [] dateList =  new String[messageListAdapter.messageList.size()];
        boolean[] sendList = new boolean[messageListAdapter.messageList.size()];
        for (int i=0; i< messageList.length;++i){
            messageList[i] = messageListAdapter.messageList.get(i).text;
            sendList[i] = messageListAdapter.messageList.get(i).isSend;
            dateList[i] = (String.valueOf(messageListAdapter.messageList.get(i).date.getTime()));
        }
        outState.putStringArray("messageList",messageList);
        outState.putStringArray("dateList",dateList);
        outState.putBooleanArray("sendList", sendList);

    }
    @Override
    protected void onRestoreInstanceState(@NonNull Bundle savedInstanceState) {
        super.onRestoreInstanceState(savedInstanceState);
        String[] tempMessage = savedInstanceState.getStringArray("messageList");
        String[] tempDate = savedInstanceState.getStringArray("dateList");
        boolean[] tempSend = savedInstanceState.getBooleanArray("sendList");
        for (int i=0; i<tempMessage.length; ++i) {
            messageListAdapter.messageList.add(new Message(tempMessage[i], tempSend[i], tempDate[i]));
        }
    }
    protected void onSend(){
        String text = questionText.getText().toString();
        AI_MAP temp = new AI_MAP();
        temp.get(text, s -> {
            messageListAdapter.messageList.add(new Message(text, true));
            messageListAdapter.messageList.add(new Message(s, false));
            messageListAdapter.notifyDataSetChanged();
            chatMessageList.scrollToPosition(messageListAdapter.messageList.size()-1);
            textToSpeech.speak(s, TextToSpeech.QUEUE_FLUSH,null, null );
            questionText.setText("");
        });

    }

}