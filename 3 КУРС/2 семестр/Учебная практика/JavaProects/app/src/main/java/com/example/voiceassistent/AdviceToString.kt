package com.example.voiceassistent

import android.util.Log
import androidx.core.util.Consumer
import com.example.voiceassistent.AdviceService.aPI
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import java.util.*

object AdviceToString {
    @JvmStatic
    fun getAdvice(number: String?, callback: Consumer<String?>) {
        val api = aPI
        val call = api.advice
        val str = arrayOf<String?>("-1")
        call!!.enqueue(object : Callback<Advice?> {
            override fun onResponse(call: Call<Advice?>, response: Response<Advice?>) {
                val result = response.body()
                if (result != null) {
                    if (result.slip!!.advice != null) {
                        str[0] = result.slip!!.advice
                        callback.accept(str[0])
                    } else {
                        str[0] = "result.advice=null"
                        callback.accept(str[0])
                    }
                    //callback.accept(String.valueOf(newStr));
                } else {
                    str[0] = "result = null"
                    callback.accept(str[0])
                }
            }

            override fun onFailure(call: Call<Advice?>, t: Throwable) {
                Log.w("ADVICE", Objects.requireNonNull(t.message))
                str[0] = "Не могу перевести failure"
            }
        })
    }
}