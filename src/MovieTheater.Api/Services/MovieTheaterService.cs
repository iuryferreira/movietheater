using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MovieTheater.Api.Converters;
using MovieTheater.Api.Models;
using MovieTheater.Api.Protos;
using MovieTheaterProtoClass = MovieTheater.Api.Protos.MovieTheater;

namespace MovieTheater.Api.Services;

public class MovieTheaterService : MovieTheaterProtoClass.MovieTheaterBase
{
    private readonly Room _room;

    public MovieTheaterService(Room room)
    {
        _room = room;
    }

    public override Task<AvailableSeatsReply> GetAvailableSeats(Empty request, ServerCallContext context)
    {
        var availableSeats = _room.GetAvailableSeats();
        var reply = new AvailableSeatsReply
        {
            SeatsNumber = {availableSeats},
            TotalSeats = _room.NumberOfSeats,
            TotalAvailableSeats = availableSeats.Count
        };

        return Task.FromResult(reply);
    }

    public override Task<BookingReply> NewBooking(NewBookingRequest request, ServerCallContext context)
    {
        BookingReply reply;

        if (string.IsNullOrEmpty(request.SeatNumber) || string.IsNullOrEmpty(request.CustomerName))
        {
            reply = new BookingReply
            {
                Error = new BookingError {Description = "Preencha os dados corretamente."}
            };

            return Task.FromResult(reply);
        }

        var booking = _room.NewBooking(request.SeatNumber, request.CustomerName);
        if (booking == null)
        {
            reply = new BookingReply
            {
                Error = new BookingError
                {
                    Description = "Não foi possível realizar a sua reserva. Assento indisponível."
                }
            };
            return Task.FromResult(reply);
        }

        reply = new BookingReply {Success = true, Booking = booking.ToBookingSuccessReply()};
        return Task.FromResult(reply);
    }

    public override async Task SubscribeBookingSeats(Empty request, IServerStreamWriter<BookingSeatsReply> responseStream, ServerCallContext context)
    {
        var bookings = _room.Bookings;
        var bookingsCount = bookings.Count;

        foreach (var booking in bookings) await responseStream.WriteAsync(booking.ToBookingSeatsReply());

        while (!context.CancellationToken.IsCancellationRequested)
        {
            if (_room.Bookings.Count <= bookingsCount) continue;

            var booking = _room.Bookings.LastOrDefault();

            if (booking == null) continue;
            await responseStream.WriteAsync(booking.ToBookingSeatsReply());
            bookingsCount += 1;
        }
    }
}