// Class Closure is used to represent the value of lambda expressions.
// It consists of the lambda expression itself, together with the
// environment in which the lambda expression was evaluated.

// The method apply() takes the environment out of the closure,
// adds a new frame for the function call, defines bindings for the
// parameters with the argument values in the new frame, and evaluates
// the function body.

using System;

namespace Tree
{
    public class Closure : Node
    {
        private Node fun;		// a lambda expression
        private Environment env;	// the environment in which
                                        // the function was defined

        public Closure(Node f, Environment e)	
        {
            fun = f;
            env = e;
        }

        public Node getFun()		
        {
            return fun; //THIS AINT FUN
        }
        public Environment getEnv()	
        { 
            return env;
        }

        // TODO: The method isProcedure() should be defined in
        // class Node to return false.    ******DONE*********
        public /* override */new bool isProcedure()	
        {
            return true; 
        }

        public override void print(int n) 
        {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.WriteLine("#{Procedure");
            if (fun != null)
                fun.print(Math.Abs(n) + 4);
            for (int i = 0; i < Math.Abs(n); i++)
                Console.Write(' ');
            Console.WriteLine('}');
        }

        // TODO: The method apply() should be defined in class Node
        // to report an error.  It should be overridden only in classes
        // BuiltIn and Closure.
        public  /*override*/new  Node apply (Node args)   //does this work??!
        {
            Node fun = getFun();
            Node funCar = fun.getCar();
            Environment env = this.getEnv();
            fun = fun.getCdr().getCar();
            
            while ((args != null && !args.getCar().isNull()))
            {
                env.define(funCar.getCar(), args.getCar());
                funCar = funCar.getCdr();
                args=args.getCdr();
            }
            return funCar.eval(env);
            
            //return new StringLit("Error: Closure.apply not yet implemented");
        }
        
        public Node eval(Node t, Environment env)
        {
            return new Nil();
        }
    }    
}