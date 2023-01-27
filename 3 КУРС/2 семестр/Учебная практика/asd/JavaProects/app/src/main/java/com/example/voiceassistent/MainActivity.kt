package com.example.voiceassistent

import android.annotation.SuppressLint
import android.content.ContentValues
import android.content.Context
import android.content.SharedPreferences
import android.database.Cursor
import android.database.sqlite.SQLiteDatabase
import android.graphics.Bitmap
import android.os.Bundle
import android.speech.tts.TextToSpeech
import android.view.Menu
import android.view.MenuItem
import android.view.View
import android.widget.Button
import android.widget.EditText
import androidx.appcompat.app.AppCompatActivity
import androidx.appcompat.app.AppCompatDelegate
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import org.apache.commons.lang3.StringUtils
import java.io.IOException
import java.net.URL
import java.text.ParseException
import java.util.*
import com.example.voiceassistent.DBHelper
import com.example.voiceassistent.DBHelper.Companion.FIELD_DATE
import com.example.voiceassistent.DBHelper.Companion.FIELD_MESSAGE
import com.example.voiceassistent.DBHelper.Companion.FIELD_SEND
import com.example.voiceassistent.DBHelper.Companion.TABLE_MESSAGES
import com.example.voiceassistent.MessageEntity
import com.example.voiceassistent.Message
import com.example.voiceassistent.MessageListAdapter

import java.util.function.Consumer

class MainActivity : AppCompatActivity() {
    protected var sendButton: Button? = null
    protected var questionText: EditText? = null
    protected var textToSpeech: TextToSpeech? = null
    protected var chatMessageList: RecyclerView? = null
    protected var messageListAdapter: MessageListAdapter? = null
    protected var sPref: SharedPreferences? = null
    var url: URL? = null
    private var isLight = true
    private val isSpeach = false
    private val THEME = "THEME"
    var dBHelper: DBHelper? = null
    lateinit var database: SQLiteDatabase
    var cursor: Cursor? = null

    //  @RequiresApi(api = Build.VERSION_CODES.JELLY_BEAN_MR1)
    override fun onCreate(savedInstanceState: Bundle?) {
        sPref = getSharedPreferences(
            APP_PREFERENCES,
            Context.MODE_PRIVATE
        )
        isLight = sPref?.getBoolean(THEME, true)!!
        if (!isLight) delegate.localNightMode = AppCompatDelegate.MODE_NIGHT_YES
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        sendButton = findViewById(R.id.sendButton)
        questionText = findViewById(R.id.questionField)
        chatMessageList = findViewById(R.id.chatMessageList)
        messageListAdapter = MessageListAdapter()

        chatMessageList?.layoutManager = LinearLayoutManager(this)
        chatMessageList?.adapter = messageListAdapter

        dBHelper = DBHelper(this)
        database = dBHelper!!.writableDatabase
        val str: ArrayList<Message>?
        if (savedInstanceState != null) {
            str = savedInstanceState.getSerializable("key") as ArrayList<Message>?
            for (i in str!!.indices) {
                messageListAdapter!!.messageList.add(str[i])
            }
            messageListAdapter!!.notifyDataSetChanged()
        }
        if (savedInstanceState == null) {
            val cursor = database.query(DBHelper.TABLE_MESSAGES, null, null, null, null, null, null)
            if (cursor.moveToFirst()) {
                val messageIndex = cursor.getColumnIndex(DBHelper.FIELD_MESSAGE)
                val dateIndex = cursor.getColumnIndex(DBHelper.FIELD_DATE)
                val sendIndex = cursor.getColumnIndex(DBHelper.FIELD_SEND)
                do {
                    val entity = MessageEntity(cursor.getString(messageIndex),
                            cursor.getString(dateIndex), cursor.getInt(sendIndex))
                    val message = Message(entity)
                    if (message.date == null || message.text == null || message.isSend == null) {
                        //
                    } else {
                        messageListAdapter!!.messageList.add(message)
                    }
                } while (cursor.moveToNext())
            }
            cursor.close()
        }
        textToSpeech = TextToSpeech(applicationContext) { i ->
            if (isSpeach) {
                if (i != TextToSpeech.ERROR) {
                    textToSpeech!!.language = Locale("ru")
                }
            }
        }
        sendButton?.setOnClickListener(View.OnClickListener {
            try {
                onSend()
            } catch (e: ParseException) {
                e.printStackTrace()
            } catch (e: IOException) {
                e.printStackTrace()
            }
        })
    }

    override fun onSaveInstanceState(outState: Bundle) {
        super.onSaveInstanceState(outState)
        val s = messageListAdapter!!.messageList as ArrayList<Message>
        outState.putSerializable("key", s)
    }

    override fun onCreateOptionsMenu(menu: Menu): Boolean {
        menuInflater.inflate(R.menu.menu_main, menu)
        return super.onCreateOptionsMenu(menu)
    }

    override fun onDestroy() {
        if (textToSpeech != null) {
            textToSpeech!!.stop()
            textToSpeech!!.shutdown()
        }
        database!!.close()
        dBHelper!!.close()
        super.onDestroy()
    }

    override fun onStop() {
        val editor = sPref!!.edit()
        editor.putBoolean(THEME, isLight)
        editor.apply()
        database!!.delete(DBHelper.TABLE_MESSAGES, null, null)
        for (i in messageListAdapter!!.messageList.indices) {
            val entity = MessageEntity(messageListAdapter!!.messageList[i])
            val contentValues = ContentValues()
            contentValues.put(DBHelper.FIELD_MESSAGE, entity.text)
            contentValues.put(DBHelper.FIELD_SEND, entity.isSend)
            contentValues.put(DBHelper.FIELD_DATE, entity.date)
            database!!.insert(DBHelper.TABLE_MESSAGES, null, contentValues)
        }
        super.onStop()
    }

    @SuppressLint("NonConstantResourceId") //  @RequiresApi(api = Build.VERSION_CODES.JELLY_BEAN_MR1)
    override fun onOptionsItemSelected(item: MenuItem): Boolean {
        when (item.itemId) {
            R.id.day_settings -> {
                delegate.localNightMode = AppCompatDelegate.MODE_NIGHT_NO
                isLight = true
            }
            R.id.night_settings -> {
                delegate.localNightMode = AppCompatDelegate.MODE_NIGHT_YES
                isLight = false
            }
            R.id.clear_chat -> {
                messageListAdapter!!.messageList.clear()
                super.recreate()
            }
            else -> {
            }
        }
        return super.onOptionsItemSelected(item)
    }


    @SuppressLint("NewApi", "StaticFieldLeak") // @RequiresApi(api = Build.VERSION_CODES.LOLLIPOP)
    @Throws(ParseException::class, IOException::class)
    protected fun onSend() {
        val text = questionText!!.text.toString()
        if (!StringUtils.isBlank(text)) {
            AI.getAnswer(text) { s: String? ->
                messageListAdapter!!.messageList.add(Message(text, true))
               if (isSpeach) {
                textToSpeech!!.speak(s, TextToSpeech.QUEUE_FLUSH, null, null)
            }
                messageListAdapter!!.messageList.add(Message(s, false))

                // }
                messageListAdapter!!.notifyDataSetChanged()
                chatMessageList!!.scrollToPosition(messageListAdapter!!.messageList.size - 1)
                questionText!!.setText("")
            }
        }
    }

    companion object {
        const val APP_PREFERENCES = "mysettings"
    }
}


