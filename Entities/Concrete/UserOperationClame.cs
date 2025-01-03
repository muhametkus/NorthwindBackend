using Core.Entities;

namespace Entities.Concrete;

public class UserOperationClame:IEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int OperationClaimId { get; set; }
}