package com.example.kotlinapp.CurrencyAPI

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory


object CurrencyService {
    val apiCurrency: CurrencyApi
        get() {
            val retrofit = Retrofit.Builder()
                .baseUrl("http://data.fixer.io/api/")
                .addConverterFactory(GsonConverterFactory.create())
                .build()
            return retrofit.create(CurrencyApi::class.java)
        }
}