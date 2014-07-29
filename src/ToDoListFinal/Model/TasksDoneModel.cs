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

            if (checkIfInDictionary(sentTask.ID))
            {
                wasSuccessfull = true;
            }

            return wasSuccessfull;
        }

        public Task getTask(int ID)
        {
            Task pulledObject = null;
            Tasks.TryGetValue(ID, out pulledObject);
            return (pulledObject);
        }

        public bool RemoveFromTasks(int sentTask)
        {
            bool wasSuccessfull = false;

            Tasks.Remove(sentTask);

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

        public bool updateTask(int ID, Task newTask)
        {
            bool wasSuccessfull = false;

            Task T = getTask(ID);
            T.ID = ID;
            T.Title = newTask.Title;
            T.Description = newTask.Description;
            Tasks.Remove(ID);
            Tasks.Add(T.ID, T);

            if (checkIfInDictionary(ID))
            {
                wasSuccessfull = true;
            }

            return wasSuccessfull;
        }

        public bool checkIfInDictionary(int ID)
        {
            bool found = false;

            if (Tasks.ContainsKey(ID))
            {
                found = true;
            }

            return found;
        }
    }
}