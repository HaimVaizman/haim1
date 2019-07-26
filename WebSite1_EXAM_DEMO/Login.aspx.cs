using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void refreshLbl()
    {
        ErrLabel.Text = "";
    }


    protected void ConnectWithDataset()
    {
        System.Data.SqlClient.SqlConnection sqlConnection1;
        //sqlConnection1 = new System.Data.SqlClient.SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Grades1;Data Source=ELAD_HA\SQLEXPRESS");
        sqlConnection1 = new System.Data.SqlClient.SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Grades1;Data Source=ELAD_SSD\SQLEXPRESS");
        SqlCommand Command;

        Command = new SqlCommand("SELECT * FROM GradesTable1 WHERE Id = @Id and Name = @Name", sqlConnection1);
        Command.Parameters.Add(new SqlParameter("@Id", IDText1.Text));
        Command.Parameters.Add(new SqlParameter("@Name", NameText1.Text));

        try
        {
            Command.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);

            DataSet dsData = new DataSet();
            adapter.Fill(dsData);

            if (dsData.Tables[0] != null)
            {
                DataRow[] userDetalis = dsData.Tables[0].Select();
                foreach (var datarow in userDetalis)
                {
                    Session["ID"] = datarow["Id"].ToString();
                    Session["Name"] = datarow["Name"].ToString();
                    Session["Course"] = datarow["Course"].ToString();
                    Session["Grade"] = datarow["Grade"].ToString();
                }
                Server.Transfer("Deatils.aspx");

            }


        }
        catch
        {

        }
        finally
        {
            if (sqlConnection1 != null && sqlConnection1.State == ConnectionState.Open)
            {
                sqlConnection1.Close();
            }
        }
    }

    protected void ConnectwithDataReader()
    {
        refreshLbl();
        string i = IDText1.Text;

        System.Data.SqlClient.SqlConnection sqlConnection1;
        //sqlConnection1 = new System.Data.SqlClient.SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Grades1;Data Source=ELAD_HA\SQLEXPRESS");
        sqlConnection1 = new System.Data.SqlClient.SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Grades1;Data Source=ELAD_SSD\SQLEXPRESS");
        SqlCommand Command;
        Command = new SqlCommand("SELECT * FROM GradesTable1", sqlConnection1);


        List<Reader> results = new List<Reader>();
        try
        {
            Command.Connection.Open();
            SqlDataReader dataRead;
            dataRead = Command.ExecuteReader();
            while (dataRead.Read())
            {
                results.Add(new Reader(Convert.ToInt32(dataRead["Id"]), dataRead["Name"].ToString(),
                    dataRead["Course"].ToString(), Convert.ToInt32(dataRead["Grade"])));

                //Session["ID"] = dataRead["Id"];
                //Session["Name"] = dataRead["Name"];

            }

            Command.Connection.Close();

            var values = results
                        .Where(item => item.ID == Convert.ToInt32(IDText1.Text) && item.Name == NameText1.Text)
                        .Select(item => new { Id = item.ID, Name = item.Name, Course = item.Course, Grade = item.Grade });


            if (values.Any())
            {

                foreach (var user in values)
                {
                    Session["ID"] = user.Id;
                    Session["Name"] = user.Name;
                    Session["Course"] = user.Course;
                    Session["Grade"] = user.Grade;

                    foreach (var record in values)
                    {
                        Console.WriteLine(record);
                    }

                }

                Server.Transfer("Deatils.aspx");
            }
            else
            {
                ErrLabel.Text = "ERR Log In!";
            }


        }

        catch (Exception err)
        {
            ErrLabel.Text = err.ToString();
        }
        finally
        {

        }

        //string sqlCommand1 = "SELECT * FROM GradesTable1";
        //DataSet ds = new DataSet();
        //SqlDataAdapter adptr = new SqlDataAdapter(sqlCommand1, sqlConnection1);

        //adptr.Fill(ds, "t1");
        //DataTable grades = ds.Tables["GradesTable1"];

        int a = 23;

        //Session["Id"] = int.Parse(IDText1.Text);
        //Session["Name"] = NameText1.Text;


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
       ConnectwithDataReader();
      //ConnectWithDataset();
    }
}
public class Reader
{

    public int ID { get; set; }
    public string Name { get; set; }
    public string Course { get; set; }
    public int Grade { get; set; }

    public Reader(int id, string name, string course, int grade)
    {
        ID = id;
        Name = name;
        Course = course;
        Grade = grade;
    }
}
