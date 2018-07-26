using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UI.Models
{
    public class LoginViewModel 
    {
        public string LoginName { get; set; }
        public string LoginPwd { get; set; }
        public string Code { get; set; }
        public bool IsRemember { get; set; }
    }
}