package com.example.voiceassistent;

import android.util.Log;


import androidx.core.util.Consumer;

import org.jetbrains.annotations.NotNull;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class ForecastToString
{
    public static void getForecast(String city, final Consumer<String> callback)
    {
        ForecastAPI api = ForecastService.getApi();
        Call<Forecast> call = api.getCurrentWeather(city);
        call.enqueue(new Callback<Forecast>() {
            @Override
            public void onResponse(@NotNull Call<Forecast> call, @NotNull Response<Forecast> response) {
                Forecast result = response.body();
                if (result!=null) {
                    int temp=result.current.temperature;
                    String answer = "сейчас где-то " + temp + " " + degrees(temp) + " и " + result.current.weather_descriptions.get(0);
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

    private static String degrees ( int x)
    {
        x = Math.abs(x);
        if (x % 10 == 1 && x != 11 && x % 100 != 11)
            return " градус";
        else if ((x % 10 == 2 && x != 12 && x % 100 != 12) || (x % 10 == 3 && x != 13 && x % 100 != 13)
                || (x % 10 == 4 && x != 14 && x % 100 != 14))
            return " градуса";
        else
            return " градусов";
    }


}
