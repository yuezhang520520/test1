using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR_Group
{
    public class UserHub:Hub
    {
        public string GetUserName()
        {
            string token = Context.QueryString.Get("token");
            string userName = JWThelper.Decrypt(token);
            return userName;
        }
    }
}