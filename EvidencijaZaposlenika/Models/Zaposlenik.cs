using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaZaposlenika.Models
{
    public class Zaposlenik
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Ovo polje je obavezno.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Prezime { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Pozicija { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Ured { get; set; }
        [Required(ErrorMessage = "Ovo polje je obavezno.")]
        public string Kontakt { get; set; }

    }
}
