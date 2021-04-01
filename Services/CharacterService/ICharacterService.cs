using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dtos;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<DotnetRpgCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<DotnetRpgCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<DotnetRpgCharacterDto>>> AddCharacter(DotnetRpgCharacterDto newCharacter);
        Task<ServiceResponse<DotnetRpgCharacterDto>> UpdateCharacter(DotnetRpgCharacterDto updatedCharacter);
        Task<ServiceResponse<List<DotnetRpgCharacterDto>>> DeleteCharacter(int id);

    }
}