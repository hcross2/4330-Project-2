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
        }
        public override Node eval(Node t, Environment env) //form (if (b t e))??
        {
            Node condition = t.getCdr().getCar(); //gets b;
            Node express;
            Node caddr = t.getCdr().getCdr().getCar();
            Node cadddr = t.getCdr().getCdr().getCdr().getCar();
            if (condition.eval(env).getBool()) //this work?
            { 
                express = caddr; //expression = t
                return express.eval(env);
            } 
            else if (!(t.getCdr().getCdr().getCdr()).isNull()) //checks if else statement is null
            {
                express = cadddr; //express = expression
                return express.eval(env);
            } 
            else //shit broke
            {
                Console.Write("SHIT AINT GO NO ELSE EXPRESSION IN IF STATEMENT");
                return new Nil();
            }
        }
    }
}

