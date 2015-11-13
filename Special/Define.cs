// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
	public Define() { }
   
        public override void print(Node t, int n, bool p)
        {
            Printer.printDefine(t, n, p);
        }
        
        public override Node eval(Node t, Environment env) //need to check to see if binding for x (in this case 'identifier') already exists
        { //works for (x 3) but does it work for twice (lambda (f x) (f.............))?
            Node identifier = t.getCdr().getCar();
            Node value = t.getCdr().getCdr().getCar();
            
            if ((identifier.isSymbol())) //this is for if it is in the form of (define x 3), here x is not a function
            {
                env.define(identifier,value);
            }
            else
            {
                Closure idFunction = new Closure(new Cons(t.getCdr().getCar().getCdr(), t.getCdr().getCdr()), env);
                env.define(identifier.getCar(), idFunction);
            }
            return null;
        }
    }
}