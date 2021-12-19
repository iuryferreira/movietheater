using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using MovieTheater.Cli;
using MovieTheaterProtoClass = MovieTheater.Cli.Protos.MovieTheater;


var channel = GrpcChannel.ForAddress("https://localhost:7241");
var client = new MovieTheaterProtoClass.MovieTheaterClient(channel);

var source = new CancellationTokenSource();
var cancellationToken = source.Token;

var streaming = client.SubscribeBookingSeats(new Empty(), cancellationToken: cancellationToken);


Console.WriteLine("BOOKINGS");
Console.WriteLine("--------");

Task.Run(async () =>
{
    while (await streaming.ResponseStream.MoveNext(cancellationToken))
    {
        var response = streaming.ResponseStream.Current;

        ConsoleExtensions.WriteWithColor($"[{DateTime.Now} - NOVA RESERVA] ", ConsoleColor.Green);
        ConsoleExtensions.WriteWithColor($"[ASSENTO: {response.SeatNumber}] ", ConsoleColor.Yellow);
        Console.Write("Reservado para ");
        ConsoleExtensions.WriteWithColor($"{response.CustomerName}\n", ConsoleColor.Blue);
    }
}, cancellationToken);

Console.ReadKey();
source.Cancel();