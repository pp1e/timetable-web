using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trainings;

namespace Timetable
{
    public partial class Add : Page
    {
        private Training currentTraining = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomerInsertButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            //currentTraining.CreatedBy = Context.User.Identity.Name;
        }

        protected void CustomerCancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        private void instantiateCustomerObject()
        {
            /*
            if (!this.IsPostBack)
                currentTraining = new CustomerManagementEntities.Customer();
            else
                currentTraining = new CustomerManagementEntities.Customer(
                    null, CustomerFirstNameTextBox.Text, CustomerLastNameTextBox.Text,
                    CustomerAddressTextBox.Text, CustomerZipCodeTextBox.Text,
                    CustomerCityTextBox.Text, CustomerStateTextBox.Text,
                    null, CustomerPhoneTextBox.Text, CustomerEmailAddressTextBox.Text,
                    CustomerWebAddressTextBox.Text, -1, CustomerNewsSubscriberCheckBox.Checked,
                    DateTime.Now, "", null, "");*/
        }
    }
}