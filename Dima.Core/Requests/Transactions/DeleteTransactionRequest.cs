﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Requests.Transactions
{
    public class DeleteTransactionRequest : BaseRequest
    {
        public long Id { get; set; }
    }
}
