namespace Simple
{
    public class Number: IExpression<int>
    {
        public int Value
        {
            get { throw new System.NotImplementedException(); }
        }

        public IExpression<int> Evaluate(IEnvironment environment)
        {
            return this;
        }
    }
}
