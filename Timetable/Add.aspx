<%@ Page Title="Добавление занятия" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="Timetable.Add" %>

<%@ Register src="Modificate.ascx" tagname="Modificate" tagprefix="uc" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="table">
        <h1><%: Title %></h1>

        <uc:Modificate ID="AdditionForm" runat="server" />
    </div>
    
</asp:Content>
