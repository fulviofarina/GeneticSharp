using GADB;
using GADB.GADataSetTableAdapters;

namespace GAForm
{
    partial class KnapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KnapForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.knapDataBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.knapDataBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.gobtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.minPopbox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.maxPopBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.mutProbbox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.crossProbbox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.stopbtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.resumebtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.statsbtn = new System.Windows.Forms.ToolStripButton();
            this.knapDataDataGridView = new System.Windows.Forms.DataGridView();
            this.SolutionsDataGridView = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.gADataGridView = new System.Windows.Forms.DataGridView();
            this.ChromosomeLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrossProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrossChromeMinLenght = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.problemsDataGridView = new System.Windows.Forms.DataGridView();
            this.knapConditionsDataGridView = new System.Windows.Forms.DataGridView();
            this.MaxWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightFine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolumeFine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueFine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knapConditionsBS = new System.Windows.Forms.BindingSource(this.components);
            this.gADataSet = new GADB.GADataSet();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.problemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxSizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.problemsBS = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gABS = new System.Windows.Forms.BindingSource(this.components);
            this.knapSolBS = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knapDataBS = new System.Windows.Forms.BindingSource(this.components);
            this.knapDataTA = new GADB.GADataSetTableAdapters.DataTableAdapter();
            this.TAM = new GADB.GADataSetTableAdapters.TableAdapterManager();
            this.gATA = new GADB.GADataSetTableAdapters.GATableAdapter();
            this.KnapConditionTA = new GADB.GADataSetTableAdapters.KnapConditionsTableAdapter();
            this.knapStringsTableAdapter1 = new GADB.GADataSetTableAdapters.KnapStringsTableAdapter();
            this.problemsTA = new GADB.GADataSetTableAdapters.ProblemsTableAdapter();
            this.knapSolTA = new GADB.GADataSetTableAdapters.SolutionsTableAdapter();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Generations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Okays = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chromosome = new System.Windows.Forms.DataGridViewImageColumn();
            this.SchOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataBindingNavigator)).BeginInit();
            this.knapDataBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDataGridView)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapConditionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapConditionsBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gABS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapSolBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataBS)).BeginInit();
            this.SuspendLayout();
            // 
            // knapDataBindingNavigator
            // 
            this.knapDataBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.knapDataBindingNavigator.BindingSource = this.knapDataBS;
            this.knapDataBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.knapDataBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.knapDataBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.knapDataBindingNavigatorSaveItem,
            this.gobtn,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.minPopbox,
            this.toolStripSeparator1,
            this.maxPopBox,
            this.toolStripSeparator3,
            this.toolStripLabel2,
            this.mutProbbox,
            this.toolStripSeparator4,
            this.crossProbbox,
            this.toolStripSeparator6,
            this.stopbtn,
            this.toolStripSeparator5,
            this.resumebtn,
            this.toolStripSeparator7,
            this.statsbtn});
            this.knapDataBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.knapDataBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.knapDataBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.knapDataBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.knapDataBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.knapDataBindingNavigator.Name = "knapDataBindingNavigator";
            this.knapDataBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.knapDataBindingNavigator.Size = new System.Drawing.Size(1209, 29);
            this.knapDataBindingNavigator.TabIndex = 0;
            this.knapDataBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(47, 26);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 29);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 29);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 26);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // knapDataBindingNavigatorSaveItem
            // 
            this.knapDataBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.knapDataBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("knapDataBindingNavigatorSaveItem.Image")));
            this.knapDataBindingNavigatorSaveItem.Name = "knapDataBindingNavigatorSaveItem";
            this.knapDataBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 26);
            this.knapDataBindingNavigatorSaveItem.Text = "Save Data";
            this.knapDataBindingNavigatorSaveItem.Click += new System.EventHandler(this.knapDataBindingNavigatorSaveItem_Click);
            // 
            // gobtn
            // 
            this.gobtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.gobtn.Image = ((System.Drawing.Image)(resources.GetObject("gobtn.Image")));
            this.gobtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.gobtn.Name = "gobtn";
            this.gobtn.Size = new System.Drawing.Size(34, 26);
            this.gobtn.Text = "Go";
            this.gobtn.Click += new System.EventHandler(this.Go);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(84, 26);
            this.toolStripLabel1.Text = "Population";
            // 
            // minPopbox
            // 
            this.minPopbox.Name = "minPopbox";
            this.minPopbox.Size = new System.Drawing.Size(70, 29);
            this.minPopbox.Text = "100";
            this.minPopbox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minPopbox.ToolTipText = "Min";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // maxPopBox
            // 
            this.maxPopBox.Name = "maxPopBox";
            this.maxPopBox.Size = new System.Drawing.Size(70, 29);
            this.maxPopBox.Text = "200";
            this.maxPopBox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxPopBox.ToolTipText = "Max";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(96, 26);
            this.toolStripLabel2.Text = "Probabilities";
            // 
            // mutProbbox
            // 
            this.mutProbbox.Name = "mutProbbox";
            this.mutProbbox.Size = new System.Drawing.Size(70, 29);
            this.mutProbbox.Text = "0.1";
            this.mutProbbox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mutProbbox.ToolTipText = "Muation";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 29);
            // 
            // crossProbbox
            // 
            this.crossProbbox.Name = "crossProbbox";
            this.crossProbbox.Size = new System.Drawing.Size(70, 29);
            this.crossProbbox.Text = "0.75";
            this.crossProbbox.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.crossProbbox.ToolTipText = "CrossOver";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 29);
            // 
            // stopbtn
            // 
            this.stopbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stopbtn.Image = ((System.Drawing.Image)(resources.GetObject("stopbtn.Image")));
            this.stopbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopbtn.Name = "stopbtn";
            this.stopbtn.Size = new System.Drawing.Size(45, 26);
            this.stopbtn.Text = "Stop";
            this.stopbtn.Click += new System.EventHandler(this.stopbtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 29);
            // 
            // resumebtn
            // 
            this.resumebtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resumebtn.Image = ((System.Drawing.Image)(resources.GetObject("resumebtn.Image")));
            this.resumebtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resumebtn.Name = "resumebtn";
            this.resumebtn.Size = new System.Drawing.Size(70, 26);
            this.resumebtn.Text = "Resume";
            this.resumebtn.Click += new System.EventHandler(this.resumebtn_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 29);
            // 
            // statsbtn
            // 
            this.statsbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statsbtn.Image = ((System.Drawing.Image)(resources.GetObject("statsbtn.Image")));
            this.statsbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.statsbtn.Name = "statsbtn";
            this.statsbtn.Size = new System.Drawing.Size(56, 26);
            this.statsbtn.Text = "STATS";
            this.statsbtn.Click += new System.EventHandler(this.statsbtn_Click);
            // 
            // knapDataDataGridView
            // 
            this.knapDataDataGridView.AutoGenerateColumns = false;
            this.knapDataDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.knapDataDataGridView.BackgroundColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.knapDataDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.knapDataDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knapDataDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.knapDataDataGridView.DataSource = this.knapDataBS;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.knapDataDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.knapDataDataGridView.Location = new System.Drawing.Point(12, 195);
            this.knapDataDataGridView.Name = "knapDataDataGridView";
            this.knapDataDataGridView.Size = new System.Drawing.Size(402, 302);
            this.knapDataDataGridView.TabIndex = 1;
            // 
            // SolutionsDataGridView
            // 
            this.SolutionsDataGridView.AllowUserToAddRows = false;
            this.SolutionsDataGridView.AllowUserToOrderColumns = true;
            this.SolutionsDataGridView.AutoGenerateColumns = false;
            this.SolutionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.SolutionsDataGridView.BackgroundColor = System.Drawing.Color.Khaki;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SolutionsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SolutionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SolutionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.Generations,
            this.dataGridViewTextBoxColumn7,
            this.Frequency,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn17,
            this.Okays,
            this.Chromosome,
            this.SchOrder,
            this.dataGridViewTextBoxColumn19});
            this.SolutionsDataGridView.DataSource = this.knapSolBS;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SolutionsDataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.SolutionsDataGridView.Location = new System.Drawing.Point(12, 503);
            this.SolutionsDataGridView.Name = "SolutionsDataGridView";
            this.SolutionsDataGridView.Size = new System.Drawing.Size(1177, 220);
            this.SolutionsDataGridView.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 743);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1209, 27);
            this.statusStrip1.TabIndex = 3;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 21);
            // 
            // gADataGridView
            // 
            this.gADataGridView.AllowUserToAddRows = false;
            this.gADataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Lavender;
            this.gADataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.gADataGridView.AutoGenerateColumns = false;
            this.gADataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gADataGridView.BackgroundColor = System.Drawing.Color.Thistle;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gADataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.gADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn33,
            this.ChromosomeLength,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn23,
            this.CrossProbability,
            this.CrossChromeMinLenght,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn22});
            this.gADataGridView.DataSource = this.gABS;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gADataGridView.DefaultCellStyle = dataGridViewCellStyle16;
            this.gADataGridView.Location = new System.Drawing.Point(420, 195);
            this.gADataGridView.Name = "gADataGridView";
            this.gADataGridView.Size = new System.Drawing.Size(769, 302);
            this.gADataGridView.TabIndex = 4;
            this.gADataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDoubleMouseclick);
            // 
            // ChromosomeLength
            // 
            this.ChromosomeLength.DataPropertyName = "ChromosomeLength";
            this.ChromosomeLength.HeaderText = "Chromosome Length";
            this.ChromosomeLength.Name = "ChromosomeLength";
            this.ChromosomeLength.Width = 157;
            // 
            // CrossProbability
            // 
            this.CrossProbability.DataPropertyName = "CrossProbability";
            dataGridViewCellStyle15.Format = "N4";
            this.CrossProbability.DefaultCellStyle = dataGridViewCellStyle15;
            this.CrossProbability.HeaderText = "CrossProbability";
            this.CrossProbability.Name = "CrossProbability";
            this.CrossProbability.Width = 141;
            // 
            // CrossChromeMinLenght
            // 
            this.CrossChromeMinLenght.DataPropertyName = "CrossChromeMinLenght";
            this.CrossChromeMinLenght.HeaderText = "CrossChromeMinLenght";
            this.CrossChromeMinLenght.Name = "CrossChromeMinLenght";
            this.CrossChromeMinLenght.Width = 191;
            // 
            // problemsDataGridView
            // 
            this.problemsDataGridView.AutoGenerateColumns = false;
            this.problemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.problemsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.problemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.problemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.problemIDDataGridViewTextBoxColumn,
            this.labelDataGridViewTextBoxColumn,
            this.minSizeDataGridViewTextBoxColumn,
            this.maxSizeDataGridViewTextBoxColumn,
            this.itersDataGridViewTextBoxColumn});
            this.problemsDataGridView.DataSource = this.problemsBS;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.problemsDataGridView.DefaultCellStyle = dataGridViewCellStyle18;
            this.problemsDataGridView.Location = new System.Drawing.Point(12, 45);
            this.problemsDataGridView.Name = "problemsDataGridView";
            this.problemsDataGridView.Size = new System.Drawing.Size(542, 144);
            this.problemsDataGridView.TabIndex = 5;
            this.problemsDataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDoubleMouseclick);
            // 
            // knapConditionsDataGridView
            // 
            this.knapConditionsDataGridView.AutoGenerateColumns = false;
            this.knapConditionsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.knapConditionsDataGridView.BackgroundColor = System.Drawing.Color.IndianRed;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.knapConditionsDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.knapConditionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knapConditionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn37,
            this.MaxWeight,
            this.MaxVolume,
            this.MaxValue,
            this.MinWeight,
            this.MinVolume,
            this.MinValue,
            this.WeightFine,
            this.VolumeFine,
            this.ValueFine,
            this.dataGridViewTextBoxColumn38});
            this.knapConditionsDataGridView.DataSource = this.knapConditionsBS;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.knapConditionsDataGridView.DefaultCellStyle = dataGridViewCellStyle20;
            this.knapConditionsDataGridView.Location = new System.Drawing.Point(573, 45);
            this.knapConditionsDataGridView.Name = "knapConditionsDataGridView";
            this.knapConditionsDataGridView.Size = new System.Drawing.Size(606, 144);
            this.knapConditionsDataGridView.TabIndex = 6;
            // 
            // MaxWeight
            // 
            this.MaxWeight.DataPropertyName = "MaxWeight";
            this.MaxWeight.HeaderText = "MaxWeight";
            this.MaxWeight.Name = "MaxWeight";
            this.MaxWeight.Width = 109;
            // 
            // MaxVolume
            // 
            this.MaxVolume.DataPropertyName = "MaxVolume";
            this.MaxVolume.HeaderText = "MaxVolume";
            this.MaxVolume.Name = "MaxVolume";
            this.MaxVolume.Width = 112;
            // 
            // MaxValue
            // 
            this.MaxValue.DataPropertyName = "MaxValue";
            this.MaxValue.HeaderText = "MaxValue";
            this.MaxValue.Name = "MaxValue";
            this.MaxValue.Width = 98;
            // 
            // MinWeight
            // 
            this.MinWeight.DataPropertyName = "MinWeight";
            this.MinWeight.HeaderText = "MinWeight";
            this.MinWeight.Name = "MinWeight";
            this.MinWeight.Width = 106;
            // 
            // MinVolume
            // 
            this.MinVolume.DataPropertyName = "MinVolume";
            this.MinVolume.HeaderText = "MinVolume";
            this.MinVolume.Name = "MinVolume";
            this.MinVolume.Width = 109;
            // 
            // MinValue
            // 
            this.MinValue.DataPropertyName = "MinValue";
            this.MinValue.HeaderText = "MinValue";
            this.MinValue.Name = "MinValue";
            this.MinValue.Width = 95;
            // 
            // WeightFine
            // 
            this.WeightFine.DataPropertyName = "WeightFine";
            this.WeightFine.HeaderText = "WeightFine";
            this.WeightFine.Name = "WeightFine";
            this.WeightFine.Width = 108;
            // 
            // VolumeFine
            // 
            this.VolumeFine.DataPropertyName = "VolumeFine";
            this.VolumeFine.HeaderText = "VolumeFine";
            this.VolumeFine.Name = "VolumeFine";
            this.VolumeFine.Width = 111;
            // 
            // ValueFine
            // 
            this.ValueFine.DataPropertyName = "ValueFine";
            this.ValueFine.HeaderText = "ValueFine";
            this.ValueFine.Name = "ValueFine";
            this.ValueFine.Width = 97;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn34.HeaderText = "ID";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Visible = false;
            this.dataGridViewTextBoxColumn34.Width = 49;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn37.HeaderText = "ID";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            this.dataGridViewTextBoxColumn37.Visible = false;
            this.dataGridViewTextBoxColumn37.Width = 49;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "ProblemID";
            this.dataGridViewTextBoxColumn38.HeaderText = "ProblemID";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.Width = 105;
            // 
            // knapConditionsBS
            // 
            this.knapConditionsBS.DataMember = "KnapConditions";
            this.knapConditionsBS.DataSource = this.gADataSet;
            // 
            // gADataSet
            // 
            this.gADataSet.DataSetName = "GADataSet";
            this.gADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Visible = false;
            this.iDDataGridViewTextBoxColumn.Width = 49;
            // 
            // problemIDDataGridViewTextBoxColumn
            // 
            this.problemIDDataGridViewTextBoxColumn.DataPropertyName = "ProblemID";
            this.problemIDDataGridViewTextBoxColumn.HeaderText = "ProblemID";
            this.problemIDDataGridViewTextBoxColumn.Name = "problemIDDataGridViewTextBoxColumn";
            this.problemIDDataGridViewTextBoxColumn.Width = 105;
            // 
            // labelDataGridViewTextBoxColumn
            // 
            this.labelDataGridViewTextBoxColumn.DataPropertyName = "Label";
            this.labelDataGridViewTextBoxColumn.HeaderText = "Label";
            this.labelDataGridViewTextBoxColumn.Name = "labelDataGridViewTextBoxColumn";
            this.labelDataGridViewTextBoxColumn.Width = 70;
            // 
            // minSizeDataGridViewTextBoxColumn
            // 
            this.minSizeDataGridViewTextBoxColumn.DataPropertyName = "MinSize";
            this.minSizeDataGridViewTextBoxColumn.HeaderText = "MinSize";
            this.minSizeDataGridViewTextBoxColumn.Name = "minSizeDataGridViewTextBoxColumn";
            this.minSizeDataGridViewTextBoxColumn.Width = 86;
            // 
            // maxSizeDataGridViewTextBoxColumn
            // 
            this.maxSizeDataGridViewTextBoxColumn.DataPropertyName = "MaxSize";
            this.maxSizeDataGridViewTextBoxColumn.HeaderText = "MaxSize";
            this.maxSizeDataGridViewTextBoxColumn.Name = "maxSizeDataGridViewTextBoxColumn";
            this.maxSizeDataGridViewTextBoxColumn.Width = 89;
            // 
            // itersDataGridViewTextBoxColumn
            // 
            this.itersDataGridViewTextBoxColumn.DataPropertyName = "Iters";
            this.itersDataGridViewTextBoxColumn.HeaderText = "Iters";
            this.itersDataGridViewTextBoxColumn.Name = "itersDataGridViewTextBoxColumn";
            this.itersDataGridViewTextBoxColumn.Width = 62;
            // 
            // problemsBS
            // 
            this.problemsBS.DataMember = "Problems";
            this.problemsBS.DataSource = this.gADataSet;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn20.HeaderText = "ID";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Visible = false;
            this.dataGridViewTextBoxColumn20.Width = 49;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Fitness";
            dataGridViewCellStyle12.Format = "N4";
            this.dataGridViewTextBoxColumn33.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn33.HeaderText = "Fitness";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.Width = 78;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "GenerationCurrent";
            this.dataGridViewTextBoxColumn30.HeaderText = "GenerationCurrent";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.Width = 155;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "GenerationTotal";
            this.dataGridViewTextBoxColumn29.HeaderText = "GenerationTotal";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Width = 140;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "TimeStamp";
            dataGridViewCellStyle13.Format = "N1";
            this.dataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn32.HeaderText = "TimeStamp";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.Width = 110;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "MutationProb";
            dataGridViewCellStyle14.Format = "N4";
            this.dataGridViewTextBoxColumn23.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn23.HeaderText = "MutationProb";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.Width = 125;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Termination";
            this.dataGridViewTextBoxColumn21.HeaderText = "Termination";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.Width = 113;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "GenerationStrategy";
            this.dataGridViewTextBoxColumn31.HeaderText = "GenerationStrategy";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.Width = 162;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "CrossParents";
            this.dataGridViewTextBoxColumn24.HeaderText = "CrossParents";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.Width = 116;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "CrossChildren";
            this.dataGridViewTextBoxColumn25.HeaderText = "CrossChildren";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.Width = 124;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "PopMin";
            this.dataGridViewTextBoxColumn27.HeaderText = "PopMin";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Width = 84;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "PopMax";
            this.dataGridViewTextBoxColumn28.HeaderText = "PopMax";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Width = 87;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "Population";
            this.dataGridViewTextBoxColumn26.HeaderText = "Population";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.Width = 105;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Crossover";
            this.dataGridViewTextBoxColumn22.HeaderText = "Crossover";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.Width = 98;
            // 
            // gABS
            // 
            this.gABS.DataMember = "GA";
            this.gABS.DataSource = this.gADataSet;
            // 
            // knapSolBS
            // 
            this.knapSolBS.DataMember = "Solutions";
            this.knapSolBS.DataSource = this.gADataSet;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 49;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProblemID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ProblemID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 105;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Weight";
            this.dataGridViewTextBoxColumn3.HeaderText = "Weight";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 81;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Volume";
            this.dataGridViewTextBoxColumn4.HeaderText = "Volume";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 84;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn5.HeaderText = "Value";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // knapDataBS
            // 
            this.knapDataBS.DataMember = "Data";
            this.knapDataBS.DataSource = this.gADataSet;
            // 
            // knapDataTA
            // 
            this.knapDataTA.ClearBeforeFill = true;
            // 
            // TAM
            // 
            this.TAM.BackupDataSetBeforeUpdate = false;
            this.TAM.DataTableAdapter = this.knapDataTA;
            this.TAM.GATableAdapter = this.gATA;
            this.TAM.KnapConditionsTableAdapter = this.KnapConditionTA;
            this.TAM.KnapStringsTableAdapter = this.knapStringsTableAdapter1;
            this.TAM.ProblemsTableAdapter = this.problemsTA;
            this.TAM.SolutionsTableAdapter = this.knapSolTA;
            this.TAM.UpdateOrder = GADB.GADataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gATA
            // 
            this.gATA.ClearBeforeFill = true;
            // 
            // KnapConditionTA
            // 
            this.KnapConditionTA.ClearBeforeFill = true;
            // 
            // knapStringsTableAdapter1
            // 
            this.knapStringsTableAdapter1.ClearBeforeFill = true;
            // 
            // problemsTA
            // 
            this.problemsTA.ClearBeforeFill = true;
            // 
            // knapSolTA
            // 
            this.knapSolTA.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 49;
            // 
            // Generations
            // 
            this.Generations.DataPropertyName = "Generations";
            this.Generations.HeaderText = "Generations";
            this.Generations.Name = "Generations";
            this.Generations.Width = 113;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ChromosomeLength";
            this.dataGridViewTextBoxColumn7.HeaderText = "ChromosomeLength";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 168;
            // 
            // Frequency
            // 
            this.Frequency.DataPropertyName = "Frequency";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Lime;
            this.Frequency.DefaultCellStyle = dataGridViewCellStyle4;
            this.Frequency.HeaderText = "Frequency";
            this.Frequency.Name = "Frequency";
            this.Frequency.Width = 101;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Fitness";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Cyan;
            dataGridViewCellStyle5.Format = "N4";
            this.dataGridViewTextBoxColumn16.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn16.HeaderText = "Fitness";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 78;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "TimeSpan";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.Format = "N3";
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn18.HeaderText = "Time";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.Width = 67;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Genotype";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Snow;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn14.HeaderText = "Genotype";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.Width = 98;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "DateTime";
            this.dataGridViewTextBoxColumn17.HeaderText = "Date";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.Width = 66;
            // 
            // Okays
            // 
            this.Okays.DataPropertyName = "Okays";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Okays.DefaultCellStyle = dataGridViewCellStyle8;
            this.Okays.HeaderText = "Okays";
            this.Okays.Name = "Okays";
            this.Okays.Width = 73;
            // 
            // Chromosome
            // 
            this.Chromosome.DataPropertyName = "Chromosome";
            this.Chromosome.HeaderText = "Chromosome";
            this.Chromosome.Name = "Chromosome";
            this.Chromosome.Width = 104;
            // 
            // SchOrder
            // 
            this.SchOrder.DataPropertyName = "SchOrder";
            this.SchOrder.HeaderText = "SchOrder";
            this.SchOrder.Name = "SchOrder";
            this.SchOrder.Width = 95;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "ProblemID";
            this.dataGridViewTextBoxColumn19.HeaderText = "Problem ID";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.Visible = false;
            this.dataGridViewTextBoxColumn19.Width = 109;
            // 
            // KnapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 770);
            this.Controls.Add(this.knapConditionsDataGridView);
            this.Controls.Add(this.problemsDataGridView);
            this.Controls.Add(this.gADataGridView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.SolutionsDataGridView);
            this.Controls.Add(this.knapDataDataGridView);
            this.Controls.Add(this.knapDataBindingNavigator);
            this.Name = "KnapForm";
            this.Text = "Knapsack GA - Fulvio Farina";
            this.Load += new System.EventHandler(this.KnapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.knapDataBindingNavigator)).EndInit();
            this.knapDataBindingNavigator.ResumeLayout(false);
            this.knapDataBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SolutionsDataGridView)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapConditionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapConditionsBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gABS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapSolBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GADataSet gADataSet;
        private System.Windows.Forms.BindingSource knapDataBS;
        private DataTableAdapter knapDataTA;
        private TableAdapterManager TAM;
        private System.Windows.Forms.BindingNavigator knapDataBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton knapDataBindingNavigatorSaveItem;
        private SolutionsTableAdapter knapSolTA;
        private System.Windows.Forms.DataGridView knapDataDataGridView;
        private System.Windows.Forms.BindingSource knapSolBS;
        private System.Windows.Forms.DataGridView SolutionsDataGridView;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripButton gobtn;
        private System.Windows.Forms.BindingSource gABS;
        private GATableAdapter gATA;
        private System.Windows.Forms.DataGridView gADataGridView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox minPopbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox maxPopBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox mutProbbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox crossProbbox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStripButton stopbtn;
        private System.Windows.Forms.ToolStripButton resumebtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.BindingSource problemsBS;
        private System.Windows.Forms.DataGridView problemsDataGridView;
        private ProblemsTableAdapter problemsTA;
        private System.Windows.Forms.BindingSource knapConditionsBS;
        private System.Windows.Forms.DataGridView knapConditionsDataGridView;
        private KnapConditionsTableAdapter KnapConditionTA;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChromosomeLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrossProbability;
        private System.Windows.Forms.DataGridViewTextBoxColumn CrossChromeMinLenght;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightFine;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolumeFine;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueFine;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn problemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn labelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn minSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxSizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton statsbtn;
        private KnapStringsTableAdapter knapStringsTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Generations;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Okays;
        private System.Windows.Forms.DataGridViewImageColumn Chromosome;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
    }
}

