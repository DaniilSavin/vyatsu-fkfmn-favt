package com.example.voiceassistent;

import java.util.Date;

public class Message {
    public String text;
    public Date date;
    public Boolean isSend;

    public Message (String text, Boolean isSend)
    {
        this.date = new Date();
        this.text=text;
        this.isSend=isSend;
    }



}
