using Domain.Base;
using Domain.Interfaces.Common.Mongo;
using MediatR;
using System.Linq.Expressions;

namespace Application.Common.Queries;

public class GetQuerablePredicated<TEntity> : IRequest<IQueryable<TEntity>> where TEntity : class, IModelBaseId
{
    public Expression<Func<TEntity, bool>>? Predicated { get; set; }
}

public class GetQuerablePredicatedHandler<TEntity> : IRequestHandler<GetQuerablePredicated<TEntity>, IQueryable<TEntity>> where TEntity : class, IModelBaseId
{
    private readonly IReadRepository<TEntity> _repository;

    public GetQuerablePredicatedHandler(IReadRepository<TEntity> repository)
    {
        _repository = repository;
    }
    public async Task<IQueryable<TEntity>> Handle(GetQuerablePredicated<TEntity> request, CancellationToken cancellationToken)
    {
        if (request.Predicated is null)
            return await _repository.GetAllQuerable();
        else
        {
            var query = await _repository.GetAllQuerable();
            return query.Where(request.Predicated);
        }
    }
}
