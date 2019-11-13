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
            var imageUrl = "https://barcode.tec-it.com/barcode.ashx?data=ABC-abc-1234&code=Code128&dpi=96";
            using (var input = await _client.GetStreamAsync(imageUrl))
            {
                _log.LogWarning("Inside input");
                using (var memory = new MemoryStream())
                {
                    _log.LogWarning("Inside memory");
                    var bitmap = new Bitmap(input);
                    _log.LogWarning("Created bitmap");
                    bitmap.Save(memory, ImageFormat.Png);
                    _log.LogWarning("Saved bitmap");
                    byte[] byteImage = memory.ToArray();
                    _log.LogWarning("Got byte array of image");
                    var someString = Convert.ToBase64String(byteImage);
                    _log.LogWarning("Converted image to Base64");
                }
            }
            return new OkObjectResult("It's OK");
        }
    }
}
