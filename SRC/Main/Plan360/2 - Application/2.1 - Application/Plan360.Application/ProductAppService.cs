using System;
using System.Collections.Generic;
using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class ProductAppService : AppServiceBase<Product>, IProductAppService
    {
        private readonly IProductService _svc;

        public ProductAppService(IProductService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }


        public IEnumerable<Product> DoSearch(int? idBrand, int? idCategory, string strSearch)
        {
            return _svc.DoSearch(idBrand, idCategory, strSearch);
        }

  


    }
}
