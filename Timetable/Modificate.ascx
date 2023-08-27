<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Modificate.ascx.cs"  ClassName="Modificate" Inherits="Timetable.Modificate"%>

<div class="table">
        <div class="tableRow">
            <div class="inputText">
                <asp:Label ID="СlientNameLabel" runat="server" Text="Имя клиента:"></asp:Label>
            </div>
            <div class="inputField">
                <asp:TextBox ID="СlientNameTextBox" runat="server" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="СlientNameRequiredFieldValidator" ControlToValidate="СlientNameTextBox"
                    runat="server" ErrorMessage="Заполните имя клиента!" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>      

        <div class="tableRow">
            <div class="inputText">
                <asp:Label ID="DateLabel" runat="server" Text="Дата тренировки:"></asp:Label>
            </div>
            <div class="inputField">
                <asp:TextBox ID="DateTextBox" runat="server" placeholder="mm/dd/yyyy" Textmode="Date" ReadOnly = "false"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="DateRequiredFieldValidator" ControlToValidate="DateTextBox"
                    runat="server" ErrorMessage="Заполните дату тренировки!" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="tableRow">
            <div class="inputText">
                <asp:Label ID="TimeFromLabel" runat="server" Text="Время начала:"></asp:Label>
            </div>
            <div class="inputField">
                <asp:TextBox ID="TimeFromTextBox" runat="server" placeholder="hh:mm" Textmode="Time" ReadOnly = "false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="TimeFromRequiredFieldValidator" ControlToValidate="TimeFromTextBox"
                    runat="server" ErrorMessage="Заполните время начала!" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div> 

        <div class="tableRow">
            <div class="inputText">
                <asp:Label ID="TimeToLabel" runat="server" Text="Время окончания:"></asp:Label>
            </div>
            <div class="inputField">
                <asp:TextBox ID="TimeToTextBox" runat="server" placeholder="hh:mm" Textmode="Time" ReadOnly = "false"></asp:TextBox>
                <asp:RequiredFieldValidator ID="TimeToRequiredFieldValidator" ControlToValidate="TimeToTextBox"
                    runat="server" ErrorMessage="Заполните время окончания!" Text="*"></asp:RequiredFieldValidator>
            </div>
        </div> 

        <div class="tableRow">
            <div class="inputText">
                <asp:Label ID="CostLabel" runat="server" Text="Стоимость:"></asp:Label>
            </div>
            <div class="inputField">
                <asp:TextBox ID="CostTextBox" runat="server" MaxLength="10"></asp:TextBox>
                <asp:RequiredFieldValidator ID="CostRequiredFieldValidator" ControlToValidate="CostTextBox"
                    runat="server" ErrorMessage="Заполните стоимость тренировки!" Text="*"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="CostRangeValidator" ControlToValidate="CostTextBox"
                    runat="server" MinimumValue="0" MaximumValue="10000" ErrorMessage="Стоимость должна быть в диапазоне от 0 до 10000!"
                    Text="*" Type="Integer"></asp:RangeValidator>
            </div>
        </div>       
        
        <div class="tableRow">
            <div class="inputText">
                <asp:Label ID="PayMethodLabel" runat="server" Text="Способ оплаты:"></asp:Label>
            </div>
            <div class="inputField">
                <asp:RadioButton id="PayMethodCard" Text="Карта" GroupName="PayMethod" runat="server" /> 
                <asp:RadioButton id="PayMethodCash" Text="Наличные" GroupName="PayMethod"  runat="server" /><br />
            </div>
        </div>

        <div class="footer">
            <asp:ValidationSummary ID="TrainingValidationSummary" runat="server"></asp:ValidationSummary>
            <div>
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
            </div>
            <asp:Button ID="AddButton" runat="server" Text="Добавить" OnClick="AddButton_Click" />
            &nbsp;<asp:Button ID="CancelButton" runat="server" Text="Отмена" OnClick="CancelButton_Click"
                CausesValidation="false" />
        </div>
    </div>
