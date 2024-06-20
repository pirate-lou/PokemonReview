using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interface
{
    public interface IPokemonRepository
    {
        // repository pattern 

        ICollection<Pokemon> GetPokemons();

    }
}
