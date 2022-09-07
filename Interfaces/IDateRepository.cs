﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace InterfacesDomain
{
    public interface IDateRepository
    {
        public Task<Date> GetDateAsync(int dateNumber);
    }
}
