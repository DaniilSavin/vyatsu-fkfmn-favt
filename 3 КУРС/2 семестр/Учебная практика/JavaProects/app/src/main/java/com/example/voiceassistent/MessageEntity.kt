package com.example.voiceassistent

class MessageEntity {
    var text: String?
    var date: String
    var isSend: Int

    constructor(text: String?, date: String, isSend: Int) {
        this.text = text
        this.date = date
        this.isSend = isSend
    }

    constructor(message: Message) {
        text = message.text
        date = message.date.toString()
        isSend = if (!message.isSend) 0 else 1
    }
}