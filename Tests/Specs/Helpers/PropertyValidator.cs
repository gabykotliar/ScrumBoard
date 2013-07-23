using System;
using System.Reflection;
using FluentAssertions;

namespace ScrumBoard.Specs.Helpers
{
    public class PropertyValidator<T>
    {        
        private readonly string name;
        private readonly object entity;
        private readonly Type entityType;
        private readonly PropertyInfo propertyInfo;

        public PropertyValidator(string name, object entity)
        {
            this.name = name;
            this.entity = entity;
            entityType = entity.GetType();

            propertyInfo = entityType.GetProperty(name);
        }

        public void CheckExistance()
        {
            // TODO: Should().NotBeNull is not supported anymore. Look for a replacement
            // propertyInfo.Should().NotBeNull(string.Format("Missing '{0}' property", name));
        }

        public void CheckIfVirtual()
        {
            var reason = string.Format("'{0}' property should be virtual", name);

            propertyInfo.GetGetMethod().IsVirtual.Should().BeTrue(reason);
            propertyInfo.GetSetMethod().IsVirtual.Should().BeTrue(reason);
        }

        public void CheckStandardSetAndGetBehaviour()
        {
            var value = default(T);

            propertyInfo.SetValue(entity, value, null);

            propertyInfo.GetValue(entity, null).Should().Be(value, "Id_Get should return the same value setted with Id_Set");
        }
    }
}
