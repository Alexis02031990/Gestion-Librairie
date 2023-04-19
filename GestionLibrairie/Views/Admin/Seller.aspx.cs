using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GestionLibrairie.Views.Admin
{
    public partial class Seller : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowSeller();
        }
        private void ShowSeller()
        {
            string Query = "SELECT * FROM SellerTb1";
            SellerList.DataSource = Con.GetData(Query);
            SellerList.DataBind();
        }
        protected void SaveId_Click(object sender, EventArgs e)
        {
            try
            {
                if (SNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddressTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!!";
                }
                else
                {
                    string SName = SNameTb.Value;
                    string Email = EmailTb.Value;
                    string Phone = PhoneTb.Value;
                    string Address = AddressTb.Value;

                    string Query = " INSERT INTO SellerTb1 values('{0}','{1}','{2}','{3}')";
                    Query = string.Format(Query, SName, Email, Phone, Address);
                    Con.SetData(Query);
                    ShowSeller();
                    ErrMsg.Text = "Seller Inserted!!!";
                    SNameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    AddressTb.Value = "";
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

            SNameTb.Value = SellerList.SelectedRow.Cells[2].Text;
            EmailTb.Value = SellerList.SelectedRow.Cells[3].Text;
            PhoneTb.Value = SellerList.SelectedRow.Cells[4].Text;
            AddressTb.Value = SellerList.SelectedRow.Cells[5].Text; 


            if (SNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddressTb.Value == "")
            {
                Key = 0;
            }
            else
            {
                //Key = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);
                Key = int.Parse(SellerList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditId_Click(object sender, EventArgs e)
        {
            try
            {
                if (SNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddressTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!!";
                }
                else
                {
                    string SName = SNameTb.Value;
                    string Email = EmailTb.Value;
                    string Phone = PhoneTb.Value;
                    string Address = AddressTb.Value;

                    string Query = " UPDATE SellerTb1 SET SelName = '{0}',SelEmail = '{1}',SelPhone = '{2}',SelAddress = '{3}' WHERE SelId= {4}";
                    Query = string.Format(Query, SName, Email, Phone, Address, SellerList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowSeller();
                    ErrMsg.Text = "Seller Update!!!";
                    SNameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    AddressTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void DeleteId_Click(object sender, EventArgs e)
        {
            try
            {
                if (SNameTb.Value == "" || EmailTb.Value == "" || PhoneTb.Value == "" || AddressTb.Value == "")
                {
                    ErrMsg.Text = "Missing Data !!!";
                }
                else
                {
                    string SName = SNameTb.Value;
                    string Email = EmailTb.Value;
                    string Phone = PhoneTb.Value;
                    string Address = AddressTb.Value;

                    string Query = " DELETE FROM SellerTb1  WHERE SelId={0}";
                    Query = string.Format(Query, SellerList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowSeller();
                    ErrMsg.Text = "Seller Deleted!!!";
                    SNameTb.Value = "";
                    EmailTb.Value = "";
                    PhoneTb.Value = "";
                    AddressTb.Value = "";
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}