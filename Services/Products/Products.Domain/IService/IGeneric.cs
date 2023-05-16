using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.IService
{
    public interface IGeneric<T>
    {
        // Default interface methods
        Task<List<T>> GetAll();
        Task<T> Get(int key1, int key2);
        Task<T> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int key1, int key2);

    }

    // FYI: If we ever need to create a more specific signature or method to use 
    // we are going to create it direct in the wanted service's interface instead 
    // of creating it here. The reason for that is cause we don't want to make this a mess.
    // only basic methods like simple GETs and POSTs methods are allowed here, if there's any 
    // minimal bussiness logic on it we want that in a more specific layer, not here.
}
