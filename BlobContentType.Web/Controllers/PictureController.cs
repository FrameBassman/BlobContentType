using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlobContentType.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PictureController : ControllerBase
    {
        private readonly ILogger<PictureController> _log;
        private readonly HttpClient _client;

        public PictureController(ILogger<PictureController> log, IHttpClientFactory clientFactory)
        {
            _log = log;
            _client = clientFactory.CreateClient();
        }
        
        public async Task<IActionResult> Index()
        {
            return new OkObjectResult("It's OK");
        }
    }
}
