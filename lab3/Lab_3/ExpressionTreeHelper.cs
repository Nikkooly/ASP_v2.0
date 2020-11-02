using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FastMember;

namespace Lab_3
{
    public static class ExpressionTreeHelper
    {
        public static dynamic GetDynamicFields<TEntity>(this TEntity entity, string[] fields)
            where TEntity : class
        {
            dynamic dynamic = new ExpandoObject();
            IDictionary<string, object> dictionary = dynamic as IDictionary<string, object>;

            TypeAccessor typeAccessor = TypeAccessor.Create(typeof(TEntity));
            ObjectAccessor accessor = ObjectAccessor.Create(entity);
            IDictionary<string, Member> members = typeAccessor.GetMembers().ToDictionary(x => x.Name);

            for (int i = 0; i < fields.Length; i++)
            {
                if (members.ContainsKey(fields[i]))
                {
                    var prop = members[fields[i]];

                    if (dictionary.ContainsKey(prop.Name))
                        dictionary[prop.Name.ToLower()] = accessor[prop.Name];
                    else
                        dictionary.Add(prop.Name.ToLower(), accessor[prop.Name]);
                }
            }

            return dynamic;
        }
    }
}
