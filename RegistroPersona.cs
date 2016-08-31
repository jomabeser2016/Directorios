using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 
namespace EjemploMVC.Models
{
    public class RegistroPersona
    {
        [DisplayName("Nombre:")]
        [Required(ErrorMessage = "No se ha ingresado Nombre.")]
        public string vNomPer { get; set; }

        [DisplayName("Apellido Paterno:")]
        [Required(ErrorMessage = "No se ha ingresado Apellido Paterno.")]
        public string vApePat { get; set; }

        [DisplayName("Apellido Materno:")]
        [Required(ErrorMessage = "No se ha ingresado Apellido Materno.")]
        public string vApeMat { get; set; }

        [DisplayName("Telf. Fijo")]
        [Required(ErrorMessage = "No se ha ingresado el n° Telefonico.")]
        public string iNumTelefonico { get; set; }
        
        [DisplayName("Sexo:")]
        public SelectList slSexo { get; set; }

        [DisplayName("Area:")]
        public SelectList slArea { get; set; }

        [DisplayName("Fecha Ingreso:")]
        [Required(ErrorMessage = "No se ha seleccionado el la Fecha Ingreso.")]
        public string dfFecha { get; set; }

    }
}