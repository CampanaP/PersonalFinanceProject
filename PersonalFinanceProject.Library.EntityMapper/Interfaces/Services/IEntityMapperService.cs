﻿using System.Linq.Expressions;

namespace PersonalFinanceProject.Library.EntityMapper.Interfaces.Services
{
    public interface IEntityMapperService
    {
        T Clone<T>(T objectToClone);

        Destination Map<Origin, Destination>(Origin originEntity, bool mapNullable = false, params object[] arguments);

        List<Destination> MapList<Origin, Destination>(List<Origin> originEntities, bool mapNullable = false, params object[] arguments);

        Destination MapToExisting<Origin, Destination>(Origin originEntity, Destination destinationEntity, bool mapNullable = false);

        Entity Set<Entity>(Expression<Func<Entity, object>> entityExpression);
    }
}