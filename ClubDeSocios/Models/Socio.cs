using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace ClubDeSocios.Models
{

    public enum Sexo{M, F}

    public class Socio
    {
        [Key]
        public int SocioID { get; set; }

        [Required]
        [Display(Name ="Nombre del socio")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido del socio")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Cédula")]
        public string Cedula { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Foto")]
        public byte[] Foto { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono/Celular/Fax")]
        public string TelefonoCelularFax { get; set; }

        [Required]
        [Display(Name = "Sexo")]
        public Sexo Sexo { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Tipo de Membresía")]
        public string TipoMembresia { get; set; }

        [Required]
        [Display(Name = "Lugar de Trabajo")]
        public string LugarTrabajo { get; set; }

        [Required]
        [Display(Name = "Dirección de Oficina")]
        public string DireccionOficina { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Teléfono de Oficina")]
        public string TelefonoOficina { get; set; }

        [Required]
        [Display(Name = "Estado de Membresía")]
        public bool EstadoMembresia { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Ingreso")]
        public DateTime FechaIngreso { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Salida")]
        public DateTime FechaSalida { get; set; }


    }
}