<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NumJum2.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NumJum 2 (2 Aug 2012)</title>
</head>
<body style="background-color: Silver;">
    <form id="MainForm" runat="server">

    <%-- Menu for Game Functions --%>
    <div>
        <asp:Menu ID="GameMenu" runat="server" OnMenuItemClick="GameMenu_MenuItemClick" 
            Orientation="Horizontal" ClientIDMode="Static" BackColor="#F7F6F3" 
            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
            ForeColor="#7C6F57" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#F7F6F3" />
            <DynamicSelectedStyle BackColor="#5D7B9D" />
        <Items>
            <asp:MenuItem Text="Load Player" Value="LoadMenu" ToolTip="Load or Create New Player"></asp:MenuItem>
            <asp:MenuItem Text="Save Player" Value="SaveMenu" ToolTip="Save Current Player"></asp:MenuItem>
            <asp:MenuItem Text="Start Game" Value="StartGameMenu" ToolTip="Start Game"></asp:MenuItem>
        
        </Items>
        
            <StaticHoverStyle BackColor="#7C6F57" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
        
        </asp:Menu>
    </div>

    <%-- Menu to simulate tab control --%>
    <div>
        <asp:Menu ID="MainView" runat="server" OnMenuItemClick="MainView_MenuItemClick" Orientation="Horizontal">
        
        <StaticMenuStyle HorizontalPadding="0px" VerticalPadding="0px" />
        <StaticSelectedStyle BackColor="Silver" BorderColor="White" />

        
        <Items>
            <asp:MenuItem Text="Play Field" Value="0" Selected="True" ToolTip="Show Main Game Screen"></asp:MenuItem>
            <asp:MenuItem Text="Scores" Value="1" ToolTip="Show the Scores Screen"></asp:MenuItem>
            <asp:MenuItem Text="About" Value="2" ToolTip="Learn about NumJum"></asp:MenuItem>
        </Items>

        <StaticHoverStyle BackColor="Yellow" />
        <StaticMenuItemStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
        </asp:Menu>
    </div>

    <%-- Begin simulated tabs using MultiView--%>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
        
            <div style="width: 922px; height: 436px" title="MainView">
    
            <asp:Label ID="PlayerNameLabel" runat="server" 
                style="z-index: 1; left: 10px; top: 60px; position: absolute" 
                Text="Player Name:" width="113px"></asp:Label>

            <asp:TextBox ID="PlayerNameTextBox" runat="server" ReadOnly="True" 
                style="z-index: 1; left: 150px; top: 60px; position: absolute"></asp:TextBox>

            <asp:Label ID="DifficultyLabel" runat="server" 
                style="z-index: 1; left: 10px; top: 98px; position: absolute" Text="Difficulty" 
                width="113px"></asp:Label>

            <asp:TextBox ID="DifficultyTextBox" runat="server" ReadOnly="True" 
                style="z-index: 1; left: 150px; top: 98px; position: absolute"></asp:TextBox>

            <asp:TextBox ID="NumDigitsTextBox" runat="server" ReadOnly="True" 
                style="z-index: 1; left: 150px; top: 134px; position: absolute"></asp:TextBox>
              
            <asp:Label ID="NumDigitsLabel" runat="server" 
                style="z-index: 1; left: 10px; top: 134px; position: absolute" 
                Text="# of Digits" width="113px"></asp:Label>

            <asp:Label ID="GuessListLabel" runat="server" 
                style="z-index: 1; left: 10px; top: 173px; position: absolute" 
                Text="Guess List" width="113px"></asp:Label>

            <asp:ListBox ID="GuessListBox" runat="server" 
                style="z-index: 1; left: 150px; top: 173px; position: absolute; width: 128px; height: 169px">
                </asp:ListBox>

            <asp:Label ID="NumCorrectDigitsLabel" runat="server" 
                style="z-index: 1; left: 17px; top: 365px; position: absolute" 
                Text="# of Correct Digits"></asp:Label>

            <asp:TextBox ID="NumCorrectDigitsTextBox" runat="server" ReadOnly="True" 
                style="z-index: 1; left: 150px; top: 365px; position: absolute"></asp:TextBox>

            <asp:Label ID="CurrentGuessLabel" runat="server" 
                style="z-index: 1; left: 17px; top: 403px; position: absolute" 
                Text="Current Guess"></asp:Label>

            <asp:TextBox ID="CurrentGuessTextBox" runat="server" ReadOnly="True" 
                style="z-index: 1; left: 150px; top: 403px; position: absolute"></asp:TextBox>

            <asp:Label ID="CurrentScoreLabel" runat="server" 
                style="z-index: 1; left: 390px; top: 323px; position: absolute" 
                Text="Current Score"></asp:Label>

            <asp:TextBox ID="CurrentScoreBox" runat="server" ReadOnly="True" 
                style="z-index: 1; left: 370px; top: 365px; position: absolute"></asp:TextBox>

            <asp:Button ID="OneButton" runat="server" 
                style="z-index: 1; left: 345px; top: 60px; position: absolute; width: 50px; height: 50px" 
                Text="1" onclick="OneButton_Click" />

             <asp:Button ID="TwoButton" runat="server" 
                style="z-index: 1; left: 405px; top: 60px; position: absolute; width: 50px; height: 50px; right: 709px" 
                Text="2" onclick="TwoButton_Click" />

            <asp:Button ID="ThreeButton" runat="server" 
                style="z-index: 1; left: 465px; top: 60px; position: absolute; width: 50px; height: 50px" 
                Text="3" onclick="ThreeButton_Click" />

            <asp:Button ID="FourButton" runat="server" 
                style="z-index: 1; left: 345px; top: 120px; position: absolute; width: 50px; height: 50px" 
                Text="4" onclick="FourButton_Click" />

            <asp:Button ID="FiveButton" runat="server" 
                style="z-index: 1; left: 405px; top: 120px; position: absolute; width: 50px; height: 50px" 
                Text="5" onclick="FiveButton_Click" />

            <asp:Button ID="SixButton" runat="server" 
                style="z-index: 1; left: 465px; top: 120px; position: absolute; width: 50px; height: 50px" 
                Text="6" onclick="SixButton_Click"/>

            <asp:Button ID="SevenButton" runat="server" 
                style="z-index: 1; left: 345px; top: 180px; position: absolute; width: 50px; height: 50px" 
                Text="7" onclick="SevenButton_Click" />

            <asp:Button ID="EightButton" runat="server" 
                style="z-index: 1; left: 405px; top: 180px; position: absolute; width: 50px; height: 50px" 
                Text="8" onclick="EightButton_Click" />

            <asp:Button ID="NineButton" runat="server" 
                style="z-index: 1; left: 465px; top: 180px; position: absolute; width: 50px; height: 50px" 
                Text="9" onclick="NineButton_Click" />

            <asp:Button ID="ZeroButton" runat="server" 
                style="z-index: 1; left: 405px; top: 238px; position: absolute; width: 50px; height: 50px" 
                Text="0" onclick="ZeroButton_Click" />

            <asp:Button ID="ResetButton" runat="server" 
                style="z-index: 1; left: 339px; top: 246px; position: absolute" Text="Reset" 
                width="56px" onclick="ResetButton_Click" />

            <asp:Button ID="GuessButton" runat="server" 
                style="z-index: 1; left: 465px; top: 246px; position: absolute" Text="Guess" />

            <%-- Hidden button for modal popup --%>
            <asp:Button ID="HiddenButton" runat="server" 
                style="display:none" 
                Text="Load Player" />
    
            <asp:Button ID="AddScoreButton" runat="server" 
                style="z-index: 1; left: 416px; top: 449px; position: absolute" 
                Text="Add Score" width="105px" onclick="AddScoreButton_Click"/>

            <asp:Label ID="OutputListBox" runat="server" 
                style="z-index: 1; left: 571px; top: 63px; position: absolute" 
                Text="Message Window" width="113px"></asp:Label>

            <asp:ListBox ID="FeedbackListBox" runat="server"
                style="z-index: 1; left: 565px; top: 84px; position: absolute; width: 313px; height: 331px">
                </asp:ListBox>

            </div>

            <%-- Script Manager and window for popups --%>
            <asp:ScriptManager ID="sc1" runat="server">
            </asp:ScriptManager>

            <ajaxToolkit:modalpopupextender ID="mpe" runat="server"
                TargetControlID = "HiddenButton"
                PopupControlID="ModalPanel"  
                CancelControlID="Cancel" 
                EnableViewState="true" 
                DropShadow="true" />

            <asp:Panel ID="ModalPanel" runat="server" 
                BackColor="White" BorderColor="Black" 
                BorderStyle="Groove" Width="450px" Height="150px">
            
                <div style="position: relative; top: 0px; left: 0px; height: 111px; width: 450px;" class="style1">
                <center>Enter Your Name</center>
                <br />
                <div>
                <asp:TextBox ID="EnteredNameTextBox" runat="server" 
                    style="left: 131px; top: 39px; position: absolute"></asp:TextBox>
                
                <asp:Label ID="PlayerLabel" runat="server" 
                    style="left: 6px; top: 39px; position: absolute" 
                    Text="Player Name"></asp:Label>
                
                <asp:Button ID="SubmitButton" runat="server" 
                    style="left: 95px; top: 109px; position: absolute" 
                    Text="Submit" onclick="SubmitButton_Click"/>
                
                <asp:Button ID="DeletePlayerButton" runat="server"
                    style="left: 195px; top: 109px; position: absolute"
                    Text="Delete" onclick="DeletePlayerButton_Click" />

                <asp:Button ID="Cancel" runat="server" 
                    style="left: 295px; top: 109px; position: absolute" 
                    Text="Cancel" onclick="SubmitButton_Click"/>
                </div>
                <br />
                <br />
                <center><b>NOTE: <i>If player does not exist, a new one will be created!</i></b></center>
                </div>                         
            </asp:Panel>
        </asp:View>
        
        <asp:View ID="View2" runat="server">
            <div style="width: 922px; height: 436px" title="ScoreView">
            <center><asp:Label ID="ScoreListLabel" runat="server" Text="Top Scores"></asp:Label></center>
            <center><asp:ListBox ID="ScoreListBox" runat="server"
                style="z-index: 1; position: relative; width: 313px; height: 331px">
            </asp:ListBox></center>
            </div>            
        </asp:View>

        <asp:View ID="View3" runat="server">
            <div style="width: 922px; height: 436px" title="MainView">
            <br/>
            <center><p>NumJum 2.01 (Build 2.01.045)
            <br />
            Build Date: 2 August 2012
            <br />
            <br />
            Written By: Rich Selmon
            <br />
            Wombat Computer Service
            <br />
            <a href="http://www.wombatcs.com">http://www.wombatcs.com</a>
            <br />
            <br />
            Copyright (C) 2102</p></center>
            </div>     
       </asp:View>

    </asp:MultiView>

    <div>
    </div>
    </form>
</body>
</html>
