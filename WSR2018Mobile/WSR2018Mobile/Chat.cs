using System;
using System.Collections.Generic;
using System.Text;

namespace WSR2018Mobile
{
    class Chat
    {
        public Conversation Conversation { get; set; }
        public Last_message Last_message { get; set; }
        public string ChatName
        {
            get
            {
                if(Conversation.Peer.Type == "chat")
                {
                    return Conversation.Chat_settings.Title;
                }
                if (Conversation.Peer.Type == "user")
                {
                    var user = ServerController.GetUserById(Conversation.Peer.Id)[0];
                    return user.First_name +" " + user.Last_name;
                }
                else
                {
                    return Conversation.Peer.Id.ToString();
                }
            }
        }
    }
    class Conversation
    {
        public Chat_settings Chat_settings { get; set; }
        public Peer Peer { get; set; }
    }
    class Peer
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
    class Chat_settings
    {
        public string Title { get; set; }
        public Photo Photo { get; set; }
    }
    class Photo
    {
        public string Photo_50 { get; set; }
    }
    class Last_message
    {
        public long Date { get; set; }
        public string Text { get; set; }
    }
}
