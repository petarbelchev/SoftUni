using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();

            PropertyInfo[] properties = objType
                .GetProperties()
                .Where(p => p.CustomAttributes
                .Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj);

                foreach (CustomAttributeData customAttributeData in property.CustomAttributes)
                {
                    Type customAttributeType = customAttributeData.AttributeType;
                    Attribute attributeInstance = property.GetCustomAttribute(customAttributeType);
                    MethodInfo method = customAttributeType.GetMethod("IsValid");
                    bool result = (bool)method.Invoke(attributeInstance, new object[] { propValue });

                    if (!result)
                        return false;
                }
            }

            return true;
        }
    }
}
