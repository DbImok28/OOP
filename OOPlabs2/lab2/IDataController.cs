﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    interface IDataController
    {
        void AddApartment(Apartment apartment);
        void AddAddress(Address address);
    }
}
