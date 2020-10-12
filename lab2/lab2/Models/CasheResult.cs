using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab2.Models
{
    public class CacheResult
    {
        public static int Result { get; set; }

        private static ConcurrentStack<int> _stack;

        public static void PopStack()
        {
            CreateStackIfNeeded();
            Result += _stack.Any() && _stack.TryPop(out var num) ? num : 0;
        }

        public static void PushToStack(int number)
        {
            CreateStackIfNeeded();
            _stack.Push(number);
            Result += number;
        }

        private static void CreateStackIfNeeded()
        {
            if (_stack == null)
                _stack = new ConcurrentStack<int>();
        }
    }
}