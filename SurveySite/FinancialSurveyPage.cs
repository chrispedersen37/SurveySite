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
    public partial class FinancialSurveyPage : Form
    {
        private bool isEditMode;
        private FinancialQueryPage _financialQueryPage;
        private readonly SurveySiteEntities _db;
        public FinancialSurveyPage(FinancialQueryPage financial_Query_Page = null)
        {
            InitializeComponent();
            lblTitle.Text = "Financial Survey";
            isEditMode = false;
            _db = new SurveySiteEntities();
            _financialQueryPage = financial_Query_Page;
            loadBoxes();
        }

        public FinancialSurveyPage(FinancialSurvey entryToEdit, FinancialQueryPage financial_Query_Page = null)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Survey Entry";
            if (entryToEdit == null)
            {
                MessageBox.Show("please ensure you select a valid survey entry");
                Close();
            }
            else
            {
                isEditMode = true;
                _financialQueryPage = financial_Query_Page;
                _db = new SurveySiteEntities();
                loadBoxes();
                PopulateFields(entryToEdit);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (isEditMode == true)
            {
                this.Hide();
                var queryPage = new FinancialQueryPage();
                queryPage.Closed += (s, args) => this.Close();
                queryPage.Show();
            }
            else
            {
                this.Hide();
                var homePage = new HomePage();
                homePage.Closed += (s, args) => this.Close();
                homePage.Show();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var name = tbName.Text;
                var q1 = (int)cbQuestion1.SelectedValue;
                var q2 = (int)cbQuestion2.SelectedValue;
                var q3 = (int)cbQuestion3.SelectedValue;
                var q4 = (int)cbQuestion4.SelectedValue;
                var q5 = (int)cbQuestion5.SelectedValue;
                var q6 = (int)cbQuestion6.SelectedValue;
                var q7 = (int)cbQuestion7.SelectedValue;
                var q8 = (int)cbQuestion8.SelectedValue;
                var q9 = (int)cbQuestion9.SelectedValue;
                var q10 = (int)cbQuestion10.SelectedValue;

                if (isEditMode)
                {
                    var id = int.Parse(lblTitle.Text);
                    var entry = _db.FinancialSurveys.FirstOrDefault(x => x.id == id);
                    entry.name = tbName.Text;
                    entry.Q1Answer = q1;
                    entry.Q2Answer = q2;
                    entry.Q3Answer = q3;
                    entry.Q4Answer = q4;
                    entry.Q5Answer = q5;
                    entry.Q6Answer = q6;
                    entry.Q7Answer = q7;
                    entry.Q8Answer = q8;
                    entry.Q9Answer = q9;
                    entry.Q10Answer = q10;

                    MessageBox.Show("Survey entry has been changed");
                }
                else
                {
                    var survey = new FinancialSurvey
                    {
                        name = name,
                        Q1Answer = q1,
                        Q2Answer = q2,
                        Q3Answer = q3,
                        Q4Answer = q4,
                        Q5Answer = q5,
                        Q6Answer = q6,
                        Q7Answer = q7,
                        Q8Answer = q8,
                        Q9Answer = q9,
                        Q10Answer = q10
                    };
                    _db.FinancialSurveys.Add(survey);
                    MessageBox.Show("Thank you for completing the Financial Survey!");
                }
                _db.SaveChanges();

                if (isEditMode == false)
                {
                    this.Hide();
                    var homePage = new HomePage();
                    homePage.Closed += (s, args) => this.Close();
                    homePage.Show();
                }
                else
                {
                    this.Hide();
                    var queryPage = new FinancialQueryPage();
                    queryPage.Closed += (s, args) => this.Close();
                    queryPage.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"AN ERROR HAS OCCURED, PLEASE TRY AGAIN: {ex.Message}");
            }
        }

        private void PopulateFields(FinancialSurvey entry)
        {
            lblTitle.Text = entry.id.ToString();
            tbName.Text = entry.name;
            cbQuestion1.SelectedValue = entry.Q1Answer;
            cbQuestion2.SelectedValue = entry.Q2Answer;
            cbQuestion3.SelectedValue = entry.Q3Answer;
            cbQuestion4.SelectedValue = entry.Q4Answer;
            cbQuestion5.SelectedValue = entry.Q5Answer;
            cbQuestion6.SelectedValue = entry.Q6Answer;
            cbQuestion7.SelectedValue = entry.Q7Answer;
            cbQuestion8.SelectedValue = entry.Q8Answer;
            cbQuestion9.SelectedValue = entry.Q9Answer;
            cbQuestion10.SelectedValue = entry.Q10Answer;

        }

        private void loadBoxes()
        {
            var answer1 = _db.Answers.ToList();
            var answer2 = _db.Answers.ToList();
            var answer3 = _db.Answers.ToList();
            var answer4 = _db.Answers.ToList();
            var answer5 = _db.Answers.ToList();
            var answer6 = _db.Answers.ToList();
            var answer7 = _db.Answers.ToList();
            var answer8 = _db.Answers.ToList();
            var answer9 = _db.Answers.ToList();
            var answer10 = _db.Answers.ToList();
            cbQuestion1.DataSource = answer1;
            cbQuestion1.ValueMember = "id";
            cbQuestion1.DisplayMember = "answer1";

            cbQuestion2.DataSource = answer2;
            cbQuestion2.ValueMember = "id";
            cbQuestion2.DisplayMember = "answer1";

            cbQuestion3.DataSource = answer3;
            cbQuestion3.ValueMember = "id";
            cbQuestion3.DisplayMember = "answer1";

            cbQuestion4.DataSource = answer4;
            cbQuestion4.ValueMember = "id";
            cbQuestion4.DisplayMember = "answer1";

            cbQuestion5.DataSource = answer5;
            cbQuestion5.ValueMember = "id";
            cbQuestion5.DisplayMember = "answer1";

            cbQuestion6.DataSource = answer6;
            cbQuestion6.ValueMember = "id";
            cbQuestion6.DisplayMember = "answer1";

            cbQuestion7.DataSource = answer7;
            cbQuestion7.ValueMember = "id";
            cbQuestion7.DisplayMember = "answer1";

            cbQuestion8.DataSource = answer8;
            cbQuestion8.ValueMember = "id";
            cbQuestion8.DisplayMember = "answer1";

            cbQuestion9.DataSource = answer9;
            cbQuestion9.ValueMember = "id";
            cbQuestion9.DisplayMember = "answer1";

            cbQuestion10.DataSource = answer10;
            cbQuestion10.ValueMember = "id";
            cbQuestion10.DisplayMember = "answer1";
        }
    }
}
