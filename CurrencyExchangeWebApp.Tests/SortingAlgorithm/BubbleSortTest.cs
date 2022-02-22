using CurrencyExchangeWebApp.SortingAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceCall;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchangeWebApp.Tests.SortingAlgorithm
{
    [TestClass]
    public class BubbleSortTest
    {
        [TestMethod]
        public void Test_Sort()
        {
            //Arange
            List<CurrencyModel> inputCurrencyModelList = new List<CurrencyModel> {
                new CurrencyModel { CurrencyCode = "inr",ExchangeValue=20},
                new CurrencyModel { CurrencyCode = "aud",ExchangeValue=40},
                new CurrencyModel { CurrencyCode = "usd",ExchangeValue=10},
                new CurrencyModel { CurrencyCode = "jpy",ExchangeValue=30},
                new CurrencyModel { CurrencyCode = "ves",ExchangeValue=10}};

            List<CurrencyModel> expectedCurrencyModelList = new List<CurrencyModel> {
                new CurrencyModel { CurrencyCode = "aud",ExchangeValue=40},
                new CurrencyModel { CurrencyCode = "jpy",ExchangeValue=30},
                new CurrencyModel { CurrencyCode = "inr",ExchangeValue=20},
                new CurrencyModel { CurrencyCode = "usd",ExchangeValue=10},
                new CurrencyModel { CurrencyCode = "ves",ExchangeValue=10}};

            LinkedList<CurrencyModel> expectedCurrencyModels = new LinkedList<CurrencyModel>(expectedCurrencyModelList);
            LinkedList<CurrencyModel> inputCurrencyModels = new LinkedList<CurrencyModel>(inputCurrencyModelList);

            //Act
            BubbleSort bubbleSort = new BubbleSort();
            LinkedList<CurrencyModel> result = bubbleSort.Sort(inputCurrencyModels);

            //Assert
            Assert.IsTrue(expectedCurrencyModels.Count().Equals(result.Count()));

            int min = 1;
            int max = result.Count();

            LinkedListNode<CurrencyModel> expectedCurrentNode = expectedCurrencyModels.First;
            LinkedListNode<CurrencyModel> resultCurrentNode = result.First;

            while (min <= max)
            {
                if(expectedCurrentNode !=null && resultCurrentNode != null)
                {
                    Assert.AreEqual(expectedCurrentNode.Value.CurrencyCode, resultCurrentNode.Value.CurrencyCode);
                    Assert.AreEqual(expectedCurrentNode.Value.ExchangeValue, resultCurrentNode.Value.ExchangeValue);
                }
                expectedCurrentNode = expectedCurrentNode.Next;
                resultCurrentNode = resultCurrentNode.Next;
                min++;
            }
        }
    }
}
