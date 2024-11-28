
using System.Runtime.InteropServices;
using System.Xml;

namespace Home_Work_BST
{
    internal class Program
    {
        public static (string?, int) EnterEmployee()
        {
            string? name;
            int salary;
            Console.WriteLine("Введите имя сотрудника: ");
            name = Console.ReadLine();
            if (name == null || name == "") return (null, 0); // введена пустая строка выход из ввода     
            Console.WriteLine("Введите значение заработной платы: ");
            while (!int.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Некорректный ввод суммы заработной платы введите заново: ");
            }
            return (name, salary);
        }
        public static int EnterSalary()
        {
            int salary;
            Console.WriteLine("Введите искомое значение заработной платы: ");
            while (!int.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Некорректный ввод суммы заработной платы введите заново: ");
            }
            return salary;
        }

        static void Main(string[] args)
        {
            // Логика ввода задачи 0, 1 
            bool firstinput = true;
            int select = 1;
            Tree BST = new Tree();
            while (true)
            {
                select = (firstinput) ? 0 : select;
                switch (select)
                {
                    case 0:
                        // постороение нового дерева 
                        BST = new Tree();
                        while (true) // ввод информации выход по пустой строке  
                        {
                            var employer = EnterEmployee();
                            if (employer.Item1 == null) break;
                            else // Формируем BST 
                            {
                                BST.InsertNode(employer.Item1, employer.Item2);
                            }
                        }
                        // Вывод сотрудников по сортировки симетричный обход 
                        BST.PrintInorder(BST.ReturnRoot());
                        Console.WriteLine(" ");
                        Console.WriteLine();
                        firstinput = true;
                        break;
                    case 1:
                        int findsalary = EnterSalary();
                        Tree? copyBST = BST;
                        Node? node = copyBST.Find(findsalary);
                        //node = copyBST.Remove(findsalary);
                        if (node == null) Console.WriteLine("Искомого сотрудника с данной зарпалтой не найдено");
                        else
                        {
                            Console.WriteLine($"Имя сотрудника с зарплатой {findsalary} - {node.Name} ");
                            copyBST.Remove(findsalary);
                            while (node != null)
                            {
                                node = copyBST.Find(findsalary);
                                if (node != null)
                                {
                                    Console.WriteLine($"Имя сотрудника с зарплатой {findsalary} - {node.Name} ");
                                    copyBST.Remove(findsalary);
                                }
                            }
                        }

                        break;
                }
                if (firstinput)
                {
                    select = 1;
                    firstinput = false;
                    continue;
                }
                Console.WriteLine("Введите 0 для повторного ввода списка сотрудников, 1 для повторного поиска в том же вводе");
                if (int.TryParse(Console.ReadLine(), out select))
                {
                    if (select == 0 || select == 1)
                        continue;
                    else break;
                }
                else break;
            }
        }
    }
}
