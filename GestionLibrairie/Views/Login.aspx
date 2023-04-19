<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GestionLibrairie.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../../Assets/Lib/css/Content/bootstrap.min.css" rel="stylesheet"/>
     <link href="../../Assets/Lib/css/Style.css" rel="stylesheet"/>
</head>
<body>

        <div class="row">
            <div class="col-md-4">
               
            </div>
             <div class="col-md-4">
                <form id="form1" runat="server">
                    <div class="image" style="text-align:center; color:darkgreen">
                        <img src="../Assets/Images/shopping-cart.png" width="50" height="50">
                    </div>
                    <div class="mt-3">
                        <label for="" class="form-label">User Name</label>
                        <input type="email" placeholder="Your Email here" autocomplete="off" runat="server" class="form-control" id="UnameTb"/>
                    </div>
                     <div class="mt-3">
                        <label for="" class="form-label">Password</label>
                        <input type="password" placeholder="Password" autocomplete="off" runat="server" class="form-control" id="PasswordTb"/>
                    </div>
                    <div class="mt-3 d-grid">
                        <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label><br />
                        <asp:Button Text="Login" ID="LoginBtn" runat="server" class="btn btn-success" OnClick="LoginBtn_Click" />
                    </div>
                    
                </form>
             </div>
            <div class="col-md-4">

            </div>
        </div>
</body>
</html>
