package com.example.voiceassistent

import retrofit2.http.GET
import retrofit2.http.Query

interface ForecastAPI {
    @GET("/current?access_key=dd0da7f561d7fb0503171d8014a631ac")
    open fun getCurrentWeather(@Query("query") city: String?): retrofit2.Call<Forecast?>?
}

//f853c8a905f351f18c211114ddac44f1
//dd0da7f561d7fb0503171d8014a631ac