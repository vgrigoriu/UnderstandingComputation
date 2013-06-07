namespace Simple
{
    public class Add:IExpression
    {
        private readonly IExpression left;

        private readonly IExpression right;

        public IExpression Left
        {
            get { return left; }
        }

        public IExpression Right
        {
            get { return right; }
        }

        public Add(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }
    }
}
