using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcToDos.Dtos;
using MvcToDos.Models;

namespace MvcToDos.Util.Extensions
{
    public static class TeendoListaExtension
    {
        public static TeendoLista Load(this TeendoListaDto source)
        {
            return source == null ? null : LoadFunc(source);
        }

        public static IEnumerable<TeendoLista> LoadFromList(this IEnumerable<TeendoListaDto> source)
        {
            return source == null ? null : source.Select(LoadFunc);
        }

        private static readonly Expression<Func<TeendoListaDto, TeendoLista>> LoadFromDto = dto => new TeendoLista()
        {
            TeendoListaElemek = dto.TeendoListaElemek.LoadFromList().ToList(),
            Id = dto.Id,
            Allapot = dto.Allapot,
            Fontossag = Fontossag.ToTipus(dto.Fontossag),
            Hatarido = dto.Hatarido == null ? null : (DateTime?)DateTime.Parse(dto.Hatarido),
            Letrehozas = DateTime.Parse(dto.Letrehozas),
            SzinKod = dto.SzinKod
        };

        private static readonly Func<TeendoListaDto, TeendoLista> LoadFunc = LoadFromDto.Compile();


        public static TeendoListaDto Save(this TeendoLista source)
        {
            return source == null ? null : SaveFunc(source);
        }

        public static IEnumerable<TeendoListaDto> SaveToList(this IEnumerable<TeendoLista> source)
        {
            return source == null ? null : source.Select(SaveFunc);
        }

        private static readonly Expression<Func<TeendoLista, TeendoListaDto>> SaveFromDto = lista => new TeendoListaDto()
        {
            TeendoListaElemek = lista.TeendoListaElemek.SaveToList().ToList(),
            Id = lista.Id,
            Allapot = lista.Allapot,
            Fontossag = lista.Fontossag.ToString(),
            Hatarido = lista.Hatarido == null ? null : ((DateTime)lista.Hatarido).ToString("yyyy-MM-dd"),
            Letrehozas = lista.Letrehozas.ToString("yyyy-MM-dd HH:mm:ss"),
            SzinKod = lista.SzinKod
        };

        private static readonly Func<TeendoLista, TeendoListaDto> SaveFunc = SaveFromDto.Compile();
    }
}