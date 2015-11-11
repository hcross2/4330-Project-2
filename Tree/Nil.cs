// Nil -- Parse tree node class for representing the empty list

using System;

namespace Tree
{
    public class Nil : Node
    {
        private static Nil instance = new Nil();

        private Nil() { }
  
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
        
        public void eval()
        {
            return Console.Write("SHIT BROKE BECAUSE YOUR DUMB ASS TRIED TO EVALUATE A NIL NODE");
        }
    }
}
