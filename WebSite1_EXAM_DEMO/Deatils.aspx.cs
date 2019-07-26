using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Deatils : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Label1.Text = Session["ID"].ToString();
        Label2.Text = Session["Name"].ToString();
        Label3.Text = $"{ Session["Course"]}";
        Label4.Text = $"{Session["Grade"]}";


    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        System.Data.SqlClient.SqlConnection sqlConnection1;
        //sqlConnection1 = new System.Data.SqlClient.SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Grades1;Data Source=ELAD_HA\SQLEXPRESS");
        sqlConnection1 = new System.Data.SqlClient.SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Grades1;Data Source=ELAD_SSD\SQLEXPRESS");

        SqlCommand Command;

        int counter = 0;
        float averageNum = 0;
        int sum = 0;
        try
        {
            Command = new SqlCommand("SELECT [Course], [Grade] FROM GradesTable1 WHERE course = @course", sqlConnection1);
            Command.Parameters.Add(new SqlParameter("@course", DropDownList1.SelectedItem.Text));



            Command.Connection.Open();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(Command);//מקשר בין הטבלה בSQL לטבלה בC# לדוגמא nvarchar לString
            adapter.Fill(dt);// ממלא את הנתונים מ SQL בשפת C#
            if (dt.Rows.Count != 0)
            {
                DataTable averageGrades = new DataTable();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    counter++;
                    sum += Convert.ToInt32(dt.Rows[i]["Grade"]);
                    //sum += int.Parse(dt.Rows[i]["Grade"].ToString());
                }

                averageNum = sum / counter;
                Label5.Text = averageNum.ToString();
            }
           
        }
        catch (Exception)// e
        {
            //throw new Exception(e.Message);
        }
        finally
        {
            if (sqlConnection1 != null && sqlConnection1.State == ConnectionState.Open)
            {
                sqlConnection1.Close();
            }
        }
    }
}