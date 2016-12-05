<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamList.aspx.cs" Inherits="TeamsApplication.TeamList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
    <div id="divTeamList" runat="server" visible="true">
    <h2>Teams</h2>
    <asp:ListBox ID="listTeam" runat="server" Height="168px" Width="490px" />
    <br />
    <br />
    <asp:Button ID="buttonDeleteTeam" Text="Delete selected Team" runat="server" OnClick="buttonDeleteTeam_Click" /><br />
    <asp:Button ID="buttonAddTeam" Text="Add a new Team" runat="server" OnClick="buttonAddTeam_Click" />
    </div>
    <div id="divAddTeam" runat="server" visible="false">
        Team Name: <asp:TextBox ID="textTeamName" runat="server" /> <br />
        City: <asp:TextBox ID="textCity" runat="server" /> <br />
        Stadium Name: <asp:TextBox ID="textStadiumName" runat="server" /> <br />
        Capacity: <asp:TextBox ID="textCapacity" runat="server" /> <br />
        Phone: <asp:TextBox ID="textPhone" runat="server" /> <br />
        Email: <asp:TextBox ID="textEmail" runat="server" /> <br />
        <br />
        <asp:Button ID="buttonDoAdd" runat="server" Text="Add the new Team" OnClick="buttonDoAdd_Click" />
    </div>
    </center>
    </form>
</body>
</html>
