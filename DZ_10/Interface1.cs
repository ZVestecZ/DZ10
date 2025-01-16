namespace DZ_10
{
    public interface IComparer<in T>
    {
        int Compare(T x, T y);
    }
}
