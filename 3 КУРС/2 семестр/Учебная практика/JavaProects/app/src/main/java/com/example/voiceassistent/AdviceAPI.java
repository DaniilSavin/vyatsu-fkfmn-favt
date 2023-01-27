package com.example.voiceassistent;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;

public interface AdviceAPI {
    @GET("/advice")
    Call<Advice> getAdvice();
}
