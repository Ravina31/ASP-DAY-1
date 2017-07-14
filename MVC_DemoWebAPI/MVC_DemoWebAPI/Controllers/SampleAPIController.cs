using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_DemoWebAPI.Controllers
{
    public class SampleAPIController : ApiController
    { private static string[] PlayerNames= {"Virat", "Sachin", "Rohit", "Dhoni", "Rahul"};
        public string[] Get()
        {
            return PlayerNames;
        }

        public string Get(int id)
        {
            return PlayerNames[id];
        }

        public void Post([FromBody] string PlayerName) 
        {
            Array.Resize(ref PlayerNames, PlayerNames.Length + 1);
            PlayerNames[PlayerNames.Length - 1] = PlayerName;
        }

        public void Put(int id,[FromBody] string PlayerName)
        {
            PlayerNames[id] = PlayerName;
        }

        public void Delete(int  id)
        {
            PlayerNames[id] = string.Empty;
        }
    }
}
