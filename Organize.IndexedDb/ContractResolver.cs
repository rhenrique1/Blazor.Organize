using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Organize.IndexedDb
{
    public class ContractResolver : DefaultContractResolver
    {
        public ContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy();
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            var propertyType = property.PropertyType;
            var isSimpleProperty = propertyType == typeof(int)
                                   || propertyType == typeof(string)
                                   || propertyType == typeof(bool)
                                   || propertyType == typeof(decimal)
                                   || propertyType == typeof(double)
                                   || propertyType == typeof(float)
                                   || propertyType.IsEnum;

            if (isSimpleProperty)
            {
                property.ShouldSerialize = instance => true;
            }
            else
            {
                property.ShouldSerialize = instance => false;
            }

            return property;
        }
    }
}
