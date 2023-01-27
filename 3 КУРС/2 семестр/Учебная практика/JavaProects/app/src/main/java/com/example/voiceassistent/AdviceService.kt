package com.example.voiceassistent

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object AdviceService {
    @JvmStatic
    val aPI: AdviceAPI
        get() {
            val retrofit = Retrofit.Builder()
                    .baseUrl("https://api.adviceslip.com/")
                    .addConverterFactory(GsonConverterFactory.create())
                    .build()
            return retrofit.create(AdviceAPI::class.java)
        }
}