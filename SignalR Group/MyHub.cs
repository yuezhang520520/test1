using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalR_Group
{
    public class MyHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void AddGroup(string groupName)
        {
            Groups.Add(this.Context.ConnectionId, groupName);
        }

        public void SendMessage(string groupName, string msg)
        {
            Clients.OthersInGroup(groupName).onMessage(msg);
            Clients.OthersInGroup(groupName).onMessage2(msg);
        }

        public Person GetPerson()
        {
            return new Person { Name = "yuezhang", Age = 18, gender = "男" };
        }

        public void Handle()
        {
            string name= this.Context.QueryString["name"];
            string age = this.Context.QueryString["age"];


            string result = null;
            result.ToString();
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string gender { get; set; }
    }
}