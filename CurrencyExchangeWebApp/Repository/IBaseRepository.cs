using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyExchangeWebApp.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        LinkedList<T> GetAll();
    }
}