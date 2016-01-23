using UnityEngine;

class SetVarianceGenerator : IVarianceGenerator
{
    private int[] set;
    public SetVarianceGenerator(int[] set) {
        this.set = set;
    }

    public int generateVariance()
    {
        return set[Random.Range(0, set.Length)];
    }
}

