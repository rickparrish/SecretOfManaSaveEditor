using System;

namespace SavLibrary {
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public sealed class MaxAttribute : Attribute {
        private readonly int max;

        public MaxAttribute(int max = 0) {
            this.max = max;
        }

        public int Max { 
            get { 
                return max;
            }
        }
    }
}
