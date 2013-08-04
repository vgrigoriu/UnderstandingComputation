using Simple.Expressions;
using Simple.Statements;

namespace Simple.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var environment = Environment.Empty;
            environment = environment.AddValue("x", new Number(3));
            environment = environment.AddValue("y", new Number(4));

            var statement = new Assign<int>(
                new Variable<int>("x"), 
                new Add(
                    new Variable<int>("x"),
                    new Variable<int>("y")));

			var machine = new Machine(statement, environment);

			machine.Run();
        }
    }
}
