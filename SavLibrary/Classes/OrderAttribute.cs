using System;
using System.Runtime.CompilerServices;

namespace SavLibrary {
    // From: https://stackoverflow.com/a/17998371/342378
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class OrderAttribute : Attribute {
        private readonly int order_;

        public OrderAttribute([CallerLineNumber] int order = 0) {
            order_ = order;
        }

        public int Order { get { return order_; } }
    }
}
