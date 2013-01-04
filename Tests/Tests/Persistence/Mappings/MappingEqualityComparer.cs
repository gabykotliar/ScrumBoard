using System;
using System.Collections;

namespace ScrumBoard.Tests.Persistence.Mappings
{
    public class MappingEqualityComparer<T> : IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
            {
                return false;
            }
            else if (x is DateTime && y is DateTime) // To compare DateTime with SQL Server datetime, we don't take into consideration milliseconds
            {
                var dt1 = (DateTime)x;
                var dt2 = (DateTime)y;

                return dt1.AddTicks(-(dt1.Ticks % TimeSpan.TicksPerSecond)) == dt2.AddTicks(-(dt2.Ticks % TimeSpan.TicksPerSecond));
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
