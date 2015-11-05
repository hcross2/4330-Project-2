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
            Node condition;
            condition = t.getCar().getCdr();
            while (!(condition.eval(env).getBool()))
            {
                eval(condition.getCar().getCdr(), env);
            }
        }
    }
}