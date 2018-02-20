using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LicoreriaMoras.Models
{
    public class LiquorType
    {
        [Key]
        public int Id_liquorType { get; set; }
        public string  Descripcion { get; set; }
    }
}