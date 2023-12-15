
using System;

namespace collections
{
    class Employee
    {
        //Variable declaration
        public string EmpName;        
        public int EmpId;
        public string Department;
		
        public string GetEmployeeName
        {
            get { return EmpName; }
        }
        public int GetEmplyeeId
        {
            get { return EmpId; }
        }
        //Constructor
        public Employee()
        {
            //Console.WriteLine("Constructed");
        }
        //Parameterised Constructor
        public Employee(string _EmpName, int _EmpId, string _Department)
        {
            EmpName = _EmpName; 
            EmpId = _EmpId;
            Department = _Department;
        }          
        //Destructor
        ~Employee()
        {
          
        }
    }
	
    class Program
    {
        //List collection creation
        public static void EmployeeList()
        {
            Console.WriteLine("System.Collections.Generic.List<>");
            List<Employee> employeesList = new List<Employee>();
            //Add employee details to the list
            employeesList.Add(new Employee() {EmpName="Sam", EmpId=1232,Department="Employee List"});
            employeesList.Add(new Employee() {EmpName="John", EmpId=1233,Department="Employee List"});
            employeesList.Add(new Employee() {EmpName="Vinay", EmpId=1234,Department="Employee List"});

            //print the added list
            foreach(Employee emp in employeesList)
            {
                Console.WriteLine("The name of the Employee is "+emp.EmpName+" with Employee Id "+emp.EmpId+" and belongs to Department "+ emp.Department);
            }

        }

        //Queue collection creation
        public static void EmployeeQueue()
        {
            Console.WriteLine("System.Collections.Generic.Queue<>");
            Queue<Employee> EmployeeQueue = new Queue<Employee>();
            EmployeeQueue.Enqueue(new Employee() {EmpName="First Employee", EmpId=1232,Department="Employee Queue"});
            EmployeeQueue.Enqueue(new Employee() {EmpName="Second Employee", EmpId=1232,Department="Employee Queue"});
            EmployeeQueue.Enqueue(new Employee() {EmpName="Third Employee", EmpId=1232,Department="Employee Queue"});
            EmployeeQueue.Enqueue(new Employee() {EmpName="Fourth Employee", EmpId=1232,Department="Employee Queue"});
            //print the values inside queue
            Console.WriteLine("The Employee Queue list");
            foreach(Employee emp in EmployeeQueue)
            {
               Console.WriteLine("The name of the Employee is "+emp.EmpName+" with Employee Id "+emp.EmpId+" and belongs to Department "+ emp.Department);
            }
            //Dequeue
            Console.WriteLine("Dequeuing '{0}'", EmployeeQueue.Dequeue());
            Console.WriteLine("Dequeuing '{0}'", EmployeeQueue.Dequeue());
            //print the value after dequeuing
            Console.WriteLine("The Employee Queue list after dequeing");
            foreach(Employee emp in EmployeeQueue)
            {
                Console.WriteLine("The name of the Employee is "+emp.EmpName+" with Employee Id "+emp.EmpId+" and belongs to Department "+ emp.Department);
            }
        }

        //Stack collection creation
        public static void EmployeeStack()
        {

            Console.WriteLine("System.Collections.Generic.Stack<>");
            Stack<Employee> EmployeeStack = new Stack<Employee>();
            EmployeeStack.Push(new Employee() {EmpName="First Employee", EmpId=1001,Department="Employee Stack"});
            EmployeeStack.Push(new Employee() {EmpName="Second Employee", EmpId=1002,Department="Employee Stack"});
            EmployeeStack.Push(new Employee() {EmpName="Third Employee", EmpId=1003,Department="Employee Stack"});
            EmployeeStack.Push(new Employee() {EmpName="Fourth Employee", EmpId=1004,Department="Employee Stack"});

            //print the stack after pushing employee data
            Console.WriteLine("Printing the Employee Stack after Push operation");
            foreach(Employee emp in EmployeeStack)
            {
                Console.WriteLine("The name of the Employee is "+emp.EmpName+" with Employee Id "+emp.EmpId+" and belongs to Department "+ emp.Department);

            }

            //print the stack after popping employee data
            EmployeeStack.Pop();
            EmployeeStack.Pop();
            Console.WriteLine("Printing the Employee Stack after pop operation");
            foreach(Employee emp in EmployeeStack)
            {
                Console.WriteLine("The name of the Employee is "+emp.EmpName+" with Employee Id "+emp.EmpId+" and belongs to Department "+ emp.Department);

            }
        }
		
