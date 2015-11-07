// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
	public Set() { }
	
        public override void print(Node t, int n, bool p)
        {
            Printer.printSet(t, n, p);
        }
        public Node eval(Node t, Environment env)
        {
            Node identifier;
            Node exp;
            identifier=t.getCdr().getCar();
            exp = t.getCdr().getCdr().getCar();
            env.define(id,exp.eval(env));
            return new StrLit("");
            
            
        }
    }
}

