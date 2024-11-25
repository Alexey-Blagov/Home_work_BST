
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_BST
{

    class Tree
    {
        public Node? root;
        public Tree()
        {
            root = null;
        }
        public Node? ReturnRoot()
        {
            return root;
        }

        /// <summary>
        /// Функция добавления элементов в BST 
        /// </summary>
        /// <param name="name"></param> Имя сотрудника 
        /// <param name="salary"></param> Зарплата
        public void InsertNode(string name, int salary)
        {
            Node newNode = new Node(name, salary); //Новый элемент BST 

            if (root == null)
                root = newNode;
            else
            {
                Node? current = root;
                Node parent;
                while (true)
                {
                    parent = current;
                    if (salary < current.Salary)
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.right;
                        if (current == null)
                        {
                            parent.right = newNode;
                            return;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Мктод симетричного обхода сформированного BST с печатью значений по уровню зарплаты при таком обходе значения узлов выстраиваются по возрастанию
        /// </summary>
        /// <param name="Root"></param> 
        public void PrintInorder(Node? Root) // Симетричный обход дерева с выводом данных по сотдникам 
        {
            if (Root != null)
            {
                PrintInorder(Root.left);
                Console.WriteLine(Root.Name + " - " + Root.Salary + " "); 
                PrintInorder(Root.right);
            }
        }

        /// <summary>
        /// Метод поиска значения с Преордер объодом дерева испоьзуя рекурсию 
        /// </summary>
        /// <param name="Root"></param> Текущее узловое знаение 
        /// <param name="findvalue"></param>
        public List<string?> FindPreorder(Node? Root, int? findvalue)
        {
            List<string?> valueList = new List<string?>(); 
            
            if (Root != null)
            {
                if (Root.Salary == findvalue)
                {
                    valueList.Add(Root.Name); 
                } 
                FindPreorder(Root.left, findvalue);
                FindPreorder(Root.right, findvalue); 
            }
            return valueList;  
        }
        public void Postorder(Node? Root)
        {
            if (Root != null)
            {
                Postorder(Root.left);
                Postorder(Root.right);
                Console.WriteLine(Root.Name + " - " + Root.Salary + " ");
            }
        }
    }
}
