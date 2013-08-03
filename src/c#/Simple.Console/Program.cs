namespace Simple.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var e = new Add(
                new Multiply(new Number(1), new Number(2)),
                new Multiply(new Number(3), new Number(4)));

			var machine = new Machine<int>(e);

			machine.Run();
        }
    }
}
