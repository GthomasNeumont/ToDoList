﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoListFinal.Endpoints
{
    public class NewEditInputModel
    {
        public string MyTitle { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
    }
}
