<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Seller.aspx.cs" Inherits="GestionLibrairie.Views.Admin.Seller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manager Seller</h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                     <label for="" class="form-label text-success">Seller FullName</label>
                     <input text="text" placeholder="Name" autocomplete="off" class="form-control" runat="server" id="SNameTb"/>
                </div>
                 <div class="mb-3">
                     <label for="" class="form-label text-success">Seller Email </label>
                     <input text="email" placeholder=" Seller's Email" autocomplete="off" class="form-control" runat="server" id="EmailTb"/>
                </div>
                 <div class="mb-3">
                     <label for="" class="form-label text-success">Seller Phone</label>
                     <input text="number" placeholder="Phone Number" autocomplete="off" class="form-control" runat="server" id="PhoneTb"/>
                </div>
                 <div class="mb-3">
                     <label for="" class="form-label text-success">Seller Address</label>
                     <input text="text" placeholder="Password" autocomplete="off" class="form-control" runat="server" id="AddressTb"/>
                </div>


                 <div class="row">
                     <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label>
                     <div class="col d-grid">
                         <asp:Button Text="Update" runat="server" class="btn btn-block btn-warning" ID="EditId" OnClick="EditId_Click" />
                     </div>
                     <div class="col d-grid">
                         <asp:Button Text="Save" runat="server" class="btn btn-block btn-success" ID="SaveId" OnClick="SaveId_Click"/>
                     </div>
                     <div class="col d-grid">
                         <asp:Button Text="Delete" runat="server" class="btn  btn-block btn-danger" ID="DeleteId" OnClick="DeleteId_Click"/>
                     </div>
                </div>
            </div>

            <div class="col-md-8">
                <asp:GridView ID="SellerList" runat="server" class="table" AutoGenerateSelectButton="True" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="AuthorsList_SelectedIndexChanged">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="teal" Font-Bold="false" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
