using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GADB;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;

namespace GAForm
{
    public partial class KnapForm : Form
    {

        /// <summary>
        /// A MOUSE EVENT ARGUMENT
        /// </summary>
        private static MouseEventArgs MOUSEVENT = new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0);
        /// <summary>
        /// A DATAGRID SELECTED ROW CALL
        /// </summary>
       private static DataGridViewCellMouseEventArgs DGVARGUMENTDUMMY = new DataGridViewCellMouseEventArgs(0, 0, 0, 0, MOUSEVENT);


        ISampleController IsampleControl = null;

       
       

        public KnapForm()
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
            MAXSIZE = currentProblem.MaxSize ;
            ITERS = currentProblem.Iters;


            int ITERCOUNTER =1;

           
            do
            {

              
              
                this.gobtn.Enabled = false;
                this.stopbtn.Enabled = true;

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

                //genetic algorithRow
                GADataSet.GARow currentGARow = null;
                currentGARow = this.gADataSet.GA.NewGARow();
                this.gADataSet.GA.AddGARow(currentGARow);
                currentGARow.ProblemID = currentProblem.ProblemID;
                currentGARow.ChromosomeLength = MINSIZE;
                //create knapRow

                this.gATA.Update(this.gADataSet.GA);

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.GAIDColumn
                    .ColumnName + "=" + currentGARow.ID;
                this.knapSolBS.Sort = this.gADataSet.KnapSolutions.TimeSpanColumn
                    .ColumnName + " desc";


                int methodNUMBER = 2;
                ///CUT HERE
                KnapsackSampleController knapController = null;
                knapController = new KnapsackSampleController(ref currentProblem, MINSIZE, methodNUMBER);
                IsampleControl = knapController;

                Probabilities prob = new Probabilities(MINPOP, MAXPOP, MUTPROB, CROSSPROB);
                IsampleControl.Probabilities = prob;
                IsampleControl.ConfigGA();


                object currentGAROW = currentGARow;
                Action a; //para rgresar al form
                a = Application.DoEvents;
                a += this.toolStripProgressBar1.PerformStep;
               
                IsampleControl.PostScript(ref currentGAROW,ref a);

              
                IsampleControl.GA.Start();
            
                                              
                //ABORT IF STOPPED
                if (!stopbtn.Enabled) break;

                //UPDATE DATABASES
                this.TAM.UpdateAll(this.gADataSet);
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

      



        private void knapDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.knapDataBS.EndEdit();
            this.knapSolBS.EndEdit();
            this.gABS.EndEdit();
            this.problemsBS.EndEdit();

            this.TAM.UpdateAll(this.gADataSet);
        }

        private void KnapForm_Load(object sender, EventArgs e)
        {

         //   this.knapSolBS.Sort =  this.gADataSet.KnapSolutions.FitnessColumn.ColumnName + ", " + this.gADataSet.KnapSolutions.TimeSpanColumn.ColumnName + ", " + this.gADataSet.KnapSolutions.FrequencyColumn.ColumnName + " asc";


            this.problemsTA.Fill(this.gADataSet.Problems);
            this.KnapConditionTA.Fill(this.gADataSet.KnapConditions);
            // TODO: This line of code loads data into the 'gADataSet.GA' table. You can move, or remove it, as needed.
            this.gATA.Fill(this.gADataSet.GA);
            // TODO: This line of code loads data into the 'gADataSet.KnapSolutions' table. You can move, or remove it, as needed.
            this.knapSolTA.Fill(this.gADataSet.KnapSolutions);
            // TODO: This line of code loads data into the 'gADataSet.KnapData' table. You can move, or remove it, as needed.
            this.knapDataTA.Fill(this.gADataSet.KnapData);

          

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

             


                this.knapConditionsBS.Filter = this.gADataSet.KnapConditions.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;

                this.knapDataBS.Filter = this.gADataSet.KnapData.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;
              

           

                this.gABS.Filter = this.gADataSet.GA.ProblemIDColumn.ColumnName + "="+currentProblem.ProblemID;

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;

                this.knapSolBS.Sort = this.gADataSet.KnapSolutions.ChromosomeLengthColumn.ColumnName + " desc";



            }
            else if (sender.Equals(this.gADataGridView))
            {
                GADataSet.GARow currentGARow = null;
                currentGARow = dgvr.Row as GADataSet.GARow;

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.GAIDColumn.ColumnName + "=" + currentGARow.ID;

                this.knapSolBS.Sort = this.gADataSet.KnapSolutions.FitnessColumn.ColumnName + " desc";


            }


        }

        private void statsbtn_Click(object sender, EventArgs e)
        {


            IsampleControl.DoStatistics<GADataSet.ProblemsRow>(this.problemsBS.Current);

            this.TAM.UpdateAll(this.gADataSet);
            this.gADataSet.WriteXml("dataset.xml", XmlWriteMode.WriteSchema);


        }


      
    }
}