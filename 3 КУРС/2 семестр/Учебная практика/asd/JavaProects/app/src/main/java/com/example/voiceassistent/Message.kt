package com.example.voiceassistent

import android.graphics.Bitmap
import java.util.*

class Message {
    @JvmField
    var text: String? = null
    @JvmField
    var date: Date? = null
    @JvmField
    var isSend: Boolean
    var str: ArrayList<String>? = null
    var message: Message? = null
    var image: Bitmap? = null

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

    constructor(entity: MessageEntity) {
        text = entity.text
        if (entity.date == null) date = null else date = Date(entity.date)
        isSend = entity.isSend != 0
    }

    constructor(image: Bitmap?, isSend: Boolean) {
        this.image = image
        this.isSend = isSend
        date = Date()
    }
}