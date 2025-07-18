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
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService; 

        public FrmCategory ()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource=categoryValues;    
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtCategoryId.Text);
            var deletedValues = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Silme başarılı");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedId=int.Parse(txtCategoryId.Text);    
            var updatedValue=_categoryService.TGetById(updatedId);  
            updatedValue.CategoryName = txtCategoryName.Text;   
            updatedValue.CategoryStatus = true; 
            _categoryService.TUpdate(updatedValue);
            MessageBox.Show("Güncelleme başarılı");
        }
    }
}
