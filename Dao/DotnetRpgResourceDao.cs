using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using dotnet_rpg.Dao.BaseObjects;
using dotnet_rpg.Dao.Interfaces;
using dotnet_rpg.Data;
using dotnet_rpg.Dtos;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg.Dao
{
    public class DotnetRpgResourceDao : IDotnetRpgResourceDao
    {
        private readonly DataContext _context;

        public DotnetRpgResourceDao(DataContext context)
        {
            _context = context;
        }

        public async Task<List<BaseDotnetRpgResource>> AddCharacter(DotnetRpgCharacterDto newCharacter)
        {
            await _context.Characters.AddAsync(BaseDotnetRpgResource.FromDto(newCharacter));
            await _context.SaveChangesAsync();
            var characters = await _context.Characters.ToListAsync();

            return characters;
        }

        public async Task<List<BaseDotnetRpgResource>> DeleteCharacter(int id)
        {
            BaseDotnetRpgResource character = await _context.Characters.FirstAsync(c => c.Id == id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            var characters = await _context.Characters.ToListAsync();

            return characters;
        }

        public async Task<List<BaseDotnetRpgResource>> GetAllCharacters()
        {
            var characters = await _context.Characters.ToListAsync();

            return characters;
        }

        public async Task<BaseDotnetRpgResource> GetCharacterById(int id)
        {
            BaseDotnetRpgResource character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);

            return character;
        }

        public async Task<BaseDotnetRpgResource> UpdateCharacter(DotnetRpgCharacterDto updatedCharacter)
        {
            BaseDotnetRpgResource character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);
            character.Name = updatedCharacter.Name;
            character.Class = updatedCharacter.Class.ToString();
            character.Defense = updatedCharacter.Defense;
            character.HitPoints = updatedCharacter.HitPoints;
            character.Intelligence = updatedCharacter.Intelligence;
            character.Strength = updatedCharacter.Strength;

            _context.Characters.Update(character);
            await _context.SaveChangesAsync();

            return character;
        }
    }
}