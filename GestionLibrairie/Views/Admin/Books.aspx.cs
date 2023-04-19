using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionLibrairie.Views.Admin
{
    public partial class Books : System.Web.UI.Page
    {
        Models.Functions Con;

        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();

            if (!IsPostBack)
            {
                ShowBooks();
                GetCategories();
                GetAuthors();
            }
           
        }

        private void GetCategories()
        {
            string Query = "SELECT * FROM CategoryTb1";
            BCatCb.DataTextField = Con.GetData(Query).Columns["CatName"].ToString();
            BCatCb.DataValueField = Con.GetData(Query).Columns["CatId"].ToString();
            BCatCb.DataSource = Con.GetData(Query);
            BCatCb.DataBind();
        }
        private void GetAuthors()
        {
            string Query = "SELECT * FROM AuthorTb1";
            BAuthCb.DataTextField = Con.GetData(Query).Columns["AutName"].ToString();
            BAuthCb.DataValueField = Con.GetData(Query).Columns["AutId"].ToString();
            BAuthCb.DataSource = Con.GetData(Query);
            BAuthCb.DataBind();
        }
        private void ShowBooks()
        {
            string Query = "SELECT * FROM BookTb1";
            BooksList.DataSource = Con.GetData(Query);
            BooksList.DataBind();
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {


            try
            {
                if (BNameTb.Value == "" || BAuthCb.SelectedIndex == -1 || BCatCb.SelectedIndex == -1 || QtyTb.Value == "" || PriceTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!!";
                }
                else
                {
                    string BName = BNameTb.Value;
                    string BAuth = BAuthCb.SelectedValue.ToString();
                    string BCat = BCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QtyTb.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);


                    string Query = "INSERT INTO BookTb1 values('{0}',{1},{2},{3},{4})";

                    Query = string.Format(Query, BName, BAuth, BCat, Quantity, Price, Price*Quantity);
                    Con.SetData(Query);
                    ShowBooks();

                    ErrMsg.Text = "Book Inserted!!!";
                    BNameTb.Value = "";
                    BAuthCb.SelectedIndex = -1;
                    BCatCb.SelectedIndex = -1;
                    QtyTb.Value = "";
                    PriceTb.Value = "";
                   
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (BNameTb.Value == "" || BAuthCb.SelectedIndex == -1 || BCatCb.SelectedIndex == -1 || QtyTb.Value == "" || PriceTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!!";
                }
                else
                {
                    string BName = BNameTb.Value;
                    string BAuth = BAuthCb.SelectedValue.ToString();
                    string BCat = BCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QtyTb.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = " UPDATE BookTb1 SET BName = '{0}',BAuthor= '{1}',BCategory='{2}',BQty='{3}',BPrice='{4}' WHERE Bid= {2}";
                    Query = string.Format(Query, BName, BAuth,BCat,Quantity,Price, Price * Quantity ,BooksList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book Updated!!!";
                    BNameTb.Value = "";
                    BAuthCb.SelectedIndex = -1;
                    BCatCb.SelectedIndex = -1;
                    QtyTb.Value = "";
                    PriceTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        int Key = 0;
        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BNameTb.Value = BooksList.SelectedRow.Cells[2].Text;
            BAuthCb.SelectedValue = BooksList.SelectedRow.Cells[3].Text;
            BCatCb.SelectedValue = BooksList.SelectedRow.Cells[4].Text;
            QtyTb.Value = BooksList.SelectedRow.Cells[5].Text;
            PriceTb.Value =BooksList.SelectedRow.Cells[6].Text;

            if (BNameTb.Value == "" || BAuthCb.SelectedIndex ==-1 || BCatCb.SelectedIndex == -1 || QtyTb.Value == "" || PriceTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                //Key = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);
                Key = int.Parse(BooksList.SelectedRow.Cells[1].Text);
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (BNameTb.Value == "" || BAuthCb.SelectedIndex == -1 || BCatCb.SelectedIndex == -1 || QtyTb.Value == "" || PriceTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!!";
                }
                else
                {
                    string BName = BNameTb.Value;
                    string BAuth = BAuthCb.SelectedValue.ToString();
                    string BCat = BCatCb.SelectedValue.ToString();
                    int Quantity = Convert.ToInt32(QtyTb.Value);
                    int Price = Convert.ToInt32(PriceTb.Value);

                    string Query = " DELETE FROM BookTb1  WHERE Bid={0}";
                    Query = string.Format(Query, BooksList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowBooks();
                    ErrMsg.Text = "Book Deleted!!!";
                    BNameTb.Value = "";
                    BAuthCb.SelectedIndex = -1;
                    BCatCb.SelectedIndex = -1;
                    QtyTb.Value = "";
                    PriceTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}