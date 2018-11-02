﻿using System.Data.SqlClient;

namespace Database.Db
{
    public class LocalDbCreator
    {
        public void CreateLocalDb()
        {
            string location = @"C:\Users\User\Desktop\c#";

            SqlConnection connection = new SqlConnection(@"server=(localdb)\MSSQLLocalDB");
            using (connection)
            {
                connection.Open();

                string sql = string.Format(@"
                    CREATE DATABASE [Library]
                    ON PRIMARY (
                        NAME=LibraryProject,
                        FILENAME = '{0}\Test_data.mdf'
                    )",
                    location
                );

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
