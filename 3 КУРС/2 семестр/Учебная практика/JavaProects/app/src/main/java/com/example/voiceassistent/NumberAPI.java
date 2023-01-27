package com.example.voiceassistent;
import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Query;

public interface NumberAPI {
    @GET("/json/convert/num2str")
    Call<Number> getNumber(@Query("num") String number);
}
