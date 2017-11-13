using Mantenimiento.CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimiento.CapaLogica
{
    class ControladorMantenimiento
    {
        public void LLenarDataGrid(DataGridView dtLLenar)
        {
            ConectorSQL c = new ConectorSQL();
            c.OpenConnection();
            DataTable data = c.informacion("Select * From reportehoteleria");
            dtLLenar.DataSource = data;
            c.CloseConnection();
        }

    }
}
