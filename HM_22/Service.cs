using System.Data.SqlClient;

namespace HM_22
{
    public class Service
    {
        public void CreateTable_Users()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=HM_22;Trusted_Connection=True;";

                var query =
                    @$"CREATE TABLE dbo.Users
        (
           ID int IDENTITY(1,1) NOT NULL,
                    FirstName nvarchar(50) NULL,
                    LastName nvarchar(50) NULL,
                    Email nvarchar(50),
                    CONSTRAINT pk_id PRIMARY KEY (ID)
        );";
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table Created Succesfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!!");
                }
            }
        }
        public void CreateTable_SMS()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=HM_22;Trusted_Connection=True;";

                var query =
                    @$"CREATE TABLE dbo.SMS
        (
           ID int IDENTITY(1,1) NOT NULL,
                    Sender nvarchar(50) NULL,
                    Recipient nvarchar(50) NULL,
                    Message nvarchar(250) NULL,
        );";
                SqlCommand cmd = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Table Created Succesfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!!");
                }
            }
        }
        public void AddUser()
        {
            Console.WriteLine("Ismingizni kiriting: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Familiyangizni kiriting: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Email kiriting: ");
            string email = Console.ReadLine();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=HM_22;Trusted_Connection=True;";
                var querry = @$"
                INSERT INTO dbo.Users
                Values('{Name}','{lastName}','{email}');";

                SqlCommand cmd = new SqlCommand(querry, connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User Created Succesfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!");
                }
            }
        }
        public void AddSMS()
        {
            Console.Write("Id ingizni kiriting: ");
            int sender = int.Parse(Console.ReadLine());
            Console.Write("Habar yubormoqchi bulgan userni Id sini kiriting: ");
            int recipient = int.Parse(Console.ReadLine());
            Console.Write("Xabar yozing: ");
            string message = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=HM_22;Trusted_Connection=True;";
                var querry = @$"Insert into dbo.SMS VALUES({sender},{recipient},'{message}');";
                SqlCommand cmd = new SqlCommand(querry, connection);
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Massage is sended!!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error!");
                }
            }
        }
        public void GetAllSms()
        {
            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=HM_22;Trusted_Connection=True;"))
            {
                connection.Open();
                var query = $"Select * from dbo.SMS;";
                var command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var c = reader.FieldCount;
                        ///column sonini bilish
                        Console.WriteLine("sms_ID Sender_ID Recipient_ID Message");
                        for (int i = 0; i < c; i++)
                        {
                            Console.Write(reader[i] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
