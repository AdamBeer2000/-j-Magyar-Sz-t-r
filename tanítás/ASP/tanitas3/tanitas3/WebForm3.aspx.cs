using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tanitas3
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        static string theam = "light";
        static int csapat_a;
        static int csapat_b;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null)
            {
                theam = Request.Cookies["User"]["Theam"].ToString();
            }
            update();
        }
        void update()
        {
            ChartPage.Attributes.Add("class", theam);
        }

        void refreshchart()
        {
            switch (DropDownList1.SelectedValue)
            {
                case "Pie": Chart1.Series["Csapatok"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie; break;
                case "Bar": Chart1.Series["Csapatok"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Bar; break;
                case "Doughnut": Chart1.Series["Csapatok"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Doughnut; break;
            }
            Chart1.Series["Csapatok"].Points.Clear();
            Chart1.Series["Csapatok"].Points.AddXY("A", csapat_a);
            Chart1.Series["Csapatok"].Points.AddXY("B", csapat_b);
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
            if(Chart1.Series.Count==0)
            {
                Chart1.Series.Add("Csapatok");
            }
            refreshchart();
        }

        protected void Send_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
                csapat_a += Convert.ToInt32(TextBox1.Text);
            if (TextBox2.Text != "")
                csapat_b += Convert.ToInt32(TextBox2.Text);

            TextBox1.Text = "";
            TextBox2.Text = "";

            refreshchart();
        }
    }
}