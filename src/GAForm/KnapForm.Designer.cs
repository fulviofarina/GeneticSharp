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
            this.knapDataBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.knapDataBS = new System.Windows.Forms.BindingSource(this.components);
            this.gADataSet = new GADB.GADataSet();
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
            this.knapDataDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knapSolutionsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knapSolBS = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.gADataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrossProbability = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CrossChromeMinLenght = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gABS = new System.Windows.Forms.BindingSource(this.components);
            this.problemsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.problemsBS = new System.Windows.Forms.BindingSource(this.components);
            this.knapConditionsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.knapConditionsBS = new System.Windows.Forms.BindingSource(this.components);
            this.knapDataTA = new GADB.GADataSetTableAdapters.KnapDataTableAdapter();
            this.TAM = new GADB.GADataSetTableAdapters.TableAdapterManager();
            this.gATA = new GADB.GADataSetTableAdapters.GATableAdapter();
            this.KnapConditionTA = new GADB.GADataSetTableAdapters.KnapConditionsTableAdapter();
            this.knapSolTA = new GADB.GADataSetTableAdapters.KnapSolutionsTableAdapter();
            this.problemsTA = new GADB.GADataSetTableAdapters.ProblemsTableAdapter();
            this.chsizebox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataBindingNavigator)).BeginInit();
            this.knapDataBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapSolutionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapSolBS)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gADataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gABS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapConditionsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapConditionsBS)).BeginInit();
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
            this.toolStripLabel3,
            this.chsizebox,
            this.toolStripSeparator6,
            this.stopbtn,
            this.toolStripSeparator5,
            this.resumebtn});
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
            // knapDataBS
            // 
            this.knapDataBS.DataMember = "KnapData";
            this.knapDataBS.DataSource = this.gADataSet;
            // 
            // gADataSet
            // 
            this.gADataSet.DataSetName = "GADataSet";
            this.gADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // knapDataDataGridView
            // 
            this.knapDataDataGridView.AutoGenerateColumns = false;
            this.knapDataDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knapDataDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.knapDataDataGridView.DataSource = this.knapDataBS;
            this.knapDataDataGridView.Location = new System.Drawing.Point(12, 195);
            this.knapDataDataGridView.Name = "knapDataDataGridView";
            this.knapDataDataGridView.Size = new System.Drawing.Size(402, 302);
            this.knapDataDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProblemID";
            this.dataGridViewTextBoxColumn2.HeaderText = "ProblemID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Weight";
            this.dataGridViewTextBoxColumn3.HeaderText = "Weight";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Volume";
            this.dataGridViewTextBoxColumn4.HeaderText = "Volume";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Value";
            this.dataGridViewTextBoxColumn5.HeaderText = "Value";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // knapSolutionsDataGridView
            // 
            this.knapSolutionsDataGridView.AutoGenerateColumns = false;
            this.knapSolutionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knapSolutionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn7});
            this.knapSolutionsDataGridView.DataSource = this.knapSolBS;
            this.knapSolutionsDataGridView.Location = new System.Drawing.Point(12, 503);
            this.knapSolutionsDataGridView.Name = "knapSolutionsDataGridView";
            this.knapSolutionsDataGridView.Size = new System.Drawing.Size(1177, 220);
            this.knapSolutionsDataGridView.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Genotype";
            this.dataGridViewTextBoxColumn14.HeaderText = "Genotype";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "WeightString";
            this.dataGridViewTextBoxColumn11.HeaderText = "WeightString";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "VolumeString";
            this.dataGridViewTextBoxColumn12.HeaderText = "VolumeString";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "ValueString";
            this.dataGridViewTextBoxColumn13.HeaderText = "ValueString";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TotalWeight";
            this.dataGridViewTextBoxColumn8.HeaderText = "TotalWeight";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "TotalVolume";
            this.dataGridViewTextBoxColumn9.HeaderText = "TotalVolume";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TotalValue";
            this.dataGridViewTextBoxColumn10.HeaderText = "TotalValue";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Fine";
            this.dataGridViewTextBoxColumn15.HeaderText = "Fine";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Fitness";
            this.dataGridViewTextBoxColumn16.HeaderText = "Fitness";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "TimeSpan";
            this.dataGridViewTextBoxColumn18.HeaderText = "TimeSpan";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "ChromosomeLenght";
            this.dataGridViewTextBoxColumn19.HeaderText = "ChromosomeLenght";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "DateTime";
            this.dataGridViewTextBoxColumn17.HeaderText = "DateTime";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "ProblemID";
            this.dataGridViewTextBoxColumn7.HeaderText = "ProblemID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // knapSolBS
            // 
            this.knapSolBS.DataMember = "KnapSolutions";
            this.knapSolBS.DataSource = this.gADataSet;
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
            this.gADataGridView.AutoGenerateColumns = false;
            this.gADataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gADataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn33,
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
            this.gADataGridView.Location = new System.Drawing.Point(420, 195);
            this.gADataGridView.Name = "gADataGridView";
            this.gADataGridView.Size = new System.Drawing.Size(769, 302);
            this.gADataGridView.TabIndex = 4;
            this.gADataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDoubleMouseclick);
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn20.HeaderText = "ID";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Visible = false;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Fitness";
            this.dataGridViewTextBoxColumn33.HeaderText = "Fitness";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "GenerationCurrent";
            this.dataGridViewTextBoxColumn30.HeaderText = "GenerationCurrent";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "GenerationTotal";
            this.dataGridViewTextBoxColumn29.HeaderText = "GenerationTotal";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "TimeStamp";
            this.dataGridViewTextBoxColumn32.HeaderText = "TimeStamp";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "MutationProb";
            this.dataGridViewTextBoxColumn23.HeaderText = "MutationProb";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            // 
            // CrossProbability
            // 
            this.CrossProbability.DataPropertyName = "CrossProbability";
            this.CrossProbability.HeaderText = "CrossProbability";
            this.CrossProbability.Name = "CrossProbability";
            // 
            // CrossChromeMinLenght
            // 
            this.CrossChromeMinLenght.DataPropertyName = "CrossChromeMinLenght";
            this.CrossChromeMinLenght.HeaderText = "CrossChromeMinLenght";
            this.CrossChromeMinLenght.Name = "CrossChromeMinLenght";
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Termination";
            this.dataGridViewTextBoxColumn21.HeaderText = "Termination";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "GenerationStrategy";
            this.dataGridViewTextBoxColumn31.HeaderText = "GenerationStrategy";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "CrossParents";
            this.dataGridViewTextBoxColumn24.HeaderText = "CrossParents";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "CrossChildren";
            this.dataGridViewTextBoxColumn25.HeaderText = "CrossChildren";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "PopMin";
            this.dataGridViewTextBoxColumn27.HeaderText = "PopMin";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "PopMax";
            this.dataGridViewTextBoxColumn28.HeaderText = "PopMax";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "Population";
            this.dataGridViewTextBoxColumn26.HeaderText = "Population";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "Crossover";
            this.dataGridViewTextBoxColumn22.HeaderText = "Crossover";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            // 
            // gABS
            // 
            this.gABS.DataMember = "GA";
            this.gABS.DataSource = this.gADataSet;
            // 
            // problemsDataGridView
            // 
            this.problemsDataGridView.AutoGenerateColumns = false;
            this.problemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.problemsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36});
            this.problemsDataGridView.DataSource = this.problemsBS;
            this.problemsDataGridView.Location = new System.Drawing.Point(12, 45);
            this.problemsDataGridView.Name = "problemsDataGridView";
            this.problemsDataGridView.Size = new System.Drawing.Size(542, 144);
            this.problemsDataGridView.TabIndex = 5;
            this.problemsDataGridView.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDoubleMouseclick);
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn34.HeaderText = "ID";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "ProblemID";
            this.dataGridViewTextBoxColumn35.HeaderText = "ProblemID";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "Label";
            this.dataGridViewTextBoxColumn36.HeaderText = "Label";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            // 
            // problemsBS
            // 
            this.problemsBS.DataMember = "Problems";
            this.problemsBS.DataSource = this.gADataSet;
            // 
            // knapConditionsDataGridView
            // 
            this.knapConditionsDataGridView.AutoGenerateColumns = false;
            this.knapConditionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.knapConditionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn42});
            this.knapConditionsDataGridView.DataSource = this.knapConditionsBS;
            this.knapConditionsDataGridView.Location = new System.Drawing.Point(573, 45);
            this.knapConditionsDataGridView.Name = "knapConditionsDataGridView";
            this.knapConditionsDataGridView.Size = new System.Drawing.Size(606, 144);
            this.knapConditionsDataGridView.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn37.HeaderText = "ID";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "ProblemID";
            this.dataGridViewTextBoxColumn38.HeaderText = "ProblemID";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "TotalWeight";
            this.dataGridViewTextBoxColumn39.HeaderText = "TotalWeight";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "TotalVolume";
            this.dataGridViewTextBoxColumn40.HeaderText = "TotalVolume";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "TotalValue";
            this.dataGridViewTextBoxColumn41.HeaderText = "TotalValue";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "Fine";
            this.dataGridViewTextBoxColumn42.HeaderText = "Fine";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            // 
            // knapConditionsBS
            // 
            this.knapConditionsBS.DataMember = "KnapConditions";
            this.knapConditionsBS.DataSource = this.gADataSet;
            // 
            // knapDataTA
            // 
            this.knapDataTA.ClearBeforeFill = true;
            // 
            // TAM
            // 
            this.TAM.BackupDataSetBeforeUpdate = false;
            this.TAM.GATableAdapter = this.gATA;
            this.TAM.KnapConditionsTableAdapter = this.KnapConditionTA;
            this.TAM.KnapDataTableAdapter = this.knapDataTA;
            this.TAM.KnapSolutionsTableAdapter = this.knapSolTA;
            this.TAM.ProblemsTableAdapter = this.problemsTA;
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
            // knapSolTA
            // 
            this.knapSolTA.ClearBeforeFill = true;
            // 
            // problemsTA
            // 
            this.problemsTA.ClearBeforeFill = true;
            // 
            // chsizebox
            // 
            this.chsizebox.Name = "chsizebox";
            this.chsizebox.Size = new System.Drawing.Size(70, 29);
            this.chsizebox.Text = "6";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(62, 26);
            this.toolStripLabel3.Text = "Ch. size";
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
            this.Controls.Add(this.knapSolutionsDataGridView);
            this.Controls.Add(this.knapDataDataGridView);
            this.Controls.Add(this.knapDataBindingNavigator);
            this.Name = "KnapForm";
            this.Text = "Knapsack GA - Fulvio Farina";
            this.Load += new System.EventHandler(this.KnapForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.knapDataBindingNavigator)).EndInit();
            this.knapDataBindingNavigator.ResumeLayout(false);
            this.knapDataBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapDataDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapSolutionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapSolBS)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gADataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gABS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.problemsBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapConditionsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.knapConditionsBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GADataSet gADataSet;
        private System.Windows.Forms.BindingSource knapDataBS;
        private KnapDataTableAdapter knapDataTA;
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
        private KnapSolutionsTableAdapter knapSolTA;
        private System.Windows.Forms.DataGridView knapDataDataGridView;
        private System.Windows.Forms.BindingSource knapSolBS;
        private System.Windows.Forms.DataGridView knapSolutionsDataGridView;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
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
        private System.Windows.Forms.ToolStripButton stopbtn;
        private System.Windows.Forms.ToolStripButton resumebtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.BindingSource problemsBS;
        private System.Windows.Forms.DataGridView problemsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private ProblemsTableAdapter problemsTA;
        private System.Windows.Forms.BindingSource knapConditionsBS;
        private System.Windows.Forms.DataGridView knapConditionsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private KnapConditionsTableAdapter KnapConditionTA;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox chsizebox;
    }
}

