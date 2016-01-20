﻿public abstract class Equation {
    public enum Operator { ADD, SUBTRACT, MULTIPLY }

    public int leftOperand { get; set; }
    public int rightOperand { get; set; }
    protected Operator operation;

    private int result;

    protected Equation (int leftOperand, int rightOperand, Operator operation)
    {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
        this.operation = operation;
    }

    public abstract int getResult();
}
