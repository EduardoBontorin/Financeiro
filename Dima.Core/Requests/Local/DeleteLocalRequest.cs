using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Requests.Local
{
    public class DeleteLocalRequest : BaseRequest
    {
        public long Id { get; set; }
    }
}
