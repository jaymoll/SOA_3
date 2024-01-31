using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MovieTicket
    {
        private int RowNr { get; set; }

        private int SeatNr { get; set; }

        private bool IsPremium { get; set; }

        public MovieTicket(int rowNr, int seatNr, bool isPremium)
        {
            RowNr = rowNr;
            SeatNr = seatNr;
            IsPremium = isPremium;
        }

        public bool IsPremiumTicket()
        {
            return IsPremium;
        }

        public double GetPrice()
        {
            return 0;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Insert(0, "This movie ticket is for row:");
            sb.Insert(1, RowNr);
            sb.Insert(2, "and seat:");
            sb.Insert(3, SeatNr);
            sb.Insert(4, "This is a premium seat:");
            sb.Insert(5, IsPremium);
            return sb.ToString();
        }
    }
}
