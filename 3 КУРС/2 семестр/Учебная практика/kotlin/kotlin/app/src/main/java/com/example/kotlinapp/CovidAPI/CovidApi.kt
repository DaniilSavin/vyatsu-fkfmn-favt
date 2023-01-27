package com.example.kotlinapp.CovidAPI


import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query


interface CovidApi {
    @GET("/v1/cases")
    fun getCurrentCountry(@Query("country") country: String?): Call<Covid?>?
}