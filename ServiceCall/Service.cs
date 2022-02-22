using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        string Baseurl = ConfigurationManager.AppSettings["serviceURL"];
        public LinkedList<CurrencyModel> GetAll()
        {
            LinkedList<CurrencyModel> currencyModelList;

            try
            {
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

                if (!string.IsNullOrWhiteSpace(result))
                {
                    JObject jsonObj = JObject.Parse(result);
                    var currencyJsonObj = jsonObj["aud"];
                    Dictionary<string, decimal> unsortedDisctionary = JsonConvert.DeserializeObject<Dictionary<string, decimal>>(currencyJsonObj.ToString());

                    currencyModelList = new LinkedList<CurrencyModel>(unsortedDisctionary.Select(x => new CurrencyModel { CurrencyCode = x.Key, ExchangeValue = x.Value }).ToList());
                }
                else
                {
                    currencyModelList = new LinkedList<CurrencyModel>();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return currencyModelList;
        }
    }
}
