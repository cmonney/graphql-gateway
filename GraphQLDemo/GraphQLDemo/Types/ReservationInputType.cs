using GraphQL.Types;

namespace GraphQLDemo.Types;

public sealed class ReservationInputType : InputObjectGraphType
{
    public ReservationInputType()
    {
        Field<StringGraphType>("customerName");
        Field<StringGraphType>("email");
        Field<StringGraphType>("phoneNumber");
        Field<IntGraphType>("partySize");
        Field<StringGraphType>("specialRequest");
        Field<DateTimeGraphType>("reservationDate");
    }
}