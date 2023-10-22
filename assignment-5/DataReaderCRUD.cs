using System.Data.SqlClient;

namespace Assignment_05
{
    public class DataReaderCRUD
    {
        public string connString;
        public DataReaderCRUD(string conn) 
        {
            connString = conn;
        }
        public void InsertEmployee(string firstName, string lastName, string email, string primaryPhoneNumber, string createdBy, DateTime createdOn, string? secondaryPhoneNumber = null, string? modifiedBy = null, DateTime? modifiedOn = null)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string insertQuery = "insert into Employees (FirstName, LastName, Email, PrimaryPhoneNumber, SecondaryPhoneNumber, CreatedBy, CreatedOn, ModifiedBy, ModifiedOn) " +
                                    "values (@FirstName, @LastName, @Email, @PrimaryPhoneNumber, @SecondaryPhoneNumber, @CreatedBy, @CreatedOn, @ModifiedBy, @ModifiedOn)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PrimaryPhoneNumber", primaryPhoneNumber);
                    command.Parameters.AddWithValue("@CreatedBy", createdBy);
                    command.Parameters.AddWithValue("@CreatedOn", createdOn);

                    if (secondaryPhoneNumber != null)
                    {
                        command.Parameters.AddWithValue("@SecondaryPhoneNumber", secondaryPhoneNumber);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@SecondaryPhoneNumber", DBNull.Value);
                    }
                    if (modifiedBy != null)
                    {
                        command.Parameters.AddWithValue("@ModifiedBy", modifiedBy);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ModifiedBy", DBNull.Value);
                    }
                    if (modifiedOn != null)
                    {
                        command.Parameters.AddWithValue("@ModifiedOn", modifiedOn);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ModifiedOn", DBNull.Value);
                    }
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"\nEmployee inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"\nInsertion operation failed.");
                    }
                }
            }
        }
        public void DeleteEmployee(long id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string deleteQuery = "delete from Employees where id=@id";
                using (SqlCommand command = new SqlCommand(deleteQuery, connection)) 
                {
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();
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
        }
        public void UpdateEmployee(long id, string firstName = null, string lastName = null, string email = null, string primaryPhoneNumber = null, string createdBy = null, DateTime? createdOn = null, string secondaryPhoneNumber = null, string modifiedBy = null, DateTime? modifiedOn = null)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();

                // Start building the query
                string updateQuery = "update Employees set ";

                List<SqlParameter> parametersToUpdate = new List<SqlParameter>();

                if (firstName != null)
                {
                    updateQuery += "FirstName = @FirstName, ";
                    parametersToUpdate.Add(new SqlParameter("@FirstName", firstName));
                }
                if (lastName != null)
                {
                    updateQuery += "LastName = @LastName, ";
                    parametersToUpdate.Add(new SqlParameter("@LastName", lastName));
                }
                if (email != null)
                {
                    updateQuery += "Email = @Email, ";
                    parametersToUpdate.Add(new SqlParameter("@Email", email));
                }
                if (primaryPhoneNumber != null)
                {
                    updateQuery += "PrimaryPhoneNumber = @PrimaryPhoneNumber, ";
                    parametersToUpdate.Add(new SqlParameter("@PrimaryPhoneNumber", primaryPhoneNumber));
                }
                if (createdBy != null)
                {
                    updateQuery += "CreatedBy = @CreatedBy, ";
                    parametersToUpdate.Add(new SqlParameter("@CreatedBy", createdBy));
                }
                if (createdOn != null)
                {
                    updateQuery += "CreatedOn = @CreatedOn, ";
                    parametersToUpdate.Add(new SqlParameter("@CreatedOn", createdOn));
                }
                if (secondaryPhoneNumber != null)
                {
                    updateQuery += "SecondaryPhoneNumber = @SecondaryPhoneNumber, ";
                    parametersToUpdate.Add(new SqlParameter("@SecondaryPhoneNumber", secondaryPhoneNumber));
                }
                if (modifiedBy != null)
                {
                    updateQuery += "ModifiedBy = @ModifiedBy, ";
                    parametersToUpdate.Add(new SqlParameter("@ModifiedBy", modifiedBy));
                }
                if (modifiedOn != null)
                {
                    updateQuery += "ModifiedOn = @ModifiedOn, ";
                    parametersToUpdate.Add(new SqlParameter("@ModifiedOn", modifiedOn));
                }

                updateQuery = updateQuery.TrimEnd(',', ' ') + " where id = @id";
                parametersToUpdate.Add(new SqlParameter("@id", id));

                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddRange(parametersToUpdate.ToArray());

                    int rowsAffected = command.ExecuteNonQuery();

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
        public void SelectEmployeeById(long id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                string selectQuery = "select * from Employees where id=@id";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    bool dataFound = false;
                    while (reader.Read())
                    {
                        dataFound = true;
                        long empId = reader.GetInt64(reader.GetOrdinal("ID"));
                        string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                        string email = reader.GetString(reader.GetOrdinal("Email"));
                        string primaryPhoneNumber = reader.GetString(reader.GetOrdinal("PrimaryPhoneNumber"));
                        string? secondaryPhoneNumber = reader.IsDBNull(reader.GetOrdinal("SecondaryPhoneNumber")) ? null : reader.GetString(reader.GetOrdinal("SecondaryPhoneNumber"));
                        string createdBy = reader.GetString(reader.GetOrdinal("CreatedBy"));
                        DateTime createdOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn"));
                        string? modifiedBy = reader.IsDBNull(reader.GetOrdinal("ModifiedBy")) ? null : reader.GetString(reader.GetOrdinal("ModifiedBy"));
                        DateTime? modifiedOn = reader.IsDBNull(reader.GetOrdinal("ModifiedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("ModifiedOn"));
                        Console.WriteLine($"\nID: {empId}\nFirstName: {firstName}\nLastName: {lastName}\nEmail: {email}\nPrimary Phone: {primaryPhoneNumber}");
                        Console.WriteLine($"Secondary Phone: {secondaryPhoneNumber}\nCreatedBy: {createdBy}\nCreatedOn: {createdOn}");
                        Console.WriteLine($"ModifiedBy: {modifiedBy}\nModifiedOn: {modifiedOn}");
                    }
                    if (dataFound == false)
                    {
                        Console.WriteLine($"\nNo employee found with ID {id}.");
                    }
                }
            }
        }
        public void SelectAllEmployees()
        {
            using(SqlConnection connection = new SqlConnection(connString)) 
            {
                connection.Open();
                string selectQuery = "select * from Employees";

                using (SqlCommand command = new SqlCommand(selectQuery, connection)) 
                {
                    SqlDataReader reader = command.ExecuteReader();
                    bool dataFound = false;
                    while (reader.Read())
                    {
                        dataFound = true;
                        long id = reader.GetInt64(reader.GetOrdinal("ID"));
                        string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                        string email = reader.GetString(reader.GetOrdinal("Email"));
                        string primaryPhoneNumber = reader.GetString(reader.GetOrdinal("PrimaryPhoneNumber"));
                        string? secondaryPhoneNumber = reader.IsDBNull(reader.GetOrdinal("SecondaryPhoneNumber")) ? null : reader.GetString(reader.GetOrdinal("SecondaryPhoneNumber"));
                        string createdBy = reader.GetString(reader.GetOrdinal("CreatedBy"));
                        DateTime createdOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn"));
                        string? modifiedBy = reader.IsDBNull(reader.GetOrdinal("ModifiedBy")) ? null : reader.GetString(reader.GetOrdinal("ModifiedBy"));
                        DateTime? modifiedOn = reader.IsDBNull(reader.GetOrdinal("ModifiedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("ModifiedOn"));
                        Console.WriteLine($"\nID: {id}\nFirstName: {firstName}\nLastName: {lastName}\nEmail: {email}\nPrimary Phone: {primaryPhoneNumber}");
                        Console.WriteLine($"Secondary Phone: {secondaryPhoneNumber}\nCreatedBy: {createdBy}\nCreatedOn: {createdOn}");
                        Console.WriteLine($"ModifiedBy: {modifiedBy}\nModifiedOn: {modifiedOn}");
                    }
                    if (dataFound == false)
                    {
                        Console.WriteLine("\nNo Employee found.");
                    }
                }
            }
        }
    }
}
