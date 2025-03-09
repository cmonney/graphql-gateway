using GraphQL.Types;

namespace GraphQLDemo.Query;

public sealed class RootQuery : ObjectGraphType
{
    public RootQuery()
    {
        Field<MenuQuery>("menuQuery").Resolve(_ => new {});
        Field<CategoryQuery>("categoryQuery").Resolve(_ => new {});
        Field<ReservationQuery>("reservationQuery").Resolve(_ => new {});
    }
    
}