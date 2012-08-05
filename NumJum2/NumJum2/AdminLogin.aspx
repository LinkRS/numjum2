<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="NumJum2.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login</title>
</head>
<body>
    <form id="LoginForm" runat="server">
    <center><div>
    
        <h2>
            NumJum 2.0 Database Display Log In
        </h2>
        <p>
            Please enter your username and password.
            Contact Website Administrator if you don't have one.
        </p>
        <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
            <LayoutTemplate>
                <span class="failureNotification">
                    <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                </span>
                <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" ValidationGroup="LoginUserValidationGroup"/>
                <br />
                <div class="accountInfo">
                    <fieldset class="login">
                        <legend>Account Information</legend>
                        <p>
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                 ErrorMessage="User Name is required." ToolTip="User Name is required." 
                                 ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                        <p>
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                 ErrorMessage="Password is required." ToolTip="Password is required." 
                                 ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                        </p>
                    </fieldset>
                    <p class="submitButton">
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                            ValidationGroup="LoginUserValidationGroup" onclick="LoginButton_Click"/>
                    </p>
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div></center>
    <center><div>
    <p>
    <asp:Label ID="FeedbackLabel" runat="server" Text=""></asp:Label>
    </p></div></center>
    </form>
</body>
</html>
