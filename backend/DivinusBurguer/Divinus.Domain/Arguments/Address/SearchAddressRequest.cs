﻿using Divinus.Domain.Interfaces.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Arguments.Address
{
    public class SearchAddressRequest : IRequest
    {
        public string ZipCode { get; set; }
    }
}
