package com.example.voiceassistent

import android.util.Log
import java.util.function.Consumer
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.util.*

object NumberToString {
    fun getNumber(number: String?, callback: Consumer<String?>) {
        val api: NumberAPI = NumberService.api
        val call: Call<Number?>? = api.getNumber(number)
        call!!.enqueue(object : Callback<Number?> {
            override fun onResponse(call: Call<Number?>, response: Response<Number?>) {
                val result = response.body()
                if (result != null) {
                    if (result.number != null) {
                        val str = result.number
                        val newStr = StringBuilder()
                        val strr = str!!.split(" ").toTypedArray()
                        var i = 0
                        while (i < strr.size) {
                            if (!strr[i].contains("руб")) {
                                newStr.append(strr[i]).append(" ")
                            } else {
                                if (strr[i].contains("руб")) {
                                    i = str.length - 1
                                }
                            }
                            i++
                        }
                        callback.accept(newStr.toString())
                    } else callback.accept("Не могу перевести result.str")
                } else callback.accept("Не могу перевести result")
            }

            override fun onFailure(call: Call<Number?>, t: Throwable) {
                Log.w("NUMBER", Objects.requireNonNull(t.message))
                callback.accept("Не могу перевести failure")
            }
        })
    }
}