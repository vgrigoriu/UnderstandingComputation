namespace Simple
{
    public static class Machine
    {
        public static Machine<T> ForExpression<T>(IExpression<T> expression)
        {
            return new Machine<T>(expression);
        }
    }
}

