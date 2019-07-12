using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WAK_Session_01_WebApp.Models;

namespace WAK_Session_01_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebAppController : ControllerBase
    {
        private static string NameKey { get { return "Key_Name"; } }

        private IMemoryCache memCache;

        public WebAppController(IMemoryCache memCache)
        {
            this.memCache = memCache;
        }

        [HttpGet]
        public ActionResult<Response<string>> Get()
        {
            if (memCache.TryGetValue(NameKey, out string name))
            {
                return new Response<string>($"Welcome {name}");
            }

            return new Response<string>("Please save your name by Post call");
        }

        [HttpPost]
        public ActionResult<Response<string>> Post([FromBody] PostModel postModel)
        {
            if(!string.IsNullOrEmpty(postModel.Name))
            {
                string val = memCache.Set(NameKey, postModel.Name);
                return new Response<string>($"Name was saved as {val}");
            }

            return new Response<string>("Name was not saved");
        }
    }
}
