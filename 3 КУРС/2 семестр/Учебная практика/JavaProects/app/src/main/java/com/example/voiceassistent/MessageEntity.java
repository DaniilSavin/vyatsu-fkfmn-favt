package com.example.voiceassistent;

public class MessageEntity {
    public String text;
    public String date;
    public int isSend;

    public MessageEntity(String text, String  date, int isSend){
        this.text = text;
        this.date = date;
        this.isSend = isSend;
    }

    public MessageEntity(Message message){
        this.text = message.text;
        this.date = message.date.toString();
        this.isSend = (!message.isSend) ? 0 : 1;
    }

}
