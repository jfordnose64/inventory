using System.Collections.Generic;
using System.Linq;
using inventory.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace inventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class inventoryController : ControllerBase
  {
    [HttpGet]
    public ActionResult<string> Sum(string s)
    {
      return "Wow";
    }

    // [HttpPost]
    // public ActionResult<string> CreateItem()
    // {

    // }
  }
}