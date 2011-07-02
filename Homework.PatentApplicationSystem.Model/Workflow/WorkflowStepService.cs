using System;
using System.Collections.Generic;
using System.Linq;

using Homework.PatentApplicationSystem.Model.Data;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    internal class WorkflowStepService : IWorkflowStepService
    {
        private readonly string _bookmarkName;
        private readonly IBookmarkRecordManager _bookmarkRecordManager;
        private readonly ICaseInfoManager _caseInfoManager;
        private readonly ICaseWorkflowManager _caseWorkflowManager;
        private readonly User _user;

        internal WorkflowStepService(User user, string bookmarkName, IBookmarkRecordManager bookmarkRecordManager,
            ICaseInfoManager caseInfoManager, ICaseWorkflowManager caseWorkflowManager)
        {
            _user = user;
            _bookmarkName = bookmarkName;
            _caseInfoManager = caseInfoManager;
            _bookmarkRecordManager = bookmarkRecordManager;
            _caseWorkflowManager = caseWorkflowManager;
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

        public IEnumerable<string> PendingCaseIds
        {
            get
            {
                return _bookmarkRecordManager
                    .GetIdsOfAllCaseSuspendedAt(BookmarkName)
                    .Where(IsTaskAssignedToMe);
            }
        }

        public bool ContinueCase(string caseId, object value)
        {
            return _caseWorkflowManager.ResumeBookmark(caseId, BookmarkName, value);
        }

        /// <remarks>
        /// 使用这个方法的假设是：案件编号为<param name="caseId"/>的案件在此对象的书签
        /// <see cref="WorkflowStepService.BookmarkName"/>处暂停。
        /// </remarks>
        private bool IsTaskAssignedToMe(string caseId)
        {
            // 只有办案员存在被分案的情况
            if (User.Role != Role.办案员)
            {
                return true;
            }
            Case @case = _caseInfoManager.GetCaseById(caseId);
            switch (BookmarkName)
            {
                case TaskNames.撰写五书:
                case TaskNames.定稿五书:
                case TaskNames.客户指示办案:
                case TaskNames.官方来函办案:
                    return User.UserName == @case.主办员用户名;
                case TaskNames.原始资料翻译:
                    return User.UserName == @case.翻译用户名;
                case TaskNames.原始资料翻译一校:
                    return User.UserName == @case.一校用户名;
                case TaskNames.原始资料翻译二校:
                    return User.UserName == @case.二校用户名;
                default:
                    throw new NotSupportedException();
            }
        }

        #endregion
    }
}