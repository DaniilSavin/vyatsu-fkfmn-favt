package com.example.voiceassistent

import com.google.gson.annotations.Expose
import com.google.gson.annotations.SerializedName
import java.io.Serializable

class Forecast : Serializable {
    @SerializedName("current")
    @Expose
    var current: Weather? = null

    inner class Weather {

        @SerializedName("temperature")
        @Expose
        var temperature: Int? = null

        @SerializedName("weather_descriptions")
        @Expose
        var weather_descriptions: List<String>? = null
    }
}