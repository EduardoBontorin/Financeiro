﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Requests
{
    public abstract class BaseRequest
    {
        public string UserId { get; set; } = string.Empty;
    }
}
