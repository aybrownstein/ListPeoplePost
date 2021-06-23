using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace homeWork3_3.Models
{
    public class HomeViewModel
    {
        public List<People> People { get; set; }
        public string Message { get; set; }
    }
    public class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    public class PeopleDb
    {
        private readonly string _connectionString;

        public PeopleDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<People> GetPeople()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<People> peoples = new();
            while (reader.Read())
            {
                peoples.Add(new People
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return peoples;
        }

        public void AddPerson(List<People> people)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO People (FirstName, LastName, Age) " +
                             "VALUES (@firstName, @lastName, @age)";
            connection.Open();
            foreach (People person in people)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);

                cmd.ExecuteNonQuery();
            }
          
        }
    }
}
