<%@ Page Title="Расписание тренировок" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Timetable._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Расписание занятий</h1>
        <p class="lead">Сайт для просмотра и редактирования расписания занятий.</p>
        <p><a runat="server" href="~/List" class="btn btn-primary btn-lg">Перейти к расписанию</a></p>
        <p><a runat="server" href="~/Add" class="btn btn-primary btn-lg">Добавить занятие</a></p>
    </div>

</asp:Content>
