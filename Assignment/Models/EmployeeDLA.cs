using System.Data.SqlClient;
namespace Assignment.Models
{
    public class EmployeeDLA
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        IConfiguration configuration;
        public EmployeeDLA(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConection"));
        }

        public List<Employee> GetEmployee()
        {
            List<Employee> list = new List<Employee>();
            string qry = "select * from employee1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Employee e1 = new Employee();
                    e1.Id = Convert.ToInt32(dr["id"]);
                    e1.Name = dr["name"].ToString();
                    e1.Department =dr["department"].ToString();
                    e1.Salary = Convert.ToInt32(dr["salary"]);
                   


                    list.Add(e1);
                }
            }
            con.Close();
            return list;
        }
        public int AddEmployee(Employee e1)
        {
            int result = 0;
            string qry = "insert into employee1 values(@name,@department,@salary)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", e1.Name);
            cmd.Parameters.AddWithValue("@department",e1.Department);
            cmd.Parameters.AddWithValue("@salary", e1.Salary);
            con.Open();
            result = cmd.ExecuteNonQuery();
            con.Close();
            return result;
        }
    }
}
