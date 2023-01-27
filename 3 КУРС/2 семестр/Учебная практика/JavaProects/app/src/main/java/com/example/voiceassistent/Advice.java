package com.example.voiceassistent;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;
import java.io.Serializable;
import java.util.List;

public class Advice implements Serializable {

    @SerializedName("slip")
    @Expose
    public adv slip;

    public class adv{
        @SerializedName("advice")
        @Expose
        public String advice;

    }
}
