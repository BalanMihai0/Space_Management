using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using UserLibrary;
using SpaceLibrary;
using CustomExceptions;

namespace DataLibrary
{
    /// <summary>
    /// this class is used for managing data of users
    /// 
    /// </summary>
    
    public class UserDataHandler : IUserDataInterface
    {
        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(storedPassword);
            //recalculate salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            using (var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000))
            {
                //check after salt is known
                byte[] hash = pbkdf2.GetBytes(20);
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        void IUserDataInterface.AddUserToDatabase(User user)
        {
            if (((IUserDataInterface)this).EmailAlreadyExists(user.Email)) throw new InvalidEmailException("Email already exists!");
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        if (user is Guest)
                        {
                            string query1 = "INSERT INTO S2_Individual_User_Guest " +
                                            "(FirstName, LastName, Email, Password, ProfilePictureUrl, BirthDate) " +
                                            "VALUES (@firstName, @lastName, @email, @password, @profilePictureUrl, @birthDate)";
                            using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                            {
                                command1.Parameters.AddWithValue("@firstName", ((Guest)user).FirstName);
                                command1.Parameters.AddWithValue("@lastName", ((Guest)user).LastName);
                                command1.Parameters.AddWithValue("@email", ((Guest)user).Email);
                                command1.Parameters.AddWithValue("@password", HashPassword(((Guest)user).Password));
                                command1.Parameters.AddWithValue("@profilePictureUrl", ((Guest)user).ProfilePictureURL);
                                command1.Parameters.AddWithValue("@birthDate", ((Guest)user).Birthdate);

                                int rowsAffected = command1.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }
                        }
                        if (user is Administrator)
                        {
                            string query1 = "INSERT INTO S2_Individual_User_Administrator " +
                                            "(FirstName, LastName, Email, Password, BirthDate) " +
                                            "VALUES (@firstName, @lastName, @email, @password, @birthDate)";
                            using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                            {
                                command1.Parameters.AddWithValue("@firstName", ((Administrator)user).FirstName);
                                command1.Parameters.AddWithValue("@lastName", ((Administrator)user).LastName);
                                command1.Parameters.AddWithValue("@email", ((Administrator)user).Email);
                                command1.Parameters.AddWithValue("@password", HashPassword(((Administrator)user).Password));
                                command1.Parameters.AddWithValue("@birthDate", ((Administrator)user).Birthdate);

                                int rowsAffected = command1.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }
                        }
                        if (user is Employee)
                        {
                            string query1 = "INSERT INTO S2_Individual_User_Employee " +
                                            "(FirstName, LastName, Email, Password, BirthDate) " +
                                            "VALUES (@firstName, @lastName, @email, @password, @birthDate)";
                            using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                            {
                                command1.Parameters.AddWithValue("@firstName", ((Employee)user).FirstName);
                                command1.Parameters.AddWithValue("@lastName", ((Employee)user).LastName);
                                command1.Parameters.AddWithValue("@email", ((Employee)user).Email);
                                command1.Parameters.AddWithValue("@password", HashPassword(((Employee)user).Password));
                                command1.Parameters.AddWithValue("@birthDate", ((Employee)user).Birthdate);

                                int rowsAffected = command1.ExecuteNonQuery();
                                Console.WriteLine($"Inserted {rowsAffected} row(s)");
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // If any exceptions were thrown, roll back the transaction
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        User IUserDataInterface.CheckUserLogin(string email, string password)
        //returns user type as object built
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();

                    // Check for guest login
                    string query1 = @$"SELECT ProfilePictureUrl, FirstName, LastName, Email, Password, BirthDate FROM S2_Individual_User_Guest WHERE Email='{email}'";
                    using (SqlCommand command1 = new SqlCommand(query1, conn))
                    {
                        using (SqlDataReader reader1 = command1.ExecuteReader())
                        {
                            if (reader1.Read())
                            {
                                string storedPassword = reader1.GetString(reader1.GetOrdinal("Password"));
                                if (VerifyPassword(password, storedPassword))
                                {
                                    Guest temp = new Guest(
                                        reader1.GetString(reader1.GetOrdinal("ProfilePictureUrl")),
                                        reader1.GetString(reader1.GetOrdinal("FirstName")),
                                        reader1.GetString(reader1.GetOrdinal("LastName")),
                                        reader1.GetString(reader1.GetOrdinal("Email")),
                                        reader1.GetString(reader1.GetOrdinal("Password")),
                                        reader1.GetDateTime(reader1.GetOrdinal("BirthDate"))
                                        );
                                    return temp;
                                }
                            }
                        }
                    }

                    // Check for administrator login
                    string query2 = @$"SELECT FirstName, LastName, Email, Password, BirthDate FROM S2_Individual_User_Administrator WHERE Email='{email}'";
                    using (SqlCommand command2 = new SqlCommand(query2, conn))
                    {
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            if (reader2.Read())
                            {
                                string storedPassword = reader2.GetString(reader2.GetOrdinal("Password"));
                                if (VerifyPassword(password, storedPassword))
                                {
                                    Administrator temp = new Administrator(
                                        reader2.GetString(reader2.GetOrdinal("FirstName")),
                                        reader2.GetString(reader2.GetOrdinal("Password")),
                                        reader2.GetString(reader2.GetOrdinal("Email")),
                                        reader2.GetString(reader2.GetOrdinal("LastName")),
                                        reader2.GetDateTime(reader2.GetOrdinal("BirthDate"))
                                        );
                                    return temp; 
                                }
                            }
                        }
                    }

                    // Check for employee login
                    string query3 = @$"SELECT FirstName, LastName, Email, Password, BirthDate FROM S2_Individual_User_Employee WHERE Email='{email}'";
                    using (SqlCommand command3 = new SqlCommand(query3, conn))
                    {
                        using (SqlDataReader reader3 = command3.ExecuteReader())
                        {
                            if (reader3.Read())
                            {
                                string storedPassword = reader3.GetString(reader3.GetOrdinal("Password"));
                                if (VerifyPassword(password, storedPassword))
                                {
                                    Employee temp = new Employee(
                                        reader3.GetString(reader3.GetOrdinal("FirstName")),
                                        reader3.GetString(reader3.GetOrdinal("Password")),
                                        reader3.GetString(reader3.GetOrdinal("Email")),
                                        reader3.GetString(reader3.GetOrdinal("LastName")),
                                        reader3.GetDateTime(reader3.GetOrdinal("BirthDate"))
                                        );
                                    return temp;
                                }
                            }
                        }
                    }

                    // No matching user found
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        bool IUserDataInterface.EmailAlreadyExists(string email)
        { 
           using (SqlConnection connection = new SqlConnection(Database.Connection))
           {
               connection.Open();

               SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM S2_Individual_User_Guest WHERE Email = @Email", connection);
               command.Parameters.AddWithValue("@Email", email);

                SqlCommand command2 = new SqlCommand("SELECT COUNT(*) FROM S2_Individual_User_Employee WHERE Email = @Email", connection);
                command2.Parameters.AddWithValue("@Email", email);

                SqlCommand command3 = new SqlCommand("SELECT COUNT(*) FROM S2_Individual_User_Administrator WHERE Email = @Email", connection);
                command3.Parameters.AddWithValue("@Email", email);

                int count = 0 ;
                count += (int)command.ExecuteScalar();
                count += (int)command2.ExecuteScalar(); count += (int)command3.ExecuteScalar();

                if (count > 0)
               {
                   return true;
               }
           }
           return false;
        }

        void IUserDataInterface.UpdateUser(string email, User newUser)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string tableName = "";
                        string firstName = "";
                        string lastName = "";
                        string password = "";
                        DateTime birthdate = DateTime.MinValue;

                        // Determine which table to update based on the type of the user
                        if (newUser is Guest)
                        {
                            tableName = "S2_Individual_User_Guest";
                            firstName = ((Guest)newUser).FirstName;
                            lastName = ((Guest)newUser).LastName;
                            password = ((Guest)newUser).Password;
                            birthdate = ((Guest)newUser).Birthdate;
                        }
                        else if (newUser is Administrator)
                        {
                            tableName = "S2_Individual_User_Administrator";
                            firstName = ((Administrator)newUser).FirstName;
                            lastName = ((Administrator)newUser).LastName;
                            password = (((Administrator)newUser).Password);
                            birthdate = ((Administrator)newUser).Birthdate;
                        }
                        else if (newUser is Employee)
                        {
                            tableName = "S2_Individual_User_Employee";
                            firstName = ((Employee)newUser).FirstName;
                            lastName = ((Employee)newUser).LastName;
                            password = (((Employee)newUser).Password);
                            birthdate = ((Employee)newUser).Birthdate;
                        }

                        // Update the user with the given email
                        string query1 = $"UPDATE {tableName} SET " +
                                        $"FirstName=@firstName, LastName=@lastName, Password=@password, BirthDate=@birthDate " +
                                        $"WHERE Email=@email";
                        using (SqlCommand command1 = new SqlCommand(query1, conn, transaction))
                        {
                            command1.Parameters.AddWithValue("@firstName", firstName);
                            command1.Parameters.AddWithValue("@lastName", lastName);
                            command1.Parameters.AddWithValue("@email", email);
                            command1.Parameters.AddWithValue("@password", password);
                            command1.Parameters.AddWithValue("@birthDate", birthdate);

                            int rowsAffected = command1.ExecuteNonQuery();
                            Console.WriteLine($"Updated {rowsAffected} row(s)");
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // If any exceptions were thrown, roll back the transaction
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        User IUserDataInterface.GetUserByEmail(string email)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();

                    //Check for email in Guest
                    string query = "SELECT * FROM S2_Individual_User_Guest WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                string LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                string EmailFromDb = reader.GetString(reader.GetOrdinal("Email"));
                                string Password = reader.GetString(reader.GetOrdinal("Password"));
                                string ProfilePictureUrl = reader.GetString(reader.GetOrdinal("ProfilePictureUrl"));
                                DateTime Birthdate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));

                                return new Guest(ProfilePictureUrl, FirstName, LastName, EmailFromDb, Password, Birthdate);
                            }
                        }
                    }

