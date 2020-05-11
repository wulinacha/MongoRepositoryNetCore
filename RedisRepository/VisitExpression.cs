using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RedisRepository
{
    public static class VisitExpression
    {
        public static void Visit(Expression expression, ref List<LambdaExpression> lambdaOut)
        {
            if (lambdaOut == null)
                lambdaOut = new List<LambdaExpression>();
            switch (expression.NodeType)
            {
                case ExpressionType.Call://执行方法
                    MethodCallExpression method = expression as MethodCallExpression;
                    Console.WriteLine("方法名:" + method.Method.Name);
                    for (int i = 0; i < method.Arguments.Count; i++)
                        Visit(method.Arguments[i], ref lambdaOut);
                    break;
                case ExpressionType.Lambda://lambda表达式
                    LambdaExpression lambda = expression as LambdaExpression;
                    lambdaOut.Add(lambda);
                    Visit(lambda.Body, ref lambdaOut);
                    break;
                case ExpressionType.Equal://相等比较
                case ExpressionType.AndAlso://and条件运算
                    BinaryExpression binary = expression as BinaryExpression;
                    Console.WriteLine("运算符:" + expression.NodeType.ToString());
                    Visit(binary.Left, ref lambdaOut);
                    Visit(binary.Right, ref lambdaOut);
                    break;
                case ExpressionType.Constant://常量值
                    ConstantExpression constant = expression as ConstantExpression;
                    Console.WriteLine("常量值:" + constant.Value.ToString());
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression Member = expression as MemberExpression;
                    Console.WriteLine("字段名称:{0}，类型:{1}", Member.Member.Name, Member.Type.ToString());
                    break;
                case ExpressionType.Quote:
                    UnaryExpression Unary = expression as UnaryExpression;
                    Visit(Unary.Operand, ref lambdaOut);
                    break;
                default:
                    Console.Write("UnKnow");
                    break;
            }
        }
    }
}
