using MovieTheater.Api.Models;

namespace MovieTheater.Api;

public static class RoomFactory
{
    public static Room Create()
    {
        List<Seat> seats = new();
        for (var index = 1; index <= 10; index++) seats.Add(new Seat {Number = $"SEAT_{index}", Busy = false});
        return new Room {Seats = seats, Bookings = new List<Booking>()};
    }
}