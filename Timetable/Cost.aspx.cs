using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trainings;

namespace Timetable
{
    public partial class Cost : Page
    {
        TimetableDatabase database = new TimetableDatabase();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CostButton_Click(object sender, EventArgs e)
        {
            CostLabel.Text = database[ClientsBox.Text].ToString();
        }

        protected void ClientsBox_Load(object sender, EventArgs e)
        {
            if (ClientsBox.Items.Count == 0)
                foreach (string client in database.Clients)
                    ClientsBox.Items.Add(client);
        }
    }
}