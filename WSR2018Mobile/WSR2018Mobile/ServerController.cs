using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WSR2018Mobile
{
    class ServerController
    {
        public static string Token { get { return token; } set { token = value; } }
        static HttpClient client = new HttpClient();
        static string token = @"70de73aea33b7e49a8530c62b5da4919e1a03aad49fde88f1c10cdf8a83b17cafd99d8c7cfb21dfd0edf4";
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
