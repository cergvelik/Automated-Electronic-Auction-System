/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using ElectronicAuction.Classes.Account;
using ElectronicAuction.Classes.Services;
using ElectronicAuction.Interfaces.ServicesInterfaces;
using System.Data.SqlClient;

namespace ElectronicAuction
{
    internal class Program
    {
        // LAPTOP - B4VML6MR\SQLEXPRESS

            static void Main(string[] args)
            {
                // введите свой
                string connectionString = "Data Source= LAPTOP-B4VML6MR\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
                ConsolePersonalAccount cpa = new ConsolePersonalAccount(); 
                RunSqlQueries(connectionString, cpa);
            }

            static void RunSqlQueries(string connectionString, ConsolePersonalAccount cpa)
            {
            
                //cpa.InitializateAccount();
                while (true)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            cpa.AccountMenu(connectionString);
                            /*Console.WriteLine("Введите SQL запрос (или 'exit' для выхода):");
                            string query = Console.ReadLine();

                            if (query.ToLower() == "exit")
                                break;

                                    SqlCommand command = new SqlCommand(query, connection);
                                    connection.Open();

                                    SqlDataReader reader = command.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        for (int i = 0; i < reader.FieldCount; i++)
                                        {
                                            Console.Write(reader[i] + "\t");
                                        }
                                        Console.WriteLine();
                                    }

                                    reader.Close();
                            */
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка: " + ex.Message);
                    }
                } 
            }
        }

    }

