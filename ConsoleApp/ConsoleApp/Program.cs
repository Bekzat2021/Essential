using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Dynamic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic person = new PersonObject();

            person.Name = "Tom";
            person.Age = 23;

            Func<int, int> Incr = delegate (int x) 
            { 
                person.Age += x; 
                return person.Age; 
            };

            person.IncrementAge = Incr;
            Console.WriteLine($"{person.Name} - {person.Age}");

            person.IncrementAge(4);
            Console.WriteLine($"{person.Name} - {person.Age}");

            //dynamic viewBag = new System.Dynamic.ExpandoObject();
            //viewBag.Name = "Tom";
            //viewBag.Age = 26;
            //viewBag.Languages = new List<string> { "english", "german", "french" };
            //Console.WriteLine($"{viewBag.Name} - {viewBag.Age}");

            //foreach (var item in viewBag.Languages)
            //{
            //    Console.WriteLine(item);
            //}

            //viewBag.IncrementAge = (Action<int>)(x => viewBag.Age += x);
            //viewBag.IncrementAge(6);
            //Console.WriteLine($"{viewBag.Name} - {viewBag.Age}");
        }
    }

    class PersonObject : DynamicObject
    {
        Dictionary<string, object> members = new Dictionary<string, object>();

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            members[binder.Name] = value;
            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            if (members.ContainsKey(binder.Name))
            {
                result = members[binder.Name];
                return true;
            }
            return false;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            dynamic method = members[binder.Name];
            result = method((int)args[0]);
            return result != null;
        }
    }

    #region Person class
    class Person
    {
        public string Name { get; set; }
        public dynamic Age { get; set; }

        public dynamic GetSalary(dynamic value, string format)
        {
            if (format == "string")
            {
                return value + " рублей";
            }
            else if (format == "int")
            {
                return value;
            }
            else
            {
                return 0.0;
            }
        }
        public override string ToString()
        {
            return Name + ", " + Age.ToString();
        }
    }
    #endregion
}