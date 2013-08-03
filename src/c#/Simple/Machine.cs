using System;

namespace Simple
{
	public class Machine
	{
		private IExpression expression;

		public IExpression Expression
		{
			get { return expression; }
		}

		public Machine(IExpression expression)
		{
			this.expression = expression;
		}

		public void Run()
		{
			while (expression.IsReducible)
			{
				Console.WriteLine(expression);
				Step();
			}

			Console.WriteLine(expression);
		}

		private void Step()
		{
			expression = expression.Reduce();
		}
	}
}

