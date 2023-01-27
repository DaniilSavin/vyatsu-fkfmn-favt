package com.example.voiceassistent

import retrofit2.http.GET
import retrofit2.http.Query

interface ForecastAPI {
    @GET("/current?access_key=f853c8a905f351f18c211114ddac44f1")
    open fun getCurrentWeather(@Query("query") city: String?): retrofit2.Call<Forecast?>?
}

//f853c8a905f351f18c211114ddac44f1