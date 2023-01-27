package com.example.voiceassistent;

import android.graphics.Bitmap;
import java.util.ArrayList;
import java.util.Date;

public class Message {

    public String text;
    public Date date;
    public Boolean isSend;
    public ArrayList <String> str;
    public Message message;
    public Bitmap image;

    public Message(String text, boolean isSend) {

        this.text = text;
        this.isSend = isSend;
        this.date = new Date();
    }

    public Message(ArrayList<String> str, boolean isSend) {
        this.str = str;
        this.isSend = isSend;
        this.date = new Date();
    }


    public Message(MessageEntity entity) {
        this.text = entity.text;
        if (entity.date == null)
            this.date = null;
        else
            this.date = new Date(entity.date);
        this.isSend = entity.isSend != 0;
    }


    public Message(Bitmap image, boolean isSend) {
        this.image = image;
        this.isSend = isSend;
        this.date = new Date();
    }


}
