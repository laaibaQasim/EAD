using System;
namespace Assignment_05
{
    class Program
    { 
        static void TakeUpdateEmployeeDetails(DataAdapterCRUD dataAdapterCRUD = null, DataReaderCRUD dataReaderCRUD = null)
        {
            Console.Write("Enter employee ID to update: ");
            long idToUpdate;
            while (true)
            {
                try
                {
                    idToUpdate = long.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {
                    Console.Write("Invalid input. Enter employee ID to update: ");
                }
            }

            Console.WriteLine("Enter updated employee details (leave empty to skip updating):");
            Console.Write("First Name: ");
            string updatedFirstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string updatedLastName = Console.ReadLine();
            Console.Write("Email: ");
            string updatedEmail = Console.ReadLine();
            Console.Write("Primary Phone Number: ");
            string updatedPrimaryPhoneNumber = Console.ReadLine();
            Console.Write("Created By: ");
            string updatedCreatedBy = Console.ReadLine();
            Console.Write("Created On (yyyy-MM-dd HH:mm:ss, press Enter to skip): ");
            string createdOnInput = Console.ReadLine();
            DateTime? updatedCreatedOn;
            while (true)
            {
                try
                {
                    updatedCreatedOn = string.IsNullOrEmpty(createdOnInput) ? null : (DateTime?)DateTime.Parse(createdOnInput);
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Invalid Input.");
                    Console.Write("Created On (yyyy-MM-dd HH:mm:ss, press Enter to skip): ");
                    createdOnInput = Console.ReadLine();
                }
            }  
            
            Console.Write("Secondary Phone Number: ");
            string updateSecondaryPhoneNumber = Console.ReadLine();
            Console.Write("Modified By: ");
            string updateModifiedBy = Console.ReadLine();
            Console.Write("Modified On (yyyy-MM-dd HH:mm:ss): ");
            string modifiedOnIn = Console.ReadLine();
            
            DateTime? updateModifiedOn;
            while (true)
            {
                try
                {
                    updateModifiedOn = string.IsNullOrEmpty(modifiedOnIn) ? null : (DateTime?)DateTime.Parse(modifiedOnIn);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input.");
                    Console.Write("Modified On (yyyy-MM-dd HH:mm:ss): ");
                    modifiedOnIn = Console.ReadLine();
                }
            }

            if (dataReaderCRUD != null)
            {
                dataReaderCRUD.UpdateEmployee(idToUpdate, updatedFirstName, updatedLastName, updatedEmail, updatedPrimaryPhoneNumber, updatedCreatedBy, updatedCreatedOn, updateSecondaryPhoneNumber, updateModifiedBy, updateModifiedOn);
            }
            else
            {
                dataAdapterCRUD.UpdateEmployee(idToUpdate, updatedFirstName, updatedLastName, updatedEmail, updatedPrimaryPhoneNumber, updatedCreatedBy, updatedCreatedOn, updateSecondaryPhoneNumber, updateModifiedBy, updateModifiedOn);
            }
        }
        static void TakeEmployeeDetails(DataAdapterCRUD dataAdapterCRUD=null, DataReaderCRUD dataReaderCRUD=null)
        {
            Console.WriteLine("Enter employee details:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(firstName))
            {
                Console.Write("First Name: ");
                firstName = Console.ReadLine();
            }

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(lastName))
            {
                Console.Write("Last Name: ");
                lastName = Console.ReadLine();
            }

            Console.Write("Email: ");
            string email = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(email))
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
            }

            Console.Write("Primary Phone Number: ");
            string primaryPhoneNumber = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(primaryPhoneNumber))
            {
                Console.Write("Primary Phone Number: ");
                primaryPhoneNumber = Console.ReadLine();
            }

