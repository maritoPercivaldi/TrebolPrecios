using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TrebolPrecios
{
    public partial class Form1 : Form
    {
        private List<Productos> listaProductos;
        public Form1()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            ProductosNegocio negocio = new ProductosNegocio();
            try
            {
                listaProductos = (List<Productos>)negocio.listar();
                dgvProductos.DataSource = listaProductos;
                dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        
    }
}
