// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            Printer.printLet(t, n, p);
        }
        
        public Node eval(Node t, Environment env)
        {
            Node bodystart = t.getCdr().getCar();
            Node expression = t.getCdr().getCdr().getCar();
            Environment e = new Environment(env);
            bodystart = evalLetBody(bodystart,e);
            return expression.eval(e);
        }
        public Node evalLetBody(Node t, Environment env)
        {
            if(t.isNull())
            {
                Node l = new Cons(new Nil(), new Nil());
                return l;
            }
            else
            {
                Node variable = t.getCar(),getCar();
                Node value = t.getCar().getCdr().getCar();
                Node restBody = t.getCdr();
                
                if(value.isSymbol())
                {
                    env.define(variable,vavalue.eval(env));
                    return evalLetBody(restBody, env);
                }
                if(variable.isPair())
                {
                    return variable.eval(env);
                }
                if(variable.isNull())
                {
                    return new Nil();
                }
            }
        }
        
        
        
        
        /*   THINK YOU NEED TWO FUNCTIONS?????????????????? LOOK ABOVE
        public Node eval(Node t, Environment env)
        {
            Node bodystart = t.getCdr().getCar();
            Node expression = t.getCdr().getCdr().getCar();
            if ((t==null || t.isNull()))
            {
                Node list = new Cons(new Nil(), new Nil());
                return list;
            }
            else
            {
                Node arg = bodystart.getCar().getCar();
            }
        }
        */
        public Node evalLetBody(Note t, Environment env)
        {
            
        }
    }
}


