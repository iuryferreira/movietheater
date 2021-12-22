using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using MovieTheaterProtoClass = MovieTheater.Web.Protos.MovieTheater;

namespace MovieTheater.Web;

public class GrpcClient
{
    public GrpcClient()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:7241", new GrpcChannelOptions
        {
            HttpHandler = new GrpcWebHandler(new HttpClientHandler())
        });
        Client = new MovieTheaterProtoClass.MovieTheaterClient(channel);
    }
    public MovieTheaterProtoClass.MovieTheaterClient Client { get; }
}