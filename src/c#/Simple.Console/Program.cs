namespace Simple.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var environment = new Environment();
            environment.SetVariable("x", 3);
            environment.SetVariable("y", 4);

            var expression = new LessThan(
                new Multiply(new Number(1), new Number(2)),
                new Multiply(new Number(3), new Number(4)));

			var machine = Machine.ForExpression(expression, environment);

			machine.Run();
        }
    }
}
