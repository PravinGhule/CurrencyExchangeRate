﻿using CurrencyExchangeWebApp.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CurrencyExchangeWebApp.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencyExchangeManager _iCurrencyExchangeManager;
        public CurrencyController(ICurrencyExchangeManager currencyExchangeManager)
        {
            _iCurrencyExchangeManager = currencyExchangeManager;
        }
        // GET: Currency
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetExchangeRates()
        {
            var result = _iCurrencyExchangeManager.GetAllCurrencyExchangeRates();
            return PartialView("_CurrencyExchangeRateGrid", result);
        }
    }
}