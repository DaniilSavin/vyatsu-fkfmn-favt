package com.example.voiceassistent

import android.os.Build
import android.util.Log
import androidx.annotation.RequiresApi
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.util.function.Consumer

object ForecastToString {
    var result: Forecast? = null
    var answer: String? = ""

    fun getForecast(city: String?, callback: Consumer<String?>) {
        val api: ForecastAPI = ForecastService.getApi
        val call: Call<Forecast?>? = api.getCurrentWeather(city)
        call!!.enqueue(object : Callback<Forecast?> {
            override fun onResponse(
                call: Call<Forecast?>?,
                response: Response<Forecast?>?
            ) {
                result = response!!.body()
                if (result != null) {
                    answer =
                        "сейчас где-то " + result!!.current!!.temperature.toString() + degrees(
                            result!!.current!!.temperature!!
                        ).toString() + " и " + result!!.current!!.weather_descriptions!![0]
                    Log.i("WEATHER", "ForecastToString: $answer")
                    callback!!.accept(answer!!)
                } else callback!!.accept("Не могу узнать погоду")
                Log.i("WEATHER", "ForecastToString: " + "Не могу узнать погоду")
            }

            override fun onFailure(
                call: Call<Forecast?>?,
                t: Throwable?
            ) {
                Log.w("WEATHER", t!!.message!!)
            }
        })
    }

    private fun degrees(x: Int): String? {
        var x = x
        x = Math.abs(x)
        return if (x % 10 == 1 && x != 11 && x % 100 != 11) " градус"
        else
            if (x % 10 == 2 && x != 12 && x % 100 != 12 || x % 10 == 3 && x != 13 && x % 100 != 13
                || x % 10 == 4 && x != 14 && x % 100 != 14
            ) " градуса"
            else " градусов"
    }
}