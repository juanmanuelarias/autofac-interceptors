using System;

namespace InterceptorsExample.Interceptors
{
    public class Measure : Attribute
    {
        public string MetricName { get; set; }
    }
}
