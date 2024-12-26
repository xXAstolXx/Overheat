using System.Collections.Generic;

namespace Overheat.Extensions.ListExtensions
{
    public static class ListExtensions
    {
        public static T GetFirstOrDefault<T>(this List<T> list)
        {
            return list.Count > 0 ? list[0] : default;
        }
    }
}

