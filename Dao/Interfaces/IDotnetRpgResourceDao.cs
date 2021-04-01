using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using dotnet_rpg.Dao.BaseObjects;
using dotnet_rpg.Dtos;

namespace dotnet_rpg.Dao.Interfaces
{
    public interface IDotnetRpgResourceDao
    {
        Task<List<BaseDotnetRpgResource>> AddCharacter(DotnetRpgCharacterDto newCharacter);
        Task<List<BaseDotnetRpgResource>> DeleteCharacter(int id);
        Task<List<BaseDotnetRpgResource>> GetAllCharacters();
        Task<BaseDotnetRpgResource> GetCharacterById(int id);
        Task<BaseDotnetRpgResource> UpdateCharacter(DotnetRpgCharacterDto updatedCharacter);
    }
}