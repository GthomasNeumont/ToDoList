using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace TodoList.Models
{
    public class Task
    {
        static int nextId;

        public int ID { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public bool isComplete { get; set; }

        public Task(String _Title , String _Description , bool _IsComplete)
        {
            Title = _Title;
            Description = _Description;
            isComplete = _IsComplete;

            ID = Interlocked.Increment(ref nextId);
        }
    }
}