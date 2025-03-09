using GraphQL;
using GraphQL.Types;
using GraphQLDemo.Interfaces;
using GraphQLDemo.Models;
using GraphQLDemo.Types;

namespace GraphQLDemo.Mutation;

public sealed class ReservationMutation : ObjectGraphType
{
    public ReservationMutation(IReservationRepository reservationRepository)
    {
        Field<ReservationType>("createReservation")
            .Arguments(new QueryArguments(new QueryArgument<ReservationInputType> { Name = "reservation" }))
            .Resolve(context => reservationRepository.CreateReservation(context.GetArgument<Reservation>("reservation")));
    }
}