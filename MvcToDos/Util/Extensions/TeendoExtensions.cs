using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcToDos.Dtos;
using MvcToDos.Models;

namespace MvcToDos.Util.Extensions
{
    public static class TeendoExtensions
    {
        public static TeendoDto Save(this Teendo source)
        {
            return source == null ? null : SaveFunc(source);
        }

        public static IEnumerable<TeendoDto> SaveToList(this IEnumerable<Teendo> source)
        {
            return source == null ? null : source.Select(SaveFunc);
        }

        private static readonly Expression<Func<Teendo, TeendoDto>> SaveToDto = teendo => new TeendoDto()
        {
            Id = teendo.Id,
            Szoveg = teendo.Szoveg,
            Allapot = teendo.Allapot,
            Fontossag = teendo.Fontossag.ToString(),
            Hatarido = teendo.Hatarido == null ? null : ((DateTime)teendo.Hatarido).ToString("yyyy-MM-dd"),
            Letrehozas = teendo.Letrehozas.ToString("yyyy-MM-dd HH:mm:ss"),
            SzinKod = teendo.SzinKod
        };

        private static readonly Func<Teendo, TeendoDto> SaveFunc = SaveToDto.Compile();


        public static TeendoBase Load(this TeendoDto source)
        {
            return source == null ? null : LoadFunc(source);
        }

        public static IEnumerable<Teendo> LoadFromList (this IEnumerable<TeendoDto> source)
        {
            return source == null ? null : source.Select(LoadFunc);
        }

        private static readonly Expression<Func<TeendoDto, Teendo>> LoadFromDto = dto => new Teendo()
        {
            Id = dto.Id,
            Szoveg = dto.Szoveg,
            Allapot = dto.Allapot,
            Fontossag = Fontossag.ToTipus(dto.Fontossag),
            Hatarido = dto.Hatarido == null ? null : (DateTime?)DateTime.Parse(dto.Hatarido),
            Letrehozas = DateTime.Parse(dto.Letrehozas),
            SzinKod = dto.SzinKod

        };

        private static readonly Func<TeendoDto, Teendo> LoadFunc = LoadFromDto.Compile();








        public static Entities.Teendo ToDb(this Teendo teendo)
        {
            return teendo == null ? null : ToDbFunc(teendo);
        }

        private static readonly Expression<Func<Teendo, Entities.Teendo>> ToDbExpression =
            teendo => new Entities.Teendo()
            {
                Allapot = teendo.Allapot,
                Fontossag = teendo.Fontossag.ToString(),
                Hatarido = teendo.Hatarido,
                Letrehozas = teendo.Letrehozas,
                SzinKod = teendo.SzinKod,
                Szoveg = teendo.Szoveg
            };

        private static readonly Func<Teendo, Entities.Teendo> ToDbFunc = ToDbExpression.Compile();

        public static IEnumerable<Teendo> FromDbToList(this IEnumerable<Entities.Teendo> teendo)
        {
            return teendo == null ? null : teendo.Select(FromDbFunc);
        }

        private static readonly Expression<Func<Entities.Teendo, Teendo>> FromDbExpression = teendo => new Teendo()
        {
            Id = teendo.Id,
            Allapot = teendo.Allapot,
            Fontossag = Fontossag.ToTipus(teendo.Fontossag),
            Hatarido = teendo.Hatarido,
            Letrehozas = teendo.Letrehozas,
            SzinKod = teendo.SzinKod,
            SzinkodMegadva = teendo.SzinKod != null,
            Szoveg = teendo.Szoveg
        };

        private static readonly Func<Entities.Teendo, Teendo> FromDbFunc = FromDbExpression.Compile();
    }
}