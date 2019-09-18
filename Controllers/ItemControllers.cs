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

    [HttpPut("{Id}")]
    public ActionResult<Item> PutItem(int Id, [FromBody]Item entry)
    {
      var context = new DatabaseContext();
      context.Items.Add(entry);
      context.SaveChanges();
      return entry;
    }

    [HttpGet("OutOfStock")]
    public ActionResult<IEnumerable<Item>> GetOutOfStockItem()
    {
      var context = new DatabaseContext();
      var theThing = context.Items.OrderByDescending(i => i.NumberInStock == 0);
      return theThing.ToList();

    }

    [HttpGet("{SKU}")]
    public ActionResult<Item> PutSku(string SKU)
    {
      var context = new DatabaseContext();
      var oneItem = context.Items.FirstOrDefault(i => i.SKU == SKU);
      if (oneItem == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(oneItem);
      }
    }

    [HttpDelete("{Id}")]
    public ActionResult<Item> DeleteItem(int Id)
    {
      return Ok(Id);
    }
  }
}