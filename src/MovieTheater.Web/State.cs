using MovieTheater.Web.Protos;

namespace MovieTheater.Web;

public class State
{
    public List<Booking> Bookings { get; }

    public State()
    {
        Bookings = new List<Booking>();
    }
}