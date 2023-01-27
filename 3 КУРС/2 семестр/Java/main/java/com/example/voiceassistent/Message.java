package com.example.voiceassistent;

import java.util.Date;

public class Message {
    public String text;
    public Date date;
    public Boolean isSend;

    public Message(String text, Boolean isSend) {
        this.text = text;
        this.isSend = isSend;
        this.date = new Date();
    }
    public Message(String text, Boolean isSend, String dateString) {
        this.text = text;
        this.isSend = isSend;
        Date date = new Date(Long.parseLong(dateString));
        this.date = date;
    }
}
