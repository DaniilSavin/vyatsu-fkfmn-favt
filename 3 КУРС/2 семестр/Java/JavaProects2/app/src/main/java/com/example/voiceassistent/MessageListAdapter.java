package com.example.voiceassistent;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;
import androidx.recyclerview.widget.RecyclerView.Adapter;

import java.util.ArrayList;
import java.util.List;

public class MessageListAdapter extends Adapter {
    public List<Message> messageList = new ArrayList<>();
    private static final int ASSISTANT_TYPE=0;
    private static final int USER_TYPE=1;

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = null;
        if (viewType == USER_TYPE) {
            view = LayoutInflater.from(parent.getContext())
                    .inflate(R.layout.user_message,parent,false);

            //создание сообщения от пользователя
        }
        else {
            view = LayoutInflater.from(parent.getContext())
                    .inflate(R.layout.assistant_message,parent,false);
            //создание сообщения от ассистента
        }

        assert view != null;
        return new MessageViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        new MessageViewHolder(holder.itemView).bind(messageList.get(position));

    }

    public int getItemViewType(int index){
        Message message = messageList.get(index);
        if (message.isSend){
            return USER_TYPE;
        }
        else return ASSISTANT_TYPE;
    }


    @Override
    public int getItemCount() {
        return messageList.size();

    }
}
