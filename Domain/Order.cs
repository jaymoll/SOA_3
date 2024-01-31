using Domain.Enum;
using Newtonsoft.Json;
using System.Text;

namespace Domain
{
    public class Order
    {
        [JsonProperty]
        private int OrderNr { get; set; }

        [JsonProperty]
        private bool IsStudentOrder { get; set; }

        [JsonProperty]
        private List<MovieTicket> Tickets { get; set; } = new List<MovieTicket>();

        [JsonProperty]
        private double TotalPrice { get; set; }

        public Order(int orderNr, bool isStudentOrder)
        {
            OrderNr = orderNr;
            IsStudentOrder = isStudentOrder;
        }

        public int GetOrderNr()
        {
            return OrderNr;
        }

        public void AddSeatReservation(MovieTicket movieTicket)
        {
            Tickets.Add(movieTicket);
        }

        public double CalculatePrice()
        {
            var prices = new List<double>();
            if (IsStudentOrder)
            {
                prices = CalculateStudentOrderPrices();
            }
            else
            {
                Tickets.ForEach(ticket => prices.Add(ticket.GetPrice()));

                for (int i = 1; i < prices.Count; i++)
                {
                    if (i % 2 == 0 && IsWeekDay(Tickets[i].Screening.GetDateAndTime()))
                    {
                        prices.Remove(i);
                    }
                }
            }

            if (Tickets.Count >= 6 && !IsStudentOrder && !IsWeekDay(Tickets.First().Screening.GetDateAndTime()))
            {
                return prices.Sum() * 0.9;
            }
            else
            {
                return prices.Sum();
            }


        }

        public async Task Export(TicketExportFormat exportFormat)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Order number: " + GetOrderNr().ToString());
            sb.AppendLine(Tickets.First().Screening.Movie.ToString());
            sb.AppendLine(Tickets.First().Screening.ToString());
            foreach (var ticket in Tickets)
            {
                if (ticket.IsPremiumTicket())
                    sb.AppendLine(ticket.ToString());
                else
                    sb.AppendLine(ticket.ToString());
            }
            var totalPrice = CalculatePrice();
            sb.AppendLine("Total price: " + totalPrice.ToString());

            if (exportFormat.Equals(TicketExportFormat.PLAINTEXT))
            {
                using (var sw = new StreamWriter("../../../Files/plaintext.txt"))
                {
                    await sw.WriteAsync(sb.ToString());
                };
            }

            if (exportFormat.Equals(TicketExportFormat.JSON))
            {
                TotalPrice = CalculatePrice();
                var json = JsonConvert.SerializeObject(this, Formatting.Indented);
                using (var sw = new StreamWriter("../../../Files/jsonformat.json"))
                {
                    await sw.WriteAsync(json);
                };
            }
        }

        private static bool IsWeekDay(DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                return false;
            }
            return true;
        }

        private List<double> CalculateStudentOrderPrices()
        {
            List<double> prices = new List<double>();

            foreach (var ticket in Tickets)
            {
                if (ticket.IsPremiumTicket())
                    prices.Add(ticket.GetPrice() - 1);

                else
                    prices.Add(ticket.GetPrice());

            }

            for (int i = 1; i < prices.Count; i++)
            {
                if (i % 2 == 0)
                {
                    prices.Remove(i);
                }
            }
            return prices;
        }
    }
}
