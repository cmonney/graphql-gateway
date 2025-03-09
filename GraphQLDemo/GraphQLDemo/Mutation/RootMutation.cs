using GraphQL.Types;

namespace GraphQLDemo.Mutation;

public sealed class RootMutation : ObjectGraphType
{
    public RootMutation()
    {
        Field<ReservationMutation>("reservationMutation").Resolve(context => new { });
        Field<CategoryMutation>("categoryMutation").Resolve(context => new { });
        Field<MenuMutation>("menuMutation").Resolve(context => new { });
    }
}