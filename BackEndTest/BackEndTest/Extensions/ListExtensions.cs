// ReSharper disable All
namespace BackEndTest.Extensions;

public static class ListExtensions
{
    public static List<TB> Map<TA, TB>(this List<TA> src, Func<TA, TB> map)
    {
        ThrowIfNull(src);

        var res = new List<TB>();

        for (var i = 0; i < src.Count; i++)
        {
            var b = map(src[i]);
            res.Add(b);
        }

        return res;
    }

    public static List<TB> Map2<TA, TB>(this List<TA> src, Func<TA, TB> map)
    {
        ThrowIfNull(src);

        return src.Fold(new List<TB>(), (lst, current) =>
        {
            lst.Add(map(current));
            return lst;
        });
    }

    public static TB Fold<TA, TB>(this List<TA> src, TB initial, Func<TB, TA, TB> folder)
    {
        ThrowIfNull(src);

        var res = initial;

        for (var i = 0; i < src.Count; i++)
        {
            res = folder(res, src[i]);
        }

        return res;
    }

    private static void ThrowIfNull<T>(T src)
    {
        if (src is null)
        {
            throw new ArgumentNullException(nameof(src));
        }
    }
}