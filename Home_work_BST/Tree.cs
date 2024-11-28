
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_BST
{ 
   /// <summary>
   /// Класс Формирования BST Binary Search Tree 
   /// </summary>
    class Tree
    {
        public Node? root;
        public Tree()
        {
            root = null;
        }
       /// <summary>
       /// Метод возврата корневого элемента дерева
       /// </summary>
       /// <returns></returns> корень BST root 
        public Node? ReturnRoot()
        {
            return root;
        }
        /// <summary>
        /// Функция добавления элементов в BST c формирванием дерева 
        /// </summary>
        /// <param name="name"></param> Имя сотрудника 
        /// <param name="salary"></param> Зарплата
        public void InsertNode(string name, int salary)
        {
            //Новый элемент BST Листок 
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
                    //случай когда введеный элемент меньше текущего листа по Salary  
                    if (salary < current.Salary) 
                    {
                        current = current.left;
                        if (current == null)
                        {
                            parent.left = newNode;
                            return;
                        }
                    }
                    //Сравнение Salary правый (больше или равно) формируем элемент, принцип постраения BST 
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
        /// Метод симетричного обхода (in-Order) сформированного BST с печатью значений по уровню зарплаты (Salary) 
        /// </summary> Вывод данного обхода сортирует элементы по возрастанию 
        /// <param name="Root"></param> Передаем зданчение листьев из дерева BST 
        public void PrintInorder(Node? Root)
        {
            if (Root != null)
            {
                //Рекурсия сдвиг по левой ветви дерева  
                PrintInorder(Root.left);
                Console.WriteLine(Root.Name + " - " + Root.Salary + " ");
                //Рекурсия сдвиц по правой ветви дерева 
                PrintInorder(Root.right);
            }
        }
        /// <summary>
        /// Метод удоления узлов в дереве  по найденному значению используем систему удолениядля вывода элементов которые имеюют одинаковые Salary
        /// </summary>
        /// <param name="salary"></param> Искомое значение Salary ЗП по базе удоляем из BST
        public void Remove(int salary)
        {
            RemoveMethed(ReturnRoot(), salary);
        }
        /// <summary>
        /// МВнутренний метод удаления элементов 
        /// </summary>
        /// <param name="root"></param> Текущий узел 
        /// <param name="salary"></param> Значение удаляемого по поиску
        /// <returns></returns>
        private Node? RemoveMethed(Node? root, int salary)
        {
            if (root == null)
                return root;
            if (salary < root.Salary)
                root.left = RemoveMethed(root.left, salary);
            else if (salary > root.Salary)
            {
                root.right = RemoveMethed(root.right, salary);
            }
            // Случай когда элемент базы равкен заданному значению 
            else
            {
                //Нет доченрних листьев
                if (root.left == null && root.right == null)
                {
                    root = null;
                }
                //Есть и правый и леавый дочерний элемент 
                else if (root.left != null && root.right != null)
                {
                    Node? maxNode = FindMax(root.right);
                    root.Salary = maxNode.Salary;
                    root.Name = maxNode.Name;
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
        /// <summary>
        /// Вспомогательный метод поиска по передачи дочерних листьев элементов до конца дерева с передвижкой  
        /// /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node FindMax(Node node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node;
        }
        /// <summary>
        /// Метод поиска элемента в BST 
        /// </summary>
        /// <param name="value"></param> Искомое значение Salary ЗП 
        /// <returns></returns>
        public Node? Find(int value)
        {
            return Find(value, ReturnRoot());
        }
        /// <summary>
        /// Внутренний метод поиска BST рекурсия 
        /// </summary>
        /// <param name="value"></param> Искомое значенеи 
        /// <param name="parent"></param> Родительский элемент поиска 
        /// <returns></returns>
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
    }
}
