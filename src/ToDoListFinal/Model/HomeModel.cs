using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoList.Models;

namespace ToDoListFinal
{
    public class HomeModel
    {

        public TasksDoneModel TDM = new TasksDoneModel();
        public TasksNotDoneModel TNDM = new TasksNotDoneModel();

        public string Message { get; set; }

        private static HomeModel instance;

        protected HomeModel(){}

        public static HomeModel Instance()
        {
          if (instance == null)
          {
            instance = new HomeModel();
          }

          return instance;
        }
    }
}