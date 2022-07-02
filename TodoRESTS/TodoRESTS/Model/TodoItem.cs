using System;
using System.Collections.Generic;
using System.Text;

namespace TodoRESTS.Model
{
    public class TodoItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

    }
}
