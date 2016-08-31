using EjemploMVC.Models;
using SAT.Libreria.JavaScript;
using SAT.Libreria.Log;
using SAT.Libreria.Model;
using SAT.SIAT.App.Servicios.Bus;
using SAT.SIAT.Model.GA.Persona;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace EjemploMVC.Controllers
{
    public class RegistroPersonaController : Controller
    {
        // GET: RegistroPersona
        public ActionResult Index()
        {
            RegistroPersona obj = new RegistroPersona();
            try {
                obj.slArea = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>() , "Valor", "Texto", "", "Seleccione una...");
                obj.slSexo = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>(), "Valor", "Texto", "", "Seleccione uno...");

                //return View(obj);

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return RedirectToAction("Error400", "Error");
            }
            return View(obj);
        }

        public FilePathResult obtenerRutaJson(string nombreControl)
        {
            string strFile = "";
            try
            {
               
                switch (nombreControl)
                {
                    case "slArea":
                        strFile = "/Json/Area.json";
                        break;
                    case "slSexo":
                        strFile = "/Json/Sexo.json";
                        break;
                }
            }
            catch (Exception ex)
            { }

            return File(strFile, "text/x-json");
        }

        [HttpPost]
        public JsonResult RegistrarPersona(string dato)
        {
            Persona obj = new Persona();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<Persona> lstPersona;

            string resultado = "";

            try
            {                
                lstPersona = jss.Deserialize<List<Persona>>(dato);
                obj = lstPersona[0];

                new PersonaServicio().RegistrarPersonas(obj);

                resultado = "Se realizó el registro con éxito";
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(resultado);
        }
    }
}