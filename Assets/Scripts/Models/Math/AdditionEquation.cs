using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AdditionEquation : Equation
{
    List<IVarianceGenerator> varianceGenerators = new List<IVarianceGenerator>();
    public AdditionEquation(int leftOperand, int rightOperand) : base (leftOperand, rightOperand, Equation.Operator.ADD)
    {
        varianceGenerators.Add(new RangeVarianceGenerator(-10, 10));
        int[] setVariance = { -1, 1 };
        varianceGenerators.Add(new SetVarianceGenerator(setVariance));     
    }

    public override int getResult()
    {
        return this.leftOperand + this.rightOperand;
    }

    public override string getDisplayEquation()
    {
        return this.leftOperand + " + " + this.rightOperand + " = ?";
    }

    public override int getGuess()
    {
        int trueAnswer = getResult();

        int guess = 0;
        do
        {
            IVarianceGenerator varianceGenerator = varianceGenerators[UnityEngine.Random.Range(0, varianceGenerators.Count)];
            guess = trueAnswer + varianceGenerator.generateVariance();
		} while (guesses.Contains(guess) && guess != trueAnswer);

        return guess;
    }
}

