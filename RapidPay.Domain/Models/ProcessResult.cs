using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidPay.Domain.Models
{
    public class ProcessResult
    {
        public Guid? TransactionId { get; set; }
        public bool IsSuccess { get; set; }
    }
}
