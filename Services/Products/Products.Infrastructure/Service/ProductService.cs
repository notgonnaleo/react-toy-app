using Azure;
using Microsoft.Extensions.Logging;
using Products.Domain.IService;
using Products.Domain.Model.Product;
using Products.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Service
{
    public class ProductService : IProductService
    {
        private readonly NightDbContext _context;
        private readonly ILogger<ProductService> _logger;

        public ProductService(NightDbContext context, ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<Product>> GetAll()
        {
            var response = new List<Product>();
            try
            {
                response = _context.Set<Product>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Product> Get(int TenantId, int ProductId)
        {
            var response = new Product();
            try
            {
                response = _context.Set<Product>().Where(x => x.ProductId == ProductId && x.TenantId == TenantId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<Product> Create(Product product)
        {
            try
            {
                int maxValue = _context.Set<Product>().Where(x => x.TenantId == product.TenantId).Max(x => x.ProductId); // Max product id value in the DB
                product.ProductId = maxValue++; // Auto-incremeting the product id

                // Looking it now i think i should had listen to Samuel's advice, this is piece of code is a fucking mess
                // Taking one GET request to do a POST is pathetic, I'm a damn clown for not going with Guid system.
                // TODO: For god's sake change this for Guid in the future.

                await _context.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return product;
        }

        public async Task<bool> Update(Product product)
        {
            try
            {
                _context.Update(product);
                var result = await _context.SaveChangesAsync(); // Return the amount of affect rows.
                if(result > 0)
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }

        public async Task<bool> Delete(int TenantId, int ProductId)
        {
            try
            {
                var response = _context.Set<Product>().Where(x => x.ProductId == ProductId && x.TenantId == TenantId).FirstOrDefault();
                if(response != null)
                {
                    response.Active = false;
                    _context.Update(response);
                    var result = await _context.SaveChangesAsync(); // Return the amount of affect rows.
                    if (result > 0)
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}