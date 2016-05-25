using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Optimization;
using MvcToDos.Dtos;
using MvcToDos.Models;

namespace MvcToDos.Util.Extensions
{
    public static class TeendoListaElemExtension
    {
        public static TeendoListaElemDto Save(this TeendoListaElem source)
        {
            return source == null ? null : SaveFunc(source);
        }

        public static IEnumerable<TeendoListaElemDto> SaveToList(this IEnumerable<TeendoListaElem> source)
        {
            return source == null ? null : source.Select(SaveFunc);
        }


        private static readonly Expression<Func<TeendoListaElem, TeendoListaElemDto>> SaveToDto =
            elem => new TeendoListaElemDto()
            {
                Id = elem.Id,
                Szoveg = elem.Szoveg
            };

        private static readonly Func<TeendoListaElem, TeendoListaElemDto> SaveFunc = SaveToDto.Compile();

        public static TeendoListaElem Load(this TeendoListaElemDto source)
        {
            return source == null ? null : LoadFunc(source);
        }

        public static IEnumerable<TeendoListaElem> LoadFromList(this IEnumerable<TeendoListaElemDto> source)
        {
            return source == null ? null : source.Select(LoadFunc);
        }

        private static readonly Expression<Func<TeendoListaElemDto, TeendoListaElem>> LoadFrom =
            dto => new TeendoListaElem()
            {
                Id = dto.Id,
                Szoveg = dto.Szoveg
            };

        private static readonly Func<TeendoListaElemDto, TeendoListaElem> LoadFunc = LoadFrom.Compile();



        public static Entities.TeendoListaElem ToDb(this TeendoListaElem elem)
        {
            return elem == null ? null : ToDbFunc(elem);
        }

        private static readonly Expression<Func<TeendoListaElem, Entities.TeendoListaElem>> ToDbExpression =
            elem => new Entities.TeendoListaElem()
            {
                Szoveg = elem.Szoveg
            };

        private static readonly Func<TeendoListaElem, Entities.TeendoListaElem> ToDbFunc = ToDbExpression.Compile();

    }
}