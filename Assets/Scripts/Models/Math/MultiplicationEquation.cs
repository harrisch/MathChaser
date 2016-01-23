using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MultiplicationEquation : Equation
{
    List<IVarianceGenerator> varianceGenerators = new List<IVarianceGenerator>();    
    public MultiplicationEquation(int leftOperand, int rightOperand) : base (leftOperand, rightOperand, Equation.Operator.MULTIPLY)
    {
        varianceGenerators.Add(new RangeVarianceGenerator(-10, 10));
        int[] setVariance = { leftOperand - 1 * rightOperand , rightOperand - 1 * leftOperand };        varianceGenerators.Add(new SetVarianceGenerator(setVariance));
    }

    public override int getResult()
    {
        return this.leftOperand * this.rightOperand;
    }

    public override string getDisplayEquation()
    {
        return this.leftOperand + " x " + this.rightOperand + " = ?";
    }

    public override int getGuess()
    {
        int trueAnswer = getResult();

        int guess = 0;
        do
        {
            IVarianceGenerator varianceGenerator = varianceGenerators[UnityEngine.Random.Range(0, varianceGenerators.Count)];
            guess = trueAnswer + varianceGenerator.generateVariance();
        } while (guesses.Contains(guess));

        return guess;
    }
}
