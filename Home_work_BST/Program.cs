
using System.Runtime.InteropServices;
using System.Xml;

namespace Home_Work_BST
{
    internal class Program
    {

        //        Напишите программу, которая:
        //принимает на вход из консоли информацию о сотрудниках: имя + зарплата (имя в первой строке, зарплата в виде целого числа во второй строке; +
        // и так для каждого сотрудника, пока пользователь не введет пустую строку в качестве имени сотрудника) + 
        //попутно при получении информации о сотрудниках строится бинарное дерево с этой информацией, где в каждом узле хранится имя сотрудника,
        //а его зарплата является значением, на основе которого производится бинарное разделение в дереве 
        //после окончания ввода пользователем программа выводит имена сотрудников и их зарплаты в порядке возрастания зарплат

        //(в каждой строчке формат вывода "Имя - зарплата"). Использовать для этого симметричный обход дерева. 

        //после этого программа запрашивает размер зарплаты, который интересует пользователя.
        //В построенном бинарном дереве программа находит сотрудника с указанной зарплатой и выводит его имя.
        //Если сотрудник не найден - выводится "такой сотрудник не найден"
        //после этого программа предлагает ввести цифру 0 (переход к началу программы) или 1 (снова поиск зарплаты).
        //При вводе 0 должен произойти переход к началу работы программы, т.е.опять запрашивается список сотрудников и строится новое дерево.
        //При вводе 1 должны снова запросить зарплату, которую хочется поискать в дереве - см.предыдущий пункт.

        public static (string, int) EnterEmployee()
        {
            string name;
            int salary;
            Console.WriteLine("Введите имя сотрудника: ");
            name = Console.ReadLine();
            if (name == null || name == "") return (null, 0); // введена пустая строка выход из ввода     
            while (!int.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Некорректный ввод суммы заработной платы введите заново: ");
            }
            return (name, salary);
        }
        static void Main(string[] args)
        {
            Tree BST = new Tree();
            BST.InsertNode("Иван", 30);
            BST.InsertNode("Николай", 35);
            BST.InsertNode("Семён", 57);
            BST.InsertNode("Ирина", 15);
            BST.InsertNode("Александр", 63);
            BST.InsertNode("Максим", 49);
            BST.InsertNode("Ольга", 89);
            BST.InsertNode("Алексей", 77);
            BST.InsertNode("Ульяна", 67);
            BST.InsertNode("Артём", 98);
            BST.InsertNode("Игорь", 1);
            Console.WriteLine("Inorder Traversal : ");
            BST.Inorder(BST.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Preorder Traversal : ");
            BST.Preorder(BST.ReturnRoot());
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Postorder Traversal : ");
            BST.Postorder(BST.ReturnRoot());
            Console.WriteLine(" ");
            Console.ReadLine();
            //while (true) // ввод информации выход по пустой строке  
            //{
            //    var employer = EnterEmployee();
            //    if (employer.Item1 == null) break;
            //    else // Формируем BST 
            //    { 
            //        BST.Insert (employer.Item1, employer.Item2);    
            //    }

        }
    }
}
