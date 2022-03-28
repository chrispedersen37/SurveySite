using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SurveySite
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void btnAcademicSurvey_Click(object sender, EventArgs e)
        {
            this.Hide();
            var academicSurvey = new AcademicSurveyPage();
            academicSurvey.Closed += (s, args) => this.Close();
            academicSurvey.Show();
        }

        private void btnExCurSurvey_Click(object sender, EventArgs e)
        {
            this.Hide();
            var excurSurvey = new ExCurSurveyPage();
            excurSurvey.Closed += (s, args) => this.Close();
            excurSurvey.Show();

        }

        private void btnFinancialSurvey_Click(object sender, EventArgs e)
        {
            this.Hide();
            var financialSurvey = new FinancialSurveyPage();
            financialSurvey.Closed += (s, args) => this.Close();
            financialSurvey.Show();
        }

        private void btnAcademicQuery_Click(object sender, EventArgs e)
        {
            this.Hide();
            var academicQuery = new AcademicQueryPage();
            academicQuery.Closed += (s, args) => this.Close();
            academicQuery.Show();
        }

        private void btnExCurQuery_Click(object sender, EventArgs e)
        {
            this.Hide();
            var exCurQuery = new ExCurQueryPage();
            exCurQuery.Closed += (s, args) => this.Close();
            exCurQuery.Show();
        }

        private void btnFinancialQuery_Click(object sender, EventArgs e)
        {
            this.Hide();
            var financialQuery = new FinancialQueryPage();
            financialQuery.Closed += (s, args) => this.Close();
            financialQuery.Show();
        }

        private void openWindow()
        {

        }
    }
}
