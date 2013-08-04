using Simple.Expressions;

namespace Simple.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var environment = Environment.Empty;
            environment = environment.AddValue("x", new Number(3));
            environment = environment.AddValue("y", new Number(4));

            var expression = new Add(
                new Variable<int>("x"), 
                new Variable<int>("y"));

			var machine = Machine.ForExpression(expression, environment);

			machine.Run();
        }
    }
}
