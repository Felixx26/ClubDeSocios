using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubDeSocios.Models
{
    public class Afiliado
    {
        [Key]
        public int AfiliadoID { get; set; }

        [Required]
        [Display(Name = "Nombre del Afiliado")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido del Afiliado")]
        public string Apellido { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public Sexo Sexo { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Socio")]
        public int SocioID { get; set; }
        public virtual Socio Socio { get; set; }
    }
}