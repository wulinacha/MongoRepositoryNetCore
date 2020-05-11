using System;
using System.Collections.Generic;
using System.Text;

namespace RedisRepository
{
    public class Error
    {
        public static Exception ArgumentNull(string s) {
            throw new Exception(s);
        }

        public static Exception NotSupported() {
            throw new Exception("不支持");
        }

        public static Exception NoMatch() {
            throw new Exception("不匹配");
        }

        public static Exception NoElements() {
            throw new Exception("无源码");
        }

        public static Exception MoreThanOneMatch() {
            throw new Exception("多余1个匹配");
        }

        public static Exception MoreThanOneElement() {
            throw new Exception("过多匹配元素");
        }

        public static Exception ArgumentOutOfRange()
        {
            throw new Exception("超出索引");
        }

        public static Exception ArgumentOutOfRange(string index)
        {
            throw new Exception("过多匹配元素");
        }
    }
}
