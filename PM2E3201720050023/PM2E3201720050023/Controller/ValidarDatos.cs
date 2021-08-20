using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E3201720050023.Controller
{
    public class ValidarDatos
    {
        bool respuesta;
        public bool validarpago(string descripcion, double monto, double fecha, byte photo_recibo)
        {

            respuesta = (descripcion == null || monto.Equals("") || fecha.Equals("") || photo_recibo.Equals(""));

            return respuesta;
        }




    }
}
