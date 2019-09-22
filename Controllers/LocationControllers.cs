using System.Collections.Generic;
using System.Linq;
using inventory.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using inventory;

namespace inventory.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class LocationController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable> GetAllLocations()
    {
      var context = new DatabaseContext();
      var theLocation = context.Location.OrderByDescending(location => location.Id);
      return theLocation.ToList();
    }

    [HttpGet("Id")]
    public ActionResult GetOneLocation(int Id)
    {
      var context = new DatabaseContext();
      var OneLocation = context.Location.FirstOrDefault(i => i.Id == Id);
      if (OneLocation == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(OneLocation);
      }
    }

    [HttpPost]
    public ActionResult<Location> CreateEntry([FromBody] Location entry)
    {
      var context = new DatabaseContext();
      context.Location.Add(entry);
      context.SaveChanges();
      return entry;
    }
  }
}