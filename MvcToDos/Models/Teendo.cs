﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcToDos.Models
{
    public class Teendo : TeendoBase
    {
        [Required]
        [Display(Name = "Teendő szövege")]
        public string Szoveg { get; set; }

    }
}