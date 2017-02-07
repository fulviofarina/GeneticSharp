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


       private GeneticAlgorithm geneticAlgo = null; //object engine

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

         
            int MINSIZE = 8; //dummy value
            int MAXSIZE = 16; //dummy value
            int ITERS = 5;
            //MIN SIZE OF CHROMOSOME TO ITERATE
            MINSIZE = this.currentProblem.MinSize;
            //MAX SIZE OF CHROMOSOME TO ITERATE
            MAXSIZE = this.currentProblem.MaxSize ;
            ITERS = this.currentProblem.Iters;


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

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.GAIDColumn.ColumnName + "=" + currentGARow.ID;


                ///CUT HERE
                KnapsackSampleController knapController = null;
                knapController = new KnapsackSampleController(ref currentProblem, MINSIZE);
                ISampleController IsampleControl = null;
                IsampleControl = knapController;

          
                IsampleControl.ConfigGA(ref geneticAlgo, MINPOP, MAXPOP, MUTPROB, CROSSPROB);


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

                    IChromosome bestChromosome = geneticAlgo.Population.BestChromosome;
                    currentGARow.Fill(ref geneticAlgo); //report GA stuff

                    Application.DoEvents();
                    GADataSet.KnapSolutionsRow currentSolution = null;
                    currentSolution = this.gADataSet.KnapSolutions.NewKnapSolutionsRow();
                    knapController.FillBasic(ref currentSolution, ref bestChromosome);
                    knapController.FillGAData(ref currentSolution, ref  currentGARow);
                    knapController.FillStrings(ref currentSolution);

                    //IF NOT PRESENT IN THE LIST IS A NEW CHROMOSOME
                    string genotype = currentSolution.Genotype;
                    if (hgenotypes.Add(genotype)) //add to hashShet
                    {
                        this.gADataSet.KnapSolutions.AddKnapSolutionsRow(currentSolution);
                       
                        sols.Add(currentSolution);//add to indexed list
                    }
                    else
                    {
                        int i = sols.FindIndex(o => o.Genotype.Equals(genotype));
                        sols[i].Frequency++;
                       // currentSolution = null;
                    }


                    this.toolStripProgressBar1.PerformStep();
                    Application.DoEvents();

                };


                geneticAlgo.GenerationRan += generationRan;

                Run();



                //clean
                hgenotypes.Clear();
                sols.Clear();
                hgenotypes = null;
                sols = null;


                geneticAlgo = null; // clean
                knapController = null;
                IsampleControl = null;

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

        private void Run()
        {
            try
            {
                geneticAlgo.Start();

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

          

            dgvDoubleMouseclick(this.problemsDataGridView, DGVARGUMENTDUMMY);
        }

        private void stopbtn_Click(object sender, EventArgs e)
        {
            this.gobtn.Enabled = true;
            this.resumebtn.Enabled = true;
            this.stopbtn.Enabled = false;
            geneticAlgo.Stop();

        }

        private void resumebtn_Click(object sender, EventArgs e)
        {
            this.resumebtn.Enabled = false;
            this.stopbtn.Enabled = true;
            this.gobtn.Enabled = false;
            geneticAlgo.Resume();
           
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


                this.gABS.Filter = this.gADataSet.GA.ProblemIDColumn.ColumnName + "="+currentProblem.ProblemID;

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.ProblemIDColumn.ColumnName + "=" + currentProblem.ProblemID;
             
              


            }
            else if (sender.Equals(this.gADataGridView))
            {
                GADataSet.GARow currentGARow = null;
        currentGARow = dgvr.Row as GADataSet.GARow;

                this.knapSolBS.Filter = this.gADataSet.KnapSolutions.GAIDColumn.ColumnName + "=" + currentGARow.ID;

         

            }


        }

        private void statsbtn_Click(object sender, EventArgs e)
        {
           IEnumerable<GADataSet.GARow> gasrows = this.currentProblem.GetGARows();

            int min =  gasrows.Min(o => o.ChromosomeLength);
            int max = gasrows.Max(o => o.ChromosomeLength);

            HashSet<string> hash = new HashSet<string>();
            List<GADataSet.KnapSolutionsRow> list = new List<GADataSet.KnapSolutionsRow>();

           // int counter = 1;
            Func<GADataSet.KnapSolutionsRow, bool> funcion;

            funcion = o =>
            {
                string genotype = o.Genotype;
                if (hash.Add(genotype)) //add to hashShet
                {
                    // this.gADataSet.KnapSolutions.AddKnapSolutionsRow(currentSolution);

                    list.Add(o);//add to indexed list
                }
                else
                {
                    int i = list.FindIndex(r => r.Genotype.Equals(genotype));
                    list[i].Frequency+=o.Frequency;
                 //   list[i].TimeSpan += o.TimeSpan;
                  //  list[i].Fitness += o.Fitness;
                  //  list[i].TotalValue += o.TotalValue;
                  //  list[i].TotalWeight += o.TotalWeight;
                  //  list[i].TotalVolume += o.TotalVolume;
                  //  counter++;
                }
                return true;
            };


            //iterate min max chromosome lenght for all genetic algorithms
            for (int j = min; j<= max; j++)
            {

                gasrows = this.currentProblem.GetGARows();

                IEnumerable<GADataSet.GARow> subs = gasrows.Where(o => o.ChromosomeLength == j).ToList();

                GADataSet.GARow subFirst = subs.FirstOrDefault();
                subFirst.GenerationCurrent = Convert.ToInt32(subs.Average(o => o.GenerationCurrent));
                subFirst.GenerationTotal = Convert.ToInt32(subs.Average(o => o.GenerationTotal));
                subFirst.MutationProb = subs.Average(o => o.MutationProb);
                subFirst.CrossProbability = subs.Average(o => o.CrossProbability);
                subFirst.TimeStamp = subs.Average(o => o.TimeStamp);




                //select GARow childrens
                IEnumerable<GADataSet.KnapSolutionsRow> knaprows = subs.SelectMany(o => o.GetKnapSolutionsRows());

                hash.Clear(); //clear
                list.Clear();//clear
             //   counter = currentProblem.Iters;

                knaprows = knaprows.Where(funcion).ToList(); //evaluate the filter function


                int count = knaprows.Count();
                for (int d = 0; d < count; d++)
                {
                   if (!list.Contains( knaprows.ElementAt(d)) )  knaprows.ElementAt(d).Delete();

                }
                count = list.Count;
                for (int d = 0; d < count; d++)
                {

                  //  list.ElementAt(d).Frequency /= counter;
                  //  list.ElementAt(d).TimeSpan /= counter;
                   // list.ElementAt(d).Fitness /= counter;
                   // list.ElementAt(d).TotalValue /= counter;
                  //  list.ElementAt(d).TotalWeight /= counter;
                  //  list.ElementAt(d).TotalVolume /= counter;
                }
                count = subs.Count();
                for (int d = 1; d < count; d++)
                {
                    subs.ElementAt(d).Delete();
                }
            }

            this.TAM.UpdateAll(this.gADataSet);
            this.gADataSet.WriteXml("dataset.xml", XmlWriteMode.WriteSchema);


        }
    }
}