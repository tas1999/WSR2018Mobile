﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WSR2018Mobile
{
    class ServerController
    {
        public static string Token { get { return token; } set { token = value; } }
        static HttpClient client = new HttpClient();
        static string token = @"03fada0d69fa4a03c3b39136b85b030f74894a3bb4bc019b2d270780c8393d534badd44f4f2633e689992";
        static ServerController()
        {
            // указываем, что ждём от сервера json объекты
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        public static async Task<List<Post>> GetAsyncStudents(int offset,int count)
        {
            // GetAsync() отправлем серверу запрос и ожидаем ответ
            HttpResponseMessage respons = client.
                GetAsync(@"https://api.vk.com/method/"
                + "wall.get?owner_id=-103815643&count=" + count + "&" + "offset=" +offset + "&" +
                "access_token=" + token + "&v=5.87"
                ).GetAwaiter().GetResult();


            // читаем ответ сервера в виде строки
            string res = await respons.Content.ReadAsStringAsync();
            // получаем из строки объект
            var postAnswer = JsonConvert.DeserializeObject<ServerAnswer<Post>>(res);
            return postAnswer.Response.Items;
        }
        public static async Task<List<Chat>> GetDialogList()
        {
            HttpResponseMessage respons = await client.GetAsync(@"https://api.vk.com/method/"
                + "messages.getConversations?count=10" + "&" +
                "access_token=" + token + "&v=5.87");
            string res = await respons.Content.ReadAsStringAsync();
            var chatAnswer = JsonConvert.DeserializeObject<ServerAnswer<Chat>>(res);
            return chatAnswer.Response.Items;
        }
        public static async Task<List<Message>> GetMessageList(int id)
        {
            HttpResponseMessage respons = await client.GetAsync(@"https://api.vk.com/method/"
                + "messages.getHistory?" + "peer_id="
                 + id + "&" + "count=5&" +
                "access_token=" + token + "&v=5.87");
            string res = await respons.Content.ReadAsStringAsync();
            var chatAnswer = JsonConvert.DeserializeObject<ServerAnswer<Message>>(res);
            return chatAnswer.Response.Items.OrderBy((i)=>(i.Id)).ToList();
        }
        public static List<User> GetUserById(int id)
        {
            HttpResponseMessage respons = client.GetAsync(@"https://api.vk.com/method/"
                + "users.get?user_ids=" +id+ "&" +
                "access_token=" + token + "&v=5.87").GetAwaiter().GetResult();
            string res = respons.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var chatAnswer = JsonConvert.DeserializeObject<ServerAnswerList<User>>(res);
            return chatAnswer.Response;
        }

        public static async Task SendMessage(string text, int id)
        {
            HttpResponseMessage response = await client.GetAsync(@"https://api.vk.com/method/"
                 + "messages.send?"
                 + "peer_id="
                 + id
                 + "&message="
                 + text
                 + "&" +
                 "access_token="
                 + token + "&v=5.87");
        }
    }
}
