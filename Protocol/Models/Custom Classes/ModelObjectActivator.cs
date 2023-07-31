namespace Skyline.DataMiner.CICD.Models.Protocol.Models.Custom_Classes
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Reflection;

    internal static class ModelObjectActivator<T1, T2, TResult> where TResult : class
    {
        static readonly ConcurrentDictionary<Type, Func<T1, T2, TResult>> _cache = new ConcurrentDictionary<Type, Func<T1, T2, TResult>>();

        public static bool TryCreate(Type type, T1 arg1, T2 arg2, out TResult result)
        {
            var func = _cache.GetOrAdd(type,
                t => ModelObjectActivatorHelper.TryCreateConstructorLambda<Func<T1, T2, TResult>>(
                    type,
                    new[] {typeof(T1), typeof(T2)},
                    new[] {arg1.GetType(), arg2.GetType()}));

            if (func != null)
            {
                result = func(arg1, arg2);
                return true;
            }

            result = null;
            return false;
        }
    }

    internal static class ModelObjectActivator<T1, T2, T3, TResult> where TResult : class
    {
        static readonly ConcurrentDictionary<Type, Func<T1, T2, T3, TResult>> _cache = new ConcurrentDictionary<Type, Func<T1, T2, T3, TResult>>();

        public static bool TryCreate(Type type, T1 arg1, T2 arg2, T3 arg3, out TResult result)
        {
            var func = _cache.GetOrAdd(type,
                t => ModelObjectActivatorHelper.TryCreateConstructorLambda<Func<T1, T2, T3, TResult>>(
                    type,
                    new[] {typeof(T1), typeof(T2), typeof(T3)},
                    new[] {arg1.GetType(), arg2.GetType(), arg3.GetType()}));

            if (func != null)
            {
                result = func(arg1, arg2, arg3);
                return true;
            }

            result = null;
            return false;
        }
    }

    internal static class ModelObjectActivatorHelper
    {
        internal static TDelegate TryCreateConstructorLambda<TDelegate>(Type type, Type[] types, Type[] argTypes) where TDelegate : class
        {
            TDelegate func = null;

            if (TryFindConstructor(type, argTypes, out ConstructorInfo constructorInfo))
            {
                func = TryCreateConstructorLambda<TDelegate>(constructorInfo, types);
            }

            return func;
        }

        private static bool TryFindConstructor(Type type, Type[] types, out ConstructorInfo constructorInfo)
        {
            constructorInfo = null;

            foreach (var ct in type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                bool ok = true;

                var constParameters = ct.GetParameters();
                if (constParameters.Length < types.Length)
                    ok = false;

                for (var i = 0; i < constParameters.Length && ok; i++)
                {
                    var p = constParameters[i];

                    if (types.Length > i)
                    {
                        if (!p.ParameterType.IsAssignableFrom(types[i]))
                        {
                            ok = false;
                        }
                    }
                    else if (!p.IsOptional)
                    {
                        ok = false;
                    }
                }

                if (ok)
                {
                    constructorInfo = ct;
                    break;
                }
            }

            return constructorInfo != null;
        }

        private static TDelegate TryCreateConstructorLambda<TDelegate>(ConstructorInfo constructorInfo, Type[] types)
            where TDelegate : class
        {
            var parameters = new List<ParameterExpression>();
            var args = new List<Expression>();

            var constParameters = constructorInfo.GetParameters();
            for (var i = 0; i < constParameters.Length; i++)
            {
                var p = constParameters[i];

                if (i < types.Length)
                {
                    var paramExp = Expression.Parameter(types[i], p.Name);
                    parameters.Add(paramExp);

                    if (types[i] == p.ParameterType)
                        args.Add(paramExp);
                    else
                        args.Add(Expression.Convert(paramExp, p.ParameterType));
                }
                else if (p.IsOptional)
                {
                    args.Add(Expression.Constant(p.DefaultValue));
                }
            }

            var newExp = Expression.New(constructorInfo, args);
            var lambda = Expression.Lambda<TDelegate>(newExp, parameters);

            return lambda.Compile();
        }
    }

}
