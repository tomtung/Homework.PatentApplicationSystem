using System;
using System.Collections.Generic;

using Homework.PatentApplicationSystem.Model.Workflow;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// 依用户身份创建不同的服务对象的工厂类实现此接口。
    /// </summary>
    public interface IUserSpecificServiceFactory
    {
        /// <summary>
        /// 为用户名为<param name="user"/>的用户创建<typeparam name="T"/>服务。
        /// </summary>
        /// <returns>创建的服务类。</returns>
        /// <exception cref="NotSupportedException">当<typeparam name="T"/>不被支持是抛出。</exception>
        T GetService<T>(User user) where T : class, IUserSpecificService;
    }

    class UserSpecificServiceFactory : IUserSpecificServiceFactory
    {
        private readonly IDictionary<Type, Func<User, IUserSpecificService>> _services
            = new Dictionary<Type, Func<User, IUserSpecificService>>();

        public UserSpecificServiceFactory()
        {
            _services.Add(typeof (I办案员流程服务), Create办案员流程服务);
        }

        #region IUserSpecificServiceFactory Members

        public T GetService<T>(User user) where T : class, IUserSpecificService
        {
            if (!_services.ContainsKey(typeof (T)))
            {
                throw new NotSupportedException();
            }
            return _services[typeof (T)](user) as T;
        }

        #endregion

        private IUserSpecificService Create办案员流程服务(User arg)
        {
            throw new NotImplementedException();
        }
    }
}