<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="Lab25_First_Website.HelloWorld" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Hello World</h1>

    <ul>
        <li>One</li>
        <li>Two</li>

    </ul>
    <asp:Label ID="Label1" runat="server">This is a label</asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"> This is a Textbox</asp:TextBox>
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
    <asp:CheckBox ID="CheckBox1" runat="server" />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Click me"/>

    <form method="get">
        First Name <input type="text" placeholder="Type name here" name="firstname"/>
        <button type="submit" onclick="eventPreventDefault()" >Submit</button>
    </form>
</asp:Content>
