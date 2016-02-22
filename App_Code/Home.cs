using System.Web.Http;

namespace CacheK
{

    [RoutePrefix("high")]
    public class HomeController : ApiController
    {
        [CustomService]
        [HttpGet]
        [Route("medium/{makeSense}")]
        public string[] data(string makeSense)
        {
            return new string[] { makeSense };
        }
    }

}