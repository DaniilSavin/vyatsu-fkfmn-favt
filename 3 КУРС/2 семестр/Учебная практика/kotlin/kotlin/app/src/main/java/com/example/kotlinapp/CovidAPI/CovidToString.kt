package com.example.kotlinapp.CovidAPI

import android.os.Build
import androidx.annotation.RequiresApi
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.util.function.Consumer


object CovidToString {
    @RequiresApi(api = Build.VERSION_CODES.N)
    var result2: Covid? = null
    var answer = ""
    @RequiresApi(api = Build.VERSION_CODES.N)
    fun getCovidString(country: String?, callback: Consumer<String?>) {
        val api2: CovidApi = CovidService.apiCovid
        val call = api2.getCurrentCountry(country)
        call!!.enqueue(object : Callback<Covid?> {
            override fun onResponse(call: Call<Covid?>, response: Response<Covid?>) {
                result2 = response.body()
                answer += """
                    Подтвержденные случаи: ${result2!!.All!!.confirmed.toString()}
                    Количество смертей: ${result2!!.All!!.deaths.toString()}
                    Количество выздоровленных: ${result2!!.All!!.recovered}
                    """.trimIndent()
                callback.accept(answer)
                answer = ""
            }

            override fun onFailure(call: Call<Covid?>, t: Throwable) {
                callback.accept("Не могу получить данные")
            }
        })
    }
}