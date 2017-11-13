using Mantenimiento.CapaLogica;
using Navegador.Utilidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimiento.CapaPresentacion
{
    public partial class FormMantemiento : Form
    {
        public FormMantemiento()
        {
            InitializeComponent();
        }

        private void FormMantemiento_Load(object sender, EventArgs e)
        {
            ControladorMantenimiento cm = new ControladorMantenimiento();
            cm.LLenarDataGrid(dataGridView1);
        }

        private void navegador1_RecibidorInsertar(object sender, EventArgs e)
        {
            string bd = navegador1.sNombreBD;
            string server = navegador1.sServidor;
            string user = navegador1.sUsuario;
            string pass = navegador1.sPass;
            string nametabla = navegador1.sNombreTabla;

            String campo1 = comboBox1.Text;
            String campo2 = comboBox2.Text;
            String campo3 = dateTimePicker1.Text;
            String campo4 = textBox1.Text;

           
            ArrayList listavalores = new ArrayList();
            ArrayList listacampos = new ArrayList();


            listavalores.Add(0);
            listavalores.Add(1);
            listavalores.Add(2);
            listavalores.Add(campo4);
            listavalores.Add(campo3);
           

            listacampos.Add("idreportehoteleria");
            listacampos.Add("descripcionmantenimiento_idDescripcion");
            listacampos.Add("empleado_idEmpleado");
            listacampos.Add("descripcion");
            listacampos.Add("fecha");



            GeneradorSQL gsql = new GeneradorSQL(server, bd, user, pass, nametabla);
            gsql.setCodigoInstDML(1);
            gsql.setCampos(listacampos);
            gsql.setValores(listavalores);
            gsql.ejecutar();
        }

        private void navegador1_RecibidorActualizar(object sender, EventArgs e)
        {
            ControladorMantenimiento cm = new ControladorMantenimiento();
            cm.LLenarDataGrid(dataGridView1);
        }
    }
}
