﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCall
{
    public class Service : IService
    {
        //Hosted web API REST Service base url
        string Baseurl = "https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/currencies/aud.json";
        public LinkedList<CurrencyModel> GetAll()
        {
            LinkedList<CurrencyModel> currencyModelList;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Baseurl);
            request.Method = "GET";
            String result = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            JObject jsonObj = JObject.Parse(result);
            var currencyJsonObj = jsonObj["aud"];
            Dictionary<string, decimal> unsortedDisctionary = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(currencyJsonObj.ToString());

            currencyModelList = new LinkedList<CurrencyModel>(unsortedDisctionary.Select(x => new CurrencyModel { CurrencyCode = x.Key, ExchangeValue = x.Value }).ToList());

            return currencyModelList;
        }
    }
}