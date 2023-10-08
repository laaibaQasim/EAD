
namespace assignment_3
{
    internal class StudentDb
    {
        public Dictionary<int, string> StudentRecords;
        public StudentDb() 
        {
            StudentRecords = new Dictionary<int, string>();
        }
        public void AddStudent(int id, string name)
        {
            if (!StudentRecords.ContainsKey(id))
            {
                StudentRecords[id] = name;
            }
            else
            {
                Console.WriteLine("Student already exist!");
            }
        }

        public void DisplayStudent(int id)
        {
            if (!StudentRecords.ContainsKey(id)) 
            {
                Console.WriteLine("Student not found!");
            }
            else
            {
                Console.WriteLine($"Student ID: {id}, Name: {StudentRecords[id]}");
            }
        }
        public void DisplayDb()
        {
            foreach(var record in StudentRecords) 
            {
                Console.WriteLine($"Student ID: {record.Key}, Name: {record.Value}");
            }
        }
        public void UpdateStudent(int id, string newName)
        {
            if (!StudentRecords.ContainsKey(id))
            {
                Console.WriteLine("Student not found!");
            }
            else
            {
                StudentRecords[id] = newName;
            }
        }
    }
}
