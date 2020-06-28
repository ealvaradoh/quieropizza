using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuieroPizza.Win
{
    public partial class frmProductos : Form
    {
        Contexto _contexto;
        public frmProductos()
        {
            _contexto = new Contexto();
            InitializeComponent();

            var productosBL = new ProductosBL();
            productoBindingSource.DataSource = productosBL.ObtenerProductos(); 
        }
    }
}
