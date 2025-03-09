using GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Types;

namespace GraphQLDemo.Query;

public sealed class ReservationQuery : ObjectGraphType
{
    public ReservationQuery(IReservationRepository reservationRepository)
    {
        Field<ListGraphType<ReservationType>>("reservations").Resolve(_ => reservationRepository.GetReservations());
    }
}