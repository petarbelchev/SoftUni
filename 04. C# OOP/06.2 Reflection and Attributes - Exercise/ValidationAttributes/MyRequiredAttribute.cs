using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string str)
            {
                return !string.IsNullOrEmpty(str);
            }

            return obj != null;
        }
    }
}
