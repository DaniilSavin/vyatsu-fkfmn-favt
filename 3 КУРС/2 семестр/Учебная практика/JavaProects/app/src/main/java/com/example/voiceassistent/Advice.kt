package com.example.voiceassistent

import com.google.gson.annotations.Expose
import com.google.gson.annotations.SerializedName
import java.io.Serializable

class Advice : Serializable {
    @JvmField
    @SerializedName("slip")
    @Expose
    var slip: adv? = null

    inner class adv {
        @JvmField
        @SerializedName("advice")
        @Expose
        var advice: String? = null
    }
}