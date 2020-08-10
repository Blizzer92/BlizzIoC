﻿using System;
using System.Linq;
using System.Reflection;
using Interfaces;
using IoCTest;

namespace IoC
{
    public class IoC
    {
        public static T Resolve<T>(string name)
        {
            Assembly accsses = Assembly.LoadFile(
                $@"C:\Users\sjuette\RiderProjects\ioctest\IoCTest\bin\Debug\netcoreapp3.1\{name}.dll");


            Type targetType = typeof(T);
            ConstructorInfo[] constructor = targetType.GetConstructors();
            Type[] accssesTypes = accsses.GetTypes();
            T dataAccsses = default(T);
            foreach (ConstructorInfo constructorInfo in constructor)
            {
                foreach (Type type in accssesTypes)
                {
                    ParameterInfo[] constructorParameter = constructorInfo.GetParameters();

                    foreach (ParameterInfo parameterInfo in constructorParameter)
                    {
                        if (parameterInfo.ParameterType == type.GetInterface(parameterInfo.ParameterType.Name))
                        {
                            dataAccsses = (T)Activator.CreateInstance(typeof(T), Activator.CreateInstance(type!));
                            return dataAccsses;
                        }
                    }
                }
            }

            return dataAccsses;

        }
    }
}