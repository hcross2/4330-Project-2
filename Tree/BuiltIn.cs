// Class BuiltIn is used for representing the value of built-in functions
// such as +.  Populate the initial environment with
// (name, new BuiltIn(name)) pairs.

// The object-oriented style for implementing built-in functions would be
// to include the C# methods for implementing a Scheme built-in in the
// BuiltIn object.  This could be done by writing one subclass of class
// BuiltIn for each built-in function and implementing the method apply
// appropriately.  This requires a large number of classes, though.
// Another alternative is to program BuiltIn.apply() in a functional
// style by writing a large if-then-else chain that tests the name of
// the function symbol.
using System;

namespace Tree
{
    public class BuiltIn : Node
    {
        private Node symbol;            // the Ident for the built-in function

        public BuiltIn(Node s)		
        {
            symbol = s; 
        }

        public Node getSymbol()		
        {
            return symbol; 
        }

        // TODO: The method isProcedure() should be defined in
        // class Node to return false.  ******DONE by EB on 10/30********
        public /* override */ bool isProcedure()	
        {
            return true;
        }

        public override void print(int n)
        {
            // there got to be a more efficient way to print n spaces
            for (int i = 0; i < n; i++)
                Console.Write(' ');
            Console.Write("#{Built-in Procedure ");
            if (symbol != null)
                symbol.print(-Math.Abs(n));
            Console.Write('}');
            if (n >= 0)
                Console.WriteLine();
        }

        // TODO: The method apply() should be defined in class Node
        // to report an error.  It should be overridden only in classes
        // BuiltIn and Closure.
        
        public Node apply(Node args)
        {
            if(args == null)
            {
                Console.Write("Error: no Node");
                return new Nil(); //was return null;
            }
            Node car = args.getCar();
            Node cdr = args.getCdr();
            if(car.isNull())    //IF CAR DOESN'T EXIST
            {
                car = new Nil();
            }
            if(cdr.isNull())   //IF CDR DOESN'T EXIST
            {
                cdr = new Nil();
            }
            else
            {
                cdr = cdr.getCar()  //THIS IS THE CADR, DOESNT WORK FOR (1 . 2) 
            }  
            String symbolNode = symbol.getName();
            if(symbolNode.equals("symbol?"))
            {
                return new BoolLit(car.isSymbol());
            }
            if(symbolNode.equals("number?"))
            {
                return new BoolLit(car.isNumber());
            }
            
            if(car.isNumber() && cdr.isNumber())
            {
                int a = car.getValue();
                int b = cdr.getValue();
                if(symbolNode.equals("b+"))
                {
                    return new IntLit(a + b);
                }
                else if(symbolNode.equals("b-"))
                {
                    return new IntLit(a - b);
                }
                else if(symbolNode.equals("b*"))
                {
                    return new IntLit(a * b);
                }
                else if(symbolNode.equals("b/"))
                {
                    return new IntLit(a / b);
                }
                else if(symbolNode.equals("b="))
                {
                    return new BoolLit(a=b);
                }
                else if(symbolNode.equals("b<"))
                {
                    return new BoolLit(a<b);
                }
                else if(symbolNode.equals("b>"))
                {
                    return new BoolLit(a>b);
                }                  
                else 
                {
                    Console.Write("Shit broke in Builtin becuase of pizza and Netflix all day.");
                    return new Nil();
                }
            } 
            if(symbolNode.equals("car"))
            {
                 car = car.getCar; //previously had check for null car
                 if (car.isNull())
                    Console.WriteLine("OOOOOOH SHIT DEMS BE ERRORS IN BUILTIN APPLY CALL OF CAR");
                 return car;
            }
            if(symbolNode.equals("cdr")) //requires a list, minimum '(example)
            {
                cdr = car.getCdr();
                if (cdr.isNull())
                    Console.WriteLine("OOOOOOH SHIT DEMS BE ERRORS IN BUILTIN APPLY CALL OF CDR");
                return car.getCdr;
            }
            if(symbolNode.equals("cons"))
            {
                return new Cons(car,cdr); //assumes we already have a list going on
            }
            if(symbolNode.equals("set-car!")) //needs better checks of criteria, errors
            {
                car.setCar(cdr); //this looks correct. 
                return car;
            }
            if(symbolNode.equals("set-cdr!")) //needs better checks of criteria, errors
            {
                car.setCdr(cdr);
                return car;
            }
            if(symbolNode.equals("null?")) 
            {
                return new BoolLit(car.isNull()); //car is never null.
            }
            if(symbolNode.equals("pair?")) //1 argument
            {
                return new BoolLit(car.isPair());
            }
            if(symbolNode.equals("eq?"))     //Equals for ints, bools, strings. nodes (only 2 arguments)
            {
                if(car.isNumber() && cdr.isNumber())
                {
                    return new BoolLit(car.getValue()==cdr.getValue());
                }
                else if(car.isString() && cdr.isString())
                {
                    return new BoolLit(car.getValue().equals(cdr.getValue()));
                }
                else if(car.isSymbol() && cdr.isSymbol())
                {
                    return new BoolLit(car.getValue().equals(cdr.getValue()));
                }
                else if(car.isBool() && cdr.isBool())
                {
                    return new BoolLit(car.getBool(), cdr.getBool());
                }
            }
            if(symbolNode.equals("procedure?"))
            {
                return new BoolLit(car.isProcedure());
            }
            if(symbolNode.equals("read")) // not started
            {
                Parser P = new Parser(); //?????
                
            }
            if(symbolNode.equals("write")) // not started
            {
                
            }
            if(symbolNode.equals("display"))
            {
                return Console.Write(car); 
            }
            if(symbolNode.equals("newline")) // not started
            {
                return Console.WriteLine(); //shhhhhh no tears
            }
            if(symbolNode.equals("eval")) // not started
            {
                //returns an error
                //Make some dumb switch statement to call c# eval or (eval '(z yet) env)??
                return eval(args);
            }
            if(symbolNode.equals("apply")) // not started
            {
                return apply(car); //??
            }
            if(symbolNode.equals("interaction-environment")) // not started
            {
                //what the flying fuck?!?
            }
            
            //now???!!!!
            
        }
        
        
        
        
        
       // public /* override */ Node apply (Node args)
        //{
         //   return new StringLit("Error: BuiltIn.apply not yet implemented");
    	//}
    }    
}

