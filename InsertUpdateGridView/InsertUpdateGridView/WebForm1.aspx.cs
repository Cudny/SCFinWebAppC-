using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace InsertUpdateGridView
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        // string connectionString = @"Data Source(local)\sqle2014;Integrated Security=true;Initial Catalog=PhoneBookDB";
        string connectionString =
            @"Data Source=CUDNY-PC\SQLEXPRESS;" +
            "Initial Catalog=PhoneBookDB;" +
            "Integrated Security=SSPI;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }

        void PopulateGridView()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                // SqlConnectionStringBuilder
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM PhoneBook", sqlCon);
                
                sqlDa.Fill(dtbl); //do zmiennej DataTable ladujemy dane
            }
            if(dtbl.Rows.Count >0)
            {
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvPhoneBook.DataSource = dtbl; //jako source ustawiamy DataTable
                gvPhoneBook.DataBind(); // ?
                gvPhoneBook.Rows[0].Cells.Clear();
                gvPhoneBook.Rows[0].Cells.Add(new TableCell());
                gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvPhoneBook.Rows[0].Cells[0].Text = "No Data found!";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
            

        }

        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e) //triggred when click on buttons
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO PhoneBook (FirstName, LastName, Contact, Email) Values (@FirstName, @LastName, @Contact, @Email)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", (gvPhoneBook.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.FooterRow.FindControl("txtContactNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (gvPhoneBook.FooterRow.FindControl("txtEmailNameFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridView();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";

                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "New Record Added";
                lblErrorMessage.Text = ex.Message;
                throw;
            }
        }

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneBook.EditIndex = e.NewEditIndex;
            PopulateGridView();

        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneBook.EditIndex =-1;
            PopulateGridView();
        }

        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE PhoneBook SET FirstName=@FirstName, LastName=@LastName, Contact=@Contact, Email=@Email WHERE PhoneBookID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);                    
                    sqlCmd.Parameters.AddWithValue("@FirstName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtContactName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtEmailName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvPhoneBook.EditIndex = -1;
                    PopulateGridView();
                    lblSuccessMessage.Text = "Selected Record Updated ";
                    lblErrorMessage.Text = "";

                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "New Record Added";
                lblErrorMessage.Text = ex.Message;
                throw;
            }
        }
        
    }
}