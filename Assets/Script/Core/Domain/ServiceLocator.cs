using System;
using System.Collections.Generic;

namespace Kamatte.Core
{
    public static class ServiceLocator    //  サービス中継クラス
    {
        static readonly Dictionary<Type, object> services = new();    //  サービス辞書

        //  --  Public API

        public static void Register<T>(T service)    //  登録
        {
            services[typeof(T)] = service;
        }
        public static void UnRegister<T>(T service)    //  登録解除
        {
            services[typeof(T)] = service;
        }

        public static T Resolve<T>()    //  取り出し
        {
            return (T)services[typeof(T)];
        }
    }
}