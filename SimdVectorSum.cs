using System.Numerics;

namespace simd_experiment;

public static class SimdVectorSum
{
    public static double[] Sum(double[] left, double[] right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        if (left.Length != right.Length)
        {
            throw new ArgumentException($"{nameof(left)} and {nameof(right)} are not the same length");
        }

        var length = left.Length;
        var result = new double[length];

        // Get the number of elements that can't be processed in the vector
        // NOTE: Vector<T>.Count is a JIT time constant and will get optimized accordingly
        var remaining = length % Vector<double>.Count;

        for (int i = 0; i < length - remaining; i += Vector<double>.Count)
        {
            var v1 = new Vector<double>(left, i);
            var v2 = new Vector<double>(right, i);
            (v1 + v2).CopyTo(result, i);
        }

        for (int i = length - remaining; i < length; i++)
        {
            result[i] = left[i] + right[i];
        }

        return result;
    }
}