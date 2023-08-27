<%@ Page Title="Изменить объявление" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Timetable.Edit" %>

<%@ Register src="Modificate.ascx" tagname="Modificate" tagprefix="uc" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="table">
        <h1><%: Title %></h1>
        <uc:Modificate ID="EditForm" runat="server" />
    </div>
    
</asp:Content>
