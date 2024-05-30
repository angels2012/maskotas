using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace maskotas.Controllers
{

    public class Testing : Controller
    {
        [HttpGet]
        [Route("/test/{id:int}")]
        public IActionResult Index([FromRoute] int id)
        {
            return Redirect($"/doge.html?id={id}");
        }
    }
}