package com.example.voiceassistent;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.app.AppCompatDelegate;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import android.annotation.SuppressLint;
import android.content.ContentValues;
import android.content.SharedPreferences;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Bitmap;
import android.os.Build;
import android.os.Bundle;
import android.speech.tts.TextToSpeech;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import org.apache.commons.lang3.StringUtils;

import java.io.IOException;
import java.net.URL;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Locale;
import java.util.concurrent.atomic.AtomicReference;

public class MainActivity extends AppCompatActivity
{
    protected Button sendButton;
    protected EditText questionText;
    protected TextToSpeech textToSpeech;
    protected RecyclerView chatMessageList;
    protected MessageListAdapter messageListAdapter;
    protected SharedPreferences sPref;
    public static final String APP_PREFERENCES = "mysettings";
    public URL url;
    private boolean isLight = true;
    private boolean isSpeach = false;
    private String THEME = "THEME";
    DBHelper dBHelper;
    SQLiteDatabase database;
    Cursor cursor;

  //  @RequiresApi(api = Build.VERSION_CODES.JELLY_BEAN_MR1)
    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        sPref = getSharedPreferences(APP_PREFERENCES,MODE_PRIVATE);
        isLight = sPref.getBoolean(THEME, true);
        if (!isLight)
            getDelegate().setLocalNightMode(AppCompatDelegate.MODE_NIGHT_YES);
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        sendButton = findViewById(R.id.sendButton);
        questionText = findViewById(R.id.questionField);
        chatMessageList = findViewById(R.id.chatMessageList);
        messageListAdapter = new MessageListAdapter();
        chatMessageList.setLayoutManager(new LinearLayoutManager(this));
        chatMessageList.setAdapter(messageListAdapter);
        dBHelper = new DBHelper(this);
        database = dBHelper.getWritableDatabase();

        ArrayList<Message> str;
        if (savedInstanceState != null) {
            str = (ArrayList<Message>) savedInstanceState.getSerializable("key");
            for (int i = 0; i < str.size(); i++)
            {
             messageListAdapter.messageList.add(str.get(i));

            }
            messageListAdapter.notifyDataSetChanged();
        }
        if(savedInstanceState == null)
        {
            Cursor cursor = database.query(dBHelper.TABLE_MESSAGES, null, null, null, null, null, null);
            if (cursor.moveToFirst()){
                int messageIndex = cursor.getColumnIndex(dBHelper.FIELD_MESSAGE);
                int dateIndex = cursor.getColumnIndex(dBHelper.FIELD_DATE);
                int sendIndex = cursor.getColumnIndex(dBHelper.FIELD_SEND);
                do{
                    MessageEntity entity = new MessageEntity(cursor.getString(messageIndex),
                            cursor.getString(dateIndex), cursor.getInt(sendIndex));
                    Message message = new Message(entity);
                    if (message.date == null || message.text == null || message.isSend == null){
                        //
                    }
                    else {
                        messageListAdapter.messageList.add(message);
                    }
                }while (cursor.moveToNext());
            }
            cursor.close();
        }
        textToSpeech = new TextToSpeech(getApplicationContext(), new TextToSpeech.OnInitListener()
        {
            @Override
            public void onInit(int i)
            {
                if (isSpeach) {
                    if (i != TextToSpeech.ERROR) {
                        textToSpeech.setLanguage(new Locale("ru"));
                    }
                }
            }
        });
        sendButton.setOnClickListener(new View.OnClickListener() {
            @SuppressLint("NewApi")
            @RequiresApi(api = Build.VERSION_CODES.LOLLIPOP)
            @Override
            public void onClick(View view) {
                try {
                    onSend();
                } catch (ParseException | IOException e) {
                    e.printStackTrace();
                }
            }
        });
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        ArrayList<Message> s = (ArrayList<Message>) messageListAdapter.messageList;
        //outState.putString("key", s);
        outState.putSerializable("key",  s);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    protected void onDestroy() {
        if (textToSpeech != null){
            textToSpeech.stop();
            textToSpeech.shutdown();
        }
        database.close();
        dBHelper.close();
        super.onDestroy();

    }

    @Override
    protected void onStop() {
        SharedPreferences.Editor editor = sPref.edit();
        editor.putBoolean(THEME, isLight);
        editor.apply();
        database.delete(dBHelper.TABLE_MESSAGES, null, null);
        for (int i = 0; i < messageListAdapter.messageList.size(); ++i)
        {
            MessageEntity entity = new MessageEntity(messageListAdapter.messageList.get(i));
            ContentValues contentValues = new ContentValues();
            contentValues.put(DBHelper.FIELD_MESSAGE, entity.text);
            contentValues.put(DBHelper.FIELD_SEND, entity.isSend);
            contentValues.put(DBHelper.FIELD_DATE, entity.date);
            database.insert(dBHelper.TABLE_MESSAGES,null,contentValues);
        }
        super.onStop();
    }

    @SuppressLint("NonConstantResourceId")
  //  @RequiresApi(api = Build.VERSION_CODES.JELLY_BEAN_MR1)
    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch (item.getItemId()) {
            case R.id.day_settings:
                getDelegate().setLocalNightMode(AppCompatDelegate.MODE_NIGHT_NO);
                isLight = true;
                break;
            case R.id.night_settings:
                getDelegate().setLocalNightMode(AppCompatDelegate.MODE_NIGHT_YES);
                isLight = false;
                break;
            case R.id.clear_chat:
                messageListAdapter.messageList.clear();
                super.recreate();
                break;
            default:
                break;
        }
        return super.onOptionsItemSelected(item);
    }

   /* public Bitmap getBitmapFromURL(String src) {
        try {
            java.net.URL url = new java.net.URL(src);
            HttpURLConnection connection = (HttpURLConnection) url
                    .openConnection();
            connection.setDoInput(true);
            connection.connect();
            InputStream input = connection.getInputStream();
            BitmapFactory.Options opt = new BitmapFactory.Options();
            Bitmap myBitmap = BitmapFactory.decodeStream(input);
            return myBitmap;
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }*/

    Bitmap image;
    @SuppressLint({"NewApi", "StaticFieldLeak"})
   // @RequiresApi(api = Build.VERSION_CODES.LOLLIPOP)
    protected void onSend() throws ParseException, IOException {
        String text = questionText.getText().toString();
        if (!StringUtils.isBlank(text))
            {
        AI.getAnswer(text, s -> {
           // Log.i("WEATHER", "MA: "+s);
            messageListAdapter.messageList.add(new Message(text, true));
           /* if (s.contains("https"))
            {
                new AsyncTask<String, Integer, Void>()
                {
                    @SuppressLint("StaticFieldLeak")
                    protected Void doInBackground(String... strings)
                    {
                        image = getBitmapFromURL(s);
                        return null;
                    }
                    @Override
                    protected void onPostExecute(Void aVoid)
                    {
                        super.onPostExecute(aVoid);
                    }
                }.execute();
                messageListAdapter.messageList.add(new Message(image, false));

                TextView txt = findViewById(R.id.messageTextView);
                txt.setHeight(100);
                txt.setWidth(100);
                txt.setBackground(new BitmapDrawable(getResources(), image));

            }
            else {*/
            if (isSpeach) {
                textToSpeech.speak(s, TextToSpeech.QUEUE_FLUSH, null, null);
            }
                messageListAdapter.messageList.add(new Message(s, false));

           // }
            messageListAdapter.notifyDataSetChanged();
            chatMessageList.scrollToPosition(messageListAdapter.messageList.size()-1);
            questionText.setText("");

        });

    }
}
}