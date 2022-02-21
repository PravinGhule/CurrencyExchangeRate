using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurrencyExchangeWebApp.Repository;
using CurrencyExchangeWebApp.SortingAlgorithm;
using ServiceCall;

namespace CurrencyExchangeWebApp.Manager
{
    public class CurrencyExchangeManager : ICurrencyExchangeManager
    {
        private readonly ICurrencyExchangeRatesRepository _iCurrencyExchangeRatesRepository;
        private readonly IBubbleSort _iBubbleSort;
        public CurrencyExchangeManager(ICurrencyExchangeRatesRepository currencyExchangeRatesRepository, IBubbleSort bubbleSort)
        {
            _iCurrencyExchangeRatesRepository = currencyExchangeRatesRepository;
            _iBubbleSort = bubbleSort;
        }
        public LinkedList<CurrencyModel> GetAllCurrencyExchangeRates()
        {
            var currencyExchangeRateList = _iCurrencyExchangeRatesRepository.GetAll();
            var sortedCurrencyExchangeRateList = _iBubbleSort.Sort(currencyExchangeRateList);
            return sortedCurrencyExchangeRateList;
        }
    }
}