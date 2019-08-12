using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace Scratch
{
    class PostMessage
    {
        private readonly RestClient client;
        private readonly RestRequest request;
        private readonly string TOKEN;
        public PostMessage(string token)
        {
            TOKEN = token;
            client = new RestClient("https://slack.com/api/chat.postMessage");
            request = new RestRequest(Method.POST);
        }
        public string GetRestResponse(MsgPayload msgPayload)
        {
            string JsonMessage = JsonConvert.SerializeObject(msgPayload);
            request.AddHeader("Authorization", "Bearer " + TOKEN);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("undefined", JsonMessage, ParameterType.RequestBody);
            return client.Execute(request).Content;
        }
    }
}
