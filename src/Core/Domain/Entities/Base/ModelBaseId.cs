using MongoDB.Bson;

namespace Domain.Base;

public abstract class ModelBaseId : IModelBaseId
{
    public string Id { get; set; }
}
