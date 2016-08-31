using SAT.Libreria;
using SAT.Libreria.Model;
using SAT.Libreria.Web.Error;
using SAT.Libreria.Web.Servicio;
using SAT.SIAT.Model.GA.Persona;
using SAT.SIAT.Model.GA.Persona.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SAT.SIAT.App.Servicios.Bus
{
    public class ListaPersona
    {
        public List<Persona> Lista = new List<Persona>();

        private static ListaPersona instance;

        private ListaPersona() 
        {
            Persona persona;

            persona = new Persona();
            persona.iCodPer = 1;
            persona.vNomPer = "Ronald";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "M";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
                
               
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 2;
            persona.vNomPer = "Pedro";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "M";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 3;
            persona.vNomPer = "Lucia";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "F";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 4;
            persona.vNomPer = "Edgard";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "M";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 5;
            persona.vNomPer = "Jhon";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "M";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 6;
            persona.vNomPer = "Omar";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "M";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 7;
            persona.vNomPer = "Juana";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "F";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 8;
            persona.vNomPer = "Carmín";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "F";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 9;
            persona.vNomPer = "Luciano";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "M";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 10;
            persona.vNomPer = "Luciano";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "M";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 11;
            persona.vNomPer = "Giancarlo";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "M";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);

            persona = new Persona();
            persona.iCodPer = 12;
            persona.vNomPer = "David";
            persona.vApePat = "Apellido 1";
            persona.vApeMat = "Apellido 2";
            persona.iNumTelefonico = 4521452;
            persona.vSexo = "M";
            persona.vArea = "Administracion";
            persona.sdFecha = "01/08/2016";
            Lista.Add(persona);
        }

        public static ListaPersona Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ListaPersona();
                }
                return instance;
            }
        }
    }

    public class PersonaServicio
    {
        ListaPersona listaPersona = ListaPersona.Instance; 

        public ICacheProvider Cache { get; set; }
        public PersonaServicio() : this(new CacheProvider())
		{
            
        }

        public PersonaServicio(ICacheProvider cacheProvider)
        {
            this.Cache = cacheProvider;            
        }

        public JQGrid ListarPersonas(FiltroPersona objFiltroPersona)
        {
            JQGrid objJQGrid = new JQGrid();
            List<Persona> lst = new List<Persona>();
            try
            {                
                lst = LlenarListaPersonas(objFiltroPersona);

                List<string> lstCampos = new List<string>();
                lstCampos.Add("iCodPer");
                lstCampos.Add("vNomPer");
                lstCampos.Add("vApePat");
                lstCampos.Add("vApeMat");
                lstCampos.Add("iNumTelefonico");
                lstCampos.Add("vSexo");
                lstCampos.Add("vArea");
                lstCampos.Add("sdFecha");

                objJQGrid = SAT.Libreria.JavaScript.JQuery.ListJQGrid<Persona>(lst, lstCampos, TipoAdministracionPaginacion.PorClase);

                return objJQGrid;
            }
            catch (WebException e)
            {
                Excepcion excepcion = new Excepcion();
                excepcion = ExcepcionWeb.ProcesarExcepcion(e);

                throw new Exception(excepcion.Identificador + ": " + excepcion.Description);
            }
            catch
            {
                throw;
            }

        }

        public List<Persona> LlenarListaPersonas(FiltroPersona objFiltroPersona)
        {
            List<Persona> lstPersonaResultado = new List<Persona>();            

            try
            {

                if (objFiltroPersona != null)
                {
                    if (objFiltroPersona.vNomPer != "")
                    {
                        string vNomPer = objFiltroPersona.vNomPer;
                        lstPersonaResultado = (List<Persona>)listaPersona.Lista.Where(person => person.vNomPer == vNomPer).ToList();
                    }
                    if (objFiltroPersona.vSexo != null)
                    {
                        string vSexo = objFiltroPersona.vSexo;
                        lstPersonaResultado = (List<Persona>)listaPersona.Lista.Where(person => person.vSexo == vSexo).ToList();
                    }
                    else
                    {
                        lstPersonaResultado = listaPersona.Lista;
                    }
                }
                else {
                    lstPersonaResultado = listaPersona.Lista;
                }

            }
            catch {
                throw;
            }

            return lstPersonaResultado;
        }

        public void RegistrarPersonas(Persona persona)
        {
            try
            {
                int iCodPer = listaPersona.Lista.Count() + 1;
                persona.iCodPer = iCodPer;
                listaPersona.Lista.Add(persona);
            }
            catch (WebException e)
            {
                Excepcion excepcion = new Excepcion();
                excepcion = ExcepcionWeb.ProcesarExcepcion(e);

                throw new Exception(excepcion.Identificador + ": " + excepcion.Description);
            }
            catch
            {
                throw;
            }
        }

    }
}
