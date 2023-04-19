using System;


namespace GestionLibrairie.Views.Admin
{
    public partial class Author : System.Web.UI.Page
    {
        Models.Functions Con;
        protected void Page_Load(object sender, EventArgs e)
        {
            Con = new Models.Functions();
            ShowAuthor();
        }

        private void ShowAuthor()
        {
            string Query = "SELECT * FROM AuthorTb1";
            AuthorsList.DataSource = Con.GetData(Query);
            AuthorsList.DataBind();
        }
        protected void SaveBtn_Click(object sender,EventArgs e)
        {
            try
            {
                if(ANameTb.Value == "" || CountryCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data !!!";
                }else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    string Query = " INSERT INTO AuthorTb1 values('{0}','{1}','{2}')";
                    Query = string.Format(Query, AName, Gender, Country);
                    Con.SetData(Query);
                    ShowAuthor();
                    ErrMsg.Text = "Author Inserted!!!";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }

            }catch(Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        int Key = 0;
        protected void AuthorsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ANameTb.Value = AuthorsList.SelectedRow.Cells[2].Text;
            GenCb.SelectedItem.Value = AuthorsList.SelectedRow.Cells[3].Text;
            CountryCb.SelectedItem.Value = AuthorsList.SelectedRow.Cells[4].Text;

            if(ANameTb.Value == "" || GenCb.SelectedItem.Value == "" || CountryCb.SelectedItem.Value == "")
            {
                Key = 0;
            }else
            {
                //Key = Convert.ToInt32(AuthorsList.SelectedRow.Cells[1].Text);
                Key = int.Parse(AuthorsList.SelectedRow.Cells[1].Text);
            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (ANameTb.Value == "" || CountryCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Missing Data !!!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    string Query = " UPDATE AuthorTb1 SET AutName = '{0}',AutGender = '{1}',AutCountry = '{2}' WHERE AutId={3}";
                    Query = string.Format(Query, AName, Gender, Country, AuthorsList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowAuthor();
                    ErrMsg.Text = "Author Updated!!!";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (ANameTb.Value == "" || CountryCb.SelectedIndex == -1 || GenCb.SelectedIndex == -1)
                {
                    ErrMsg.Text = "Select an Author!!!";
                }
                else
                {
                    string AName = ANameTb.Value;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Country = CountryCb.SelectedItem.ToString();

                    string Query = " DELETE FROM AuthorTb1  WHERE AutId={0}";
                    Query = string.Format(Query, AuthorsList.SelectedRow.Cells[1].Text);
                    Con.SetData(Query);
                    ShowAuthor();
                    ErrMsg.Text = "Author Deleted!!!";
                    ANameTb.Value = "";
                    GenCb.SelectedIndex = -1;
                    CountryCb.SelectedIndex = -1;
                }

            }
            catch (Exception ex)
            {
                ErrMsg.Text = ex.Message;
            }
        }
    }
}