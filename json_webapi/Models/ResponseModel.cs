using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace json_webapi.Models
{
    public class ResponseModel
    {
        public List<ResponseSet> response { get; set; }
    }

    public class ResponseSet
    {
        public string image { get; set; }
        public string slug { get; set; }
        public string title { get; set; }
    }
}