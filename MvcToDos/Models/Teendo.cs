using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MvcToDos.Models
{
    public class Teendo
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Teendő szövege")]
        public string Szoveg { get; set; }
        
        public bool Allapot { get; set; }

        public Teendo()
        {
            Allapot = false;
        }
    }
}