using System;
using System.Collections.Generic;

using Homework.PatentApplicationSystem.Model.Workflow;

namespace Homework.PatentApplicationSystem.Model
{
    /// <summary>
    /// ���û���ݴ�����ͬ�ķ������Ĺ�����ʵ�ִ˽ӿڡ�
    /// </summary>
    public interface IUserSpecificServiceFactory
    {
        /// <summary>
        /// Ϊ�û���Ϊ<param name="user"/>���û�����<typeparam name="T"/>����
        /// </summary>
        /// <returns>�����ķ����ࡣ</returns>
        /// <exception cref="NotSupportedException">��<typeparam name="T"/>����֧�����׳���</exception>
        T GetService<T>(User user) where T : class, IUserSpecificService;
    }

    class UserSpecificServiceFactory : IUserSpecificServiceFactory
    {
        private readonly IDictionary<Type, Func<User, IUserSpecificService>> _services
            = new Dictionary<Type, Func<User, IUserSpecificService>>();

        public UserSpecificServiceFactory()
        {
            _services.Add(typeof (I�참Ա���̷���), Create�참Ա���̷���);
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

        private IUserSpecificService Create�참Ա���̷���(User arg)
        {
            throw new NotImplementedException();
        }
    }
}