﻿using Core.DataAccess;
using Core.Entities;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserDal:IEntityRepository<User>
{
    List<OperationClaim> GetClaims(User user);
}