using Application.Common;
using Domain.Entities.ApplicationEntities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
     public class PaymentTransactionDto:BaseDto<int>
    {
        public TransactionTypeEnum TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
       // public Payment payment { get; set; } // Navigation
        //public PaymentMethod? PaymentMethod { get; set; } // Navigat
    }
}
