using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Scratch
{
    public static class CallingClass
    {
        [FunctionName("CallingClass")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        { 
        
            log.LogInformation("C# HTTP trigger function processed a request.");
            
           
                string channel = req.Query["channel"];
                string text = req.Query["text"];
            try
            {
                StreamReader sr = new StreamReader(req.Body);
                string requestBody = await sr.ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                channel = channel ?? data?.channel;
                text = text ?? data?.text;
                sr.Close();
            }
            catch { }
                

                dynamic obj = new PostMessage("xoxp-715816215412-715816216372-718874144608-10fb1406a95d6b5eb9b411ecf05b51ff");
                

                if (text == null || channel == null)
                {
                    return new BadRequestObjectResult("BOTH CHANNEL NAME and MESSAGE are required!");
                }
                else
                {
                    MsgPayload messagePayload = new MsgPayload()
                    {
                        text = text,
                        channel = channel
                    };
                    return (ActionResult)new OkObjectResult(obj.GetRestResponse(messagePayload));
                }
            
            
            }
        }
    }


 
