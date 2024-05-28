using System.Data;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;
namespace ContosoPizza.Controllers;
[ApiController]
[Route("[controller]")]
public class FruitController : ControllerBase
{
    public FruitController()
    {
        
    }
    // GET all action
    [HttpGet]
    public ActionResult<List<Fruit>> GetAll() => 
    FruitService.GetAll();
    //Get All Order
    [HttpGet("GetAllOrder")]

    public ActionResult<List<Fruit>> GetAllOrder() => FruitService.GetAllOrder();
    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Fruit> Get(int id)
    {
        var fruit = FruitService.Get(id);
        if (fruit == null)
            return NotFound();
        return fruit;
    }

    // POST action
    [HttpPost]
    public ActionResult<Fruit> Post(Fruit fruit){
        
         FruitService.Add(fruit);
         return CreatedAtAction(nameof(Get),new {id = fruit.Id},fruit);
    }
    [HttpPut("{id}")]
        public IActionResult Put(int id, Fruit fruit)
        {
            if (id != fruit.Id) return BadRequest();

            var existingFruit = FruitService.Get(id);
            if (existingFruit == null) return NotFound();

            FruitService.Update(fruit);
            return NoContent();
        }

        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fruit = FruitService.Get(id);
            if (fruit == null) return NotFound();

            FruitService.Delete(id);
            return NoContent();
        }
}