package com.example.voiceassistent;

import android.util.Log;


import androidx.core.util.Consumer;

import org.jetbrains.annotations.NotNull;

import java.util.Objects;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class NumberToString {
    public static void getNumber(String number, final Consumer<String> callback){
        NumberAPI api = NumberService.getApi();
        Call<Number> call = api.getNumber(number);
        call.enqueue(new Callback<Number>() {
            @Override
            public void onResponse(@NotNull Call<Number> call, @NotNull Response<Number> response) {
                Number result = response.body();
                if (result!=null) {
                    if (result.number!= null) {
                        String str=result.number;
                        StringBuilder newStr= new StringBuilder();
                        String []strr=str.split(" ");
                        for (int i=0; i<strr.length; i++)
                        {
                            if (!strr[i].contains("руб"))
                            {
                                newStr.append(strr[i]).append(" ");
                            }
                            else {
                                if (strr[i].contains("руб")) {
                                    i = str.length() - 1;
                                }
                            }
                        }
                        callback.accept(String.valueOf(newStr));
                    }
                    else
                        callback.accept("Не могу перевести result.str");
                }
                else callback.accept("Не могу перевести result");
            }
            @Override
            public void onFailure(@NotNull Call<Number> call, @NotNull Throwable t) {
                Log.w("NUMBER", Objects.requireNonNull(t.getMessage()));
                callback.accept("Не могу перевести failure");
            }
        });
    }
}
