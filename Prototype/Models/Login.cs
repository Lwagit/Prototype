using System.Data.SqlClient;

namespace Prototype.Models
{
    //login.cs added
    public class Login
    {
        //GETTER AND SETTER PROPERTIES
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public int? EmployeeNo { get; set; }

        public int? Contact { get; set; }

        public int? Password { get; set; }

        public string? Description { get; set; }




        //connection string class
        //Connection connect = new Connection();

        /*
        //inserting user data
        public string login(string Name, string Surname, int EmployeeNo, int Contact, string Password, string Description)
        {
            // Temp message
            string message = "";
            try
            {
                // Connect and open
                using (SqlConnection connects = new SqlConnection(connect.connecting()))
                {
                    // Open connection
                    connects.Open();

                    // Parameterized query to prevent SQL injection
                    string query = "SELECT * FROM users WHERE name = @Name AND password = @Password";

                    // Prepare to execute with parameterized query
                    using (SqlCommand prepare = new SqlCommand(query, connects))
                    {
                        // Add parameters to the query
                        prepare.Parameters.AddWithValue("@Name", Name);
                        prepare.Parameters.AddWithValue("@Password", Password);

                        // Read the data
                        using (SqlDataReader find_user = prepare.ExecuteReader())
                        {
                            // Then check if the user is found
                            if (find_user.HasRows)
                            {
                                // Then assign message
                                message = "found";
                                Console.WriteLine(message);
                            }
                            else
                            {
                                message = "not";
                                Console.WriteLine(message);
                            }
                        }
                    }

                    // Close the connection after query execution
                    connects.Close();

                    // If the user is found, update active status
                    if (message == "found")
                    {
                        update_active(Name);
                    }
                }
            }
            catch (SqlException sqlEx) // Catch SQL-related exceptions
            {
                message = "Database error: " + sqlEx.Message;
                Console.WriteLine(message);
            }
            catch (Exception ex) // Catch any other exceptions
            {
                message = "Error: " + ex.Message;
                Console.WriteLine(message);
            }
            return message;
        }

        // Update active method
        public void update_active(string email)
        {
            try
            {
                using (SqlConnection connects = new SqlConnection(connect.connecting()))
                {
                    connects.Open();

                    // Use parameterized query for updating
                    string query = "UPDATE active SET email = @Email";

                    using (SqlCommand done = new SqlCommand(query, connects))
                    {
                        // Add parameter to the query
                        done.Parameters.AddWithValue("@Email", email);

                        // Execute the update command
                        done.ExecuteNonQuery();
                    }

                    // Close the connection
                    connects.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Database error: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }/

        */
    }
}

