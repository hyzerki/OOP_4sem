using Lab6.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Lab6.DAO
{
    internal class DatabaseAccessObject : IDisposable
    {
        private SqlConnection connection;

        #region Proc SQL
        private const string ADD_BOOK_PROC_ADD = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_AddBook'))
                               exec('CREATE PROCEDURE [dbo].[sp_AddBook]
                                @price int,
                                @name nvarchar(MAX),
                                @author nvarchar(MAX),
                                @pages int,
                                @description nvarchar(MAX),
                                @image varbinary(MAX)
                            AS
                                INSERT INTO [Books] (Price, Name, Author, Pages, Description, Image)
                                VALUES (@price, @name, @author, @pages, @description, @image)
                            ')
                            ";

        private const string GET_BOOKS_PROC_ADD = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetBooks'))
                               exec('CREATE PROCEDURE [dbo].[sp_GetBooks]
                                    AS
                                        SELECT * FROM [Books]
                                    ')
                            ";

        private const string GET_BOOK_PROC_ADD = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_GetBook'))
                               exec('CREATE PROCEDURE [dbo].[sp_GetBook]
                                    @id uniqueidentifier
                                AS
                                    SELECT * FROM [Books] WHERE Id=@id
                                ')
                            ";

        private const string DELETE_BOOK_PROC_ADD = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_DeleteBook'))
                               exec('CREATE PROCEDURE [dbo].[sp_DeleteBook]
                                @id uniqueidentifier
                            AS
                                DELETE FROM [Books] WHERE [id]=@id
                            ')
                            ";

        private const string UPDATE_BOOK_PROC_ADD = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID('dbo.sp_AddBook'))
                               exec('CREATE PROCEDURE [dbo].[sp_AddBook]
                                @price int,
                                @name nvarchar(MAX),
                                @author nvarchar(MAX),
                                @pages int,
                                @description nvarchar(MAX),
                                @image varbinary(MAX)
                            AS
                                INSERT INTO [Books] (Price, Name, Author, Pages, Description, Image)
                                VALUES (@price, @name, @author, @pages, @description, @image)
                            ')
                            ";

        private const string ENSURE_DB_CREATED = @"
        ";

        #endregion

        public DatabaseAccessObject()
        {
            connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            connection.OpenAsync();
        }

        public async void AddBook(Book book)
        {
            await new SqlCommand(ADD_BOOK_PROC_ADD, connection).ExecuteNonQueryAsync();
            // добавляем первую процедуру
            string sqlExpression = "sp_AddBook";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            // указываем, что команда представляет хранимую процедуру
            command.CommandType = CommandType.StoredProcedure;
            // параметр для ввода имени
            command.Parameters.AddWithValue("@price", book.Price);
            command.Parameters.AddWithValue("@name", book.Name);
            command.Parameters.AddWithValue("@author", book.Author);
            command.Parameters.AddWithValue("@pages", book.Pages);
            command.Parameters.AddWithValue("@description", book.Description);
            command.Parameters.AddWithValue("@image", book.Image);
            // выполняем процедуру
            await command.ExecuteNonQueryAsync();
        }

        public async Task<int> DeleteBook(Guid id)
        {
            await new SqlCommand(DELETE_BOOK_PROC_ADD, connection).ExecuteNonQueryAsync();
            // добавляем первую процедуру
            string sqlExpression = "sp_DeleteBook";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            int res = 0;
            try
            {
                // указываем, что команда представляет хранимую процедуру
                command.CommandType = CommandType.StoredProcedure;
                // параметр для ввода имени
                command.Parameters.AddWithValue("@id", id);
                res = await command.ExecuteNonQueryAsync();
                await transaction.CommitAsync();

            }
            catch
            {
                transaction.Rollback();
            }
            return res;
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {
            await new SqlCommand(GET_BOOKS_PROC_ADD, connection).ExecuteNonQueryAsync();
            string sqlExpression = "sp_GetBooks";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = CommandType.StoredProcedure;
            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                List<Book> result = new List<Book>();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        result.Add(new Book { Id = (Guid)reader["Id"], Author = (string)reader["Author"], Description = (string)reader["Description"], Image = (byte[])reader["Image"], Name = (string)reader["Name"], Pages = (int)reader["Pages"], Price = (int)reader["Price"] });
                    }
                }
                return result;
            }
        }











        private bool disposed;
        public async void Dispose()
        {
            if (!this.disposed)
            {
                if (connection.State == ConnectionState.Open)
                {
                    await connection.CloseAsync();
                }
                this.connection.Dispose();
                GC.SuppressFinalize(this);
            }
            this.disposed = true;
        }
    }
}
