using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Trainings;

namespace Timetable
{
    public partial class List : System.Web.UI.Page
    {
        TimetableDatabase database = new TimetableDatabase();

        protected void Page_Load(object sender, EventArgs e)
        {         
            TrainingGrid.DataSource = database.Trainings;
            TrainingGrid.DataBind();
        }

        protected void TrainigsList_Load(object sender, EventArgs e)
        {

        }

        protected void TrainingGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            database.deleteTraining((int) e.Keys["ID"]);

            TrainingGrid.DataSource = database.Trainings;
            TrainingGrid.DataBind();
        }


        protected void TrainingGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Edit.aspx?id=" + TrainingGrid.SelectedDataKey.Value.ToString());
        }
    }
}