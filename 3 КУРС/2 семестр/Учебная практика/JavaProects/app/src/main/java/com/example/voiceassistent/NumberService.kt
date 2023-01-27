package com.example.voiceassistent

import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object NumberService {
    val api: NumberAPI
        get() {
            val retrofit = Retrofit.Builder()
                    .baseUrl("https://htmlweb.ru") //Базовая часть адреса
                    .addConverterFactory(GsonConverterFactory.create()) //Конвертер, необходимый для преобразования JSON'а в объекты
                    .build()
            return retrofit.create(NumberAPI::class.java) //Создание объекта, при помощи которого будут выполняться запросы
        }
}