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

        static MouseEventArgs a = new MouseEventArgs(MouseButtons.Left, 2, 0, 0, 0);
        static DataGridViewCellMouseEventArgs arg = new DataGridViewCellMouseEventArgs(0, 0, 0, 0, a);




      
        private KnapsackSampleController controller = null;


        public GeneticAlgorithm ga = null; //object engine
        private ISampleController sampleController = null;


        int MINPOP=10; //dummy value
        int MAXPOP=20 ; //dummy value
        float MUTPROB =0.1f; //dummy value
        float CROSSPROB =0.75f; //dummy value
        int MINSIZE=8; //dummy value
        int MAXSIZE = 16; //dummy value
        int ITERS = 5;
       
        private GADataSet.KnapSolutionsRow currentSolution = null;
        private GADataSet.GARow currentGARow = null;
        private GADataSet.ProblemsRow currentProblem;
       

        public KnapForm()
        {
            InitializeComponent();

            this.resumebtn.Enabled = false;
            this.stopbtn.Enabled = false;

        }

        public void Go(object sender, EventArgs e)
        {

            this.Validate();

            //MIN SIZE OF CHROMOSOME TO ITERATE
            MINSIZE = this.currentProblem.MinSize;
            //MAX SIZE OF CHROMOSOME TO ITERATE
            MAXSIZE = this.currentProblem.MaxSize ;

            ITERS = this.currentProblem.Iters;


            int iterCounter=1;

            do
            {

              
              
                this.gobtn.Enabled = false;
                this.stopbtn.Enabled = true;


                MINPOP = int.Parse(minPopbox.Text);
                MAXPOP = int.Parse(maxPopBox.Text);
                MUTPROB = float.Parse(mutProbbox.Text);
                CROSSPROB = float.Parse(crossProbbox.Text);

                this.toolStripProgressBar1.Maximum = MAXPOP;
                this.toolStripProgressBar1.Step = 1;
                this.toolStripProgressBar1.Value = 0;
                this.toolStripProgressBar1.Minimum = 0;

                //genetic algorithRow
                currentGARow = this.gADataSet.GA.NewGARow();
                this.gADataSet.GA.AddGARow(currentGARow);
                currentGARow.ProblemID = currentProblem.ProblemID;
                currentGARow.ChromosomeLength = MINSIZE;
                //create knapRow

                this.gATA.Update(this.gADataSet.GA);

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.GAIDColumn.ColumnName + "=" + currentGARow.ID;
             //   this.knapSolBS.Sort = this.gADataSet.KnapSolutions.TimeSpanColumn.ColumnName + " desc";


                ///CUT HERE


                controller = new KnapsackSampleController(ref currentProblem, MINSIZE);
                sampleController = controller;
                sampleController.ConfigGA(ref ga, MINPOP, MAXPOP, MUTPROB, CROSSPROB);



                Application.DoEvents();
                ///DEFAULT TEMPLATE for handler
                EventHandler generationRan = null;
                //LIST OF NON REPEATED VALUES
                HashSet<string> hgenotypes = new HashSet<string>();
                //NORMAL LIST TO ACCOMPANY, BECAUSE  A LIST IS INDEXED
                //AND A HASHSET IS NOT
                List<GADataSet.KnapSolutionsRow> sols = new List<GADataSet.KnapSolutionsRow>();
                generationRan = delegate
                {

                    IChromosome bestChromosome = ga.Population.BestChromosome;
                    currentGARow.Fill(ref ga); //report GA stuff

                    Application.DoEvents();
                    currentSolution = this.gADataSet.KnapSolutions.NewKnapSolutionsRow();
                    controller.FillBasic(ref currentSolution, ref bestChromosome);
                    controller.FillGAData(ref currentSolution, ref  currentGARow);
                    controller.FillStrings(ref currentSolution);

                    //IF NOT PRESENT IN THE LIST IS A NEW CHROMOSOME
                    if (hgenotypes.Add(currentSolution.Genotype)) //add to hashShet
                    {
                        this.gADataSet.KnapSolutions.AddKnapSolutionsRow(currentSolution);
                       
                        sols.Add(currentSolution);//add to indexed list
                    }
                    else
                    {
                        int i = sols.FindIndex(o => o.Genotype.Equals(currentSolution.Genotype));
                        sols[i].Frequency++;
                        currentSolution = null;
                    }

                    //  sampleController.Add(bestChromosome); //report CHROMOSOME stuff

                    this.toolStripProgressBar1.PerformStep();
                    Application.DoEvents();

                };


                ga.GenerationRan += generationRan;

                Run();



                //clean
                hgenotypes.Clear();
                sols.Clear();
                hgenotypes = null;
                sols = null;


                ga = null; // clean


                //ABORT IF STOPPED
                if (!stopbtn.Enabled) break;

                //UPDATE DATABASES
                this.TAM.UpdateAll(this.gADataSet);
                this.gobtn.Enabled = true;
                this.stopbtn.Enabled = false;


                if (iterCounter < ITERS)
                {
                    iterCounter++;
                }
                else
                {
                    iterCounter = 1;
                    MINSIZE++; //ADD SIZE OF CHROMOSOME NEXT GENETIC ALGORITHM
                }

            } while (MINSIZE <= MAXSIZE);

            
         

        }

        private void Run()
        {
            try
            {
                ga.Start();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace);

            }
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

            this.knapSolBS.Sort = this.gADataSet.KnapSolutions.ChromosomeLengthColumn.ColumnName + "," + this.gADataSet.KnapSolutions.FitnessColumn.ColumnName + "," + this.gADataSet.KnapSolutions.TimeSpanColumn.ColumnName + "," + this.gADataSet.KnapSolutions.FrequencyColumn.ColumnName + " desc";


            this.problemsTA.Fill(this.gADataSet.Problems);
            this.KnapConditionTA.Fill(this.gADataSet.KnapConditions);
            // TODO: This line of code loads data into the 'gADataSet.GA' table. You can move, or remove it, as needed.
            this.gATA.Fill(this.gADataSet.GA);
            // TODO: This line of code loads data into the 'gADataSet.KnapSolutions' table. You can move, or remove it, as needed.
            this.knapSolTA.Fill(this.gADataSet.KnapSolutions);
            // TODO: This line of code loads data into the 'gADataSet.KnapData' table. You can move, or remove it, as needed.
            this.knapDataTA.Fill(this.gADataSet.KnapData);

          

            dgvDoubleMouseclick(this.problemsDataGridView, arg);
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

                currentProblem = dgvr.Row as GADataSet.ProblemsRow;


                this.knapConditionsBS.Filter = this.gADataSet.KnapConditions.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;

                this.knapDataBS.Filter = this.gADataSet.KnapData.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;
              

                IList<GADataSet.KnapDataRow> datas = this.gADataSet.KnapData.Where(o => o.ProblemID == currentProblem.ProblemID).ToList();
                int count = datas.Count;
                datas = null;

              //  chsizebox.Text = count.ToString();
              //  chSizeMaxbox.Text = (count * 2).ToString();

                this.gABS.Filter = this.gADataSet.GA.ProblemIDColumn.ColumnName + "="+currentProblem.ProblemID;

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;
             
                //  dgvDoubleMouseclick(this.gADataGridView,arg);


            }
            else if (sender.Equals(this.gADataGridView))
            {

                currentGARow = dgvr.Row as GADataSet.GARow;

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.GAIDColumn.ColumnName + "=" + currentGARow.ID;

           //     this.knapSolBS.Sort = this.gADataSet.KnapSolutions.FitnessColumn.ColumnName + "," + this.gADataSet.KnapSolutions.TimeSpanColumn.ColumnName + "," + this.gADataSet.KnapSolutions.FrequencyColumn.ColumnName + " desc";

                //this.knapSolBS.Sort = this.gADataSet.KnapSolutions.TimeSpanColumn.ColumnName + " desc";


            }


        }
    }
}