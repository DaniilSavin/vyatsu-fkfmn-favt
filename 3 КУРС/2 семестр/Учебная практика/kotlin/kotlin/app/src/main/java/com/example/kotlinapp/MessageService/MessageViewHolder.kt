package com.example.kotlinapp.MessageService

import android.view.View
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.example.kotlinapp.R
import java.text.DateFormat
import java.text.SimpleDateFormat

open class MessageViewHolder(itemView: View) :
    RecyclerView.ViewHolder(itemView)
{
    private var messageText: TextView
    private var messageDate: TextView
    fun bind(message: Message) {
        messageText.text = message.text
        val fmt: DateFormat = SimpleDateFormat("HH:mm")
        messageDate.text = fmt.format(message.date)
    }

    init {
        messageText = itemView.findViewById(R.id.messageTextView)
        messageDate = itemView.findViewById(R.id.messageDateView)
    }
}