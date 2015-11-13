// Nil -- Parse tree node class for representing the empty list

using System;

namespace Tree
{
    public class Nil : Node
    {
        private static Nil instance = new Nil();

        public Nil() { }  //I changed this to public becaues when it was private before, it wouldn't compile???!!!
  
        public static Nil getInstance()
        {
            return instance;
        }

        public override void print(int n)
        {
            print(n, false);
        }

        public override void print(int n, bool p) {
            Printer.printNil(n, p);
        }

        public override bool isNull()
        {
            return true;
        }
        
        public Node eval(Node t, Environment env) //DOES THIS HAVE TO BE VOID, IT USED TO BE
        {
            Console.Write("SHIT BROKE BECAUSE YOUR DUMB ASS TRIED TO EVALUATE A NIL NODE");
            return new Nil();
        }
    }
}
