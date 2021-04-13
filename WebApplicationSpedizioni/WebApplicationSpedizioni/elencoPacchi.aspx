<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="elencoPacchi.aspx.cs" Inherits="WebApplicationSpedizioni.elencoPacchi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="shortcut icon" href="img/icona.ico" />
<link href="App_Themes/css/style.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Elenco Pacchi</title>
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
        <div  class="contenuto">
            <h1>Elenco Pacchi</h1>
            Aggiungi un pacco: <br />
            Viaggio a cui assegnare il pacco: <asp:DropDownList ID="ddlViaggi" runat="server"></asp:DropDownList>
            <asp:Button class="btn" ID="btnAggiungiPacco" runat="server" Text="Aggiungi un pacco" OnClick="AggiungiPacco" /><br /><br />
            Mostra tutti i pacchi: <asp:Button class="btn" ID="btnTutti" runat="server" Text="Mostra" OnClick="FiltraTutti" /><br /> <br />
            Mostra pacchi non ancora consegnati: <asp:Button class="btn" ID="btnNoConsegnati" runat="server" Text="Mostra" OnClick="FiltraNonConsegnati" /><br /> <br />
            Mostra pacchi non programmati: <asp:Button class="btn" ID="btnNoProgrammati" runat="server" Text="Mostra" OnClick="FiltraNonProgrammati" />
            <asp:Button class="btn" ID="btnProgrammaPacco" runat="server" Text="Programma un pacco non ancora programmato" OnClick="ProgrammaPacco" /><br /> <br />
            Filtra per mittente: <asp:DropDownList ID="ddlMittente" runat="server"></asp:DropDownList>
            <asp:Button class="btn" ID="btFiltraMittente" runat="server" Text="Filtra mittente" OnClick="FiltraMittente" /><br /> <br />
            Filtra per destinatario:<asp:DropDownList ID="ddlDestinatario" runat="server"></asp:DropDownList>
            <asp:Button class="btn" ID="btFiltraDestinatario" runat="server" Text="Filtra destinatario" OnClick="FiltraDestinatario" /><br /> <br />
            Filtra per Volume: <asp:TextBox ID="tbFiltraVolume" runat="server"></asp:TextBox>
            <asp:Button class="btn" ID="btFiltraVolume" runat="server" Text="Filtra Volume" OnClick="FiltraVolume" /><br /><br />
            Filtra per Data: <asp:Calendar ID="clnData" runat="server" OnSelectionChanged="FiltraData" SelectionMode="DayWeekMonth" BackColor="white" BorderStyle="Groove"></asp:Calendar><br />
            <asp:GridView ID="gvPacchi" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False" BorderStyle="Double">
                <Columns>
                    <asp:BoundField DataField="IdPacco" HeaderText="Id Pacco" />
                    <asp:BoundField DataField="IdViaggio" HeaderText="Viaggio" />
                    <asp:BoundField DataField="NOrdineConsegna" HeaderText="Priorità" />
                    <asp:BoundField DataField="Volume" HeaderText="Volume Pacco" />
                    <asp:BoundField DataField="NomeCompletoMittente" HeaderText="Mittente" />
                    <asp:BoundField DataField="NomeCompletoDestinatario" HeaderText="Destinatario" />
                    <asp:BoundField DataField="Data" HeaderText="Data di consegna prevista" />
                </Columns>
            </asp:GridView><br />
        </div>
    </form>
</body>
</html>
