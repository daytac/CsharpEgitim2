using CsharpEgitim2.BusinessLayer.Abstract;
using CsharpEgitim2.BusinessLayer.Concrete;
using CsharpEgitim2.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpEgitim2.PresentationLayer
{
    public partial class FrmProduct : Form
    {

        private readonly IProductService _productService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService=new ProductManager(new EfPRoductDal());
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource=values; 
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.GetProductsWithCategory();
            dataGridView1.DataSource=values;    
        }
    }
}
