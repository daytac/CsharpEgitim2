﻿using CsharpEgitim2.BusinessLayer.Abstract;
using CsharpEgitim2.BusinessLayer.Concrete;
using CsharpEgitim2.DataAccessLayer.EntityFramework;
using CsharpEgitim2.EntityLayer.Concrete;
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
        private readonly ICategoryService _categoryService; 
        public FrmProduct()
        {
            InitializeComponent();
            _productService=new ProductManager(new EfPRoductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.CategoryId=int.Parse(cmbCategory.SelectedValue.ToString());
            product.ProductPrice=decimal.Parse(txtProductPrice.Text);   
            product.ProductName=txtProductName.Text;    
            product.ProductDescription=txtDescription.Text; 
            product.ProductStock=int.Parse(txtProductStock.Text);   
            _productService.TInsert(product);
            MessageBox.Show("Ekleme yapıldı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtProductId.Text);
            var value=_productService.TGetById(id); 
            _productService.TDelete(value);
            MessageBox.Show("silme işlemi");

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            dataGridView1.DataSource = value;   
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtProductId.Text);
            var value = _productService.TGetById(id);
            value.CategoryId=int.Parse(cmbCategory.SelectedValue.ToString()) ;  
            value.ProductDescription = txtDescription.Text;
            value.ProductPrice= decimal.Parse(txtProductPrice.Text);    
            value.ProductStock= int.Parse(txtProductStock.Text);    
            value.ProductName= txtProductName.Text; 
            _productService.TUpdate(value);
            MessageBox.Show("güncellendi");
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            var values=_categoryService.TGetAll();  
            cmbCategory.DataSource= values; 
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";  
        }
    }
}
