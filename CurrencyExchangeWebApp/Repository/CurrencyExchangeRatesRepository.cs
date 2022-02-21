using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceCall;

namespace CurrencyExchangeWebApp.Repository
{
    public class CurrencyExchangeRatesRepository : ICurrencyExchangeRatesRepository
    {
        private readonly IService _iService;
        public CurrencyExchangeRatesRepository(IService service)
        {
            _iService = service;
        }

        public LinkedList<CurrencyModel> GetAll()
        {
            return _iService.GetAll();
        }
    }
}