using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RedisRepository
{
    public class RedisQuery<T> : IQueryable<T>
    {
        public RedisQuery()
        {
            Provider = new RedisQueryProvider();
            Expression = Expression.Constant(this);
        }

        public RedisQuery(Expression expression)
        {
            Provider = new RedisQueryProvider();
            Expression = expression;
        }
        public Type ElementType => throw new NotImplementedException();

        public Expression Expression { get; set; }

        public IQueryProvider Provider { get; }
        public static List<T> List { get; set; } = new List<T>();

        public void Add(T item) {
            List.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var result = Provider.Execute<List<T>>(Expression);
            if (result == null)
                yield break;
            foreach (var item in result)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (Provider.Execute(Expression) as IEnumerable).GetEnumerator();
        }
    }
}
