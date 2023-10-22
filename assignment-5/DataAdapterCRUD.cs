using System.Data;
using System.Data.SqlClient;

namespace Assignment_05
{
    public class DataAdapterCRUD
    {
        public string connString;
        public DataAdapterCRUD(string conn)
        {
            connString = conn;
        }
        public void SelectAllEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connString)) 
            {
                connection.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Employees", connString);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                bool dataFound = false;
                foreach (DataRow row in dataTable.Rows)
                {
                    dataFound = true;
                    Console.WriteLine($"\nID: {row["ID"]}\nFirstName: {row["FirstName"]}\nLastName: {row["LastName"]}\nEmail: {row["Email"]}\nPrimaryPhoneNumber: {row["PrimaryPhoneNumber"]}\nCreatedBy: {row["CreatedBy"]}\nCreatedOn: {row["CreatedOn"]}\nModifiedBy: {row["ModifiedBy"]}\nModifiedOn: {row["ModifiedOn"]}");
                }
                if (dataFound == false)
                {
                    Console.WriteLine("\nNo Employee Found.");
                }
            }
        }
        public void InsertEmployee(string firstName, string lastName, string email, string primaryPhoneNumber, string createdBy, DateTime createdOn, string? secondaryPhoneNumber = null, string? modifiedBy = null, DateTime? modifiedOn = null)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = "insert into Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn) " +
                               "values (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, @CreatedOn, @ModifiedBy, @ModifiedOn)";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = new SqlCommand(query, connection);

                adapter.InsertCommand.Parameters.AddWithValue("@FirstName", firstName);
                adapter.InsertCommand.Parameters.AddWithValue("@LastName", lastName);
                adapter.InsertCommand.Parameters.AddWithValue("@Email", email);
                adapter.InsertCommand.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                adapter.InsertCommand.Parameters.AddWithValue("@CreatedBy", createdBy);
                adapter.InsertCommand.Parameters.AddWithValue("@CreatedOn", createdOn);
                if (secondaryPhoneNumber != null)
                {
                    adapter.InsertCommand.Parameters.AddWithValue("@SecondaryPhoneNumber", secondaryPhoneNumber);
                }
                else
                {
                    adapter.InsertCommand.Parameters.AddWithValue("@SecondaryPhoneNumber", DBNull.Value);
                }
                if (modifiedBy != null)
                {
                    adapter.InsertCommand.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
                }
                else
                {
                    adapter.InsertCommand.Parameters.AddWithValue("@ModifiedBy", DBNull.Value);
                }
                if (modifiedOn != null)
                {
                    adapter.InsertCommand.Parameters.AddWithValue("@ModifiedOn", modifiedOn);
                }
                else
                {
                    adapter.InsertCommand.Parameters.AddWithValue("@ModifiedOn", DBNull.Value);
                }
                int rowsAffected = adapter.InsertCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("\nEmployee inserted Successfully.");
                }
            }
        }
        public void DeleteEmployee(long id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = "delete from Employees where id = @id";
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.DeleteCommand = new SqlCommand(query, connection);
                adapter.DeleteCommand.Parameters.AddWithValue("@id", id);
                int rowsAffected = adapter.DeleteCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"\nEmployee with ID {id} deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"\nNo employee found with ID {id}.");
                }
            }
        }
        public void SelectEmployeeById(long id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string query = "select * from Employees where id = @id";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@ID", id);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine($"\nID: {row["ID"]}\nFirstName: {row["FirstName"]}\nLastName: {row["LastName"]}\nEmail: {row["Email"]}\nPrimaryPhoneNumber: {row["PrimaryPhoneNumber"]}\nCreatedBy: {row["CreatedBy"]}\nCreatedOn: {row["CreatedOn"]}\nModifiedBy: {row["ModifiedBy"]}\nModifiedOn: {row["ModifiedOn"]}");
                    }
                }
                else
                {
                    Console.WriteLine($"\nNo employee found with ID {id}.");
                }
            }
        }
        public void UpdateEmployee(long id, string firstName = null, string lastName = null, string email = null, string primaryPhoneNumber = null, string createdBy = null, DateTime? createdOn = null, string secondaryPhoneNumber = null, string modifiedBy = null, DateTime? modifiedOn = null)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string updateQuery = "update Employees set";

                List<SqlParameter> parametersToUpdate = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(firstName))
                {
                    updateQuery += " FirstName = @FirstName,";
                    parametersToUpdate.Add(new SqlParameter("@FirstName", firstName));
                }
                if (!string.IsNullOrEmpty(lastName))
                {
                    updateQuery += " LastName = @LastName,";
                    parametersToUpdate.Add(new SqlParameter("@LastName", lastName));
                }
                if (!string.IsNullOrEmpty(email))
                {
                    updateQuery += " Email = @Email,";
                    parametersToUpdate.Add(new SqlParameter("@Email", email));
                }
                if (!string.IsNullOrEmpty(primaryPhoneNumber))
                {
                    updateQuery += " PrimaryPhoneNumber = @PrimaryPhoneNumber,";
                    parametersToUpdate.Add(new SqlParameter("@PrimaryPhoneNumber", primaryPhoneNumber));
                }
                if (!string.IsNullOrEmpty(createdBy))
                {
                    updateQuery += " CreatedBy = @CreatedBy,";
                    parametersToUpdate.Add(new SqlParameter("@CreatedBy", createdBy));
                }
                if (createdOn.HasValue)
                {
                    updateQuery += " CreatedOn = @CreatedOn,";
                    parametersToUpdate.Add(new SqlParameter("@CreatedOn", createdOn));
                }
                if (!string.IsNullOrEmpty(secondaryPhoneNumber))
                {
                    updateQuery += " SecondaryPhoneNumber = @SecondaryPhoneNumber,";
                    parametersToUpdate.Add(new SqlParameter("@SecondaryPhoneNumber", secondaryPhoneNumber));
                }
                if (!string.IsNullOrEmpty(modifiedBy))
                {
                    updateQuery += " ModifiedBy = @ModifiedBy,";
                    parametersToUpdate.Add(new SqlParameter("@ModifiedBy", modifiedBy));
                }
                if (modifiedOn.HasValue)
                {
                    updateQuery += " ModifiedOn = @ModifiedOn,";
                    parametersToUpdate.Add(new SqlParameter("@ModifiedOn", modifiedOn));
                }
                updateQuery = updateQuery.TrimEnd(',') + " where id = @id";
                parametersToUpdate.Add(new SqlParameter("@id", id));

                SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddRange(parametersToUpdate.ToArray());

                int rowsAffected = updateCommand.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine($"\nEmployee with ID {id} updated successfully.");
                }
                else
                {
                    Console.WriteLine($"\nNo employee found with ID {id}.");
                }
            }
        }

    }
}
