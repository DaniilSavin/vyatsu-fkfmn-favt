package com.example.kotlinapp.CurrencyAPI

import com.google.gson.annotations.Expose
import com.google.gson.annotations.SerializedName
import java.io.Serializable


class Currency : Serializable {
    @SerializedName("rates")
    @Expose
    var rates: Currency2? = null

    inner class Currency2 {
        @SerializedName("RUB")
        @Expose
        var RUB: Double? = null

        @SerializedName("USD")
        @Expose
        var USD: Double? = null
    }
}