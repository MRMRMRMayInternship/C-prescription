using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebDemo.Controllers
{
    public class LoginController : ApiController
    {
        public bool GetCheckResult(string id, string pw)
        {
            var result = false;
            if (id.Equals("root") && pw.Equals("roor"))
            {
                result = true;
            }
            return result;
        }
    }
}
