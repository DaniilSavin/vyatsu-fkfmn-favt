package com.example.voiceassistent;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.io.Serializable;
import java.util.List;

public class Number implements Serializable {

    @SerializedName("str")
    @Expose
    public String number;

}
//https://htmlweb.ru/json/convert/num2str?num=34
