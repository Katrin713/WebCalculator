<%@ Page Title="Калькулятор" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebCalclator.Calculator"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="css/Calculator.css" type="text/css" rel="Stylesheet" />
    <table class ="myTable">
        <tr>
            <td>
                <asp:Button class="allButtons cleanButton" ID="ButtonClean" runat="server" Text="C" OnClick="clean_Click"/>
            </td>
            <td colspan ="3">
                <asp:TextBox class="resBox" ID="ResultBox" runat="server" ReadOnly="true"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button class ="allButtons digitButton" ID="Button7" runat="server" Text="7" OnClick="button_Click"/>
            </td>
            <td>
                <asp:Button class ="allButtons digitButton" ID="Button8" runat="server" Text="8" OnClick="button_Click"/>
            </td>
            <td>
                <asp:Button class ="allButtons digitButton" ID="Button9" runat="server" Text="9" OnClick="button_Click"/>
            </td>
            <td> 
                <asp:Button class ="allButtons operationButton" ID="ButtonPlus" runat="server" Text="+" OnClick="button_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button class ="allButtons digitButton" ID="Button4" runat="server" Text="4" OnClick="button_Click"/>
            </td>
            <td>
                <asp:Button class ="allButtons digitButton" ID="Button5" runat="server" Text="5" OnClick="button_Click"/>
            </td>
            <td> 
                <asp:Button class ="allButtons digitButton" ID="Button6" runat="server" Text="6" OnClick="button_Click"/>
            </td>
            <td> 
                <asp:Button class ="allButtons operationButton" ID="ButtonMinus" runat="server" Text="-" OnClick="button_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button class ="allButtons digitButton" ID="Button1" runat="server" Text="1" OnClick="button_Click"/>
            </td>
            <td>
                <asp:Button class ="allButtons digitButton" ID="Button2" runat="server" Text="2" OnClick="button_Click"/>
            </td>
            <td>
                <asp:Button class ="allButtons digitButton" ID="Button3" runat="server" Text="3" OnClick="button_Click"/>
            </td>
            <td>
                <asp:Button class ="allButtons operationButton" ID="ButtonDivide" runat="server" Text="/" OnClick="button_Click"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button class ="allButtons digitButton" ID="ButtonSem" runat="server" Text="," OnClick="button_Click"/>
            </td>
            <td> 
                <asp:Button class ="allButtons digitButton" ID="Button0" runat="server" Text="0" OnClick="button_Click"/>
            </td>
            <td> 
                <asp:Button class ="allButtons resultButton" ID="ButtonResult" runat="server" Text="=" OnClick="result_Click"/>
            </td>
            <td> 
                <asp:Button class ="allButtons operationButton" ID="ButtonMult" runat="server" Text="*" OnClick="button_Click"/>
            </td>
        </tr>
        <tr>
            <td colspan ="4">
                <asp:Label ID="ErrorLabel1" runat="server" BackColor="White" ForeColor="Red"/>
        </tr>
    </table>
</asp:Content>
