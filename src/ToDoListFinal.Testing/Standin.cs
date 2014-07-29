using NUnit.Framework;
using TodoList.Models;

namespace ToDoListFinal.Testing
{
	[TestFixture]
	public class Standin
	{
        HomeModel HM = new HomeModel();
        Task TestTask = new Task("TestTitle", "TestDescription", false);
        Task TestTask2 = new Task("TestTitle2", "TestDescription2", false);

        [Test]
        public void AddTask_TasksNotDoneList()
        {
            int TaskID = TestTask.ID;
            HM.TNDM.AddToTasks(TestTask);

            Assert.IsTrue(TestTask.Title == HM.TNDM.getTask(TaskID).Title);
        }

        [Test]
        public void AddTask_TasksDoneList()
        {
            int TaskID = TestTask.ID;
            HM.TDM.AddToTasks(TestTask);

            Assert.IsTrue(TestTask.Title == HM.TDM.getTask(TaskID).Title);
        }

        [Test]
        public void DeleteTask_TasksNotDoneList()
        {
            int TaskID = TestTask.ID;
            HM.TNDM.RemoveFromTasks(TaskID);

            Assert.IsNull(HM.TNDM.getTask(TaskID));
        }

        [Test]
        public void DeleteTask_TasksDoneList()
        {
            int TaskID = TestTask.ID;
            HM.TDM.RemoveFromTasks(TaskID);

            Assert.IsNull(HM.TDM.getTask(TaskID));
        }
	}
}