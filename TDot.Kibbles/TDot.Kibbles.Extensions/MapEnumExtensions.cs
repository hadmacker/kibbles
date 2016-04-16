using System;

namespace TDot.Kibbles.Extensions
{
    public static class MapEnumExtensions
    {
        public static void MapEnum<T>(this uint source, Action<uint, bool> onMatch, MapOptions options = null) where T: struct, IComparable
        {
            var targetType = typeof (T);
            if(!targetType.IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            if (options == null)
                options = MapOptions.Default();

            var names = Enum.GetNames(targetType);
            var values = Enum.GetValues(targetType);
            for (var i = options.StartingIndex; i < names.Length; i++)
            {
                var value = (uint)values.GetValue(i);
                var match = (source & value) == value;

                if (match || options.ShowUnmappedFlags)
                    onMatch(value, match);
            }
        }
    }

    public class MapOptions
    {
        public bool ShowUnmappedFlags;
        public bool ShowNoneFlag = false;

        public int StartingIndex {  get { return ShowNoneFlag ? 0 : 1; } }

        public static MapOptions Default()
        {
            return new MapOptions
            {
                ShowUnmappedFlags = true,
            };
        }
    }
}