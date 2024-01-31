using Domain;
using Domain.Enum;

var movie = new Movie("matrix");
MovieScreening movieScreening = new(DateTime.Now, 12.50, movie);

MovieTicket movieTicket0 = new(4, 9, true, movieScreening);
MovieTicket movieTicket1 = new(4, 10, true, movieScreening);
MovieTicket movieTicket2 = new(6, 1, false, movieScreening);
MovieTicket movieTicket3 = new(6, 9, false, movieScreening);
MovieTicket movieTicket4 = new(7, 5, true, movieScreening);
MovieTicket movieTicket5 = new(8, 9, true, movieScreening);
MovieTicket movieTicket6 = new(2, 12, true, movieScreening);

Order studentLessThan6Order = new(1, true);
Order studentMoreThan6Order = new(2, true);

Order regularLessThan6Order = new(3, false);
Order regularMoreThan6Order = new(4, false);

studentLessThan6Order.AddSeatReservation(movieTicket0);
studentLessThan6Order.AddSeatReservation(movieTicket1);
studentLessThan6Order.AddSeatReservation(movieTicket2);
studentLessThan6Order.AddSeatReservation(movieTicket3);

studentMoreThan6Order.AddSeatReservation(movieTicket0);
studentMoreThan6Order.AddSeatReservation(movieTicket1);
studentMoreThan6Order.AddSeatReservation(movieTicket2);
studentMoreThan6Order.AddSeatReservation(movieTicket3);
studentMoreThan6Order.AddSeatReservation(movieTicket4);
studentMoreThan6Order.AddSeatReservation(movieTicket5);
studentMoreThan6Order.AddSeatReservation(movieTicket6);

regularLessThan6Order.AddSeatReservation(movieTicket0);
regularLessThan6Order.AddSeatReservation(movieTicket1);
regularLessThan6Order.AddSeatReservation(movieTicket2);
regularLessThan6Order.AddSeatReservation(movieTicket3);

regularMoreThan6Order.AddSeatReservation(movieTicket0);
regularMoreThan6Order.AddSeatReservation(movieTicket1);
regularMoreThan6Order.AddSeatReservation(movieTicket2);
regularMoreThan6Order.AddSeatReservation(movieTicket3);
regularMoreThan6Order.AddSeatReservation(movieTicket4);
regularMoreThan6Order.AddSeatReservation(movieTicket5);

await studentLessThan6Order.Export(TicketExportFormat.PLAINTEXT);
await studentMoreThan6Order.Export(TicketExportFormat.JSON);