using CsharpEgitim2.DataAccessLayer.Abstract;
using CsharpEgitim2.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEgitim2.BusinessLayer.Abstract
{
    public interface ICategoryService: IGenericService<Category>
    {
    }
}
