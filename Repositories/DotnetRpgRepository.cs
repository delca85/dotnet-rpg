using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;
using dotnet_rpg.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Repositories
{
    public class DotnetRpgRepository : IDotnetRpgRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public DotnetRpgRepository(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
        {
            Character character = _mapper.Map<Character>(newCharacter);

            await _context.Characters.AddAsync(character);
            await _context.SaveChangesAsync();
            var characters = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return characters;
        }

        public async Task<List<GetCharacterDto>> DeleteCharacter(int id)
        {
            Character character = await _context.Characters.FirstAsync(c => c.Id == id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            var characters = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

            return characters;
        }

        public async Task<List<GetCharacterDto>> GetAllCharacters()
        {
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            var characters = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return characters;
        }

        public async Task<GetCharacterDto> GetCharacterById(int id)
        {
            Character dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
            var character = _mapper.Map<GetCharacterDto>(dbCharacter);
            return character;
        }

        public async Task<GetCharacterDto> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            Character character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
            character.Name = updatedCharacter.Name;
            character.Class = updatedCharacter.Class;
            character.Defense = updatedCharacter.Defense;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Strength = updatedCharacter.Strength;

            _context.Characters.Update(character);
            await _context.SaveChangesAsync();

            return _mapper.Map<GetCharacterDto>(character);
        }
    }
}