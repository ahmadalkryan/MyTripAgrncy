﻿using Domain.Entities.ApplicationEntities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CreatePaymentTransactionDto
    {

        public int PaymentId { get; set; }
        public int PaymentMethodId { get; set; }
        public TransactionTypeEnum TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
      //  public Payment? Payment { get; set; } // Navigation
      //    public PaymentMethod? paymentMethod { get; set; } // Navigat
    }
}
