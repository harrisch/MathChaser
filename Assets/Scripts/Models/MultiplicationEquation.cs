﻿using UnityEngine;using System.Collections;using System;public class MultiplicationEquation : Equation{    public MultiplicationEquation(int leftOperand, int rightOperand) : base (leftOperand, rightOperand, Equation.Operator.MULTIPLY)    {            }    public override int getResult()    {        return this.leftOperand * this.rightOperand;    }}