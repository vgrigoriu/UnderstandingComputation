using System;

namespace Simple
{
	public class Machine<T>
	{
		private IExpression<T> expression;

		public IExpression<T> Expression
		{
			get { return expression; }
		}

		public Machine(IExpression<T> expression)
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

