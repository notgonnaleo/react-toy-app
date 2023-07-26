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

        public async Task<Product> Get(Guid TenantId, Guid ProductId)
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
                product.ProductId = product.GenerateGuid();
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

        public async Task<bool> Delete(Guid TenantId, Guid ProductId)
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