using Domain.Base;
using Domain.Entities.Base;
using Domain.Interfaces.Common.Mongo;
using MediatR;

namespace Application.Common.MediatR.Queries;

public class GetAllQuery<TEntity> : IRequest<IEnumerable<TEntity>> where TEntity : class, IModelBaseId
{
}

public class GetAllQueryHandler<TEntity> : IRequestHandler<GetAllQuery<TEntity>, IEnumerable<TEntity>> where TEntity : class, IModelBaseId
{
    private readonly IReadRepository<TEntity> _repository;

    public GetAllQueryHandler(IReadRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TEntity>> Handle(GetAllQuery<TEntity> request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
