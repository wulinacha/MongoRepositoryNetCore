using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RedisRepository
{
    public class RedisQueryProvider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new RedisQuery<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            List<LambdaExpression> lambdaExpressions = new List<LambdaExpression>();
            VisitExpression.Visit(expression,ref lambdaExpressions);
            IEnumerable<Product> enumerable = null;
            for (int i = 0; i < lambdaExpressions.Count; i++)
            {
                //把LambdaExpression转成Expression<Func<Student, bool>>类型
                //通过方法Compile()转成委托方法
                Func<Product, bool> func = (lambdaExpressions[i] as Expression<Func<Product, bool>>).Compile();
                if (enumerable == null)
                    enumerable = RedisQuery<Product>.List.Where(func);//取得IEnumerable
                else
                    enumerable = enumerable.Where(func);
            }
            dynamic obj = enumerable.ToList();
            return (TResult)obj;
        }
    }
}
