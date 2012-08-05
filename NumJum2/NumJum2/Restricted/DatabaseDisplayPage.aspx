<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatabaseDisplayPage.aspx.cs" Inherits="NumJum2.Restricted.DatabaseDisplayPage" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
	protected void Page_Load(Object sender, EventArgs e) {
		SqlConnection con = null;
		SqlCommand cmd = null;
		
		try {
            con = GetConnection();
            cmd = new SqlCommand("SELECT PlayerName, GameStatus, NumScores FROM PlayerDbs", con);
			
			con.Open();
			grid.DataSource = cmd.ExecuteReader();
			grid.DataBind();

		} catch (Exception err) {
			message.Text = "<p><font color=\"red\">Err: " + 
				err.Message + "</font></p>";
		} finally {
			if(con != null)
				con.Close();
		}
	}
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>Contents of Player Database</title>
</head>
<body>
    <form id="DisplayDatabase" runat="server">
    <center><h1>Current Players In Player Database</h1></center>
    <center><div>
    <asp:datagrid ID="grid" runat="server"/>
	<asp:label ID="message" runat="server"/>
    </div></center>
    <center><div>
     <asp:Button ID="ReturnButton" runat="server" Text="Return" onclick="ReturnButton_Click"/>
    </div></center>
    </form>
</body>
</html>
