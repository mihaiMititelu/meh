using System;
using System.Linq;
using FileHolder.DataAccess;
using FileHolder.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileHolder.Controllers
{
    [Produces("application/json")]
    [Route("api/YourFiles")]
    public class YourFilesController : Controller
    {
        private readonly IRepository _repository;

        public YourFilesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllFilesForUser()
        {
            return Ok(_repository.GetAll<File>().Where(f => f.CreationDate < DateTime.Now));
        }
    }
}