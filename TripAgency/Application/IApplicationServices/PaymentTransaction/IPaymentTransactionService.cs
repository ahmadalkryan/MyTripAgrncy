﻿using Application.Common;
using Application.DTOs;
using Application.DTOs.PaymentMethod;
using Application.DTOs.PaymentTransaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IApplicationServices.PaymentTransaction
{
    public interface IPaymentTransactionService
    {
        Task<IEnumerable<PaymentTransactionDto>> GetPaymentTransactionsAsync();
        Task<PaymentTransactionDto> GetPaymentTransactionByIdAsync(BaseDto<int> dto);
        Task<PaymentTransactionDto> CreatePaymentTransactionAsync(CreatePaymentTransactionDto createPaymentTranDto);
        Task<PaymentTransactionDto> UpdatePaymentTransaction(UpdatePaymentTransactionDto updatePaymentTranDto);
        Task<PaymentTransactionDto> DeletePaymentTransactionAsync(BaseDto<int> dto);
        Task<IEnumerable<PaymentTransactionDto>> GetPaymentTransactionForPayment(BaseDto<int> dto);
        Task<IEnumerable<PaymentTransactionDto>> GetPaymentTransactionDtosByMethod(BaseDto<int> dto);
       
    }
}
