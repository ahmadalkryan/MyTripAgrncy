﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.CarBooking
{
    public class CarBookingFilter
    {
        public int? BookingId { get; set; }
        public int? CarId { get; set; }
        public string? PickupLocation { get; set; }
        public string? DropoffLocation { get; set; }
        public bool? WithDriver { get; set; }
    }
}
