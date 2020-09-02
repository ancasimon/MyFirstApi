using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;

namespace MyFirstApi.Controllers
{
    [Route("api/pizzas")]
    [ApiController]
    public class PizzasController : ControllerBase

    {
        //List<Pizza> _pizzas;
        static List<Pizza> _pizzas;


        //public PizzasController()
        static PizzasController()


        {
            var pizza1 = new Pizza { Id = 1, Size = "Medium", Toppings = new List<string> { "Pepperoni" } };
            var pizza2 = new Pizza { Id = 2, Size = "Medium", Toppings = new List<string> { "Sausage" } };
            var pizza3 = new Pizza { Id = 3, Size = "Medium", Toppings = new List<string> { "Bacon" } };

            _pizzas = new List<Pizza> { pizza1, pizza2, pizza3 };
        }
    [HttpGet]//this tells ASP.NET that when someone hits that route above with a get method, then they should be routed to this function!
             //a method that will return a list of pizzas and is publicly accessible
    public List<Pizza> GetAllPizzas()
        {
            return _pizzas;
        }
        //a method to return a  single pizza 
        //api/pizzas/{id}
        //api/pizzas/2
        [HttpGet("{id}")]
        //public Pizza GetPizzaById(int id)
        public IActionResult GetPizzaById(int id)
        {
            var result = _pizzas.SingleOrDefault(pizza => pizza.Id == id);
            if (result == null)
            {
                return NotFound($"Could not find a pizza with the id {id}");
            }
            return Ok(result);//you can pass in the status you want and the response/body you want!
        }

        //api/pizzas
        [HttpPost]
        public IActionResult CreatePizza(CreatePizzaCommand command)
        {
            var newPizza = new Pizza { Size = command.Size };
            //to set the id to the next id after the greatest id currently on a pizza:
            //take the pizzas collection > transform it into a collection of just ids > and then use .Max() to give me the biggest id and then add 1 to create the id of the new pizza.
            newPizza.Id = _pizzas.Select(p => p.Id).Max() + 1;
            _pizzas.Add(newPizza);

            return Created($"api/pizzas/{newPizza.Id}", newPizza);
        }
    }
}
