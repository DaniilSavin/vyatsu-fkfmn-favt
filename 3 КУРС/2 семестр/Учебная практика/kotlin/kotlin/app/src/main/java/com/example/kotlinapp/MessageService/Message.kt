package com.example.kotlinapp.MessageService

import com.example.kotlinapp.Database.MessageEntity
import java.util.*


class Message {
    public var text: String? = null
    public var date: Date? = null
    public var isSend: Boolean
    public var str: ArrayList<String>? = null
    public var message: Message? = null

    constructor(text: String?, isSend: Boolean) {
        this.text = text
        this.isSend = isSend
        date = Date()
    }

    constructor(str: ArrayList<String>?, isSend: Boolean) {
        this.str = str
        this.isSend = isSend
        date = Date()
    }

    /*  public Message(Message message, boolean isSend) {
        this.message = message;
        this.isSend = isSend;
        this.date = new Date();
    }*/
    constructor(entity: MessageEntity) {
        text = entity.text
        if (entity.date == null) date = null
        else date = Date(entity.date)
        isSend = entity.isSend !== 0

    }
}