using System;
using System.Collections;

public class MultiplicationEquationGenerator : IEquationGenerator
{
    public Equation generate()
    {
        return new MultiplicationEquation(UnityEngine.Random.Range(0, 10), UnityEngine.Random.Range(0, 10));
    }
}
