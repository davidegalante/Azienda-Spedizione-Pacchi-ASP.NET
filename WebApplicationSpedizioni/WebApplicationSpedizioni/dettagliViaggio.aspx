<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dettagliViaggio.aspx.cs" Inherits="WebApplicationSpedizioni.dettagliViaggio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="shortcut icon" href="img/icona.ico" />
<link href="App_Themes/css/style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Dettagli Viaggio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div  class="menu" >
            <asp:TreeView runat="server" ID="twMenu" NodeStyle-CssClass="treeNode"
            RootNodeStyle-CssClass="rootNode"
            LeafNodeStyle-CssClass="leafNode" 
            NodeStyle-NodeSpacing="3px">    
                 <Nodes>    
                   <asp:TreeNode Text="Home" NavigateUrl="~/home.aspx" Expanded="False"/>    
                    <asp:TreeNode Text="Elenchi" Expanded="True" SelectAction="Expand">    
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
        <div class="contenuto" >
            
            <asp:GridView ID="gvPacchi" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="IdPacco" HeaderText="Id Pacco" />
                    <asp:BoundField DataField="NOrdineConsegna" HeaderText="Priorità" />
                    <asp:BoundField DataField="Volume" HeaderText="Volume Pacco" />
                    <asp:BoundField DataField="NomeCompletoMittente" HeaderText="Mittente" />
                    <asp:BoundField DataField="NomeCompletoDestinatario" HeaderText="Destinatario" />
                    <asp:BoundField DataField="Orario" HeaderText="Orario Consegna Pacco" />
                </Columns>
            </asp:GridView><br />

            <asp:Button class="btn" ID="btnAggiungiPacco" runat="server" Text="Aggiungi un pacco" OnClick="AggiungiPacco" />
            <asp:Button class="btn" ID="btnTornaElencoViaggi" runat="server" Text="Torna all'elenco dei viaggi" OnClick="TornaElencoViaggi" />

        </div>
    </form>
</body>
</html>
