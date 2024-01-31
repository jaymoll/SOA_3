using Newtonsoft.Json;
using System.Text;

namespace Domain
{
    public class MovieScreening
    {
        [JsonProperty]
        private DateTime DateAndTime { get; set; }

        [JsonProperty]
        private double PricePerSeat { get; set; }

        [JsonProperty]
        public Movie Movie { get; set; }

        public MovieScreening(DateTime dateAndTime, double pricePerSeat, Movie movie)
        {
            DateAndTime = dateAndTime;
            PricePerSeat = pricePerSeat;
            Movie = movie;
        }

        public double GetPricePerSeat()
        {
            return PricePerSeat;
        }

        public DateTime GetDateAndTime()
        {
            return DateAndTime;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("This movie screening is at:");
            sb.AppendLine(DateAndTime.ToString("dddd, dd MMMM yyyy"));
            sb.AppendLine("The price per seat for this screening is:");
            sb.AppendLine(GetPricePerSeat().ToString());

            return sb.ToString();
        }
    }
}
