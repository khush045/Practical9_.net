
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;

namespace Practical_9
{
    public partial class Practical_9 : Page
    {
        string cs = ConfigurationManager
            .ConnectionStrings["PlacementDB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStudents();
                LoadSummary();
            }
        }

        void LoadStudents()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "SELECT ID, StudentID AS [Student ID], " +
                    "Company, Department FROM Students";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvStudents.DataSource = dt;
                gvStudents.DataBind();
            }
        }

        void LoadSummary()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"
                    SELECT
                    COUNT(*) AS [Total Students],
                    SUM(CASE WHEN Status = 'Placed'
                        THEN 1 ELSE 0 END) AS [Placed Students],
                    SUM(CASE WHEN Status <> 'Placed' OR Status IS NULL
                        THEN 1 ELSE 0 END) AS [Unplaced Students],
                    CAST(100.0 * SUM(CASE WHEN Status = 'Placed'
                        THEN 1 ELSE 0 END) / NULLIF(COUNT(*), 0)
                        AS DECIMAL(5,2)) AS [Placement Percent],
                    ISNULL(MAX(CASE WHEN Status = 'Placed'
                        THEN Package END), 0) AS [Highest Package (LPA)]
                    FROM Students";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvSummary.DataSource = dt;
                gvSummary.DataBind();
            }
        }
    }
}
