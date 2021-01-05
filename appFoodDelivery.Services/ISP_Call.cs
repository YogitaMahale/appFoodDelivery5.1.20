using Dapper;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace appFoodDelivery.Services
{
  public  interface ISP_Call:IDisposable
    {
        //single value
        T Single<T>(string procedurename, DynamicParameters param = null);
        //add,delete
        void Execute(string procedurename, DynamicParameters param = null);

        T OneRecord<T>(string procedurename, DynamicParameters param = null);
        IEnumerable<T> List<T>(string procedurename, DynamicParameters param = null);
        Tuple<IEnumerable<T1>,IEnumerable<T2>> List<T1,T2>(string procedurename, DynamicParameters param = null);
    }
}
