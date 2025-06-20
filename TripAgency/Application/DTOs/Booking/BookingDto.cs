﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common;
using Domain.Entities.ApplicationEntities;
using Domain.Enum;

namespace Application.DTOs.Booking
{
    public class BookingDto : BaseDto<int>
    {
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long EmployeeId { get; set; }
        public string BookingType { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public BookingStatusEnum Status { get; set; }  
        public int NumOfPassengers { get; set; }
    }
}
