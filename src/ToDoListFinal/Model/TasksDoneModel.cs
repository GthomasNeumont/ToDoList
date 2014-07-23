using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class TasksDoneModel
    {
        private Dictionary<int, Task> Tasks;

        public TasksDoneModel()
        {
            Tasks = new Dictionary<int, Task>();
        }

        public bool AddToTasks(Task sentTask)
        {
            bool wasSuccessfull = false;

            Tasks.Add(sentTask.ID, sentTask);

            if (checkIfInDictionary(sentTask))
            {
                wasSuccessfull = true;
            }

            return wasSuccessfull;
        }

        public bool RemoveFromTasks(Task sentTask)
        {
            bool wasSuccessfull = false;

            Tasks.Remove(sentTask.ID);

            if (!checkIfInDictionary(sentTask))
            {
                wasSuccessfull = true;
            }

            return wasSuccessfull;
        }

        public List<Task> listOfTasks()
        {
            List<Task> tasks = Tasks.Values.ToList();

            return tasks;
        }

        public bool updateTask(Task oldTask, Task newTask)
        {
            bool wasSuccessfull = false;

            Tasks.Remove(oldTask.ID);
            Tasks.Add(newTask.ID, newTask);

            if (!checkIfInDictionary(oldTask) && checkIfInDictionary(newTask))
            {
                wasSuccessfull = true;
            }

            return wasSuccessfull;
        }

        private bool checkIfInDictionary(Task task)
        {
            bool found = false;

            if (Tasks.ContainsKey(task.ID))
            {
                found = true;
            }

            return found;
        }
    }
}