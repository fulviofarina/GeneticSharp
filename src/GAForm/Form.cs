using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GADB;

namespace GAForm
{
    public partial class Form : System.Windows.Forms.Form
    {
        /// <summary>
        /// A MOUSE EVENT ARGUMENT
        /// </summary>
        private static MouseEventArgs MOUSEVENT = new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0);

        /// <summary>
        /// A DATAGRID SELECTED ROW CALL
        /// </summary>
        private static DataGridViewCellMouseEventArgs DGVARGUMENTDUMMY = new DataGridViewCellMouseEventArgs(0, 0, 0, 0, MOUSEVENT);

        private IController IsampleControl = null;

        public Form()
        {
            InitializeComponent();

            this.resumebtn.Enabled = false;
            this.stopbtn.Enabled = false;
        }

        public void Go(object sender, EventArgs e)
        {
            this.Validate();

            GADataSet.ProblemsRow currentProblem = (this.problemsBS.Current as DataRowView).Row as GADataSet.ProblemsRow;

            int MINSIZE = 8; //dummy value
            int MAXSIZE = 16; //dummy value
            int ITERS = 5;
            //MIN SIZE OF CHROMOSOME TO ITERATE
            MINSIZE = currentProblem.MinSize;
            //MAX SIZE OF CHROMOSOME TO ITERATE
            MAXSIZE = currentProblem.MaxSize;
            ITERS = currentProblem.Iters;

            int ITERCOUNTER = 1;

            do
            {
                this.gobtn.Enabled = false;
                this.stopbtn.Enabled = true;

                Probabilities prob = setProbabilities();
                //genetic algorithRow
                GADataSet.GARow currentGARow = null;
                currentGARow = this.gADataSet.GA.NewGARow();
                this.gADataSet.GA.AddGARow(currentGARow);
                currentGARow.ProblemID = currentProblem.ProblemID;
                currentGARow.ChromosomeLength = MINSIZE;
                //create knapRow

                this.gATA.Update(this.gADataSet.GA);

                this.SolBS.Filter = this.gADataSet.Solutions.GAIDColumn
                    .ColumnName + "=" + currentGARow.ID;
                this.SolBS.Sort = this.gADataSet.Solutions.FitnessColumn
                    .ColumnName + " desc";

                ///CUT HERE
          // IsampleControl= new KnapController();

                IsampleControl = new ExamController();

                IsampleControl.SetControllerFor(ref currentProblem, MINSIZE);
                IsampleControl.Probabilities = prob;
                IsampleControl.ConfigGA();

                IsampleControl.CallBack = delegate
                {
                    Application.DoEvents();
                    this.toolStripProgressBar1.PerformStep();
                    GADB.GADataSetTableAdapters.GATableAdapter gata = new GADB.GADataSetTableAdapters.GATableAdapter();
                    gata.Update(this.gADataSet.GA);
                    gata.Dispose();
                    gata = null;
                    GADB.GADataSetTableAdapters.SolutionsTableAdapter solta = new GADB.GADataSetTableAdapters.SolutionsTableAdapter();
                    solta.Update(this.gADataSet.Solutions);
                    solta.Dispose();
                    solta = null;


                



                };

                IsampleControl.FinalCallBack = delegate 
                {
                    GADB.GADataSetTableAdapters.StringsTableAdapter sta = new GADB.GADataSetTableAdapters.StringsTableAdapter();
                    sta.Update(this.gADataSet.Strings);
                    sta.Dispose();
                    sta = null;

                    //    if (System.IO.File.Exists("DRONE.gif")) System.IO.File.Delete("DRONE.gif");

                   // picBox.Refresh();
                   // picBox.ImageLocation = "DRONE.gif";

                    dgvDoubleMouseclick(this.SolutionsDataGridView,new DataGridViewCellMouseEventArgs(0,0,0,0, MOUSEVENT));


                };

                IsampleControl.GARow = currentGARow;

                //no BKG worker for now...
                IsampleControl.PostScript(false);

                //ABORT IF STOPPED
                if (!stopbtn.Enabled) break;


                //UPDATE DATABASES

                IsampleControl.ConfigGA();

                GADataSet.SolutionsRow[] sols = currentGARow.GetSolutionsRows();
                //reset counters///
                foreach (GADataSet.SolutionsRow s in sols) s.Counter = 1;


                this.gobtn.Enabled = true;
                this.stopbtn.Enabled = false;

                if (ITERCOUNTER < ITERS)
                {
                    ITERCOUNTER++;
                }
                else
                {
                    ITERCOUNTER = 1;
                    MINSIZE++; //ADD SIZE OF CHROMOSOME NEXT GENETIC ALGORITHM
                }



            }
            while (MINSIZE <= MAXSIZE);

            



        }

