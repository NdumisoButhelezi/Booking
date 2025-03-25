using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace anele.Models
{
    public class Booking
    {
        public int NumberOfGuests { get; set; }
        public int NumberOfNights { get; set; }
        public decimal PricePerPersonPerNight { get; set; }
        private const decimal VAT_RATE = 0.15m; // 15% VAT

        // Method to calculate total before VAT
        public decimal CalculateTotalBeforeVAT()
        {
            decimal discount = 0;

            if (NumberOfNights > 3)
            {
                discount = (NumberOfGuests * PricePerPersonPerNight) / 2; // Half price for one night per guest
            }

            return (NumberOfGuests * NumberOfNights * PricePerPersonPerNight) - discount;
        }

        // Method to calculate VAT amount
        public decimal CalculateVAT()
        {
            return CalculateTotalBeforeVAT() * VAT_RATE;
        }

        // Method to calculate total amount including VAT
        public decimal CalculateTotalAfterVAT()
        {
            return CalculateTotalBeforeVAT() + CalculateVAT();
        }
    }

}