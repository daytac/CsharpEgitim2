using CsharpEgitim2.BusinessLayer.Abstract;
using CsharpEgitim2.DataAccessLayer.Abstract;
using CsharpEgitim2.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEgitim2.BusinessLayer.Concrete
{
    internal class OrderMAnager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderMAnager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public void TDelete(Order entity)
        {
            
            _orderDal.Delete(entity);   
        }

        public List<Order> TGetAll()
        {
            return _orderDal.GetAll();  
        }

        public Order TGetById(int id)
        {
            return _orderDal.GetById(id);
        }

        public void TInsert(Order entity)
        {
            _orderDal.Insert(entity);
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}
