using System;

namespace ChurnZeroApiClient.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class QueryParamNameAttribute : Attribute
    {
        private readonly string _name;

        public QueryParamNameAttribute(string name)
        {
            _name = name;
        }

        public virtual string Name
        {
            get { return _name; }
        }
    }
}
