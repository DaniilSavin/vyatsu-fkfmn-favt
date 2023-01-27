package com.example.voiceassistent;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;

public interface ForecastAPI {
    @GET("/current?access_key=f853c8a905f351f18c211114ddac44f1")
    Call<Forecast> getCurrentWeather(@Query("query") String city);
}

