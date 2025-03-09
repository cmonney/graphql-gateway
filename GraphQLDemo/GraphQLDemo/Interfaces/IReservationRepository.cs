using GraphQLDemo.Models;

namespace GraphQLDemo.Interfaces;

public interface IReservationRepository
{
    List<Reservation> GetReservations();
    Reservation CreateReservation(Reservation reservation);
}