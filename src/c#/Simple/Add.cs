namespace Simple
{
    public class Add: IExpression<int>
    {
        private readonly Number firstOperand;
        private readonly Number secondOperand;

        public Add(Number firstOperand, Number secondOperand)
        {
            this.firstOperand = firstOperand;
            this.secondOperand = secondOperand;
        }
        public int Value
        {
            get { throw new System.NotImplementedException(); }
        }

        public IExpression<int> Evaluate(IEnvironment environment)
        {
            return new Number(firstOperand.Value + secondOperand.Value);
        }
    }
}
