using UnityEngine;

class RangeVarianceGenerator : IVarianceGenerator
{
    private int min;
    private int max;
    
    public RangeVarianceGenerator(int min, int max) {
        this.min = min;
        this.max = max;
    }

    public int generateVariance()
    {
        return Random.Range(min, max + 1);
    }
}

