<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="elencoVeicoli.aspx.cs" Inherits="WebApplicationSpedizioni.elencoVeicoli" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="shortcut icon" href="img/icona.ico" />
<link href="App_Themes/css/style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Elenco Veicoli</title>
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
            <h1>Elenco Veicoli</h1>
             <asp:GridView ID="gvVeicolo" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows"  AutoGenerateColumns="False" BorderStyle="Double">
                <Columns>
                    <asp:BoundField DataField="Targa" HeaderText="Targa veicolo" />
                    <asp:BoundField DataField="Marca" HeaderText="Marca veicolo" />
                    <asp:BoundField DataField="Modello" HeaderText="Modello veicolo" />
                    <asp:BoundField DataField="CapacitaMax" HeaderText="Capacità massima" />
                    <asp:BoundField DataField="PesoMax" HeaderText="Peso massimo" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button class="btn" ID="btnAggiungiVeicolo" runat="server" Text="Aggiungi un nuovo veicolo" OnClick="AggiungiVeicolo" />
             <br /><br />
           <img src="img/viaggi.jpg" width="500"/>
        </div>
    </form>
</body>
</html>
