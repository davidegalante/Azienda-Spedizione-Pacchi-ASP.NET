<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplicationSpedizioni.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="shortcut icon" href="img/icona.ico" />
<link href="App_Themes/css/style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="menu">
            <asp:TreeView runat="server" ID="twMenu" NodeStyle-CssClass="treeNode"
            RootNodeStyle-CssClass="rootNode"
            LeafNodeStyle-CssClass="leafNode" 
            NodeStyle-NodeSpacing="3px">    
                 <Nodes>    
                    <asp:TreeNode Text="Index" NavigateUrl="~/index.aspx"  Expanded="False">    
                        <asp:TreeNode Text="Tracciabilità" NavigateUrl="~/tracciabilità.aspx"  Expanded="False" />     
                    </asp:TreeNode>        
                 </Nodes>    
             </asp:TreeView>
        </div>
        <div  class="contenuto">
            <img src="img/logo.svg" width="350" height="130"/><br />
            Username:<asp:TextBox ID="tbUser" runat="server"></asp:TextBox><br />
            Password:<asp:TextBox ID="tbPassword" runat="server"></asp:TextBox><br /><br />
            <asp:Button class="btn" ID="btnAccedi" runat="server" Text="Accedi" OnClick="Accedi"/>
            <asp:Button class="btn" ID="btnAreaPubblica" runat="server" Text="Vai all'area di tracciabilità" OnClick="Traccia"/>
        </div>
    </form>
</body>
</html>
