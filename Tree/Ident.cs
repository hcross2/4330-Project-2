// Ident -- Parse tree node class for representing identifiers

using System;

namespace Tree
{
    public class Ident : Node
    {
        private string name;

        public Ident(string n)
        {
            name = n;
        }

        public override void print(int n)
        {
            Printer.printIdent(n, name);
        }

        public override String getName()
        {
            return name;
        }

        public override bool isSymbol()
        {
            return true;
        }
        
        public Node eval(Node t, Environment env) //Does this have a node passed in? THIS IS WRONG!
        {
            Node a = env.lookup(this);
            if(a == Nil.getInstance())
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                return a;
            }
            return null;
        }
    }
}