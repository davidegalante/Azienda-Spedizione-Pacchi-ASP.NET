<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="elencoViaggi.aspx.cs" Inherits="WebApplicationSpedizioni.elencoViaggi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="shortcut icon" href="img/icona.ico" />
<link href="App_Themes/css/style.css" rel="stylesheet" type="text/css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Elenco Viaggi</title>
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
                   <asp:TreeNode Text="Home" NavigateUrl="~/home.aspx" Expanded="True"/>    
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

<NodeStyle NodeSpacing="3px" CssClass="treeNode"></NodeStyle>

<RootNodeStyle CssClass="rootNode"></RootNodeStyle>
             </asp:TreeView>
        </div>
        <div class="contenuto">
            <h1>Elenco Viaggi</h1>
            <asp:GridView ID="gvViaggi" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False" BorderStyle="Double">
                <Columns>
                    <asp:BoundField DataField="Data" HeaderText="Data Inizio Viaggio" />
                    <asp:BoundField DataField="NomeCorriere" HeaderText="Nome del corriere" />
                    <asp:BoundField DataField="Targa" HeaderText="Targa del veicolo" />
                    <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <a href='dettagliViaggio.aspx?idViaggio=<%#Eval("idViaggio")%>'> Dettagli del viaggio </a>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView><br />
            <img src="img/veicolo.png" />
            <img src="img/veicolo.png" />
            <img src="img/veicolo.png" />
            <img src="img/veicolo.png" />
            <img src="img/veicolo.png" />
        </div>
    </form>
</body>
</html>
