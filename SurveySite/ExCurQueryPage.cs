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
    public partial class ExCurQueryPage : Form
    {
        private readonly SurveySiteEntities _db;
        public ExCurQueryPage()
        {
            InitializeComponent();
            _db = new SurveySiteEntities();
        }

        private void ExCurQueryPage_Load(object sender, EventArgs e)
        {
            PopulateGrid();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var homePage = new HomePage();
            homePage.Closed += (s, args) => this.Close();
            homePage.Show();
        }

        private void btnEditEntry_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvExCurQuery.SelectedRows[0].Cells["id"].Value;
                var entry = _db.ExCurSurveys.FirstOrDefault(q => q.id == id);
                this.Hide();
                var addEditEntry = new ExCurSurveyPage(entry, this);
                addEditEntry.Closed += (s, args) => this.Close();
                addEditEntry.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"AN ERROR HAS OCCURED, PLEASE TRY AGAIN: {ex.Message}");
            }
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            try
            {
                var id = (int)gvExCurQuery.SelectedRows[0].Cells["id"].Value;
                var entry = _db.ExCurSurveys.FirstOrDefault(q => q.id == id);

                DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?", "Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.Yes)
                {
                    _db.ExCurSurveys.Remove(entry);
                    _db.SaveChanges();
                }
                PopulateGrid();

                gvExCurQuery.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"AN ERROR HAS OCCURED, PLEASE TRY AGAIN: {ex.Message}");
            }
        }

        public void PopulateGrid()
        {

            var entries = _db.ExCurSurveys
                .Select(q => new
                {
                    q.id,
                    Name = q.name,
                    Q1Answer = q.Q1Answer,
                    Q2Answer = q.Q2Answer,
                    Q3Answer = q.Q3Answer,
                    Q4Answer = q.Q4Answer,
                    Q5Answer = q.Q5Answer,
                    Q6Answer = q.Q6Answer,
                    Q7Answer = q.Q7Answer,
                    Q8Answer = q.Q8Answer,
                    Q9Answer = q.Q9Answer,
                    Q10Answer = q.Q10Answer,
                }).ToList();
            gvExCurQuery.DataSource = entries;
            gvExCurQuery.Columns[0].Visible = false;
        }
    }
}
