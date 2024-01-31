using Newtonsoft.Json;
using System.Text;

namespace Domain
{
    public class MovieTicket
    {
        [JsonProperty]
        private int RowNr { get; set; }

        [JsonProperty]
        private int SeatNr { get; set; }

        [JsonProperty]
        private bool IsPremium { get; set; }

        [JsonProperty]
        public MovieScreening Screening { get; set; }

        public MovieTicket(int rowNr, int seatNr, bool isPremium, MovieScreening movieScreening)
        {
            RowNr = rowNr;
            SeatNr = seatNr;
            IsPremium = isPremium;
            Screening = movieScreening;
        }

        public bool IsPremiumTicket()
        {
            return IsPremium;
        }

        public double GetPrice()
        {
            if (IsPremium)
                return Screening.GetPricePerSeat() + 3;
            else
                return Screening.GetPricePerSeat();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("This movie ticket is for row:");
            sb.AppendLine(RowNr.ToString());
            sb.AppendLine("and seat:");
            sb.AppendLine(SeatNr.ToString());

            if (IsPremium)
                sb.AppendLine("This is a premium ticket");
            else
                sb.AppendLine("This is a regular ticket");

            return sb.ToString();
        }
    }
}
