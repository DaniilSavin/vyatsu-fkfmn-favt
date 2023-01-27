package com.example.voiceassistent

import com.google.gson.annotations.SerializedName
import com.google.gson.annotations.Expose
import java.io.Serializable

class Number : Serializable {
    @SerializedName("str")
    @Expose
    var number: String? = null
}