using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E3201720050023.Models
{
    public class Pagos
    {
        [PrimaryKey, AutoIncrement]
        public int Id_pago { get; set; }
        public String Descripcion { get; set; }
        public Double Monto { get; set; }
        public Double Fecha { get; set; }
        public Byte Photo_recibo { get; set; }


    }
}
