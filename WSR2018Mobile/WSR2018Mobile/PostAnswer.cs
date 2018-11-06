using System;
using System.Collections.Generic;
using System.Text;

namespace WSR2018Mobile
{
   public class PostAnswer
   {
        public Response Response { get; set; }
   }
   public class Response
   {
        public int Count { get; set; }
        public List<Post> Items { get; set; }
   }
}
