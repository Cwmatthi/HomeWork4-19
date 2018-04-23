using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HomeWork4_19
{
    public partial class CustomerLookup : Form
    {
        const string connDefault = @"Server=PL7\MTCDB;Database=AdventureWorks2012;Trusted_Connection=True;";
        SqlConnection sqlConn = new SqlConnection(connDefault);

        public CustomerLookup()
        {
            InitializeComponent();
        }

        private void CustomerLookup_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sqlDA = new SqlDataAdapter("sp_ActiveCust", sqlConn);
            DataTable dtCustomers = new DataTable();
            int CustomerID;
            string CustomerName;

            try
            {
                sqlDA.Fill(dtCustomers);

                foreach(DataRow drCustomer in dtCustomers.Rows)
                {
                    CustomerID = int.Parse(drCustomer.ItemArray[0].ToString());
                    CustomerName = drCustomer.ItemArray[1].ToString();
                    cbCustomer.Items.Add(new Combobj(CustomerID, CustomerName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...");
            }
        }

        private void cbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Combobj currentObject = (Combobj)cbCustomer.SelectedItem;
            int CustomerID = currentObject.CustomerID;
            DataTable dtCustomerItems = new DataTable();

            try
            {
                SqlCommand sqlComm = new SqlCommand("sp_CustomerSales", sqlConn);
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlParameter prmCustomerID = new SqlParameter("@CustID", CustomerID);
                sqlComm.Parameters.Add(prmCustomerID);

                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlComm);

                sqlDa.Fill(dtCustomerItems);

                dgCustFill.DataSource = dtCustomerItems;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...");
            }
        }
    }

    public class Combobj
    {
        int cID;
        string cName;
        
        public Combobj(int CustomerID, string CustomerName)
        {
            cID = CustomerID;
            cName = CustomerName;
        }

        public string CustomerName
        {
            get { return cName; }
            set { cName = value; }
        }

        public int CustomerID
        {
            get { return cID;  }
            set { cID = value; }
        }

        public override string ToString()
        {
            return this.CustomerName;
        }
    }
}
