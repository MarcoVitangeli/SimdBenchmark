namespace simd_experiment;

public class NormalVectorSum
{
    public static double[] Sum(double[] left, double[] right)
    {
        ArgumentNullException.ThrowIfNull(left);
        ArgumentNullException.ThrowIfNull(right);

        if (left.Length != right.Length)
        {
            throw new ArgumentException($"{nameof(left)} and {nameof(right)} are not the same length");
        }
        
        var res = new double[left.Length];

        for (int i = 0; i < left.Length; i++)
        {
            res[i] = left[i] + right[i];
        }

        return res;
    }
}