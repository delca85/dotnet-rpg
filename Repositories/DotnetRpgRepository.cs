using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dao.Interfaces;
using dotnet_rpg.Dtos;
using dotnet_rpg.Repositories.Interfaces;

namespace dotnet_rpg.Repositories
{
    public class DotnetRpgRepository : IDotnetRpgRepository
    {

        private readonly IDotnetRpgResourceDao _dotnetRpgResourceDao;
        public DotnetRpgRepository(IDotnetRpgResourceDao dotnetRpgResourceDao)
        {
            _dotnetRpgResourceDao = dotnetRpgResourceDao;
        }
        public async Task<List<DotnetRpgCharacterDto>> AddCharacter(DotnetRpgCharacterDto newCharacter)
        {
            var characters = await _dotnetRpgResourceDao.AddCharacter(newCharacter);
            return characters.ConvertAll(c => c.ToDto());
        }

        public async Task<List<DotnetRpgCharacterDto>> DeleteCharacter(int id)
        {
            var characters = await _dotnetRpgResourceDao.DeleteCharacter(id);
            return characters.ConvertAll(c => c.ToDto());
        }

        public async Task<List<DotnetRpgCharacterDto>> GetAllCharacters()
        {
            var characters = await _dotnetRpgResourceDao.GetAllCharacters();
            return characters.ConvertAll(c => c.ToDto());
        }

        public async Task<DotnetRpgCharacterDto> GetCharacterById(int id)
        {
            var character = await _dotnetRpgResourceDao.GetCharacterById(id);
            return character.ToDto();
        }

        public async Task<DotnetRpgCharacterDto> UpdateCharacter(DotnetRpgCharacterDto updatedCharacter)
        {
            var character = await _dotnetRpgResourceDao.UpdateCharacter(updatedCharacter);
            return character.ToDto();
        }
    }
}