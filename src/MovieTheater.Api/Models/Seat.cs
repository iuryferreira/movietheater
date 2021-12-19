namespace MovieTheater.Api.Models;

public class Seat
{
    public string Number { get; init; }
    public bool Busy { get; set; }

    public void BookSeat(Booking booking)
    {
        booking.Seat = this;
        Busy = true;
    }
}