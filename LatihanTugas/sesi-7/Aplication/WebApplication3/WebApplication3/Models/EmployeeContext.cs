﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace WebApplication3.Models
{
    public class EmployeeContext
    {
        public int ConnectionString { get; set; }

        public EmployeeContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<EmployeeItem> GetAllEmployee()
        {
            List<EmployeeItem> list = new List<EmloyeeItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM employee", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new EmployeeItem()
                        {
                            id = reader.GetInt32("id"),
                            nama = reader.GetString("nama"),
                            jenisKelamin = reader.GetString("jenis_kelamin"),
                            alamat = reader.GerString("alamat")
                        });
                    }
                }
            }
            return list;

            public List<EmployeeItem> GetEmployee(string id)
            {
                List<EmployeeItem> list = new List<EmployeeItem>();

                using (MySqlConnection con = GetConnection())
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM employee WHERE id =@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new EmployeeItem()
                            {
                                id = reader.GetInt32("id"),
                                nama = reader.GetString("nama"),
                                jenisKelamin = reader.GetString("jenis_kelamin"),
                                alamat = reader.GerString("alamat")
                            });
                        }
                    }
                }
                return list;
            }
        }
    }
}
