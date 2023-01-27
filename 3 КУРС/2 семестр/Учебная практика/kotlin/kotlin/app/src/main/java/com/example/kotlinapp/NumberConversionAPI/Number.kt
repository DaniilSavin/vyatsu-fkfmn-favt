package com.example.kotlinapp.NumberConversionAPI

import com.google.gson.annotations.Expose
import com.google.gson.annotations.SerializedName
import java.io.Serializable


class Number : Serializable {
    @SerializedName("str")
    @Expose
    var str: String? = null
}