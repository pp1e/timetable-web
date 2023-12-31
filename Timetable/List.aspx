﻿<%@ Page Title="Расписание" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Timetable.List" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="table">
        <h1><%: Title %></h1>
        <asp:GridView ID="TrainingGrid" AutoGenerateColumns="false" runat="server" CssClass="mydatagrid"
            PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" DataKeyNames="ID"
            AllowPaging="True" AutoGenerateSelectButton="True" AutoGenerateDeleteButton="True" OnRowDeleting="TrainingGrid_RowDeleting" OnSelectedIndexChanged="TrainingGrid_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField DataField="TableDayOfWeek" HeaderText="День недели" />
                    <asp:BoundField DataField="TableTime" HeaderText="Дата и время" />
                    <asp:BoundField DataField="ClientName" HeaderText="Имя клиента" />
                    <asp:BoundField DataField="Price" HeaderText="Цена" />
                    <asp:BoundField DataField="TablePayMethod" HeaderText="Способ оплаты" />               
            </Columns>
            </asp:GridView>
    </div>
</asp:Content>
