﻿using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Interceptors;

public class AspectInterceptorSelector: IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
        var methodAttributes = type.GetMethod(method.Name)?.GetCustomAttributes<MethodInterceptionBaseAttribute>(true);


        if (methodAttributes!=null)
        {
            classAttributes.AddRange(methodAttributes);
        }

        return classAttributes.OrderBy(x=>x.Priority).ToArray();
    }
}