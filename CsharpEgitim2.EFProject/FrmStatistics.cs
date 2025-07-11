using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpEgitim2.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelEntities db=new EgitimKampiEfTravelEntities();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            lblLocationCount.Text = db.Location.Count().ToString(); //toplam lokasyon sayısı
            lblSumCapacity.Text = db.Location.Sum(x=>x.Capasity).ToString(); //toplam kapasite sayisi
            lblGuideCount.Text = db.Location.Count().ToString(); //Rehber sayısı
            lblAvgCapacity.Text = db.Location.Average(x => (decimal?)x.Capasity)?.ToString("0.00"); //ortalama kapasite
            lblAvgLocationPrice.Text=db.Location.Average(x=>(decimal?)x.Price)?.ToString("0.00")+ "₺"; //ortalama tur fiyatı

            int lastCountryId = db.Location.Max(x => x.LocationId); //eklenen son ülke
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblKapadokyaCapacity.Text=db.Location.Where(x=>x.City=="Kapadokya").Select(y => y.Capasity).
                FirstOrDefault().ToString();//kapadokya turunun kapasitesi
            lblTurkeyCapasityAvg.Text=db.Location.Where(x=>x.Country=="Türkiye").
                Average(y=>y.Capasity).ToString();//türkiye turları ortalama kapasite 

            var romaGuideId = db.Location.Where(x => x.City == "Roma").Select(y=>y.GuideId).FirstOrDefault();
            lblRomaGuideName.Text = db.Guide.Where(x => x.GuideId == romaGuideId).
                Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();//roma gezi rehberi 

            var maxCapacity = db.Location.Max(x => x.Capasity);//max kapasiteli tur
            lblMaxCapacityLocation.Text=db.Location.Where(x=>x.Capasity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();    

            var maxPrice=db.Location.Max(x=>x.Price);//en pahalı tur
            lblMaxPriceLocation.Text=db.Location.Where(x=>x.Price==maxPrice).Select(y=>y.Price).FirstOrDefault().ToString();

            var guideIdByNameAysegulCınar = db.Guide.Where(x => x.GuideName == "Ayşegül" && x.GuideSurname =="Çınar")
                .Select(y=>y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text=db.Location.Where(x=>x.GuideId==guideIdByNameAysegulCınar).Count().ToString();   

        }

    }
}
