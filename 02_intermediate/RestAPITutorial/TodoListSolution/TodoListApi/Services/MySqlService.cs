using MySql.Data.MySqlClient;
using System.Data;
using System.Diagnostics;
using System.Xml.Linq;
using TodoListApi.Models;

namespace TodoListApi.Services
{
    public class MySqlService
    {
        public string ConnectionString { get; set; } = string.Empty;

        public MySqlService(string connstring) {
            this.ConnectionString = connstring;
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<TodoItem> GetTodoItems()
        {
            List<TodoItem> list = new List<TodoItem>();

            string query = @"SELECT id,
                                    Name,
                                    IsComplete
                               FROM todoitem ";
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);  
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TodoItem()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = reader["Name"].ToString(),
                            IsComplete = reader["IsComplete"].ToString()
                        });
                    }
                }                
            }

            return list;
        }

        public bool SetTodoItem(string name, string isComplete)
        {
            bool result = false;
            string query = @"INSERT INTO todoitem
                                   (Name,
                                    IsComplete)
                             VALUES
                                   (@Name,
                                    @IsComplete)";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@IsComplete", isComplete);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Debug.WriteLine("Insert Succeed!!");
                        result = true;
                    }
                    else
                    {
                        Debug.WriteLine("Insert Failed!");
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception {ex.Message}");
                result = false;
            }

            return result;            
        }

        public bool DelTodoItem(int id)
        {
            bool result = false;
            string query = @"DELETE FROM todoitem
                              WHERE id = @id";

            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Debug.WriteLine("Delete Succeed!!");
                        result = true;
                    }
                    else
                    {
                        Debug.WriteLine("Delete Failed!");
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception {ex.Message}");
                result = false;
            }

            return result;
        }
    }
}
