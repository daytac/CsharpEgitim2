﻿using CsharpEgitim2.BusinessLayer.Abstract;
using CsharpEgitim2.DataAccessLayer.EntityFramework;
using CsharpEgitim2.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEgitim2.BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly EfCustomerDal _customerDal;

        public CustomerManager(EfCustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public void TDelete(Customer entity)
        {
            _customerDal.Delete(entity);    
        }

        public List<Customer> TGetAll()
        {
            return _customerDal.GetAll();   
        }

        public Customer TGetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public void TInsert(Customer entity)
        {
            if (entity.CustomerName != "" && entity.CustomerName.Length >= 3 && entity.CustomerCity != null
                    && entity.CustomerSurname != "" && entity.CustomerName.Length <= 3)
            {
                _customerDal.Insert(entity);    
            }

            else
            {

            }
        }

        public void TUpdate(Customer entity)
        {
            if(entity.CustomerId!=0&&entity.CustomerCity.Length>=3)
            {
                _customerDal.Update(entity);
            }
            else
            {
                
            }
        }
    }
}
