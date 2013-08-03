namespace Simple.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var environment = new Environment();
            environment.SetVariable("x", new Number(3));
            environment.SetVariable("y", new Number(4));

            var expression = new Add(
                new Variable<int>("x"), 
                new Variable<int>("y"));

			var machine = Machine.ForExpression(expression, environment);

			machine.Run();
        }
    }
}
