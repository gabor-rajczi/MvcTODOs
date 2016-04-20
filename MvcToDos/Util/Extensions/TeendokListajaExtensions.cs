using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MvcToDos.Dtos;
using MvcToDos.Models;

namespace MvcToDos.Util.Extensions
{
    public static class TeendokListajaExtensions
    {
        public static TeendokListaja Load(this TeendokListajaDto source)
        {
            return source == null ? null : LoadFunc(source);
        }

        private static readonly Expression<Func<TeendokListajaDto, TeendokListaja>> LoadFromDto = dto => dto.FromDto();

        private static readonly Func<TeendokListajaDto, TeendokListaja> LoadFunc = LoadFromDto.Compile();

        private static TeendokListaja FromDto(this TeendokListajaDto lista)
        {
            var adat = new TeendokListaja();
            if (lista.Teendok.Any())
            {
                foreach (var teendo in lista.Teendok)
                {
                    adat.Teendok.Add(teendo.Load());
                }
            }
            if (lista.TeendoListak.Any())
            {
                foreach (var teendo in lista.TeendoListak)
                {
                    adat.Teendok.Add(teendo.Load());
                }
            }
            return adat;
        }


        public static TeendokListajaDto Save(this TeendokListaja source)
        {
            return source == null ? null : SaveFunc(source);
        }

        private static readonly Expression<Func<TeendokListaja, TeendokListajaDto>> SaveToDto = lista => lista.ToDto();

        private static readonly Func<TeendokListaja, TeendokListajaDto> SaveFunc = SaveToDto.Compile();

        private static TeendokListajaDto ToDto(this TeendokListaja lista)
        {
            var dto = new TeendokListajaDto();
            if (lista.Teendok.Exists(t => t is Teendo))
            {
                dto.Teendok = new List<TeendoDto>();
                foreach (var teendo in lista.Teendok.Where(t=>t is Teendo))
                {
                   dto.Teendok.Add(((Teendo)teendo).Save()); 
                }
            }
            if (lista.Teendok.Exists(t => t is TeendoLista))
            {
                dto.TeendoListak = new List<TeendoListaDto>();
                foreach (var teendo in lista.Teendok.Where(t => t is TeendoLista))
                {
                    dto.TeendoListak.Add(((TeendoLista)teendo).Save());
                }
            }
            return dto;
        }
    }
}