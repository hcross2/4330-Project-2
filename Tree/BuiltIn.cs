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
        public /* override */ new bool isProcedure()	
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
        
        public new Node apply(Node args)
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
                cdr = cdr.getCar();  //THIS IS THE CADR, DOESNT WORK FOR (1 . 2) 
            }  
            String symbolNode = symbol.getName();
            if(symbolNode.Equals("symbol?"))
            {
                return new BoolLit(car.isSymbol());
            }
            if(symbolNode.Equals("number?"))
            {
                return new BoolLit(car.isNumber());
            }
            
            if(car.isNumber() && cdr.isNumber())
            {
                int a = car.getValue();
                int b = cdr.getValue();
                if(symbolNode.Equals("b+"))
                {
                    return new IntLit(a + b);
                }
                else if(symbolNode.Equals("b-"))
                {
                    return new IntLit(a - b);
                }
                else if(symbolNode.Equals("b*"))
                {
                    return new IntLit(a * b);
                }
                else if(symbolNode.Equals("b/"))
                {
                    return new IntLit(a / b);
                }
                else if(symbolNode.Equals("b="))
                {
                    return new BoolLit(a==b);
                }
                else if(symbolNode.Equals("b<"))
                {
                    return new BoolLit(a<b);
                }
                else if(symbolNode.Equals("b>"))
                {
                    return new BoolLit(a>b);
                }                  
                else 
                {
                    Console.Write("Shit broke in Builtin becuase of pizza and Netflix all day.");
                    return new Nil();
                }
            } 
            if(symbolNode.Equals("car"))
            {
                 car = car.getCar(); //previously had check for null car
                 if (car.isNull())
                    Console.WriteLine("OOOOOOH SHIT DEMS BE ERRORS IN BUILTIN APPLY CALL OF CAR");
                 return car;
            }
            if(symbolNode.Equals("cdr")) //requires a list, minimum '(example)
            {
                cdr = car.getCdr();
                if (cdr.isNull())
                    Console.WriteLine("OOOOOOH SHIT DEMS BE ERRORS IN BUILTIN APPLY CALL OF CDR");
                return car.getCdr();
            }
            if(symbolNode.Equals("cons"))
            {
                return new Cons(car,cdr); //assumes we already have a list going on
            }
            if(symbolNode.Equals("set-car!")) //needs better checks of criteria, errors
            {
                car.setCar(cdr); //this looks correct. 
                return car;
            }
            if(symbolNode.Equals("set-cdr!")) //needs better checks of criteria, errors
            {
                car.setCdr(cdr);
                return car;
            }
            if(symbolNode.Equals("null?")) 
            {
                return new BoolLit(car.isNull()); //car is never null.
            }
            if(symbolNode.Equals("pair?"))
            {
                return new BoolLit(car.isPair());
            }
            if(symbolNode.Equals("eq?"))  
            {
                if(car.isNumber() && cdr.isNumber())
                {
                    return new BoolLit(car.getValue()==cdr.getValue());
                }
                else if(car.isString() && cdr.isString())
                {
                    return new BoolLit(car.getValue().Equals(cdr.getValue()));
                }
                else if(car.isSymbol() && cdr.isSymbol())
                {
                    return new BoolLit(car.getValue().Equals(cdr.getValue()));
                }
                else if(car.isBool() && cdr.isBool())
                {
                    return new BoolLit(car.getBool().Equals(cdr.getBool()));
                }
            }
            if(symbolNode.Equals("procedure?"))
            {
                return new BoolLit(car.isProcedure());
            }
            if(symbolNode.Equals("read")) // not started
            {
                
                return null;
            }
            if(symbolNode.Equals("write")) // not started
            {
                car.print(0);
                return new StringLit("");
            }
            if(symbolNode.Equals("display"))
            {
                return car; 
            }
            if(symbolNode.Equals("newline")) // is this right?!
            {
                return new StringLit("");
            }
            if(symbolNode.Equals("eval")) // is this right?!
            {
                return car;
            }
            if(symbolNode.Equals("apply"))
            {
                return car.apply(cdr); //??
            }
            if(symbolNode.Equals("interaction-environment")) // not started
            {
                return null;
                //what the flying fuck?!?
            }

            //now???!!!!
            return null;
        }
        public Node eval(Node t, Environment env)
        {
            return new Nil();
        }
        
        
        
        
       // public /* override */ Node apply (Node args)
        //{
         //   return new StringLit("Error: BuiltIn.apply not yet implemented");
    	//}
    }    
}

