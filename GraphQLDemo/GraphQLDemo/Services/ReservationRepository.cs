using GraphQLDemo.Data;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Services;

public class ReservationRepository(AppDbContext dbContext) : IReservationRepository
{
    public List<Reservation> GetReservations()
    {
        return dbContext.Reservations.AsNoTracking().AsQueryable().ToList();
    }

    public Reservation CreateReservation(Reservation reservation)
    {
         dbContext.Reservations.Add(reservation);
         dbContext.SaveChanges();
         return reservation;
    }
}