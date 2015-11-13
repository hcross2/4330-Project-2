// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printRegular(t, n, p);
        }
        
        public override Node eval(Node t, Environment env)  //NEED TO DO THIS
        {
            Node a = t.getCar();
            Node b = evalRest(t.getCdr(), env);
            while(a.isSymbol())
            {
                a = env.lookup(a);
            }
            if(a == null)
            {
                return null;
            }
            if(a.isProcedure())
            {
                return a.apply(b);
            }
            else
            {
                return a.eval(env).apply(b);
            }
        }
        public Node evalRest(Node t, Environment env)
        {
            Node c;
            if(t == null)
            {
                c = new Cons(new Nil(), new Nil());
            }
            else
            {
                Node car = t.getCar();
                Node cdr = t.getCdr();
                if(car.isSymbol())
                {
                    car = env.lookup(car);
                }
                
                c = new Cons(car.eval(env), evalRest(cdr, env));
                return c;
            }
            return c;
        }
    }
}