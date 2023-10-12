using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IntelliTect.Function
{
    public static class AddJoke
    {

        // add a joke
        // - connect to storage
        // - send to queue for later processing
        // - receive joke type

        [FunctionName("AddJoke")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            [Queue("outqueue"), StorageAccount("AzureWebJobsStorage")] ICollector<string> msg,
            ILogger log)
        {
            log.LogInformation("Add a joke");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string name = data?.name;

            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // Joke? joke = JsonConvert.DeserializeObject<Joke>(requestBody);

            if (!string.IsNullOrEmpty(name))
            {
                msg.Add(name);
                return new OkObjectResult($"Hello, {name}. This HTTP triggered function executed successfully.");
            }
            else
            {
                return new BadRequestObjectResult("Need a joke name");
            }
        }
    }
}
