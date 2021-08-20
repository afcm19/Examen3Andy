using PM2E3201720050023.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM2E3201720050023.Controller
{
    public class Cruds
    {

        Connexion conn = new Connexion();

        public Task<List<Pagos>> getReadPago()
        {
            return conn.GetConnectionAsync().Table<Pagos>().ToListAsync();
        }

        public Task<Pagos> getPagosid(int id)
        {
            return conn
                .GetConnectionAsync()
                .Table<Pagos>()
                .Where(item => item.Id_pago == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> getPagosUpdate(Pagos pagos)
        {
            return conn
                .GetConnectionAsync()
                .UpdateAsync(pagos);

        }

        public Task<int> Delete(Pagos pagos)
        {
            return conn
                .GetConnectionAsync()
                .DeleteAsync(pagos);
        }



    }
}
