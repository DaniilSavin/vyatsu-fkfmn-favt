package com.example.voiceassistent

import android.content.Context
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper

class DBHelper(context: Context?) :
    SQLiteOpenHelper(
        context,
        DATABASE_NAME,
        null,
        DATABASE_VERSION
    ) {
    override fun onCreate(db: SQLiteDatabase) {
        db.execSQL(
            "create table " + TABLE_MESSAGES + "(" +
                    FIELD_ID + " integer primary key," +
                    FIELD_MESSAGE + " text," +
                    FIELD_SEND + " integer," +
                    FIELD_DATE + " text" + ")"
        )
    }

    override fun onUpgrade(
        db: SQLiteDatabase,
        oldVersion: Int,
        newVersion: Int
    ) {
        db.execSQL("drop table if exists $TABLE_MESSAGES")
        onCreate(db)
    }

    companion object {
        const val DATABASE_VERSION = 1
        const val DATABASE_NAME = "messageDb"
        const val TABLE_MESSAGES = "messages"
        const val FIELD_ID = "id"
        const val FIELD_MESSAGE = "message"
        const val FIELD_SEND = "send"
        const val FIELD_DATE = "date"
    }
}