using PersonalFinanceProject.Library.DependencyInjection.Attributes;
using PersonalFinanceProject.Library.EntityMapper.Interfaces.Services;
using System.Reflection;

namespace PersonalFinanceProject.Library.EntityMapper.Services
{
    [ScopedLifetime]
    internal class EntityMapperService : IEntityMapperService
    {
        public Destination Map<Origin, Destination>(Origin originEntity, bool mapNullable = false, params object[] arguments)
        {
            Destination? destinationEntity = (Destination?)Activator.CreateInstance(typeof(Destination), arguments);
            if (destinationEntity is null)
            {
                throw new Exception($"{nameof(EntityMapperService)} - {nameof(Map)} - DestinationEntity is null");
            }

            //Get properties...
            IEnumerable<PropertyInfo> originProperties = typeof(Origin).GetRuntimeProperties();
            IEnumerable<PropertyInfo> destinationProperties = typeof(Destination).GetRuntimeProperties();

            //Get original values mappable...
            Dictionary<string, Type> originalTypes = new Dictionary<string, Type>();
            foreach (PropertyInfo originProperty in originProperties)
            {
                if (!destinationProperties.Any(p => p.Name.ToLower() == originProperty.Name.ToLower() && (p.PropertyType == originProperty.PropertyType || mapNullable && (p.PropertyType == Nullable.GetUnderlyingType(originProperty.PropertyType) || originProperty.PropertyType == Nullable.GetUnderlyingType(p.PropertyType)))))
                {
                    continue;
                }

                PropertyInfo? property = typeof(Destination).GetRuntimeProperty(originProperty.Name);
                if (property is null || !property.CanWrite || !originProperty.CanRead || property.SetMethod is null || !property.SetMethod.IsPublic)
                {
                    continue;
                }

                property.SetValue(destinationEntity, originProperty.GetValue(originEntity, null), null);
            }

            return destinationEntity;
        }

        public List<Destination> MapList<Origin, Destination>(List<Origin> originEntities, bool mapNullable = false, params object[] arguments)
        {
            List<Destination> destinationEntities = Activator.CreateInstance<List<Destination>>();

            //Get original values mappable...
            foreach (Origin originEntity in originEntities)
            {
                destinationEntities.Add(Map<Origin, Destination>(originEntity, mapNullable, arguments));
            }

            return destinationEntities;
        }

        public Destination MapToExisting<Origin, Destination>(Origin originEntity, Destination destinationEntity, bool mapNullable = false)
        {
            //Get properties...
            IEnumerable<PropertyInfo> originProperties = typeof(Origin).GetRuntimeProperties();
            IEnumerable<PropertyInfo> destinationProperties = typeof(Destination).GetRuntimeProperties();

            //Get original values mappable...
            Dictionary<string, Type> originalTypes = new Dictionary<string, Type>();
            foreach (PropertyInfo originalProperty in originProperties)
            {
                if (destinationProperties.Any(p => p.Name.ToLower() == originalProperty.Name.ToLower() && (p.PropertyType == originalProperty.PropertyType || mapNullable && (p.PropertyType == Nullable.GetUnderlyingType(originalProperty.PropertyType) || originalProperty.PropertyType == Nullable.GetUnderlyingType(p.PropertyType)))))
                {
                    continue;
                }

                PropertyInfo? property = typeof(Destination).GetRuntimeProperty(originalProperty.Name);
                if (property is null || !property.CanWrite || !originalProperty.CanRead || property.SetMethod is null || !property.SetMethod.IsPublic)
                {
                    continue;
                }

                property.SetValue(destinationEntity, originalProperty.GetValue(originEntity, null), null);
            }

            return destinationEntity;
        }

        public T Clone<T>(T objectToClone)
        {
            return Map<T, T>(objectToClone);
        }
    }
}