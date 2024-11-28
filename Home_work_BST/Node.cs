﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_BST
{
    internal class Node
    {
        public string? Name { get; set; }
        public int Salary { get; set; }

        public Node? left;

        public Node? right;

        public Node (string _name, int _salary)
        {
            Name = _name;
            Salary = _salary;
        }
    }
}
