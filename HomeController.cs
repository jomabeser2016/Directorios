using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using SAT.Libreria.Model;
using SAT.SIAT.App.Servicios.Bus;
using SAT.SIAT.Model.GA.Persona;
using SAT.SIAT.Model.GA.Persona.Filtros;
using SAT.Libreria.Log;
using EjemploMVC.Models;
using SAT.Libreria.JavaScript;

namespace EjemploMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
           ConsultaPersona obj = new ConsultaPersona();
            try {
                obj.vSexo = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>(), "Valor", "Texto", "", "Seleccione uno...");

                //ViewBag.lst = new List<Persona>();                
                //return View();                
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return RedirectToAction("Error400", "Error");
            }
            return View(obj);
        }

         
        [HttpPost]
        public JsonResult ListarPersonas(int page, int rows, string sidx, string sord, bool _search, string dato)
        {
            FiltroPersona obj = new FiltroPersona();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<FiltroPersona> lstFiltroPersona;
            JQGrid objGrid = new JQGrid();

            try
            {
                lstFiltroPersona = jss.Deserialize<List<FiltroPersona>>(dato);
                obj = lstFiltroPersona[0];

                objGrid = new PersonaServicio().ListarPersonas(obj);
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(objGrid, JsonRequestBehavior.AllowGet);
        }

        public FilePathResult obtenerRutaJson(string nombreControl)
        {
            string strFile = "";
            try
            {

                switch (nombreControl)
                {
                  case "vSexo":
                        strFile = "/Json/Sexo.json";
                        break;
                }
            }
            catch (Exception ex)
            { }

            return File(strFile, "text/x-json");
        }


    }
}