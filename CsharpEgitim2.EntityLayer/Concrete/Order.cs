﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEgitim2.EntityLayer.Concrete
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId {  get; set; } 
        public Product Product { get; set; }
        public int Quantity {  get; set; }  
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int CustomerId {  get; set; }    

    }
}
