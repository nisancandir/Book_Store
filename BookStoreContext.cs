﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication21.Models;

namespace WebApplication21
{
    public class BookStoreContext
    {
        public string ConnectionString { get; set; }

        public BookStoreContext(string connectionString)
        {
            this.ConnectionString = "server=127.0.0.1;port=3307;database=book_try;user=root;password=nisanS36";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from books", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Book()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            BookName = reader["book_title"].ToString(),
                            AuthorName = reader["author_name"].ToString(),
                            Alphabet = reader["alphabet"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}
