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
        
        public override Node eval(Node t, Environment env)
        {
            t = t.getCdr();
            while (!t.getCdr().isNull())
            {
                t.getCar().eval(env);
                t = t.getCdr();
            }
            
            return null;
        }
    }
}