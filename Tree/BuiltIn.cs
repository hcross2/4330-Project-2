// BuiltIn -- the data structure for built-in functions

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
                return null;
            }
            Node car = args.getCar();
            Node cdr = args.getCdr();
            if(car == null || car.isNull())    //IF CAR DOESN'T EXIST
            {
                car = new Nil();
            }
            if(cdr == null || cdr.isNull())   //IF CDR DOESN'T EXIST
            {
                cdr = new Nil();
            }
            else
            {
                cdr = cdr.getCar()  //THIS IS THE CADR
            }  
            String symbolNode = symbol.getName();
            if(symbolNode.equals("symbol?"))
            {
                return new BooleanLit(car.isSymbol());
            }
            if(symbolNode.equals("number?"))
            {
                return new BooleanLit(car.isNumber());
            }
            
            if(car.isNumber() && cdr.isNumber())
            {
                if(symbolNode.equals("b+"))
                {
                    int a = car.getValue();
                    int b = cdr.getValue();
                    return new IntLit(a+b);
                }
                if(symbolNode.equals("b-"))
                {
                    int a = car.getValue();
                    int b = cdr.getValue();
                    return new IntLit(a-b);
                }
                if(symbolNode.equals("b*"))
                {
                    int a = car.getValue();
                    int b = cdr.getValue();
                    return new IntLit(a*b);
                }
                if(symbolNode.equals("b/"))
                {
                    int a = car.getValue();
                    int b = cdr.getValue();
                    return new IntLit(a/b);
                }
                if(symbolNode.equals("b="))
                {
                    int a = car.getValue();
                    int b = cdr.getValue();
                    return new BoolLit(a=b);
                }
                if(symbolNode.equals("b<"))
                {
                    int a = car.getValue();
                    int b = cdr.getValue();
                    return new BoolLit(a<b);
                }
                if(symbolNode.equals("b>"))
                {
                    int a = car.getValue();
                    int b = cdr.getValue();
                    return new BoolLit(a>b);
                }                  
            } 
            if(symbolNode.equals("car"))
            {
                if(car.isNull)
                {
                    return car;
                }
                else
                {
                    return car.getCar;
                }
            }
            if(symbolNode.equals("cdr"))
            {
                if(car.isNull)
                {
                    return car;
                }
                else
                {
                    return car.getCdr;
                }
            }
            if(symbolNode.equals("cons"))
            {
                return new Cons(car,cdr);
            }
            
            if(symbolNode.equals("set-car!"))
            {
                car.setCar(cdr);
                return car;
            }
            if(symbolNode.equals("set-cdr!"))
            {
                car.setCdr(cdr);
                return car;
            }
            if(symbolNode.equals("null?"))
            {
                return new BoolLit(car.isNull());
            }
            if(symbolNode.equals("pair?"))
            {
                return new BoolLit(car.isPair());
            }
            if(symbolNode.equals("eq?"))     //Equals for ints, bools, strings, nodes
            {
                if(car.isNumber() && cdr.isNumber())
                {
                    return new BoolLit(car.getValue()==cdr.getValue());
                }
                if(car.isString() && cdr.isString())
                {
                    return new BoolLit(car.getValue().equals(cdr.getValue()));
                }
                if(car.isSymbol() && cdr.isSymbol())
                {
                    return new BoolLit(car.getValue().equals(cdr.getValue()));
                }
                
            }
            if(symbolNode.equals("procedure?"))
            {
                return new BoolLit(car.isProcedure());
            }
            if(symbolNode.equals("read"))
            {
                Parser P = new Parser();
                
            }
            if(symbolNode.equals("write"))
            {
                
            }
            if(symbolNode.equals("display"))
            {
                
            }
            if(symbolNode.equals("newline"))
            {
                
            }
            if(symbolNode.equals("eval"))
            {
                
            }
            if(symbolNode.equals("apply"))
            {
                
            }
            if(symbolNode.equals("interaction-environment"))
            {
                
            }
            
            
            
        }
        
        
        
        
        
       // public /* override */ Node apply (Node args)
        //{
         //   return new StringLit("Error: BuiltIn.apply not yet implemented");
    	//}
    }    
}

