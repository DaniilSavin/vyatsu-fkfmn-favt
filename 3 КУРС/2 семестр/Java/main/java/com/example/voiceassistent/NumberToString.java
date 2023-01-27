package com.example.voiceassistent;

import android.util.Log;


import androidx.core.util.Consumer;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class NumberToString {
    public static void getNumber(String number, final Consumer<String> callback){
        NumberApi api = NumberService.getApi();
        Call<Number> call = api.getNumber(number);
        call.enqueue(new Callback<Number>() {
            @Override
            public void onResponse(Call<Number> call, Response<Number> response) {
                Number result = response.body();
                if (result!=null) {
                    if (result.number!= null)
                        callback.accept(result.number);
                    else
                    callback.accept("Не могу перевести result.str");
                }
                else callback.accept("Не могу перевести result");
            }
            @Override
            public void onFailure(Call<Number> call, Throwable t) {
                Log.w("NUMBER",t.getMessage());
                callback.accept("Не могу перевести failure");
            }
        });
    }

}
