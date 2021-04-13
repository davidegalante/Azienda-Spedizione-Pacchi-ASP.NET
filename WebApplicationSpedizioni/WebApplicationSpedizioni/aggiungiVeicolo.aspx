<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aggiungiVeicolo.aspx.cs" Inherits="WebApplicationSpedizioni.aggiungiVeicolo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="shortcut icon" href="img/icona.ico" />
<link href="App_Themes/css/style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aggiungi Veicolo</title>
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
                    <asp:TreeNode Text="Elenchi" Expanded="True" SelectAction="Expand">    
                        <asp:TreeNode Text="Elenco Viaggi" NavigateUrl="~/elencoViaggi.aspx" Expanded="False"> </asp:TreeNode>
                        <asp:TreeNode Text="Elenco Veicoli" NavigateUrl="~/elencoVeicoli.aspx"  Expanded="True"> 
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
            Targa: <asp:TextBox ID="tbTarga" runat="server"></asp:TextBox><br />
            Marca: <asp:TextBox ID="tbMarca" runat="server"></asp:TextBox><br />
            Modello: <asp:TextBox ID="tbModello" runat="server"></asp:TextBox><br />
            Capacità Massima: <asp:TextBox ID="tbCapacitaMax" runat="server"></asp:TextBox><br />
            Peso Massimo: <asp:TextBox ID="tbPesoMax" runat="server"></asp:TextBox><br /><br />
            <asp:Button  class="btn" ID="btnInserisciVeicolo" runat="server" Text="Inserisci il veicolo" OnClick="InserisciVeicolo" />
            <asp:Button class="btn" ID="btnTornaVeicoli" runat="server" Text="Torna ai veicoli" OnClick="TornaVeicoli" />
        </div>
    </form>
</body>
</html>
