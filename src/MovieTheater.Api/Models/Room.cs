using System.Collections.Immutable;
using Google.Protobuf.WellKnownTypes;

namespace MovieTheater.Api.Models;

public class Room
{
    public List<Seat> Seats { get; init; }
    public List<Booking> Bookings { get; init; }
    public int NumberOfSeats => Seats.Count;

    public ImmutableList<string> GetAvailableSeats()
    {
        return Seats.Where(seat => !seat.Busy).Select(seat => seat.Number).ToImmutableList();
    }

    public Booking NewBooking(string seatNumber, string customerName)
    {
        var seat = Seats.FirstOrDefault(seat => seat.Number == seatNumber && !seat.Busy);
        if (seat is null) return null;

        var booking = new Booking
        {
            TicketNumber = $"{DateTime.Now.ToFileTimeUtc()}{seatNumber}",
            CustomerName = customerName
        };

        seat.BookSeat(booking);
        Bookings.Add(booking);
        return booking;
    }
}