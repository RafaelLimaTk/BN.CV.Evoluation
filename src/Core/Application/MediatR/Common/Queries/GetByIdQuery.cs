using AutoMapper;
using Domain.Base;
using Domain.Interfaces.Common.Mongo;
using MediatR;
using RS = Resources.Common;

namespace Application.Common.MediatR.Queries;

public class GetByIdQuery<TEntity> : IRequest<TEntity> where TEntity : class, IModelBaseId
{
    public string Id { get; set; }
}

public class GetByIdQueryHandler<TEntity> : IRequestHandler<GetByIdQuery<TEntity>, TEntity> where TEntity : class, IModelBaseId
{
    private readonly IMapper mapper;
    private readonly IReadRepository<TEntity> _repository;

    public GetByIdQueryHandler(IMapper mapper, IReadRepository<TEntity> repository)
    {
        this.mapper = mapper;
        this._repository = repository;
    }
    public async Task<TEntity> Handle(GetByIdQuery<TEntity> request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Id)) throw new Exception(RS.EXCEPTION_MSG_THE_PROPERTY_CANNOT_BE_NULL.Replace("{0}", nameof(request.Id)));

        var result = await _repository.GetByIdAsync(request.Id);

        if (result == null)
            throw new Exception(RS.EXCEPTION_MSG_NOT_FOUND.Replace("{0}", ""));

        return result;
    }
}