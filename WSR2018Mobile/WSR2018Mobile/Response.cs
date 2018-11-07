using System;
using System.Collections.Generic;
using System.Text;

namespace WSR2018Mobile
{
    public class Response<T>
    {
        public int Count { get; set; }
        public List<T> Items { get; set; }
    } 
}
