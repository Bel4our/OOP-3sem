using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP11
{

    static class Reflector
    {
        public static string NameofAssembly(Object obj)
        {
            Type type = obj.GetType();

            return type.Assembly.FullName;
        }

        public static bool HasPublicConstructors(Object obj)
        {
            Type type = obj.GetType();

            foreach (var constructor in type.GetConstructors())
            {
                if (constructor.IsPublic)
                {
                    return true;
                }
            }
            return false;
        }

        public static IEnumerable<string> GetPublicMethods(Object obj)
        {
            Type type = obj.GetType();

            IEnumerable<string> methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Select(m => m.Name);


            return methods;
        }

        public static IEnumerable<string> GetPropertiesAndFields(Object obj)
        {
            Type type = obj.GetType();

            IEnumerable<string> mas = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).Select(m => m.Name);
            IEnumerable<string> fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static).Select(m => m.Name);
            IEnumerable<string> ret = mas.Concat(fields);

            return ret;

        }


        public static IEnumerable<string> GetRInterfaces(Object obj)
        {
            Type type = obj.GetType();

            IEnumerable<string> methods = type.GetInterfaces().Select(m => m.Name);

            return methods;
        }

        public static IEnumerable<string> GetMethodsWithParameterType(string name, string param)
        {
            Type type = Type.GetType(name);

            return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                   .Where(m => m.GetParameters().Any(p => p.ParameterType.Name == param))
                   .Select(m => m.Name);
        }

        public static object Invoke(string className, string methodName, string parametersFilePath = "")
        {
            Type type = Type.GetType(className);

            MethodInfo method = type.GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

            ParameterInfo[] parameters = method.GetParameters();

            object[] args = parameters.Length == 0 ? null : new object[parameters.Length];


            if (args != null && File.Exists(parametersFilePath))
            {
                string[] values = File.ReadAllLines(parametersFilePath);
                for (int i = 0; i < parameters.Length; i++)
                {
                    args[i] = Convert.ChangeType(values[i], parameters[i].ParameterType);
                }
            }
            else if (args != null)
            {
                Random rnd = new Random();
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType == typeof(int))
                        args[i] = rnd.Next(1, 100);
                    else if (parameters[i].ParameterType == typeof(string))
                        args[i] = $"String{rnd.Next(1, 100)}";
                    else
                        args[i] = Activator.CreateInstance(parameters[i].ParameterType);
                }
            }

            object obj = Activator.CreateInstance(type);
            return method.Invoke(obj, args);
        }

        public static void WriteClassInfoToFile(Object obj, string filePath)
        {
            var info = new
            {
                AssemblyName = NameofAssembly(obj),
                HasPublicConstructors = HasPublicConstructors(obj),
                PublicMethods = GetPublicMethods(obj),
                PropertiesAndFields = GetPropertiesAndFields(obj),
                Interfaces = GetRInterfaces(obj)
            };

            string json = JsonSerializer.Serialize(info, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }


        public static T Create<T>() where T : class
        {
            Type type = typeof(T);
            ConstructorInfo constructor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault();

            ParameterInfo[] parameters = constructor.GetParameters();
            object[] args = new object[parameters.Length];
            Random rnd = new Random();

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType == typeof(int))
                    args[i] = rnd.Next(1, 100);
                else if (parameters[i].ParameterType == typeof(string))
                    args[i] = $"{rnd.Next(1, 100)}";
                else
                    args[i] = Activator.CreateInstance(parameters[i].ParameterType);
            }

            return constructor.Invoke(args) as T;
        }
    }

}
