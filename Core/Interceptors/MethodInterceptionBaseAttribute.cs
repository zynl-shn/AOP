﻿using Castle.DynamicProxy;

namespace Core.Interceptors;
[AttributeUsage(AttributeTargets.Method |AttributeTargets.Class| AttributeTargets.Assembly,AllowMultiple = true,Inherited = true)]
public abstract class MethodInterceptionBaseAttribute: Attribute,IInterceptor
{
    public int Priority { get; set; }
    public virtual void Intercept(IInvocation invocation)
    {
    }
}