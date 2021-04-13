<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aggiungiPacco.aspx.cs" Inherits="WebApplicationSpedizioni.aggiungiPacco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="shortcut icon" href="img/icona.ico" />
<link href="App_Themes/css/style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Aggiungi Pacco</title>
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
            Mittente: 
            <asp:DropDownList ID="ddlMittente" runat="server">
            </asp:DropDownList>
            <br />
            Destinatario: 
            <asp:DropDownList ID="ddlDestinatario" runat="server">
            </asp:DropDownList>
            <br />
            Volume: 
            <asp:TextBox ID="tbVolume" runat="server"></asp:TextBox><br />
            Numero Ordine Di Consegna: 
            <asp:TextBox ID="tbNumeroOrdineConsegna" runat="server"></asp:TextBox><br /><br />
            <asp:Button class="btn" ID="btnAggiungiPacco" runat="server" Text="Aggiungi il pacco" OnClick="AggiungiPacco" />
            <asp:Button class="btn" ID="btnAggiungiCliente" runat="server" Text="Aggiungi nuovo cliente" OnClick="AggiungiCliente" />
            <asp:Button class="btn" ID="btnTorna" runat="server" Text="Torna indietro" OnClick="TornaIndietro" />
            <br /><br />
            <asp:Label ID="lbError" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
