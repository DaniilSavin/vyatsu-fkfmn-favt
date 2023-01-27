package com.example.kotlinapp.NumberConversionAPI

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory


object NumberService {
    val apiNum: NumbersAPI
        get() {
            val retrofit = Retrofit.Builder()
                .baseUrl("https://htmlweb.ru")
                .addConverterFactory(GsonConverterFactory.create())
                .build()
            return retrofit.create(NumbersAPI::class.java)
        }
}