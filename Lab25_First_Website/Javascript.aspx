<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Javascript.aspx.cs" Inherits="Lab25_First_Website.Javascript" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">





    <script>

        var x = 0;
        
        function runSomeTestData()
        {
            alert('The value of x is: ' + x);
            var geek = confirm('are you a computer geek?');
            var SSN = prompt('Ok fine, Just gimmie your social security number');
            if (geek) {
                alert('Thanks for the SSN:' + SSN + " Geek");
            }
            else {
                alert('I have your SSN:' + SSN + "Geek")
            }
            console.log(geek);
            console.log(SSN);
        }

    </script>

    <button onclick="runSomeTestData()">Run some test data</button>
    <div id="test-data">

    </div>

</asp:Content>
