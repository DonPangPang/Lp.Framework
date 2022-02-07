namespace Lp.Framework.Shared.Base
{
    public static class MarkExtensions
    {
        public static bool Transform(this bool mark)
        {
            return !mark;
        }
    }
}