package com.example.voiceassistent;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.io.Serializable;
import java.util.List;

public class Forecast implements Serializable {

    @SerializedName("current")
    @Expose
    public Weather current;

    public class Weather{
        @SerializedName("temperature")
        @Expose
        public Integer temperature;

        @SerializedName("weather_descriptions")
        @Expose
        public List<String> weather_descriptions;
    }
}

