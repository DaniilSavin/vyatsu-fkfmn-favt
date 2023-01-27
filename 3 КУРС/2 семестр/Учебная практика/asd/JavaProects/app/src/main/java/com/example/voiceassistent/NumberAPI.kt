package com.example.voiceassistent

import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query

interface NumberAPI {
    @GET("/json/convert/num2str")
    fun getNumber(@Query("num") number: String?): Call<Number?>?
}