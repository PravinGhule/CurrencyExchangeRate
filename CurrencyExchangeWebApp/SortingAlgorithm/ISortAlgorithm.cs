using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceCall;

namespace CurrencyExchangeWebApp.SortingAlgorithm
{
    public interface ISortAlgorithm<T> where T : class
    {
        LinkedList<T> Sort(LinkedList<T> unsortedData);
    }
}
