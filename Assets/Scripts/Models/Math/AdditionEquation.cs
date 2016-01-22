using UnityEngine;using System.Collections;using System;public class AdditionEquation : Equation{    public AdditionEquation(int leftOperand, int rightOperand) : base (leftOperand, rightOperand, Equation.Operator.ADD)    {            }    public override int getResult()    {        return this.leftOperand + this.rightOperand;    }    public override string getDisplayEquation()
    {
        return this.leftOperand + " + " + this.rightOperand + " = ?";
    }}