using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_rpg.Dtos;
using dotnet_rpg.Models;
using dotnet_rpg.Repositories.Interfaces;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IDotnetRpgRepository _dotnetRpgRepository;
        public CharacterService(IDotnetRpgRepository dotnetRpgRepository)
        {
            _dotnetRpgRepository = dotnetRpgRepository;
        }

        public async Task<ServiceResponse<List<DotnetRpgCharacterDto>>> AddCharacter(DotnetRpgCharacterDto newCharacter)
        {
            ServiceResponse<List<DotnetRpgCharacterDto>> serviceResponse = new ServiceResponse<List<DotnetRpgCharacterDto>>();
            serviceResponse.Data = await _dotnetRpgRepository.AddCharacter(newCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DotnetRpgCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<DotnetRpgCharacterDto>> serviceResponse = new ServiceResponse<List<DotnetRpgCharacterDto>>();
            serviceResponse.Data = await _dotnetRpgRepository.GetAllCharacters();
            return serviceResponse;
        }

        public async Task<ServiceResponse<DotnetRpgCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<DotnetRpgCharacterDto> serviceResponse = new ServiceResponse<DotnetRpgCharacterDto>();
            serviceResponse.Data = await _dotnetRpgRepository.GetCharacterById(id);
            return serviceResponse;
        }

        public async Task<ServiceResponse<DotnetRpgCharacterDto>> UpdateCharacter(DotnetRpgCharacterDto updatedCharacter)
        {
            ServiceResponse<DotnetRpgCharacterDto> serviceResponse = new ServiceResponse<DotnetRpgCharacterDto>();
            try
            {
                serviceResponse.Data = await _dotnetRpgRepository.UpdateCharacter(updatedCharacter);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DotnetRpgCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<DotnetRpgCharacterDto>> serviceResponse = new ServiceResponse<List<DotnetRpgCharacterDto>>();
            try
            {
                serviceResponse.Data = await _dotnetRpgRepository.DeleteCharacter(id);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

    }
}