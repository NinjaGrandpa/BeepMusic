namespace BeepMusic.Utils
{
    public static class Extensions
    {
        public static T GetNextItem<T>(this List<T> list, T item, int step = 1)
        {
            var index = list.IndexOf(item);
            var newIndex = index + step;

            if ((list.Count - 1 - newIndex) < 0 || newIndex < 0)
            {
                return item;
            }

            return list[index + step];
        }
    }
}
