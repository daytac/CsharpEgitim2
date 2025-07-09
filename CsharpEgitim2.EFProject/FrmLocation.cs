using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace CsharpEgitim2.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelEntities db=new EgitimKampiEfTravelEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values=db.Location.ToList();
            dataGridView1.DataSource = values;  
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var updateValue = db.Location.Find(id);
            updateValue.DayNight=txtDayNight.Text;  
            updateValue.Price=decimal.Parse(txtPrice.Text); 
            updateValue.Capasity=byte.Parse(nudCapacity.Value.ToString());
            updateValue.City=txtCity.Text;
            updateValue.Country=txtCountry.Text;    
            updateValue.GuideId=int.Parse(cbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var delectedValue = db.Location.Find(id);
            db.Location.Remove(delectedValue);
            db.SaveChanges();
            MessageBox.Show("Silme işlemi başarılı");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.Capasity=byte.Parse(nudCapacity.Value.ToString());
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight=txtDayNight.Text;
            location.GuideId= int.Parse(cbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Ekleme işlemi başarılı");

        }

        private void btnGetById_Click(object sender, EventArgs e)
        {

        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values =db.Guide.Select(x => new 
            { 
                FullName=x.GuideName +" "+ x.GuideSurname,x.GuideId
            }).ToList();
            cbGuide.DisplayMember = "FullName";   
            cbGuide.ValueMember = "GuideId";
            cbGuide.DataSource = values;
        }
    }
}
