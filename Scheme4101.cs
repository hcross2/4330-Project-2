// Emmitt Busch and Hunter Crossett

using System;
using Parse;
using Tokens;
using Tree;

public class Scheme4101
{
    public static int Main(string[] args)
    {
        // Create scanner that reads from standard input
        Scanner scanner = new Scanner(Console.In);
        
        if (args.Length > 1 ||
            (args.Length == 1 && ! args[0].Equals("-d")))
        {
            Console.Error.WriteLine("Usage: mono SPP [-d]");
            return 1;
        }
        
        // If command line option -d is provided, debug the scanner.
        if (args.Length == 1 && args[0].Equals("-d"))
        {
            // Console.Write("Scheme 4101> ");
            Token tok = scanner.getNextToken();
            while (tok != null)
            {
                TokenType tt = tok.getType();

                Console.Write(tt);
                if (tt == TokenType.INT)
                    Console.WriteLine(", intVal = " + tok.getIntVal());
                else if (tt == TokenType.STRING)
                    Console.WriteLine(", stringVal = " + tok.getStringVal());
                else if (tt == TokenType.IDENT)
                    Console.WriteLine(", name = " + tok.getName());
                else
                    Console.WriteLine();

                // Console.Write("Scheme 4101> ");
                tok = scanner.getNextToken();
            }
            return 0;
        }

        // Create parser
        TreeBuilder builder = new TreeBuilder();
        Parser parser = new Parser(scanner, builder);
        Node root;
        
        // TODO: Create and populate the built-in environment and
        // create the top-level environment
        Tree.Environment env = new Tree.Environment(); //Added "Tree. " in front to SHUT IT UPPPP
        Node id = new Ident ("car");
        env.define(id, new BuiltIn(id));
        env = new Tree.Environment(env);  //Added "Tree. " in front of Environment to Shut It UPPP
        // Read-eval-print loop

        // TODO: print prompt and evaluate the expression
        root = (Node) parser.parseExp();
        while (root != null) 
        {
            if(env!=null)
            {
                root.eval(env).print(0);
                root = (Node)parser.parseExp();
            }
            else
            {
                Console.WriteLine("Environment not defined");
            }
            
        }

        return 0;
    }
}