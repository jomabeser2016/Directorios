using SAT.SIAT.Model.GA.Persona;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EjemploMVC.Models 
{
    public class ConsultaPersona
    {        
        [DisplayName("Nombre:")]        
        public string vNomPer { get; set; }

        [DisplayName("Sexo:")]
        public SelectList vSexo { get; set; }
    }
}