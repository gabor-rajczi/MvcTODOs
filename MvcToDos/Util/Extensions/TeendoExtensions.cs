﻿using System;
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
            Allapot = teendo.Allapot
        };

        private static readonly Func<Teendo, TeendoDto> SaveFunc = SaveToDto.Compile();


        public static Teendo Load(this TeendoDto source)
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
            Allapot = dto.Allapot
        };

        private static readonly Func<TeendoDto, Teendo> LoadFunc = LoadFromDto.Compile();
    }
}