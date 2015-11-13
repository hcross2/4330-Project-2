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
        public override Node eval(Node t, Environment env)
        {
            Node identifier;
            Node exp;
            identifier = t.getCdr().getCar();
            exp = t.getCdr().getCdr().getCar();
            env.define(identifier, exp.eval(env));
            return new StringLit(""); //Why? Probably will return void instead of an empty node.
        }
    }
}