using MovieTheater.Api;
using MovieTheater.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var room = RoomFactory.Create();
builder.Services.AddSingleton(room);
builder.Services.AddGrpcReflection();

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<MovieTheaterService>();
app.MapGrpcReflectionService();

app.Run();