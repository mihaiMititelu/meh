using FileHolder.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileHolder.Controllers
{
    [Produces("application/json")]

    public class UploadController : Controller
    {
        [HttpPost]
        [Route("api/Upload")]
        public IActionResult Upload(string contentFromClient)
        {
            return Ok(contentFromClient);
        }
    }
}