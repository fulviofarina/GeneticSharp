using System;
using System.Windows.Forms;
using GeneticSharp.Domain;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Fitnesses;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Selections;
using GADB;
using GADB.GADataSetTableAdapters;

namespace GAForm
{
    public partial class KnapForm : Form
    {


        public GeneticAlgorithm ga = null; //object engine
        ISampleController sampleController = null;


        public KnapForm()
        {
            InitializeComponent();
        }

        public void Go(object sender, EventArgs e)
        {

            fitnesslbl.Text = "Starting...";

            GADataSet ds = gADataSet;
          //  ds.KnapSolutions.BeginLoadData();
         //   ds.GA.BeginLoadData();

            KnapsackSampleController2 controller = new KnapsackSampleController2(ref ds);
          

            int minPop = int.Parse(minPopbox.Text);
            int maxPop = int.Parse(maxPopBox.Text);
            float mutProb = float.Parse( mutProbbox.Text);
            float crossProb = float.Parse(crossProbbox.Text);



            sampleController = controller;
            sampleController.ConfigGA(ref ga, minPop, maxPop, mutProb,crossProb);

            ///DEFAULT TEMPLATE
            EventHandler generationRan = createGAHandler(controller);
            ga.GenerationRan += generationRan;

            try
            {
              
                ga.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }



            Application.DoEvents();
            

            controller.FillRows(); //fill rows after been listed


         //   ds.KnapSolutions.EndLoadData();
        //    ds.GA.EndLoadData();

        }

     


        private EventHandler createGAHandler( KnapsackSampleController2 con)
        {
         

            GADataSet.GARow gaRow = gADataSet.GA.NewGARow();
            gADataSet.GA.AddGARow(gaRow);


            GADataSet.KnapSolutionsRow knap = this.gADataSet.KnapSolutions.NewKnapSolutionsRow();
            this.gADataSet.KnapSolutions.AddKnapSolutionsRow(knap);
            knap.GAID = gaRow.ID;

            EventHandler generationRan=null;


            generationRan = delegate
            {
                //  Msg.DrawSampleName(selectedSampleName);

                IChromosome bestChromosome = ga.Population.BestChromosome;

                double? fitnessVal = bestChromosome.Fitness;

                if (fitnessVal == null) fitnessVal = 0;

                gaRow.Fitness = (double)fitnessVal;

                gaRow.Fill(ref ga); //report GA stuff

                TimeSpan te = ga.TimeEvolving;
                gaRow.TimeStamp = te.TotalSeconds;

                fitnesslbl.Text = gaRow.Fitness.ToString();
                timeSpanlbl.Text = te.ToString();

                con.FillRow(ref knap, ref bestChromosome);
                knap.TimeSpan = gaRow.TimeStamp;

                Application.DoEvents();


                gaRow.AcceptChanges();
                knap.AcceptChanges();

                sampleController.Add(bestChromosome); //report CHROMOSOME stuff
                                                       //  Application.DoEvents();
            };

            return generationRan;


        }

     

        private void knapDataBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.knapDataBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.gADataSet);
        }

        private void KnapForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gADataSet.GA' table. You can move, or remove it, as needed.
            this.gATableAdapter.Fill(this.gADataSet.GA);
            // TODO: This line of code loads data into the 'gADataSet.KnapSolutions' table. You can move, or remove it, as needed.
            this.knapSolutionsTableAdapter.Fill(this.gADataSet.KnapSolutions);
            // TODO: This line of code loads data into the 'gADataSet.KnapData' table. You can move, or remove it, as needed.
            this.knapDataTableAdapter.Fill(this.gADataSet.KnapData);

            // Go();
        }

       

       
    }
}