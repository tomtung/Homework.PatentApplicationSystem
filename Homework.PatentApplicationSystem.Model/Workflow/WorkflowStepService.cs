using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    internal class WorkflowStepService : IWorkflowStepService
    {
        private readonly string _bookmarkName;
        private readonly User _user;

        /// <remark>
        /// 假设：参数合法
        /// </remark>
        internal WorkflowStepService(User user, string bookmarkName)
        {
            _user = user;
            _bookmarkName = bookmarkName;
        }

        public string BookmarkName
        {
            get { return _bookmarkName; }
        }

        #region Implementation of IUserSpecificService

        public User User
        {
            get { return _user; }
        }

        #endregion

        #region Implementation of IWorkflowStepService

        public IEnumerable<Guid> PendingCaseIds
        {
            get
            {
                return GlobalKernel.Instance.Get<IBookmarkRecordManager>()
                    .GetIdsOfAllCaseSuspendedAt(BookmarkName)
                    .Where(IsTaskAssignedToMe);
            }
        }

        /// <remarks>
        /// 使用这个方法的假设是：案件编号为<param name="caseId"/>的案件在此对象的书签
        /// <see cref="WorkflowStepService.BookmarkName"/>处暂停。
        /// </remarks>
        private bool IsTaskAssignedToMe(Guid caseId)
        {
            // 只有办案员存在被分案的情况
            if (User.Role != Role.办案员) return true;
            var @case = GlobalKernel.Instance.Get<ICaseInfoManager>().GetCaseById(caseId);
            switch (BookmarkName)
            {
                case BookmarkNames.撰写五书:
                case BookmarkNames.定稿五书:
                case BookmarkNames.客户指示办案:
                case BookmarkNames.官方来函办案:
                    return User.UserName == @case.主办员用户名;
                case BookmarkNames.原始资料翻译:
                    return User.UserName == @case.翻译用户名;
                case BookmarkNames.原始资料翻译一校:
                    return User.UserName == @case.一校用户名;
                case BookmarkNames.原始资料翻译二校:
                    return User.UserName == @case.二校用户名;
                default:
                    throw new NotSupportedException();
            }
        }

        public bool ContinueCase(Guid caseId, object value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}