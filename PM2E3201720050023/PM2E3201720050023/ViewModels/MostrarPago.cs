using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PM2E3201720050023.ViewModels
{
    public class MostrarPago : BaseViewMoldels
    {
  
        private int Id_Pago;
        private String Descripcion;
        private Double Monto;
        private Double Fecha;
        private Byte Photo;

        public int id_Pago
        {
            get { return id_Pago; }
            set { id_Pago = value; OnPropertyChanged(); }
        }

        public String descripcion
        {
            get { return descripcion; }
            set { descripcion = value; OnPropertyChanged(); }
        }

        public double monto
        {
            get { return monto; }
            set { monto = value; OnPropertyChanged(); }
        }

        public double fecha
        {
            get { return fecha; }
            set { fecha = value; OnPropertyChanged(); }
        }

        public ICommand LimpiarCommand { private get; set; }


        public MostrarPago()
        {
            LimpiarCommand = new Command(() => Limpiar());
        }

        void Limpiar()
        {
            id_Pago = 0;
            descripcion = String.Empty;
            monto = 0.0;
            fecha = 0;
        }

    }
    
}