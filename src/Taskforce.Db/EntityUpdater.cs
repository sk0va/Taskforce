using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Taskforce.Domain;

namespace Taskforce.Db;

internal record struct EntityUpdater<TDomain, TDb> (IMapper Mapper)
 : IEntityUpdater<TDomain>
    where TDomain : Domain.Entities.Entity
    where TDb : Entities.Entity
{
    private static readonly ParameterExpression _target =  Expression.Parameter(typeof(SetPropertyCalls<TDb>), "setter");
    private Expression _setCallsChain = _target;

    public IEntityUpdater<TDomain> Set<TValue>(Expression<Func<TDomain, TValue>> propertySetter, TValue value)
    {
        var propertyTypeArg = Type.MakeGenericMethodParameter(0);

        var miSetProperty = typeof(SetPropertyCalls<TDb>)
            .GetMethod(
                nameof(SetPropertyCalls<TDb>.SetProperty),
                1,
                new []
                {
                    typeof(Func<,>).MakeGenericType(typeof(TDb), propertyTypeArg),
                    propertyTypeArg
                });

        var setExpression = Mapper.Map<Expression<Func<TDb, TValue>>>(propertySetter);

        _setCallsChain = Expression.Call(
            _setCallsChain,
            miSetProperty.MakeGenericMethod(typeof(TValue)),
            new Expression[]{setExpression, Expression.Constant(value, typeof(TValue))});

        return this;
    }

    public Expression<Func<SetPropertyCalls<TDb>, SetPropertyCalls<TDb>>> GenerateUpdateExpression()
    {
        var lambda = Expression.Lambda<Func<SetPropertyCalls<TDb>, SetPropertyCalls<TDb>>>(_setCallsChain, false, new[]{_target});

        return lambda;
    }
}
