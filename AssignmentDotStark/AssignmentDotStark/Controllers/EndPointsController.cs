using AssignmentDotStark.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssignmentDotStark.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EndPointsController : ControllerBase
    {
        [Route("GetISO8601Format")]
        [HttpGet]
        public JsonResult GetISO8601Format()
        {
            try
            {
                return new JsonResult(General.GetISO8601Format());
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [Route("PostWithMinima")]
        [HttpGet]
        public async Task<JsonResult> PostWithMinima()
        {
            var httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts").ConfigureAwait(false);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonResult = httpResponseMessage.Content.ReadAsStringAsync().Result;
                return new JsonResult(JsonConvert.DeserializeObject<List<PlaceholderResultModel>>(jsonResult).Where(x => x.Body.Contains("minima")).ToList());
            }

            return new JsonResult("Post not found!");
        }
    }
}
