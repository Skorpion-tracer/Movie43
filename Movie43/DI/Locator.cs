using Movie43.Entities;
using Movie43.Models;
using Movie43.Repositories;
using Movie43.Services;
using Ninject;
using System;

namespace Movie43.DI
{
    public static class Locator
    {
        #region Поля
        private static readonly IKernel _kernel;
        #endregion

        #region Конструктор
        static Locator()
        {
            _kernel = new StandardKernel();
        }
        #endregion

        #region Публичные методы
        public static void Load()
        {
            BindModels();
            BindRepositories();
            BindViewModels();
            BindServices();
        }

        public static T Resolve<T>()
        {
            if (!_kernel.CanResolve<T>())
            {
                throw new ArgumentException($"{typeof(T).Name} не зарегистрирован в контейнере.");
            }
            return _kernel.Get<T>();
        }
        #endregion

        #region Приватные методы
        private static void BindModels()
        {
            BindSingleton<FilmModel>();
        }

        private static void BindRepositories()
        {
            BindTransient<IRepository<Film>, XMLRepository<Film>>();
        }

        private static void BindViewModels()
        {

        }

        private static void BindServices()
        {
            BindTransient<FilmService>();
        }

        private static void BindTransient<T>()
        {
            _kernel.Bind<T>().ToSelf().InTransientScope();
        }

        private static void BindSingleton<T>()
        {
            _kernel.Bind<T>().ToSelf().InSingletonScope();
        }

        private static void BindTransient<T1, T2>() where T2 : T1
        {
            _kernel.Bind<T1>().To<T2>().InTransientScope();
        }

        private static void BindSingleton<T1, T2>() where T2 : T1
        {
            _kernel.Bind<T1>().To<T2>().InSingletonScope();
        }
        #endregion
    }
}
