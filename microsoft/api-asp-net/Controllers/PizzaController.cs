using api_asp_net.Models;
using api_asp_net.Services;
using Microsoft.AspNetCore.Mvc;

namespace api_asp_net.Controllers;

// atributos
[ApiController]
[Route("[controller]")] // define o padrão pizza/
public class PizzaController : ControllerBase
{
    public PizzaController()
    {

    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

    [HttpGet("{id}")] // pizza/{id}
    public ActionResult<Pizza> Get(int id)
    {
        var pizza = PizzaService.Get(id);
        var teste = "das";

        if (pizza == null)
        {
            return NotFound();
        }

        return pizza;
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
        {
            return BadRequest();
        }

        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        PizzaService.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        PizzaService.Delete(id);

        return NoContent();
    }

}

