package com.example.voiceassistent

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.recyclerview.widget.RecyclerView
import java.util.*
import com.example.voiceassistent.R


class MessageListAdapter : RecyclerView.Adapter<RecyclerView.ViewHolder>() {
    var messageList: ArrayList<Message> = ArrayList()


    override fun onCreateViewHolder(
        parent: ViewGroup,
        viewType: Int
    ): RecyclerView.ViewHolder {
        val view: View
        return if (viewType == USER_TYPE) {
            view = LayoutInflater.from(parent.context)
                .inflate(R.layout.user_message, parent, false)
            MessageViewHolder(view)
        } else {
            view = LayoutInflater.from(parent.context)
                .inflate(R.layout.assistant_message, parent, false)
            MessageViewHolder(view)
        }
    }

    override fun onBindViewHolder(holder: RecyclerView.ViewHolder, position: Int) {
        MessageViewHolder(holder.itemView).bind(messageList[position])
    }
    override fun getItemCount(): Int {
        return messageList.size

    }

    override fun getItemViewType(index: Int): Int {
        var message = messageList[index]
        return if (message.isSend) {
            USER_TYPE
        } else ASSISTANT_TYPE
    }

    companion object {
        private const val ASSISTANT_TYPE = 0
        private const val USER_TYPE = 1
    }

}