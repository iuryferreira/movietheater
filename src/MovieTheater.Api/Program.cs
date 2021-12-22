using MovieTheater.Api;
using MovieTheater.Api.Services;

var builder = WebApplication.CreateBuilder(args);

var room = RoomFactory.Create();
builder.Services.AddSingleton(room);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policyBuilder =>
   {
       policyBuilder.WithOrigins("https://localhost:5001")
           .AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();
   });
});

builder.Services.AddGrpcReflection();
builder.Services.AddGrpc();

var app = builder.Build();

app.UseCors();
app.MapGrpcService<MovieTheaterService>().EnableGrpcWeb();
app.MapGrpcReflectionService();

app.UseGrpcWeb();

app.Run();