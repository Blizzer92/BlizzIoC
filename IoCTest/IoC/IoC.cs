using System;
using System.Collections.Generic;
using System.Reflection;

namespace IoC
{
    public class IoCResolver
    {
        private Dictionary<string,Type> interfaces = new Dictionary<string, Type>();

        public IoCResolver(string assembly)
        {
            Assembly accsses = Assembly.LoadFile(
                $@"C:\Users\sjuette\RiderProjects\ioctest\IoCTest\bin\Debug\netcoreapp3.1\{assembly}.dll");
            
            Type[] accssesTypes = accsses.GetTypes();
            foreach (Type accssesType in accssesTypes)
            {
                foreach (Type @interface in accssesType.GetInterfaces())
                {
                    this.interfaces.Add(@interface.Name, accssesType);
                }
            }
        }
        
        public T Resolve<T>()
        {
            Type targetType = typeof(T);
            ConstructorInfo[] constructors = targetType.GetConstructors();
            T dataAccsses = default;
            foreach (ConstructorInfo constructor in constructors)
            {
                ParameterInfo[] constructorParameters = constructor.GetParameters();
                object[] argarray = new object[constructorParameters.Length];

                for (int i = 0; i < constructorParameters.Length; i++)
                {
                    argarray[i] = Activator.CreateInstance(this.interfaces[constructorParameters[i].ParameterType.Name]);
                }
                dataAccsses = (T)Activator.CreateInstance(typeof(T), argarray);
                return dataAccsses;
            }

            return dataAccsses;
        }
    }
}