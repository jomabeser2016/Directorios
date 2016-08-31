using SAT.Libreria.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAT.SIAT.Model.GA.Persona
{
    public class Persona : Pagina
    {
        public int iCodPer { get; set; }
        public string vNomPer { get; set; }
        public string vApePat { get; set; }
        public string vApeMat { get; set; } 
        public int iNumTelefonico { get; set; }
        public string vSexo { get; set; }
        public string vArea { get; set; }
        public string sdFecha { get; set; }
    }
}
