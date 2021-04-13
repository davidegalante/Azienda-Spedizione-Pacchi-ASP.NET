<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aggiungiCliente.aspx.cs" Inherits="WebApplicationSpedizioni.aggiungiCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<link rel="shortcut icon" href="img/icona.ico" />
<link href="App_Themes/css/style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aggiungi Cliente</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="menu">
            <asp:TreeView runat="server" ID="twMenu" NodeStyle-CssClass="treeNode"
            RootNodeStyle-CssClass="rootNode"
            LeafNodeStyle-CssClass="leafNode" 
            NodeStyle-NodeSpacing="3px">   
                 <Nodes>    
                   <asp:TreeNode Text="Home" NavigateUrl="~/home.aspx" Expanded="False"/>    
                    <asp:TreeNode Text="Elenchi" Expanded="False" SelectAction="Expand">    
                        <asp:TreeNode Text="Elenco Viaggi" NavigateUrl="~/elencoViaggi.aspx" Expanded="False"> </asp:TreeNode>
                        <asp:TreeNode Text="Elenco Veicoli" NavigateUrl="~/elencoVeicoli.aspx"  Expanded="False"> 
                            <asp:TreeNode Text="Aggiungi Veicoli" NavigateUrl="~/aggiungiVeicolo.aspx" > </asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Text="Elenco Pacchi" NavigateUrl="~/elencoPacchi.aspx"  Expanded="False"> </asp:TreeNode>
                   </asp:TreeNode>    
                    <asp:TreeNode Text="Index" NavigateUrl="~/index.aspx"  Expanded="False">    
                        <asp:TreeNode Text="Tracciabilità" NavigateUrl="~/tracciabilità.aspx"  Expanded="False" />     
                    </asp:TreeNode>        
                 </Nodes>    
             </asp:TreeView>
        </div>
        <div class="contenuto">
            Nome: <asp:TextBox ID="tbNome" runat="server"></asp:TextBox><br />
            Cognome:<asp:TextBox ID="tbCognome" runat="server"></asp:TextBox><br />
            Indirizzo:<asp:TextBox ID="tbIndirizzo" runat="server"></asp:TextBox><br /><br />
            <asp:Button class="btn" ID="btnInserisciCliente" runat="server" Text="Inserisci il cliente" OnClick="InserisciCliente" />
            <asp:Button class="btn" ID="btnTornaPacchi" runat="server" Text="Torna all'inserimento dei pacchi" OnClick="TornaPacchi" />
            <br />
        </div>
    </form>
</body>
</html>
