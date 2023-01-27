package com.example.voiceassistent;

import java.io.IOException;

import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class AdviceService {
    public static AdviceAPI getAPI(){
        Retrofit retrofit=new Retrofit.Builder()
                .baseUrl("https://api.adviceslip.com/")
                .addConverterFactory(GsonConverterFactory.create().create())
                .build();
        return retrofit.create(AdviceAPI.class);

    }
}
