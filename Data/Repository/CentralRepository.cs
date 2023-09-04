using Domain.Entities;
using Domain.Interface.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CentralRepository : ICentralRepository
    {
        IUnitOfWorkCentral _unitOfWork;
        public CentralRepository(IUnitOfWorkCentral unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Arquivo> GetArquivo(string filename)
        {
            var connString = Environment.GetEnvironmentVariable("BASE_SQL");
            Arquivo arquivo = new Arquivo();
            using (var conn = new SqlConnection(connString))
            {
                var sql = @"SELECT filename,
                                   filesize,
                                   lastmodified
                            FROM Files 
                            where filename = @filename";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("filename", filename);

                    cmd.Connection = conn;
                    conn.Open();
                    using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                    {
                        while (dr.Read())
                        {
                            arquivo.filename = dr["filename"].ToString();
                            arquivo.filesize = Convert.ToInt64(dr["filesize"]);
                            arquivo.lastmodified = Convert.ToDateTime(dr["lastmodified"]);
                            
                        }
                    }
                    conn.Close();
                }
            }

            return arquivo;
        }
    }
}
