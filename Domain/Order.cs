using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        private int OrderNr { get; set; }

        private bool IsStudentOrder { get; set; }

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
            throw new NotImplementedException();
        }

        public double CalculatePrice()
        {
            throw new NotImplementedException();
        }

        public void Export(TicketExportFormat exportFormat)
        {
            throw new NotImplementedException();
        }
    }
}
