using System;
using System.Collections;

namespace ScrumBoard.Tests.Persistence.Mappings
{
    public class EntityEqualityComparer<T> : IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            else if (x is T && y is T && x.GetType().GetProperty("Id") != null && y.GetType().GetProperty("Id") != null)
            {
                var entity1 = x.GetType().GetProperty("Id");
                var entity2 = y.GetType().GetProperty("Id");
                return (int)entity1.GetValue(x) == (int)entity2.GetValue(y);
            }

            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
