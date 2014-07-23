using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class TasksNotDoneModel
    {
        private Dictionary<int,Task> Tasks; 

        public TasksNotDoneModel()
        {
            Tasks = new Dictionary<int,Task>();
        }

        public bool AddToTasks(Task sentTask)
        {
            bool wasSuccessfull = false;

            Tasks.Add(sentTask.ID , sentTask);

            if (checkIfInDictionary(sentTask.ID))
            {
                wasSuccessfull = true;
            }

            return wasSuccessfull;
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

        public bool updateTask(Task oldTask, Task newTask)
        {
            bool wasSuccessfull = false;

            Tasks.Remove(oldTask.ID);
            Tasks.Add(newTask.ID, newTask);

            if (!checkIfInDictionary(oldTask.ID) && checkIfInDictionary(newTask.ID))
            {
                wasSuccessfull = true;
            }

            return wasSuccessfull;
        }

        private bool checkIfInDictionary(int ID)
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