﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEgitim2.EntityLayer.Concrete
{
    public class Customer
    {
        public int CustomerId { get; set; } 
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerDistric {  get; set; }    
        public string CustomerCity {  get; set; }   
        public List<Order> Orders { get; set;}
        public bool CustomerStatus {  get; set; }   

    }
}
