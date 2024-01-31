using System.Text;

namespace Domain
{
    public class MovieScreening
    { 
        private DateTime DateAndTime { get; set; }
        private double PricePerSeat { get; set; }

        public MovieScreening(DateTime dateAndTime, double pricePerSeat)
        {
            DateAndTime = dateAndTime;
            PricePerSeat = pricePerSeat;
        }

        public double GetPricePerSeat()
        {
            return PricePerSeat;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Insert(0, "This movie screening is at:");
            sb.Insert(1, DateAndTime.ToString("dddd, dd MMMM yyyy"));
            sb.Insert(2, "The price per seat for this screening is:");
            sb.Insert(3, PricePerSeat);

            return sb.ToString();
        }
    }
}
