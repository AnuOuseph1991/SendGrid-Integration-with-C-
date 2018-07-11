using sendGridEmailPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sendGridEmailPOC.Controllers
{
    public class SendGridController : ApiController
    {
        
        // POST: api/SendGrid
        public List<ModelSendGrid> Post(List<ModelSendGrid> model)
        {
            //do what ever you want with the notification data.
            return model;
        }
    }
}
