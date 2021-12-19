using MovieTheater.Api.Models;
using MovieTheater.Api.Protos;

namespace MovieTheater.Api.Converters;

public static class MovieTheaterConverter
{
    public static BookingSuccess ToBookingSuccessReply(this Booking data)
    {
        if (data == null) return new BookingSuccess();
        return new BookingSuccess
        {
            TicketNumber = data.TicketNumber,
            CustomerName = data.CustomerName
        };
    }

    public static BookingSeatsReply ToBookingSeatsReply(this Booking data)
    {
        if (data == null) return new BookingSeatsReply();
        return new BookingSeatsReply
        {
            SeatNumber = data.Seat?.Number,
            TicketNumber = data.TicketNumber,
            CustomerName = data.CustomerName
        };
    }
}