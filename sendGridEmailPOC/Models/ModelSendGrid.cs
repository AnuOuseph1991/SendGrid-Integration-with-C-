using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sendGridEmailPOC.Models
{
    public class ModelSendGrid
    {
        public string email { get; set; }
        public int timestamp { get; set; }
        public string Event { get; set; }
        public int userid { get; set; }
        public string template { get; set; }
        public string sg_message_id { get; set; }
    }
}