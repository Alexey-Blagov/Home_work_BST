
using System;
using System.Collections.Generic;
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
            Node newNode = new Node(name, salary);

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

       
        public void Inorder(Node? Root) // Симетричный обход дерева с выводом данных по сотдникам 
        {
            if (Root != null)
            {
                Inorder(Root.left);
                Console.WriteLine(Root.Name + " - " + Root.Salary + " ");
                Inorder(Root.right);
            }
        }
        public void Preorder(Node? Root)
        {
            if (Root != null)
            {
                Console.WriteLine(Root.Name + " - " + Root.Salary + " ");
                Preorder(Root.left);
                Preorder(Root.right);
            }
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
