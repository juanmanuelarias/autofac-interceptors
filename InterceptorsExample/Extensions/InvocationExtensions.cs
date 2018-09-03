using Castle.DynamicProxy;
using System.Linq;
using System.Reflection;

namespace InterceptorsExample.Interceptors
{
    public static class InvocationExtensions
    {
        public static CustomAttributeData GetAttribute<T>(this IInvocation invocation)
        {
            return invocation
                .MethodInvocationTarget
                .CustomAttributes
                .FirstOrDefault(a => a.AttributeType == typeof(T));
        }

        public static string GetValue(this CustomAttributeData attributeData, string key)
        {
            var attribute = attributeData
                .NamedArguments
                .FirstOrDefault(a => a.MemberName == key);

            return attribute.TypedValue.Value?.ToString();
        }
    }
}
