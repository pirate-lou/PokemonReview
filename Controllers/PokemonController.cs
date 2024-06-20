using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interface;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]

    public class PokemonController : Controller
    {
        private readonly IPokemonRepository PokemonRepository;
        public PokemonController(IPokemonRepository pokemonRepository)
        {
            PokemonRepository = pokemonRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]

        public IActionResult GetPokemons()
        {
            // it's bring all code from "Controller"
            var pokemons = PokemonRepository.GetPokemons();

            if (!ModelState.IsValid)
                // Explanation of ModelState - instead of submitting a pokemons to out api
                // or we submitted a wrong data say we submitted a dog to out api
                // the model state pick that up and it's going to return a bad request 
                return BadRequest(ModelState);
            return Ok(pokemons);
        }
    }
}
