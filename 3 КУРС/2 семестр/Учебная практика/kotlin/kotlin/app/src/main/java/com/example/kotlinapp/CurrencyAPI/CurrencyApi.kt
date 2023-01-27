package com.example.kotlinapp.CurrencyAPI

import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query


interface CurrencyApi {
    @GET("latest?access_key=c9247f8509de4c72ec5ff1eb57b3ff68")
    fun getCurrentCurrency(@Query("symbols") temp: String?): Call<Currency?>?
}