            Console.Write("Created By: ");
            string createdBy = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(createdBy))
            {
                Console.Write("Created By: ");
                createdBy = Console.ReadLine();
            }

            Console.Write("Created On (yyyy-MM-dd HH:mm:ss): ");
            DateTime createdOn;
            while(true)
            {
                try
                {
                    createdOn = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input. Enter again: ");
                }
            }

            Console.Write("Secondary Phone Number (optional, press Enter to skip): ");
            string secondaryPhoneNumber = Console.ReadLine();
            if (secondaryPhoneNumber == "")
            {
                secondaryPhoneNumber = null;
            }

            Console.Write("Modified By (optional, press Enter to skip): ");
            string modifiedBy = Console.ReadLine();
            if(modifiedBy == "")
            {
                modifiedBy = null;
            }

            Console.Write("Modified On (optional, press Enter to skip): ");
            string modifiedOnInput = Console.ReadLine();

            DateTime? modifiedOn;
            while (true)
            {
                try
                {
                    modifiedOn = string.IsNullOrEmpty(modifiedOnInput) ? null : (DateTime?)DateTime.Parse(modifiedOnInput);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Input.");
                    Console.Write("Modified On (optional, press Enter to skip): ");
                    modifiedOnInput = Console.ReadLine();
                }
            }

            if (dataReaderCRUD == null)
            {
                dataAdapterCRUD.InsertEmployee(firstName, lastName, email, primaryPhoneNumber, createdBy, createdOn, secondaryPhoneNumber, modifiedBy, modifiedOn);
            }
            else
            {
                dataReaderCRUD.InsertEmployee(firstName, lastName, email, primaryPhoneNumber, createdBy, createdOn, secondaryPhoneNumber, modifiedBy, modifiedOn);
            }

        }
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AssignmentFive;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            DataReaderCRUD dataReaderCRUD = new DataReaderCRUD(connectionString);
            DataAdapterCRUD dataAdapterCRUD = new DataAdapterCRUD(connectionString);

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. DataReader - Insert Employee");
                Console.WriteLine("2. DataReader - Delete Employee by ID");
                Console.WriteLine("3. DataReader - Update Employee by ID");
                Console.WriteLine("4. DataReader - Select Employee by ID");
                Console.WriteLine("5. DataReader - Select All Employees");
                Console.WriteLine("6. DataAdapter - Insert Employee");
                Console.WriteLine("7. DataAdapter - Delete Employee by ID");
                Console.WriteLine("8. DataAdapter - Update Employee by ID");
                Console.WriteLine("9. DataAdapter - Select Employee by ID");
                Console.WriteLine("10. DataAdapter - Select All Employees");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Insert Employee using DataReaderCRUD
                        TakeEmployeeDetails(null, dataReaderCRUD);
                       break;

                    case "2":
                        // Delete Employee by ID using DataReaderCRUD
                        Console.Write("Enter employee ID to delete: ");
                        long idToDelete = long.Parse(Console.ReadLine());
                        dataReaderCRUD.DeleteEmployee(idToDelete);
                        break;

                    case "3":
                        // Update Employee by ID using DataReaderCRUD
                        TakeUpdateEmployeeDetails(null, dataReaderCRUD);
                        break;

                    case "4":
                        // Select Employee by ID using DataReaderCRUD
                        Console.Write("Enter employee ID to select: ");
                        long idToSelect = long.Parse(Console.ReadLine());
                        dataReaderCRUD.SelectEmployeeById(idToSelect);
                        break;

                    case "5":
                        // Select All Employees using DataReaderCRUD
                        dataReaderCRUD.SelectAllEmployees();
                        break;

                    case "6":
                        // Insert Employee using DataAdapterCRUD
                        TakeEmployeeDetails(dataAdapterCRUD, null);
                        break;

                    case "7":
                        // Delete Employee by ID using DataAdapterCRUD
                        Console.Write("Enter employee ID to delete: ");
                        long id = long.Parse(Console.ReadLine());
                        dataAdapterCRUD.DeleteEmployee(id);
                        break;

                    case "8":
                        // Update Employee by ID using DataAdapterCRUD
                        TakeUpdateEmployeeDetails(dataAdapterCRUD, null); 
                       break;

                    case "9":
                        // Select Employee by ID using DataAdapterCRUD
                        Console.Write("Enter employee ID to select: ");
                        long selectId = long.Parse(Console.ReadLine());
                        dataAdapterCRUD.SelectEmployeeById(selectId);
                        break;

                    case "10":
                        // Select All Employees using DataAdapterCRUD
                        dataAdapterCRUD.SelectAllEmployees();
                        break;

                    case "0":
                        // Exit the program
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}