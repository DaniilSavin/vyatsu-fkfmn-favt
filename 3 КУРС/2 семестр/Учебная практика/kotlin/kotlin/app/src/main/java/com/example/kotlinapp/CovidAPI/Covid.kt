package com.example.kotlinapp.CovidAPI

import com.google.gson.annotations.Expose
import com.google.gson.annotations.SerializedName
import java.io.Serializable


class Covid : Serializable {
    @SerializedName("All")
    @Expose
    var All: Covid2? = null

    inner class Covid2 {
        @SerializedName("confirmed")
        @Expose
        var confirmed: Int? = null

        @SerializedName("deaths")
        @Expose
        var deaths: Int? = null

        @SerializedName("recovered")
        @Expose
        var recovered: Int? = null
    }
}