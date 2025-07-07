﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEgitim2.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId {  get; set; }
        public string CategoryName { get; set; }
        public string CategoryStatus { get; set; }
        public List<Product> Products { get; set; } 
    }
}
