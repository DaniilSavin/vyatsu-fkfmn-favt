package com.example.voiceassistent;

import android.util.Log;

import androidx.core.util.Consumer;

import org.jetbrains.annotations.NotNull;

import java.util.Objects;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AdviceToString {

    public static void getAdvice(String number, final Consumer<String> callback){
        AdviceAPI api = AdviceService.getAPI();
        Call<Advice> call = api.getAdvice();
        String[] str = {"-1"};
        call.enqueue(new Callback<Advice>() {
            @Override
            public void onResponse(@NotNull Call<Advice> call, @NotNull Response<Advice> response) {
                Advice result = response.body();
                if (result != null) {
                    if (result.slip.advice != null) {
                        str[0] = result.slip.advice;
                        callback.accept(str[0]);

                    } else {
                        str[0] = "result.advice=null";
                        callback.accept(str[0]);
                    }
                    //callback.accept(String.valueOf(newStr));
                } else {
                    str[0]="result = null";
                    callback.accept(str[0]);

                }
            }
            @Override
            public void onFailure(Call<Advice> call, Throwable t) {
                Log.w("ADVICE", Objects.requireNonNull(t.getMessage()));
                str[0]=("Не могу перевести failure");
            }
        });

    }
}
