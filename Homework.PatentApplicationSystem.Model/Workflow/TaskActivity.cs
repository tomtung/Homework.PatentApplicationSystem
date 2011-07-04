using System.Activities;
using System.Diagnostics;

namespace Homework.PatentApplicationSystem.Model.Workflow
{
    public sealed class TaskActivity<T> : NativeActivity<T>
    {
        public InArgument<string> TaskName { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            string taskName = context.GetValue(TaskName);
            context.CreateBookmark(taskName, Resume);

            var extension = context.GetExtension<ITaskActivityExtension>();
            extension.AddBookmarkRecord(taskName, context.WorkflowInstanceId);

            Debug.WriteLine("Bookmark: " + taskName);
        }

        private void Resume(NativeActivityContext context, Bookmark bookmark, object value)
        {
            Result.Set(context, (T) value);

            var extension = context.GetExtension<ITaskActivityExtension>();
            extension.RemoveBookmarkRecord(bookmark.Name);

            Debug.WriteLine("Bookmark " + bookmark.Name + " resumed, with value " + value);
        }
    }

    public sealed class TaskActivity : NativeActivity
    {
        public InArgument<string> BookmarkName { get; set; }

        protected override bool CanInduceIdle
        {
            get { return true; }
        }

        protected override void Execute(NativeActivityContext context)
        {
            string taskName = context.GetValue(BookmarkName);
            context.CreateBookmark(taskName, Resume);

            var extension = context.GetExtension<ITaskActivityExtension>();
            extension.AddBookmarkRecord(taskName, context.WorkflowInstanceId);

            Debug.WriteLine("Bookmark: " + taskName);
        }

        private static void Resume(NativeActivityContext context, Bookmark bookmark, object value)
        {
            var extension = context.GetExtension<ITaskActivityExtension>();
            extension.RemoveBookmarkRecord(bookmark.Name);

            Debug.WriteLine("Bookmark " + bookmark.Name + " resumed, with value " + value);
        }
    }
}