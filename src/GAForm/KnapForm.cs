using System;
using System.Data;
using System.Windows.Forms;
using GADB;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;

namespace GAForm
{
    public partial class KnapForm : Form
    {
        public GeneticAlgorithm ga = null; //object engine
        private ISampleController sampleController = null;
        int minPop=10;
        int maxPop=20 ;
        float mutProb =0.1f;
        float crossProb =0.75f;
        int size=8;
       
        private GADataSet.KnapSolutionsRow currentRow = null;
        private GADataSet.GARow gaRow = null;
        private KnapsackSampleController controller = null;
        GADataSet.ProblemsRow p;
        public KnapForm()
        {
            InitializeComponent();

            this.resumebtn.Enabled = false;
            this.stopbtn.Enabled = false;

        }

        public void Go(object sender, EventArgs e)
        {

            this.Validate() ;
            this.gobtn.Enabled = false;
            this.stopbtn.Enabled = true;

             minPop = int.Parse(minPopbox.Text);
             maxPop = int.Parse(maxPopBox.Text);
             mutProb = float.Parse(mutProbbox.Text);
             crossProb = float.Parse(crossProbbox.Text);
             size = int.Parse(this.chsizebox.Text);

            this.toolStripProgressBar1.Maximum = maxPop;
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Value = 0;
            this.toolStripProgressBar1.Minimum = 0;


            GADataSet.KnapSolutionsDataTable dt = gADataSet.KnapSolutions;
            controller = new KnapsackSampleController(ref dt, ref p, size);
            sampleController = controller;
            sampleController.ConfigGA(ref ga, minPop, maxPop, mutProb, crossProb);



            //genetic algorithRow
            gaRow = this.gADataSet.GA.NewGARow();
            this.gADataSet.GA.AddGARow(gaRow);
            gaRow.ProblemID = p.ProblemID;

          


            //create knapRow
            currentRow = this.gADataSet.KnapSolutions.NewKnapSolutionsRow();
            this.gADataSet.KnapSolutions.AddKnapSolutionsRow(currentRow);

            this.TAM.UpdateAll(this.gADataSet);


            this.knapSolBS.Filter = this.gADataSet.KnapSolutions.GAIDColumn.ColumnName + "=" + gaRow.ID;

            ///DEFAULT TEMPLATE for handler
            EventHandler generationRan = null;

            generationRan = delegate
            {

                IChromosome bestChromosome = ga.Population.BestChromosome;

                gaRow.Fill(ref ga); //report GA stuff

                controller.FillRow(ref currentRow, ref bestChromosome, gaRow.ID);
                currentRow.TimeSpan = gaRow.TimeStamp;

                sampleController.Add(bestChromosome); //report CHROMOSOME stuff


                this.toolStripProgressBar1.PerformStep();
                Application.DoEvents();


            };


            ga.GenerationRan += generationRan;


            try
            {
                ga.Start();
                             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);
              
            }

            controller.FillRows(gaRow.ID); //fill rows after been listed


            this.TAM.UpdateAll(this.gADataSet);


            this.gobtn.Enabled = true;
            this.stopbtn.Enabled = false;

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
            this.problemsTA.Fill(this.gADataSet.Problems);
            this.KnapConditionTA.Fill(this.gADataSet.KnapConditions);
            // TODO: This line of code loads data into the 'gADataSet.GA' table. You can move, or remove it, as needed.
            this.gATA.Fill(this.gADataSet.GA);
            // TODO: This line of code loads data into the 'gADataSet.KnapSolutions' table. You can move, or remove it, as needed.
            this.knapSolTA.Fill(this.gADataSet.KnapSolutions);
            // TODO: This line of code loads data into the 'gADataSet.KnapData' table. You can move, or remove it, as needed.
            this.knapDataTA.Fill(this.gADataSet.KnapData);

            
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            this.gobtn.Enabled = true;
            this.resumebtn.Enabled = true;
            this.stopbtn.Enabled = false;
            ga.Stop();

        }

        private void resumebtn_Click(object sender, EventArgs e)
        {
            this.resumebtn.Enabled = false;
            this.stopbtn.Enabled = true;
            this.gobtn.Enabled = false;
            ga.Resume();
           
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

                p = dgvr.Row as GADataSet.ProblemsRow;


                this.knapConditionsBS.Filter = this.gADataSet.KnapConditions.ProblemIDColumn.ColumnName + "=" + p.ProblemID;

                this.knapDataBS.Filter = this.gADataSet.KnapData.ProblemIDColumn.ColumnName + "=" + p.ProblemID;


                this.gABS.Filter = this.gADataSet.GA.ProblemIDColumn.ColumnName + "="+p.ProblemID;


                MouseEventArgs a = new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 1);
                DataGridViewCellMouseEventArgs arg =  new DataGridViewCellMouseEventArgs(0, 0, 0,0, a );

               dgvDoubleMouseclick(this.gADataGridView,arg);

              
            }
            else if (sender.Equals(this.gADataGridView))
            {

                gaRow = dgvr.Row as GADataSet.GARow;

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.GAIDColumn.ColumnName + "=" + gaRow.ID;


            }


        }
    }
}