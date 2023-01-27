package com.example.voiceassistent;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.ViewGroup;
import android.view.View;
import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;
import android.view.LayoutInflater;

public class MessageListAdapter extends RecyclerView.Adapter  {

    public List<Message> messageList = new ArrayList<>();
    private static final int ASSISTANT_TYPE=0;
    private static final int USER_TYPE=1;

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view;
        if (viewType == USER_TYPE) {
            view = LayoutInflater.from(parent.getContext()).inflate(R.layout.user_message,parent,false);
        }
        else {
            view = LayoutInflater.from(parent.getContext()).inflate(R.layout.assistant_messgae,parent,false);
        }
        return new MessageViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        ((MessageViewHolder)holder).bind(messageList.get(position));
    }

    @Override
    public int getItemCount() {
        return messageList.size();
    }

    public int getItemViewType(int index){
        Message message = messageList.get(index);
        if (message.isSend){
            return USER_TYPE;
        }
        else return ASSISTANT_TYPE;
    }

}