                    //Check for email in Admin
                    string query1 = "SELECT * FROM S2_Individual_User_Administrator WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                string LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                string EmailFromDb = reader.GetString(reader.GetOrdinal("Email"));
                                string Password = reader.GetString(reader.GetOrdinal("Password"));
                                DateTime Birthdate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));

                                return new Administrator(FirstName, Password, EmailFromDb, LastName, Birthdate);
                            }
                        }
                    }

                    //Check for email in Employee
                    string query2 = "SELECT * FROM S2_Individual_User_Employee WHERE Email = @Email";
                    using (SqlCommand command = new SqlCommand(query2, conn))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                string LastName = reader.GetString(reader.GetOrdinal("LastName"));
                                string EmailFromDb = reader.GetString(reader.GetOrdinal("Email"));
                                string Password = reader.GetString(reader.GetOrdinal("Password"));
                                DateTime Birthdate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));

                                return new Employee(FirstName, Password, EmailFromDb, LastName, Birthdate);
                            }
                        }
                    }

                    //no user found 
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        void IUserDataInterface.DeleteUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();
                    // Begin a transaction on the connection
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string query2 = "DELETE FROM ";
                        if (user is Guest)
                        {
                            query2 += "S2_Individual_User_Guest ";
                        }
                        else if (user is Administrator)
                        {
                            query2 += "S2_Individual_User_Administrator ";
                        }
                        else if (user is Employee)
                        {
                            query2 += "S2_Individual_User_Employee ";
                        }
                        query2 += "WHERE Email = @Email";
                        using (SqlCommand command2 = new SqlCommand(query2, conn, transaction))
                        {
                            command2.Parameters.AddWithValue("@Email", user.Email);

                            int rowsAffected = command2.ExecuteNonQuery();
                            Console.WriteLine($"Deleted {rowsAffected} row(s) from the individual user table");
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // If any exceptions were thrown, roll back the transaction
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        List<User> IUserDataInterface.GetAllAdministrators()
        {
            List<User> admins = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM S2_Individual_User_Administrator";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                                string email = reader.GetString(reader.GetOrdinal("Email"));
                                string password = reader.GetString(reader.GetOrdinal("Password"));
                                DateTime birthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));

                                User admin = new Administrator(firstName, password, email, lastName, birthDate);
                                admins.Add(admin);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return admins;
        }
        List<User> IUserDataInterface.GetAllEmployees()
        {
            List<User> employees = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM S2_Individual_User_Employee";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                                string email = reader.GetString(reader.GetOrdinal("Email"));
                                string password = reader.GetString(reader.GetOrdinal("Password"));
                                DateTime birthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));

                                User employee = new Employee(firstName, password, email, lastName, birthDate);
                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return employees;
            

        }
        List<User> IUserDataInterface.GetAllGuests()
        {
            List<User> guests = new List<User>();

            try
            {
                using (SqlConnection conn = new SqlConnection(Database.Connection))
                {
                    conn.Open();
                    string query = "SELECT * FROM S2_Individual_User_Guest";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string firstName = reader.GetString(reader.GetOrdinal("FirstName"));
                                string lastName = reader.GetString(reader.GetOrdinal("LastName"));
                                string email = reader.GetString(reader.GetOrdinal("Email"));
                                string password = reader.GetString(reader.GetOrdinal("Password"));
                                DateTime birthDate = reader.GetDateTime(reader.GetOrdinal("BirthDate"));
                                string? profilePicUrl = reader.GetString(reader.GetOrdinal("ProfilePictureUrl"));

                                User guest = new Guest(profilePicUrl, firstName, lastName, email, password, birthDate);
                                guests.Add(guest);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return guests;
        }
    }
}