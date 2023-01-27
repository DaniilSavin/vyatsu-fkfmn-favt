package com.example.voiceassistent

import retrofit2.Call
import retrofit2.http.GET

interface AdviceAPI {
    @get:GET("/advice")
    val advice: Call<Advice?>?
}