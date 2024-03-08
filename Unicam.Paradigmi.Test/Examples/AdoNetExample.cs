using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Paradigmi.Abstractions;

namespace Unicam.Paradigmi.Test.Examples
{
    public class AdoNetExample : IExample
    {
        public void RunExample()
        {
            var connection = new SqlConnection();
            connection.ConnectionString = "Server=localhost;Database=Paradigmi;User Id=paradigmi;Password=paradigmi;";
            connection.Open();

        }
    }
}
