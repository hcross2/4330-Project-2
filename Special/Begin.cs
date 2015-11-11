using System;

namespace Tree
{
    public class Begin : Special
    {
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printBegin(t, n, p);
        }
        
        public eval(Node t, Environment env)
        {
            if (!t.getCdr().isNull())
                return t.eval(t.getCdr().getCar(), env); //how do we return this properly
            else
                return new Nil();;
        }
    }
}