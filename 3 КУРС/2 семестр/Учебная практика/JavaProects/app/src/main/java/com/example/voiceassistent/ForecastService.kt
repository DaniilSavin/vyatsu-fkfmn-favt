package com.example.voiceassistent

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory


object ForecastService {
    val getApi: ForecastAPI
        get() {
            val retrofit = Retrofit.Builder()
                .baseUrl("http://api.weatherstack.com")
                .addConverterFactory(GsonConverterFactory.create())
                .build()
            return retrofit.create(ForecastAPI::class.java)
        }
}