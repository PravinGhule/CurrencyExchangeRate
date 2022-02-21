using ServiceCall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyExchangeWebApp.SortingAlgorithm
{
    public class BubbleSort : IBubbleSort
    {
        public LinkedList<CurrencyModel> Sort(LinkedList<CurrencyModel> unsortedData)
        {
            int maxIteration = unsortedData.Count();
            int minIteration = 1;
            int minCounter = 1;
            int maxCounter = unsortedData.Count();

            while (minIteration < maxIteration)
            {
                LinkedListNode<CurrencyModel> currentNode = unsortedData.First;
                LinkedListNode<CurrencyModel> nextNode = null;

                while (minCounter < (maxCounter - minIteration + 1))
                {
                    if (currentNode.Next != null)
                    {
                        nextNode = currentNode.Next;

                        if (currentNode.Value.ExchangeValue < nextNode.Value.ExchangeValue ||
                            (currentNode.Value.ExchangeValue == nextNode.Value.ExchangeValue &&
                            (string.Compare(currentNode.Value.CurrencyCode, nextNode.Value.CurrencyCode) > 0)))
                        {
                            currentNode.List.Remove(currentNode);
                            nextNode.List.AddAfter(nextNode, currentNode);
                        }
                        else
                        {
                            currentNode = currentNode.Next;
                        }
                    }
                    minCounter++;
                }
                minCounter = 1;
                minIteration++;
            }

            var sortedData = unsortedData;

            return sortedData;
        }
    }
}