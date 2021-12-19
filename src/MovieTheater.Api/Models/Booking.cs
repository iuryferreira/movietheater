namespace MovieTheater.Api.Models;

public class Booking
{
    public string TicketNumber { get; init; }
    public string CustomerName { get; init; }
    public Seat Seat { get; set; }
}