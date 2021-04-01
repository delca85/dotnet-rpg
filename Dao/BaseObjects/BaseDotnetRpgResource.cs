using System;
using dotnet_rpg.Dtos;
using dotnet_rpg.Models;

namespace dotnet_rpg.Dao.BaseObjects
{
    public class BaseDotnetRpgResource
    {
        internal static class Fields
        {
            internal const string Id = "Id";
            internal const string Name = "Name";
            internal const string HitPoints = "HitPoints";
            internal const string Strength = "Strength";
            internal const string Defence = "Defence";
            internal const string Intelligence = "Intelligence";
            internal const string Class = "Class";
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int Intelligence { get; set; }
        public string Class { get; set; }

        public static BaseDotnetRpgResource FromDto(DotnetRpgCharacterDto dotnetRpgCharacterDto)
        {
            return new BaseDotnetRpgResource
            {
                Id = dotnetRpgCharacterDto.Id,
                Name = dotnetRpgCharacterDto.Name,
                HitPoints = dotnetRpgCharacterDto.HitPoints,
                Strength = dotnetRpgCharacterDto.Strength,
                Defense = dotnetRpgCharacterDto.Defense,
                Intelligence = dotnetRpgCharacterDto.Intelligence,
                Class = dotnetRpgCharacterDto.Class.ToString(),
            };
        }

        internal DotnetRpgCharacterDto ToDto()
        {
            return new DotnetRpgCharacterDto
            {
                Id = Id,
                Name = Name,
                HitPoints = HitPoints,
                Strength = Strength,
                Defense = Defense,
                Intelligence = Intelligence,
                Class = (RpgClass)Enum.Parse(typeof(RpgClass), Class),
            };
        }
    }
}