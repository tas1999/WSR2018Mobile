using System;
using System.Collections.Generic;
using System.Text;

namespace WSR2018Mobile
{
   public class ServerAnswer<T>
   {
        public Response<T> Response { get; set; }
   }
   public class ServerAnswerList<T>
   {
        public List<T> Response { get; set; }
   }
}
