<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tracciabilità.aspx.cs" Inherits="WebApplicationSpedizioni.tracciabilità" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="shortcut icon" href="img/icona.ico" />
<link href="App_Themes/css/style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Traccia Pacco</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="menu">
            <asp:TreeView runat="server" ID="twMenu" NodeStyle-CssClass="treeNode"
            RootNodeStyle-CssClass="rootNode"
            LeafNodeStyle-CssClass="leafNode" 
            NodeStyle-NodeSpacing="3px">    
                 <Nodes>    
                    <asp:TreeNode Text="Index" NavigateUrl="~/index.aspx"  Expanded="True">    
                        <asp:TreeNode Text="Tracciabilità" NavigateUrl="~/tracciabilità.aspx"  Expanded="True" />     
                    </asp:TreeNode>        
                 </Nodes>    
             </asp:TreeView>
        </div>
        <div  class="contenuto">
            <img src="img/tracking.png" /><br />
            idPacco: <asp:TextBox ID="tbIdPacco" runat="server"></asp:TextBox><br />
            
            <asp:GridView ID="gvPacchi" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="IdPacco" HeaderText="Id Pacco" />
                    <asp:BoundField DataField="NOrdineConsegna" HeaderText="Numero Ordine" />
                    <asp:BoundField DataField="Volume" HeaderText="Volume Pacco" />
                    <asp:BoundField DataField="NomeCompletoMittente" HeaderText="Mittente" />
                    <asp:BoundField DataField="NomeCompletoDestinatario" HeaderText="Destinatario" />
                    <asp:BoundField DataField="Data" HeaderText="Data Consegna" />
                </Columns>
            </asp:GridView><br />
            <asp:Button class="btn" ID="btnTraccia" runat="server" Text="Traccia" onclick="Traccia"/>
            <asp:Button class="btn" ID="btnIndex" runat="server" Text="Torna alla pagina iniziale" onclick="PaginaIniziale"/>
             
        </div>
    </form>
</body>
</html>
