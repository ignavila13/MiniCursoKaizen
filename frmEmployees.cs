using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MiniCursoKaizen
{
    public partial class frmEmployees : Form
    {
        DataView dv = new DataView();

        public frmEmployees()
        {

            InitializeComponent();

            SqlConnection connection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["conectar"].ConnectionString);

            SqlCommand qry = new SqlCommand("EXEC spEmployeesSelectAll", connection);
            SqlDataAdapter da = new SqlDataAdapter(qry);

            DataTable dt = new DataTable();
            da.Fill(dt);
            grdEmployees.DataSource = dt.DefaultView;

            dv = dt.DefaultView;


        }

        private void searchEmployee (string filter)
        {

            string sqlstring = "";
            dv.RowFilter = sqlstring;
            sqlstring = $"[LastName] LIKE '{filter}%'";
            sqlstring = sqlstring + $" OR [FirstName] LIKE '{filter}%'";
            dv.RowFilter = sqlstring;

        }

        private void txtBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            searchEmployee(txtSearch.Text);
        }


    }
}
