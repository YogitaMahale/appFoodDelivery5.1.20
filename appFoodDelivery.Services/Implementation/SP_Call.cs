using appFoodDelivery.Persistence;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace appFoodDelivery.Services.Implementation
{
    public class SP_Call : ISP_Call
    {
        public readonly ApplicationDbContext _db;
        private static string Connectionstring = "";
        public SP_Call(ApplicationDbContext db)
        {
            _db = db;
            Connectionstring = db.Database.GetDbConnection().ConnectionString;
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Execute(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
                sqlcon.Execute(procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<T> List<T>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
                return sqlcon.Query<T>(procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
                var result = SqlMapper.QueryMultiple(sqlcon, procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();
                if(item1!=null&item2!=null )
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
                else
                {

                }
                
            }
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        public T OneRecord<T>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
                var value= sqlcon.Query<T>(procedurename, param, commandType: System.Data.CommandType.StoredProcedure);
                return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
            }
        }

        public T Single<T>(string procedurename, DynamicParameters param = null)
        {
            using (SqlConnection sqlcon = new SqlConnection(Connectionstring))
            {
                sqlcon.Open();
               return (T)Convert.ChangeType(sqlcon.ExecuteScalar <T>(procedurename, param, commandType: System.Data.CommandType.StoredProcedure),typeof(T));
            }
        }
    }
}
