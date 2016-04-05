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

        private static readonly Expression<Func<TeendokListajaDto, TeendokListaja>> LoadFromDto = dto => new TeendokListaja()
        {
            Teendok = dto.Teendok.LoadFromList().ToList()
        };

        private static readonly Func<TeendokListajaDto, TeendokListaja> LoadFunc = LoadFromDto.Compile();


        public static TeendokListajaDto Save(this TeendokListaja source)
        {
            return source == null ? null : SaveFunc(source);
        }

        private static readonly Expression<Func<TeendokListaja, TeendokListajaDto>> SaveFromDto = lista => new TeendokListajaDto()
        {
            Teendok = lista.Teendok.SaveToList().ToList()
        };

        private static readonly Func<TeendokListaja, TeendokListajaDto> SaveFunc = SaveFromDto.Compile();
    }
}