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
    public partial class Form1 : Form
    {
        private readonly ICategoryService _categoryService; 

        public Form1 ()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource=categoryValues;    
        }
    }
}
