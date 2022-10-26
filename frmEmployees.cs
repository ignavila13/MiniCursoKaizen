//importo librerias necesarias
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace MiniCursoKaizen
{
    public partial class frmEmployees : Form
    {
        //creo dv global
        DataView dv = new DataView();
        public frmEmployees()
        {
            InitializeComponent();
            //conexión a base de datos
            SqlConnection connection = new SqlConnection();
            connection = getConnectionDB();
            //ejecución de procedimiento de almacenado
            SqlCommand qry = new SqlCommand("EXEC spEmployeesSelectAll", connection);
            SqlDataAdapter da = new SqlDataAdapter(qry);
            //asignación de resultados al datatable
            DataTable dt = new DataTable();
            da.Fill(dt);
            dv = dt.DefaultView; //asignación del dt a dv
            grdEmployees.DataSource = dv; //asignación del dv a la grilla
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            //el procedimiento será ejecutado cuando el usuario presione una tecla
            searchEmployee(txtSearch.Text);
        }
        private SqlConnection getConnectionDB()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["conectar"].ConnectionString);
            return connection;
        }
        /*
         aplicación del filtro por nombre y apellido
        */
        private void searchEmployee (string filter)
        {
            string sqlstring = "";
            dv.RowFilter = sqlstring;
            sqlstring = $"[LastName] LIKE '{filter}%'";
            sqlstring = sqlstring + $" OR [FirstName] LIKE '{filter}%'";
            dv.RowFilter = sqlstring;
        }

    }
}
