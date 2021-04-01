using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dtos;

namespace dotnet_rpg.Repositories.Interfaces
{
    public interface IDotnetRpgRepository
    {
        Task<List<DotnetRpgCharacterDto>> AddCharacter(DotnetRpgCharacterDto newCharacter);
        Task<List<DotnetRpgCharacterDto>> GetAllCharacters();
        Task<DotnetRpgCharacterDto> GetCharacterById(int id);
        Task<DotnetRpgCharacterDto> UpdateCharacter(DotnetRpgCharacterDto updatedCharacter);
        Task<List<DotnetRpgCharacterDto>> DeleteCharacter(int id);


    }
}