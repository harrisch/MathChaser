using System;
using System.Collections;

public class SubtractionEquationGenerator : IEquationGenerator
{
    public Equation generate()
    {
        return new SubtractionEquation(UnityEngine.Random.Range(25, 51), UnityEngine.Random.Range(0, 26));
    }
}
