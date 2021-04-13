<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplicationSpedizioni.backOffice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="App_Themes/css/style.css" rel="stylesheet" />
<link rel="shortcut icon" href="img/icona.ico" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Home</title>
</head>
<body>

    <form id="form1" runat="server">
        <div class="menu">
            <asp:TreeView runat="server" ID="twMenu" NodeStyle-CssClass="treeNode"
            RootNodeStyle-CssClass="rootNode"
            LeafNodeStyle-CssClass="leafNode" 
            NodeStyle-NodeSpacing="3px">    
<LeafNodeStyle CssClass="leafNode"></LeafNodeStyle>
                 <Nodes>    
                   <asp:TreeNode Text="Home" NavigateUrl="~/home.aspx" Expanded="False"/>    
                    <asp:TreeNode Text="Elenchi" Expanded="False" SelectAction="Expand">    
                        <asp:TreeNode Text="Elenco Viaggi" NavigateUrl="~/elencoViaggi.aspx" Expanded="False"> </asp:TreeNode>
                        <asp:TreeNode Text="Elenco Veicoli" NavigateUrl="~/elencoVeicoli.aspx"  Expanded="False" > 
                            <asp:TreeNode Text="Aggiungi Veicoli" NavigateUrl="~/aggiungiVeicolo.aspx" > </asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Elenco Pacchi" NavigateUrl="~/elencoPacchi.aspx"  Expanded="False"> </asp:TreeNode>
                   </asp:TreeNode>    
                    <asp:TreeNode Text="Index" NavigateUrl="~/index.aspx"  Expanded="False">    
                        <asp:TreeNode Text="Tracciabilità" NavigateUrl="~/tracciabilità.aspx"  Expanded="False" />     
                    </asp:TreeNode>        
                 </Nodes>    

<NodeStyle NodeSpacing="3px" CssClass="treeNode"></NodeStyle>

<RootNodeStyle CssClass="rootNode"></RootNodeStyle>
             </asp:TreeView>
        </div>
        <div class="contenuto"> 
            <h1>Pagina amministrativa spedizione pacchi</h1>
            <asp:Label ID="lbProva" runat="server" Text=""></asp:Label>
            <img src="img/home.jpg" />
        </div>
    </form>
</body>
</html>
