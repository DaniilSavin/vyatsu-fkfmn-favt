package com.example.voiceassistent;

import android.util.Log;


import androidx.core.util.Consumer;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ForecastToString {
    public static void getForecast(String city, final Consumer<String> callback){
        ForecastApi api = ForecastService.getApi();
        Call<Forecast> call = api.getCurrentWeather(city);
        call.enqueue(new Callback<Forecast>() {
            @Override
            public void onResponse(Call<Forecast> call, Response<Forecast> response) {
                Forecast result = response.body();
                if (result!=null) {
                    int temp=result.current.temperature;
                    String end="kjdns";
                    if (Math.abs(temp)>=11 && Math.abs(temp)<=19) end="градусов";
                    else if (Math.abs(temp)%1==0) end="градус";
                    else if (Math.abs(temp)%10>=2 && Math.abs(temp)%10<=4) end="градуса";
                    else if (Math.abs(temp)%10==0 || Math.abs(temp)%10>=5 && Math.abs(temp)%10<=9) end="градусов";
                    String answer = "сейчас где-то " + result.current.temperature + " " + end + " и " + result.current.weather_descriptions.get(0);
                    callback.accept(answer);
                }
                else callback.accept("Не могу узнать погоду");
            }

            @Override
            public void onFailure(Call<Forecast> call, Throwable t) {
                Log.w("WEATHER",t.getMessage());
                callback.accept("Не могу узнать погоду");
            }
        });
    }

}