		//Linked List creation
        public static void EmployeeLinkedList()
        {

            Console.WriteLine("System.Collections.Generic.LinkedList<>");
            LinkedList<Employee> EmployeeLinkedList = new LinkedList<Employee>();
            EmployeeLinkedList.AddFirst(new Employee() {EmpName="First Employee", EmpId=1001,Department="Employee Linked List"});
            EmployeeLinkedList.AddFirst(new Employee() {EmpName="Second Employee", EmpId=1002,Department="Employee Linked List"});
			
            //move the first node to be the last node
            LinkedListNode<Employee> EmpNode = EmployeeLinkedList.First;
            EmployeeLinkedList.RemoveFirst();
            EmployeeLinkedList.AddLast(EmpNode);
            
            //print the linked list
            Console.WriteLine("Print the Linked list after creation");
            foreach(Employee emp in EmployeeLinkedList)
            {
                Console.WriteLine("The name of the Employee is "+emp.EmpName+" with Employee Id "+emp.EmpId+" and belongs to Department "+ emp.Department);

            }

            //change the last node to Employee number three
            EmployeeLinkedList.RemoveLast();
            EmployeeLinkedList.AddLast(new Employee() {EmpName="Third Employee", EmpId=1003,Department="Employee Linked List"});

            //print the linked list
            Console.WriteLine("Print the Linked list after removing last node and adding new node");
            foreach(Employee emp in EmployeeLinkedList)
            {
                Console.WriteLine("The name of the Employee is "+emp.EmpName+" with Employee Id "+emp.EmpId+" and belongs to Department "+ emp.Department);

            }
        }
		
		//Dictionary List creation
        public static void EmployeeDictionaryList()
        {
 
            Console.WriteLine("System.Collections.Generic.Dictionary<,> ");
            Dictionary<string, Employee> EmployeeDictionary = new Dictionary<string, Employee>();
            EmployeeDictionary.Add("Dict ID 1", new Employee(){EmpName="Employee A", EmpId=1001,Department="Dictionary List"});
            EmployeeDictionary.Add("Dict ID 2", new Employee(){EmpName="Employee B", EmpId=1002,Department="Dictionary List"});
            EmployeeDictionary.Add("Dict ID 3", new Employee(){EmpName="Employee C", EmpId=1003,Department="Dictionary List"});
        
            //print the dictionary list collection value
            if(EmployeeDictionary != null)
            {
                Console.WriteLine("Printing the Dictionary key value pairs");
                foreach( KeyValuePair<string, Employee> emp in EmployeeDictionary )
                {
                    Console.WriteLine("Key = {0}, Value = The name of the Employee is {1} with Employee Id {2} and belongs to Department {3}", emp.Key, emp.Value.EmpName, emp.Value.EmpId, emp.Value.Department);
                }
                
            }
            
            //remove the first dictionary list item with Id "Dict ID 1"
            EmployeeDictionary.Remove("Dict ID 1");
            if(!EmployeeDictionary.ContainsKey("Dict ID 1"))
            {
                Console.WriteLine("key is not found");
            }

            //print the dictionary after deleting the item
            if(EmployeeDictionary != null)
            {
                Console.WriteLine("Printing the Dictionary key value pairs");
                foreach( KeyValuePair<string, Employee> emp in EmployeeDictionary )
                {
                    Console.WriteLine("Key = {0}, Value = The name of the Employee is {1} with Employee Id {2} and belongs to Department {3}", emp.Key, emp.Value.EmpName, emp.Value.EmpId, emp.Value.Department);
                }
                
            }

            //To individually access the values of the Dictionary
            Dictionary<string, Employee>.ValueCollection ValueColl = EmployeeDictionary.Values;
            foreach(Employee emp in ValueColl)
            {
                Console.WriteLine("The name of the Employee is "+emp.EmpName+" with Employee Id "+emp.EmpId+" and belongs to Department "+ emp.Department);
            }
            
            //To individually access the keys of the Dictionary
            Dictionary<string, Employee>.KeyCollection keyColl = EmployeeDictionary.Keys;
            foreach(string s in keyColl)
            {
                Console.WriteLine("Key = {0}", s);
            }
        }

        static void Main(string[] args)
        {
              
            EmployeeList();
         
            EmployeeQueue();
 
            EmployeeStack();
            
            EmployeeLinkedList();
           
            EmployeeDictionaryList();
            
        }
    }   
}

       
