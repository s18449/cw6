using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class SqlServerDbService : IDbService
    {
        public void CheckIndexNumber(string index)
{
            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18449;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                con.Open();

                    com.CommandText = "select * from students where indexnumber = @index";

                    com.Parameters.AddWithValue("index", index);

                    var dr = com.ExecuteReader();

                    if (!dr.Read())
                    {
                        return NotFound("Student nie istnieje");
                    }
               
            }
            return Ok();

        }

        //...
    }
}
