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
            bodystart = evalLetBody(bodystart, e); //Should we be returning bodystart?
            return expression.eval(e); //Why return e?
        }
        public Node evalLetBody(Node t, Environment env)
        {
            if(t.isNull()) //This isn't correct. What do?
            {
                Node l = new Cons(new Nil(), new Nil()); //tree with pair of ()
                return l;
            }
            else
            {
                Node variable = t.getCar(),getCar();
                Node value = t.getCar().getCdr().getCar();
                Node restBody = t.getCdr();
                
                if(variable.isSymbol()) //was value earlier, should be variable?
                {
                    env.define(variable,value.eval(env));
                    return evalLetBody(restBody, env);
                }
                else if(variable.isPair()) //if it is a cons node. ???
                {
                    return variable.eval(env);
                }
                else if(variable.isNull())
                {
                    return new Nil();
                }
                else
                {
                    Console.Write("Error in Let->evalLetBody, variable is not valid");
                    return new Nil();
                }
            }
        }
    }
}