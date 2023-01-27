package com.example.kotlinapp.NumberConversionAPI

import android.os.Build
import androidx.annotation.RequiresApi
import com.example.kotlinapp.WeatherAPI.Forecast
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.util.function.Consumer


object NumberToString {

    var result: Forecast? = null
    var result2: Number? = null
    var answer = ""
    var answer2 = ""
    var URL: String? = null
    var temp = 0


    fun getNumString(number: Int?, callback: Consumer<String?>) {
        val api2: NumbersAPI = NumberService.apiNum
        val call2: Call<Number?>? = api2.getCurrentNumber(number)
        call2!!.enqueue(object : Callback<Number?> {
            override fun onResponse(
                call: Call<Number?>,
                response: Response<Number?>
            ) {
                result2 = response.body()
                answer += result2!!.str
                answer = answer.replace(" рублей 00 копеек", "")
                answer = answer.replace(" рубля 00 копеек", "")
                answer = answer.replace(" рубль 00 копеек", "")
                callback.accept(answer)
                answer = ""
            }

            override fun onFailure(
                call: Call<Number?>,
                t: Throwable
            ) {
                callback.accept("Не могу перевести число")
            }
        })
    }
}