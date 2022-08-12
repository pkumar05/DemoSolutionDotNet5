using System;

namespace DS.Domain.DynamicQuery
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    sealed class SourcePropertyAttribute : Attribute
    {
        public SourcePropertyAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
