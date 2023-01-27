package com.example.kotlinapp.NumberConversionAPI

import com.example.kotlinapp.NumberConversionAPI.Number
import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query


interface NumbersAPI {
    @GET("/json/convert/num2str")
    fun getCurrentNumber(@Query("num") number: Int?): Call<Number?>?
}
