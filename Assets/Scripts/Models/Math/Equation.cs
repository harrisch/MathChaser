using System.Collections.Generic;

public abstract class Equation {
    public enum Operator { ADD, SUBTRACT, MULTIPLY }

    public int leftOperand { get; set; }
    public int rightOperand { get; set; }
    
    protected Operator operation;

    protected List<int> guesses;   
    protected int result;

    protected Equation (int leftOperand, int rightOperand, Operator operation)
    {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
        this.operation = operation;
    }

    public abstract int getResult();

    public abstract string getDisplayEquation();

    public int[] getGuesses(int numGuesses)
    {
        guesses = new List<int>(numGuesses);

        int solutionIndex = UnityEngine.Random.Range(0, numGuesses);        
        
        for (int i = 0; i < numGuesses; i++) {
            if (i == solutionIndex) {
                guesses.Add(getResult());
            } else {
                guesses.Add(getGuess());
            }
        }

        return guesses.ToArray();
    }

    public abstract int getGuess();

    public Operator getOperation()
    {
        return operation;
    }
}
