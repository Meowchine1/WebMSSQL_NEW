using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMSSQL.Controllers
{
    public class HangFireController : Controller
    {
        [HttpPost]
        [Route("fire-and-forget")]
        public IActionResult FireForget(string client)
        {
            string jobId = BackgroundJob.Enqueue(() =>
            Console.WriteLine($"{client}, thank you."));

            return Ok($"Job id {jobId}");
        }

        [HttpPost]
        [Route("delayed")]
        public IActionResult Delayed(string client) {

            string jobId = BackgroundJob.Schedule(() =>
            Console.WriteLine($"Session for client {client}  will be closed"), TimeSpan.FromSeconds(60));
            return Ok($"Job id is {jobId}");
        }

        [HttpPost]
        [Route("recurring")]
        public IActionResult Recurring() {

            RecurringJob.AddOrUpdate(() => Console.WriteLine("Good morning!"), Cron.Daily);

            return Ok();
        }

    }

   
}
