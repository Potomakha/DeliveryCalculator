using System;
using System.Linq;

namespace DeliveryCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Order date");
            var inputString = Console.ReadLine();
            var orderDate = DateTime.Parse(inputString);
            Console.WriteLine("Delivery date");
            Console.WriteLine(DeliveryTimeCalculation(orderDate).ToString("dd.MM.yyy HH:mm"));
            Console.ReadKey();
        }

        public static DateTime DeliveryTimeCalculation(DateTime orderTime)
        {
            var shedule = new DeliveryShedule();
            var deliveryTime = orderTime;

            if (shedule.Weekend.Contains((int)deliveryTime.DayOfWeek))
            {
                while (shedule.Weekend.Contains((int)deliveryTime.DayOfWeek))
                {
                    deliveryTime = deliveryTime.AddDays(1);
                }

                deliveryTime = new DateTime(deliveryTime.Year, deliveryTime.Month, deliveryTime.Day, shedule.StartHour, 00, 00);
            }

            if (deliveryTime.Hour < shedule.StartHour)
            {
                deliveryTime = new DateTime(deliveryTime.Year, deliveryTime.Month, deliveryTime.Day, shedule.StartHour, 00, 00);
            }

            if (deliveryTime.Hour > shedule.EndHour)
            {
                deliveryTime = deliveryTime.AddDays(1);
                deliveryTime = new DateTime(deliveryTime.Year, deliveryTime.Month, deliveryTime.Day, shedule.StartHour, 00, 00);
            }

            deliveryTime = deliveryTime.AddHours(48);
            return deliveryTime;
        }
    }
}
