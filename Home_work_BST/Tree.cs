
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
        public void PrintInorder(Node? Root)
        {
            if (Root != null)
            {
                PrintInorder(Root.left);
                Console.WriteLine(Root.Name + " - " + Root.Salary + " ");
                PrintInorder(Root.right);
            }
        }
        //        Метод поиска узла:
        //Поиск узла в дереве начинается с его корня(метод FindWithParent) и предполагает следующие шаги:
        //Если значения текущего узла null — закончить поиск и вернуть null.
        //Если значения текущего узла равно искомому, результатом поиска будет текущие значение узла.
        //Если искомое значение меньше чем текущие, нужно перейти к левому потомку и повторить алгоритм с первого пункта.
        //Если значение больше или равно текущему, нужно перейти к правому потомку и повторить алгоритм с первого пункта.
        //void RemoveDuplicates(Node current)
        //{
        //    Node duplicate;
        //    while ((duplicate = Find(current.Left, current.Value)) != null)
        //        Delete(duplicate);

        //    RemoveDuplicates(current.Left);
        //    RemoveDuplicates(current.Right);
        public Node? Remove(int salary)
        {
            return RemoveMethed(ReturnRoot(), salary);
        }

        private Node? RemoveMethed(Node? root, int salary)
        {
            if (root == null)
                return root;
            //if Val less than the root node,recurse left subtree
            if (salary < root.Salary)
                root.left = RemoveMethed(root.left, salary);
            // if Val is more than the root node,recurse right subtree
            else if (salary > root.Salary)
            {
                root.right = RemoveMethed(root.right, salary);
            }
            //else we found the VAl
            else
            {
                //case 1: Node to be deleted has no children
                if (root.left == null && root.right == null)
                {
                    //update root to null
                    root = null;
                }
                //case 2 : node to be deleted has two children
                else if (root.left != null && root.right != null)
                {
                    Node? maxNode = FindMax(root.right);
                    //copy the value
                    root.Salary = maxNode.Salary;
                    root.right = RemoveMethed(root.right, maxNode.Salary);
                }
                //Удаление дочерних узлов дерева
                else
                {
                    Node? child = (root.left != null) ? root.left : root.right;
                    root = child;
                }
            }
            return root;
        }
        private Node FindMax(Node node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }
        public Node? Find(int value)
        {
            return Find(value, ReturnRoot());
        }
        private Node? Find(int value, Node? parent)
        {
            if (parent != null)
            {
                if (value == parent.Salary)
                {
                    return parent;
                }
                if (value < parent.Salary)
                    return Find(value, parent.left);
                else
                    return Find(value, parent.right);
            }
            return null;
        }

        /// <summary>
        /// Метод поиска значения с Преордер объодом дерева испоьзуя рекурсию 
        /// </summary>
        /// <param name="Root"></param> Текущее узловое знаение 
        /// <param name="findvalue"></param>
        public string? FindPreorder(Node? Root, int? findvalue)
        {
            if (Root != null)
            {
                if (Root.Salary == findvalue)
                {
                    return Root.Name;
                }
                FindPreorder(Root.left, findvalue);
                FindPreorder(Root.right, findvalue);
            }
            return null;
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
