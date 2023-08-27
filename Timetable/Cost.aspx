<%@ Page Title="Стоимость занятий" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cost.aspx.cs" Inherits="Timetable.Cost" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="table"> 
        <h1><%: Title %></h1>

        <div class="tableRow">
            <asp:ListBox ID="ClientsBox" runat="server" Height="123px" Width="199px" OnLoad="ClientsBox_Load"></asp:ListBox>
         </div>
        <div>
             <asp:Label ID="CostLabel" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="CostButton" runat="server" Text="Стоимость всех занятий" OnClick="CostButton_Click" />
        </div>

     </div>
</asp:Content>
