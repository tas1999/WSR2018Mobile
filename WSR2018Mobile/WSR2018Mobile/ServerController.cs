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
        static HttpClient client = new HttpClient();
        static string token =
           @"8a40179ecabac32ef3376edae326aa01bbbad81bc93e453b07100"
           + "83ec99b2a2d7d05df8193d0db5142877";
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
            var postAnswer = JsonConvert.DeserializeObject<PostAnswer>(res);
            return postAnswer.Response.Items;
        }
    }
}
