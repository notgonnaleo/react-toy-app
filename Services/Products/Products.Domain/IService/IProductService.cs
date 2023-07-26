using Products.Domain.IService.Core;
using Products.Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.IService
{
    public interface IProductService : IGeneric<Product>
    {
        // Use this layer to create any method that relay on some bussiness logic onto it.
    }
}
