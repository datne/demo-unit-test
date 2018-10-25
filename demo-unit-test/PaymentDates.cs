using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo_unit_test
{
   public class PaymentDates
    {
        public DateTime CalculateFuturePaymentDate(DateTime startDate)
        {
            var tempDate = startDate.AddDays(30);
            switch(tempDate.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    tempDate = tempDate.AddDays(2);
                    break;
                case DayOfWeek.Sunday:
                    tempDate = tempDate.AddDays(1);// error if AddDays(3)
                    break;
            }
            return tempDate;
        }
    }
}
