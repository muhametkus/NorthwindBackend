﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfUserDal:EfEntityRepositoryBase<User,NorthwindContext>, IUserDal
{
    public List<OperationClaim> GetClaims(User user)
    {
        using (var context=new NorthwindContext())
        {
            var result = from operationClaim in context.OperationClaims
                join UserOperationClaim in context.UserOperationClaims
                    on operationClaim.Id equals UserOperationClaim.OperationClaimId
                where UserOperationClaim.UserId == user.Id
                select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}