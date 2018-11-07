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
        static string token = @"638993f469bdc06f2f09ab9208c62e8f15863d535d110e80dc159ce39c7f51a8d041f5551c3c7c21dd6ab";
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
