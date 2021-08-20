using PM2E3201720050023.Controller;
using PM2E3201720050023.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PM2E3201720050023.ViewModels
{
    class PagosViewModels : BaseViewMoldels
    {

        Connexion conn = new Connexion();
        Cruds crud = new Cruds();


        private int Id_pago;
        private string Descripcion;
        private double Monto;
        private double Fecha;
        private byte Photo;


        public int id_pago
        {
            get { return Id_pago; }
            set { Id_pago = value; OnPropertyChanged(); }
        }
        public string descripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; OnPropertyChanged(); }
        }
        public double monto
        {
            get { return Monto; }
            set { Monto = value; OnPropertyChanged(); }
        }

        public double fecha
        {
            get { return Fecha; }
            set { Fecha = value; OnPropertyChanged(); }
        }

        public byte photo
        {
            get { return Photo; }
            set { Photo = value; OnPropertyChanged(); }
        }

        public async void Guardar()
        {
          
            if (string.IsNullOrEmpty(descripcion))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de Descripcion vacio", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(monto.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de Monto vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(fecha.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de Fecha vacio", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(photo.ToString()))
            {
                await App.Current.MainPage.DisplayAlert("Alerta", "Campo de Recibo vacio", "Ok");
                return;
            }

            var pagos = new Pagos()
            {
                Id_pago = id_pago,
                Descripcion = descripcion,
                Monto = monto,
                Fecha = fecha,
                
            };

            try
            {


                conn.Conn().CreateTable<Pagos>();
                conn.Conn().Insert(pagos);
                conn.Conn().Close();

                await App.Current.MainPage.DisplayAlert("Success", "Datos Guardados", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new Home());


            }
            catch (SQLiteException)
            {
               
            }
        }

        public ICommand ClearCommand { private set; get; }
        public ICommand SendEmailCommand { private set; get; }

        public PagosViewModels()
        {
            ClearCommand = new Command(() => Clear());

        }


        public ICommand GuardarCommand
        {
            get { return new Command(() => Guardar()); }
        }
        public ICommand DeleteCommand { get { return new Command(() => eliminar()); } }
        public ICommand UpdateCommand { get { return new Command(() => actualizar()); } }


        void Clear()
        {
            descripcion = string.Empty;
            monto = 0;
            fecha = 0;
        }

        async void eliminar()
        {
            var pagos = await crud.getPagosid(Convert.ToInt32(id_pago));
            bool conf = await App.Current.MainPage.DisplayAlert("Delete", "Eliminar Pagos", "Accept", "Cancel");
            if (conf)
            {
                if (pagos != null)
                {
                    await crud.Delete(pagos);
                    await App.Current.MainPage.DisplayAlert("Delete", "Datos Eliminados", "ok");
                    Clear();
                    await App.Current.MainPage.Navigation.PopModalAsync();

                }
            }
        }

        

        async void actualizar()
        {
            bool conf = await App.Current.MainPage.DisplayAlert("Update", "Actualizar datos de Pagos", "Accept", "Cancel");
            if (conf)
            {
                if (!string.IsNullOrEmpty(id_pago.ToString()))
                {
                    Pagos update = new Pagos
                    {
                        Id_pago = Convert.ToInt32(id_pago.ToString()),
                        Descripcion = descripcion,
                        Monto = Convert.ToDouble(monto),
                        Fecha = Convert.ToDouble(fecha),
                       
                    };
                    await crud.getPagosUpdate(update);
                    await App.Current.MainPage.DisplayAlert("Update", "Datos Actualizados", "ok");
                    await App.Current.MainPage.Navigation.PopModalAsync();

                }
            }
        }
    }
}
