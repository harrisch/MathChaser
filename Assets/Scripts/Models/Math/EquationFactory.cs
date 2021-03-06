﻿using System;
using System.Collections;
using System.Collections.Generic;

public class EquationFactory {
    private static EquationFactory instance;

    private Dictionary<Equation.Operator, IEquationGenerator> generators = new Dictionary<Equation.Operator, IEquationGenerator>();
    
    private EquationFactory() 
    {
        generators.Add(Equation.Operator.ADD, new AdditionEquationGenerator());
        generators.Add(Equation.Operator.SUBTRACT, new SubtractionEquationGenerator());
        generators.Add(Equation.Operator.MULTIPLY, new MultiplicationEquationGenerator());
    }  

    public static EquationFactory Instance 
    {
        get {
            if (instance == null) {
                instance = new EquationFactory();
            }
            
            return instance;            
        }        
    }

    public Equation generate(Equation.Operator op)
    {        
        IEquationGenerator generator = generators[op];
        Equation generated = generator.generate();

        return generated;
    }


}

