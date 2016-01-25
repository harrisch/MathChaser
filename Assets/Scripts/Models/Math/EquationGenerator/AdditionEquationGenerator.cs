﻿using System.Collections;
using System;

public class AdditionEquationGenerator : IEquationGenerator
{
    public Equation generate()
    {
        return new AdditionEquation(UnityEngine.Random.Range(0, 100), UnityEngine.Random.Range(0, 100));
    }
}
