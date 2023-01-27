package com.example.kotlinapp.CovidAPI

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory


object CovidService {
    val apiCovid: CovidApi
        get() {
            val retrofit = Retrofit.Builder()
                .baseUrl("https://covid-api.mmediagroup.fr")
                .addConverterFactory(GsonConverterFactory.create())
                .build()
            return retrofit.create(CovidApi::class.java)
        }
}