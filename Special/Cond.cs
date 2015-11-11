using System;

namespace Tree
{
    public class Cond : Special
    {
	public Cond() { }

        public override void print(Node t, int n, bool p)
        { 
            Printer.printCond(t, n, p);
        }
        
        public Node eval(Node t, Environment env)
        {
            Node expression;
            if ((!t.isPair()))
            {
                Console.write("Invalid Cond statement");
            }
            expression = t.getCdr();
            while (!(expression.getCar().getCar().eval(env).isBool())) //This step skips all the false bools to find the one that returns true
            {
                expression = expression.getCdr();
            }
            if(expression.isNull()) //if it is of the empty list form, return it, which is what this does
            {
                return new Nil();
            }
            else
            {
                return (expression.getCar().getCdr().eval(env));
            }
        }
    }
}