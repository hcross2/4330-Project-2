// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printIf(t, n, p);
        
        public Node eval(node t, Environment env) //form (if (b t e))??
        {
            Node condition;
            Node express;
            condition = t.getCdr().getCar(); //gets b
            if (condition.eval(env).getBool()) //this work?
            { 
                express = t.getCdr().getCdr().getCar(); //expression = t
                return express.eval(env);
            } 
            else if (!(t.getCdr().getCdr().getCdr()).isNull()) //checks if else statement is null
            {
                express = t.getCdr().getCdr().getCdr().getCar(); //express = expression
                return express.eval(env);
            } 
            else //shit broke
            {
                Console.WriteLine("SHIT AINT GO NO ELSE EXPRESSION IN IF STATEMENT");
                return new Nil();
            }
        }
    }
}

