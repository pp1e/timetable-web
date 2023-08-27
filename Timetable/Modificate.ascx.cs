using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trainings;
using System.Runtime.InteropServices;

namespace Timetable
{
    public partial class Modificate : System.Web.UI.UserControl
    {
        TimetableDatabase database = new TimetableDatabase();
        private Training currentTraining = null;
        string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();

                if (!Page.IsValid)
                    return;
            }

            id = Request.QueryString["id"];
            if (id != null)
                AddButton.Text = "Изменить";
            fillTrainig();
            populateUI();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid || currentTraining == null)
                return;

            if (id != null)
            {
                currentTraining.ID = int.Parse(id);
                database.editTraining(currentTraining);
            }
            else
                database.addTraining(currentTraining);

            Response.Redirect("~/List.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/List.aspx");
        }

        private void fillTrainig()
        {
            if (!this.IsPostBack)
                if (id != null)
                    currentTraining = database.getTraining(int.Parse(id));
                else
                    currentTraining = new Training();
            else {
                PayMethod payMethod;
                if (PayMethodCard.Checked)
                    payMethod = PayMethod.Card;
                else
                    payMethod = PayMethod.Cash;
                DateTime timeFrom = DateTime.Parse(DateTextBox.Text + " " + TimeFromTextBox.Text);
                DateTime timeTo = DateTime.Parse(DateTextBox.Text + " " + TimeToTextBox.Text);

                try
                {
                    currentTraining = new Training(
                        -1,
                        СlientNameTextBox.Text,
                        payMethod,
                        timeFrom,
                        timeTo,
                        int.Parse(CostTextBox.Text)
                        );
                }catch (FormatException e)
                {
                    ErrorLabel.Text = e.Message;
                }
            }
        }

        private void populateUI()
        {
            if (currentTraining != null)
            {
                СlientNameTextBox.Text = currentTraining.ClientName;
                DateTextBox.Text = currentTraining.TimeFrom.ToString();
                TimeFromTextBox.Text = currentTraining.TimeFrom.TimeOfDay.ToString();
                TimeToTextBox.Text = currentTraining.TimeTo.TimeOfDay.ToString();
                if (currentTraining.PayMethod == PayMethod.Card)
                    PayMethodCard.Checked = true;
                else
                    PayMethodCash.Checked = true;
                CostTextBox.Text = currentTraining.Price.ToString();
            }
        }
    }
}