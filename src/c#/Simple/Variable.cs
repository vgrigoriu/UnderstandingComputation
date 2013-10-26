﻿namespace Simple
{
    public class Variable<T>: IExpression<T>
    {
        private string name;

        public T Value
        {
            get { throw new System.NotImplementedException(); }
        }

        public IExpression<T> Evaluate(IEnvironment environment)
        {
            return (IExpression<T>)environment[name];
        }

        public Variable(string name)
        {
            this.name = name;
        }
    }
}
