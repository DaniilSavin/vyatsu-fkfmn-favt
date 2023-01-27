package com.example.kotlinapp.CurrencyAPI

import android.os.Build
import androidx.annotation.RequiresApi
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.util.function.Consumer


object CurrencyToString {
    @RequiresApi(api = Build.VERSION_CODES.N)
    var result2: Currency? = null
    var answer = ""
    @RequiresApi(api = Build.VERSION_CODES.N)
    fun getCurrencyString(callback: Consumer<String?>) {
        val api2: CurrencyApi = CurrencyService.apiCurrency
        val call = api2.getCurrentCurrency("USD,RUB")
        call!!.enqueue(object : Callback<Currency?> {
            override fun onResponse(call: Call<Currency?>, response: Response<Currency?>) {
                result2 = response.body()
                val result2znakaRUB = java.lang.String.format("%.2f", result2!!.rates!!.RUB)
                val temp = result2!!.rates!!.RUB!! / result2!!.rates!!.USD!!
                val result2znakaUSD = String.format("%.2f", temp)
                answer += "Евро: $result2znakaRUB руб.\n"
                answer += "Доллар: $result2znakaUSD руб."
                //answer += "";
                callback.accept(answer)
                answer = ""
            }

            override fun onFailure(call: Call<Currency?>, t: Throwable) {
                callback.accept("Не могу получить данные")
            }
        })
    }
}