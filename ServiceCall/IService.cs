﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCall
{
    public interface IService
    {
        LinkedList<CurrencyModel> GetAll();
    }
}
