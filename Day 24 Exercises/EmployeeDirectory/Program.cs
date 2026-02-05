using System.Collections;
namespace EmployeeDirectory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hashtable employeeTable = new Hashtable();
            employeeTable.Add(101, "Alice");
            employeeTable.Add(102, "Bob");
            employeeTable.Add(103, "Charlie");
            employeeTable.Add(104, "Diana");

            if (employeeTable.ContainsKey(105))
            {
                Console.WriteLine("ID Already exists.");
            }
            else
            {
                employeeTable.Add(105,"Edward");
            }

            string var = (string) employeeTable[102];
            Console.WriteLine(var);
            

            foreach(DictionaryEntry item  in employeeTable)
            {
                Console.WriteLine($"Id: {item.Key}, Name: {item.Value}");
            }

            employeeTable.Remove(103);
            Console.WriteLine($"Total count of Remaining Employees: {employeeTable.Count}");

        }
    }
}
