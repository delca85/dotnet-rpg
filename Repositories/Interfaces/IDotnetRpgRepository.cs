using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Repositories.Interfaces
{
    public interface IDotnetRpgRepository
    {
        Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter);
        Task<List<GetCharacterDto>> GetAllCharacters();
        Task<GetCharacterDto> GetCharacterById(int id);
        Task<GetCharacterDto> UpdateCharacter(UpdateCharacterDto updatedCharacter);
        Task<List<GetCharacterDto>> DeleteCharacter(int id);


    }
}