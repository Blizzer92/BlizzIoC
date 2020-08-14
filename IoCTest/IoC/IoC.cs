using System;
using System.Collections.Generic;
using System.Reflection;

namespace IoC
{
    public class IoCResolver
    {
        private readonly Dictionary<string,Type> interfaceTypes = new Dictionary<string, Type>();
        private readonly Dictionary<string, object> classes = new Dictionary<string, object>();

        public IoCResolver(string assembly)
        {
            Assembly accsses = Assembly.LoadFile(assembly);
            
            Type[] accssesTypes = accsses.GetTypes();
            foreach (Type accssesType in accssesTypes)
            {
                foreach (Type interfaceType in accssesType.GetInterfaces())
                {
                    this.interfaceTypes.Add(interfaceType.Name, accssesType);
                    this.classes.Add(interfaceType.Name, Activator.CreateInstance(accssesType));
                }
            }
        }
        
        public T Resolve<T>(bool asNew = false)
        {
            Type targetType = typeof(T);
            ConstructorInfo[] constructors = targetType.GetConstructors();
            T dataAccsses = default;
            foreach (ConstructorInfo constructor in constructors)
            {
                ParameterInfo[] constructorParameters = constructor.GetParameters();
                object[] argarray = new object[constructorParameters.Length];

                if (asNew)
                {
                    for (int i = 0; i < constructorParameters.Length; i++)
                    {
                        argarray[i] = Activator.CreateInstance(this.interfaceTypes[constructorParameters[i].ParameterType.Name]);
                    }
                }
                else
                {
                    for (int i = 0; i < constructorParameters.Length; i++)
                    {
                        argarray[i] = this.classes[constructorParameters[i].ParameterType.Name];
                    }
                }
                dataAccsses = (T)Activator.CreateInstance(typeof(T), argarray);
                return dataAccsses;


            }

            return dataAccsses;
        }
    }
}