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

  public class inventoryController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable> GetAllItems()
    {
      var context = new DatabaseContext();
      var theThing = context.Items.OrderByDescending(item => item.Id);
      return theThing.ToList();
    }

    [HttpGet("{Id}")]
    public ActionResult GetOneItem(int id)
    {
      var context = new DatabaseContext();
      var oneItem = context.Items.FirstOrDefault(i => i.Id == id);
      if (oneItem == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(oneItem);
      }
    }

    [HttpPost]
    public ActionResult<Item> CreateEntry([FromBody] Item entry)
    {
      var context = new DatabaseContext();
      context.Items.Add(entry);
      context.SaveChanges();
      return entry;
    }

  }
}