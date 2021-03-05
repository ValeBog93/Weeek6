using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace TestWeek6
{
   public  class ConnectionMode
    {
        const string connectionString = @"Persist Security Info = False; Integrated Security = true; Initial Catalog = POLIZZIA; Server =.\SQLEXPRESS";
        public static void TuttiAgenti()
        {
            //Creare la connesione

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Aprire la connesione
                connection.Open();


                //Creare un Command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT* FROM AGENTE";

                //Esecuzione del Comand
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dei dati
                while (reader.Read())
                {
                    Console.WriteLine("{0} - {1} {2} {3} {4}",
                        reader["ID"],
                        reader["NOME"],
                        reader["COGNOME"],
                        reader["CODICE_FISCALE"],
                        reader["DATA DI NASCITA"]);
                        

                }
                //Chiusura connesione
                reader.Close();
                connection.Close();

                

            }
        }
        public static void AgentePerAria()
        {
            //CReare la connesione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                Console.WriteLine("ID del ARIA");
                string Area = Console.ReadLine();

             
                connection.Open();
                //Creare il comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM ASSEGNAZIONE Where AREA_AD =@AREA_AD";

                //Creare il parametro
                SqlParameter genParam = new SqlParameter();
                genParam.ParameterName = "@AREA_AD";
                genParam.Value = Area;
                command.Parameters.Add(genParam);

               
                //Esecuzione del command
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{ reader["ID"]}-{ reader["AREA_AD"]} { reader["AGENTE_AD"]}");
                }
                //Chiudere la connesione
                reader.Close();
                connection.Close();
            }
        }
    }

    
}
