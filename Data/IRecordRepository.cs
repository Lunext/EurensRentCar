﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EurenRentCar.Data
{
    internal interface IRecordRepository<T>
    {
        T Create (T record);
        T Update (T record);
        void Delete (T record);
        List<T> View (bool all);
    }
}
