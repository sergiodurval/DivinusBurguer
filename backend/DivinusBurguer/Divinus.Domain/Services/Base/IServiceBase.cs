﻿using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divinus.Domain.Services.Base
{
    public interface IServiceBase : INotifiable, IDisposable
    {
    }
}