        private Probabilities setProbabilities()
        {
            int MINPOP = 10; //dummy value
            int MAXPOP = 20; //dummy value
            float MUTPROB = 0.1f; //dummy value
            float CROSSPROB = 0.75f; //dummy value

            MINPOP = int.Parse(minPopbox.Text);
            MAXPOP = int.Parse(maxPopBox.Text);
            MUTPROB = float.Parse(mutProbbox.Text);
            CROSSPROB = float.Parse(crossProbbox.Text);

            this.toolStripProgressBar1.Maximum = MAXPOP;
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Value = 0;
            this.toolStripProgressBar1.Minimum = 0;

            return new Probabilities(MINPOP, MAXPOP, MUTPROB, CROSSPROB);
        }

        private void knapDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.DataBS.EndEdit();
            this.SolBS.EndEdit();
            this.gABS.EndEdit();
            this.problemsBS.EndEdit();

            this.TAM.UpdateAll(this.gADataSet);
        }

        private void fillMissingColumns()
        {
            string relation = "KnapStrings_Solutions";
            this.SolutionsDataGridView.AutoGenerateColumns = true;
            foreach (DataColumn c in gADataSet.Strings.Columns)
            {
                if (!c.ColumnName.Contains("ID"))
                {
                    string str = "Parent(" + relation + ")." + c.ColumnName;
                    this.gADataSet.Solutions.Columns.Add(new DataColumn(c.ColumnName, c.DataType, str));
                }
            }
          
        }

        private void KnapForm_Load(object sender, EventArgs e)
        {
            //   this.knapSolBS.Sort =  this.gADataSet.Solutions.FitnessColumn.ColumnName + ", " + this.gADataSet.Solutions.TimeSpanColumn.ColumnName + ", " + this.gADataSet.Solutions.FrequencyColumn.ColumnName + " asc";
            fillMissingColumns();

            this.problemsTA.Fill(this.gADataSet.Problems);
            this.ConditionTA.Fill(this.gADataSet.Conditions);
            // TODO: This line of code loads data into the 'gADataSet.GA' table. You can move, or remove it, as needed.
            this.gATA.Fill(this.gADataSet.GA);
            // TODO: This line of code loads data into the 'gADataSet.Solutions' table. You can move, or remove it, as needed.
            this.SolTA.Fill(this.gADataSet.Solutions);
            // TODO: This line of code loads data into the 'gADataSet.KnapData' table. You can move, or remove it, as needed.
            this.DataTA.Fill(this.gADataSet.Data);
            this.StringsTA.Fill(this.gADataSet.Strings);

            dgvDoubleMouseclick(this.problemsDataGridView, DGVARGUMENTDUMMY);

          
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            this.gobtn.Enabled = true;
            this.resumebtn.Enabled = true;
            this.stopbtn.Enabled = false;
            IsampleControl.GA.Stop();
        }

        private void resumebtn_Click(object sender, EventArgs e)
        {
            this.resumebtn.Enabled = false;
            this.stopbtn.Enabled = true;
            this.gobtn.Enabled = false;
            IsampleControl.GA.Resume();
        }

        private void dgvDoubleMouseclick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridView dgv = (sender as DataGridView);
            if (dgv.Rows.Count == 0) return;

            dynamic dgvr = dgv.Rows[e.RowIndex].DataBoundItem;

            if (dgvr == null) return;

            if (sender.Equals(this.problemsDataGridView))
            {
                GADataSet.ProblemsRow currentProblem = dgvr.Row as GADataSet.ProblemsRow;

                this.ConditionsBS.Filter = this.gADataSet.Conditions.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;

                this.DataBS.Filter = this.gADataSet.Data.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;

                this.gABS.Filter = this.gADataSet.GA.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;
                this.gABS.Sort = this.gADataSet.GA.IDColumn.ColumnName + " desc";
                this.SolBS.Filter = this.gADataSet.Solutions.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;

                this.SolBS.Sort = this.gADataSet.Solutions.ChromosomeLengthColumn.ColumnName + " desc";
            }
            else if (sender.Equals(this.gADataGridView))
            {
                GADataSet.GARow currentGARow = null;
                currentGARow = dgvr.Row as GADataSet.GARow;

                this.SolBS.Filter = this.gADataSet.Solutions.GAIDColumn.ColumnName + "=" + currentGARow.ID;

                this.SolBS.Sort = this.gADataSet.Solutions.FitnessColumn.ColumnName + " desc";
            }
            else if (sender.Equals(this.SolutionsDataGridView))
            {
                GADataSet.SolutionsRow sol = dgvr.Row as GADataSet.SolutionsRow;
                if (sol.IsChromosomeNull()) return;
                System.IO.File.WriteAllBytes("current.gif", sol.Chromosome);
                picBox.ImageLocation = "current.gif";
                picBox.Refresh();
            }
        }

        private void statsbtn_Click(object sender, EventArgs e)
        {
            DataRowView rv= this.problemsBS.Current as DataRowView;
            GADataSet.ProblemsRow p = rv.Row as GADataSet.ProblemsRow;


            Aid.DoStatistics<GADataSet.ProblemsRow>(p);

            this.TAM.UpdateAll(this.gADataSet);
            this.gADataSet.WriteXml("dataset.xml", XmlWriteMode.WriteSchema);
        }
    }
}