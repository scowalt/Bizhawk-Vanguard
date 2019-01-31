﻿namespace RTCV.UI
{
	partial class RTC_CustomEngineConfig_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RTC_CustomEngineConfig_Form));
            this.cbLockUnits = new System.Windows.Forms.CheckBox();
            this.btnClearActive = new System.Windows.Forms.Button();
            this.nmMaxInfinite = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gbUnitSource = new System.Windows.Forms.GroupBox();
            this.rbUnitSourceStore = new System.Windows.Forms.RadioButton();
            this.rbUnitSourceValue = new System.Windows.Forms.RadioButton();
            this.gbValueList = new System.Windows.Forms.GroupBox();
            this.cbValueList = new System.Windows.Forms.ComboBox();
            this.gbValueSource = new System.Windows.Forms.GroupBox();
            this.rbRange = new System.Windows.Forms.RadioButton();
            this.rbValueList = new System.Windows.Forms.RadioButton();
            this.rbRandom = new System.Windows.Forms.RadioButton();
            this.gbValueRange = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.nmMaxValue = new RTCV.UI.NumericUpDownHexFix();
            this.nmMinValue = new RTCV.UI.NumericUpDownHexFix();
            this.gbLimiterList = new System.Windows.Forms.GroupBox();
            this.cbLimiterInverted = new System.Windows.Forms.CheckBox();
            this.rbLimiterNone = new System.Windows.Forms.RadioButton();
            this.rbLimiterExecute = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.rbLimiterFirstExecute = new System.Windows.Forms.RadioButton();
            this.rbLimiterGenerate = new System.Windows.Forms.RadioButton();
            this.cbLimiterList = new System.Windows.Forms.ComboBox();
            this.cbClearRewind = new System.Windows.Forms.CheckBox();
            this.cbLoopUnit = new System.Windows.Forms.CheckBox();
            this.gbStepSettings = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nmTilt = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.nmDelay = new System.Windows.Forms.NumericUpDown();
            this.nmLifetime = new System.Windows.Forms.NumericUpDown();
            this.gbCheckBoxes = new System.Windows.Forms.GroupBox();
            this.gbStoreTime = new System.Windows.Forms.GroupBox();
            this.rbStoreFirstExecute = new System.Windows.Forms.RadioButton();
            this.rbStoreImmediate = new System.Windows.Forms.RadioButton();
            this.rbStoreSame = new System.Windows.Forms.RadioButton();
            this.rbStoreRandom = new System.Windows.Forms.RadioButton();
            this.gbStoreType = new System.Windows.Forms.GroupBox();
            this.rbStoreStep = new System.Windows.Forms.RadioButton();
            this.rbStoreOnce = new System.Windows.Forms.RadioButton();
            this.gbBackupSource = new System.Windows.Forms.GroupBox();
            this.btnResetConfig = new System.Windows.Forms.Button();
            this.pnTopBar = new System.Windows.Forms.Panel();
            this.btnCustomTemplateSaveAs = new System.Windows.Forms.Button();
            this.btnCustomTemplateLoad = new System.Windows.Forms.Button();
            this.btnCustomTemplateSave = new System.Windows.Forms.Button();
            this.cbSelectedTemplate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxInfinite)).BeginInit();
            this.gbUnitSource.SuspendLayout();
            this.gbValueList.SuspendLayout();
            this.gbValueSource.SuspendLayout();
            this.gbValueRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinValue)).BeginInit();
            this.gbLimiterList.SuspendLayout();
            this.gbStepSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTilt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmLifetime)).BeginInit();
            this.gbCheckBoxes.SuspendLayout();
            this.gbStoreTime.SuspendLayout();
            this.gbStoreType.SuspendLayout();
            this.gbBackupSource.SuspendLayout();
            this.pnTopBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLockUnits
            // 
            this.cbLockUnits.AutoSize = true;
            this.cbLockUnits.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbLockUnits.ForeColor = System.Drawing.Color.White;
            this.cbLockUnits.Location = new System.Drawing.Point(6, 17);
            this.cbLockUnits.Name = "cbLockUnits";
            this.cbLockUnits.Size = new System.Drawing.Size(95, 23);
            this.cbLockUnits.TabIndex = 151;
            this.cbLockUnits.Text = "Lock Units";
            this.cbLockUnits.UseVisualStyleBackColor = true;
            this.cbLockUnits.CheckedChanged += new System.EventHandler(this.cbLockUnits_CheckedChanged);
            // 
            // btnClearActive
            // 
            this.btnClearActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClearActive.FlatAppearance.BorderSize = 0;
            this.btnClearActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearActive.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnClearActive.ForeColor = System.Drawing.Color.Black;
            this.btnClearActive.Location = new System.Drawing.Point(15, 305);
            this.btnClearActive.Name = "btnClearActive";
            this.btnClearActive.Size = new System.Drawing.Size(154, 24);
            this.btnClearActive.TabIndex = 150;
            this.btnClearActive.TabStop = false;
            this.btnClearActive.Tag = "color:light";
            this.btnClearActive.Text = "Clear all active units";
            this.btnClearActive.UseVisualStyleBackColor = false;
            this.btnClearActive.Click += new System.EventHandler(this.btnClearActive_Click);
            // 
            // nmMaxInfinite
            // 
            this.nmMaxInfinite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nmMaxInfinite.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.nmMaxInfinite.ForeColor = System.Drawing.Color.White;
            this.nmMaxInfinite.Location = new System.Drawing.Point(6, 80);
            this.nmMaxInfinite.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.nmMaxInfinite.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmMaxInfinite.Name = "nmMaxInfinite";
            this.nmMaxInfinite.Size = new System.Drawing.Size(106, 25);
            this.nmMaxInfinite.TabIndex = 149;
            this.nmMaxInfinite.Tag = "color:dark";
            this.nmMaxInfinite.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nmMaxInfinite.ValueChanged += new System.EventHandler(this.nmMaxInfinite_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 19);
            this.label1.TabIndex = 148;
            this.label1.Text = "Max Infinite Units:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gbUnitSource
            // 
            this.gbUnitSource.Controls.Add(this.rbUnitSourceStore);
            this.gbUnitSource.Controls.Add(this.rbUnitSourceValue);
            this.gbUnitSource.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbUnitSource.ForeColor = System.Drawing.Color.White;
            this.gbUnitSource.Location = new System.Drawing.Point(15, 12);
            this.gbUnitSource.Name = "gbUnitSource";
            this.gbUnitSource.Size = new System.Drawing.Size(98, 54);
            this.gbUnitSource.TabIndex = 161;
            this.gbUnitSource.TabStop = false;
            this.gbUnitSource.Text = "Unit Source";
            // 
            // rbUnitSourceStore
            // 
            this.rbUnitSourceStore.AutoSize = true;
            this.rbUnitSourceStore.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbUnitSourceStore.ForeColor = System.Drawing.Color.White;
            this.rbUnitSourceStore.Location = new System.Drawing.Point(6, 31);
            this.rbUnitSourceStore.Name = "rbUnitSourceStore";
            this.rbUnitSourceStore.Size = new System.Drawing.Size(62, 23);
            this.rbUnitSourceStore.TabIndex = 1;
            this.rbUnitSourceStore.Text = "Store";
            this.rbUnitSourceStore.UseVisualStyleBackColor = true;
            this.rbUnitSourceStore.CheckedChanged += new System.EventHandler(this.unitSource_CheckedChanged);
            // 
            // rbUnitSourceValue
            // 
            this.rbUnitSourceValue.AutoSize = true;
            this.rbUnitSourceValue.Checked = true;
            this.rbUnitSourceValue.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbUnitSourceValue.ForeColor = System.Drawing.Color.White;
            this.rbUnitSourceValue.Location = new System.Drawing.Point(6, 14);
            this.rbUnitSourceValue.Name = "rbUnitSourceValue";
            this.rbUnitSourceValue.Size = new System.Drawing.Size(63, 23);
            this.rbUnitSourceValue.TabIndex = 0;
            this.rbUnitSourceValue.TabStop = true;
            this.rbUnitSourceValue.Text = "Value";
            this.rbUnitSourceValue.UseVisualStyleBackColor = true;
            this.rbUnitSourceValue.CheckedChanged += new System.EventHandler(this.unitSource_CheckedChanged);
            // 
            // gbValueList
            // 
            this.gbValueList.Controls.Add(this.cbValueList);
            this.gbValueList.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbValueList.ForeColor = System.Drawing.Color.White;
            this.gbValueList.Location = new System.Drawing.Point(260, 10);
            this.gbValueList.Name = "gbValueList";
            this.gbValueList.Size = new System.Drawing.Size(144, 66);
            this.gbValueList.TabIndex = 167;
            this.gbValueList.TabStop = false;
            this.gbValueList.Text = "Value List";
            // 
            // cbValueList
            // 
            this.cbValueList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbValueList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbValueList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbValueList.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbValueList.ForeColor = System.Drawing.Color.White;
            this.cbValueList.FormattingEnabled = true;
            this.cbValueList.Location = new System.Drawing.Point(12, 24);
            this.cbValueList.Name = "cbValueList";
            this.cbValueList.Size = new System.Drawing.Size(115, 25);
            this.cbValueList.TabIndex = 87;
            this.cbValueList.Tag = "color:dark";
            this.cbValueList.SelectedIndexChanged += new System.EventHandler(this.cbValueList_SelectedIndexChanged);
            // 
            // gbValueSource
            // 
            this.gbValueSource.Controls.Add(this.rbRange);
            this.gbValueSource.Controls.Add(this.rbValueList);
            this.gbValueSource.Controls.Add(this.rbRandom);
            this.gbValueSource.Controls.Add(this.gbValueRange);
            this.gbValueSource.Controls.Add(this.gbValueList);
            this.gbValueSource.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbValueSource.ForeColor = System.Drawing.Color.White;
            this.gbValueSource.Location = new System.Drawing.Point(15, 91);
            this.gbValueSource.Name = "gbValueSource";
            this.gbValueSource.Size = new System.Drawing.Size(419, 85);
            this.gbValueSource.TabIndex = 169;
            this.gbValueSource.TabStop = false;
            this.gbValueSource.Text = "Value Source";
            // 
            // rbRange
            // 
            this.rbRange.AutoSize = true;
            this.rbRange.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbRange.ForeColor = System.Drawing.Color.White;
            this.rbRange.Location = new System.Drawing.Point(6, 36);
            this.rbRange.Name = "rbRange";
            this.rbRange.Size = new System.Drawing.Size(68, 23);
            this.rbRange.TabIndex = 180;
            this.rbRange.Text = "Range";
            this.rbRange.UseVisualStyleBackColor = true;
            this.rbRange.CheckedChanged += new System.EventHandler(this.valueSource_CheckedChanged);
            // 
            // rbValueList
            // 
            this.rbValueList.AutoSize = true;
            this.rbValueList.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbValueList.ForeColor = System.Drawing.Color.White;
            this.rbValueList.Location = new System.Drawing.Point(6, 54);
            this.rbValueList.Name = "rbValueList";
            this.rbValueList.Size = new System.Drawing.Size(88, 23);
            this.rbValueList.TabIndex = 177;
            this.rbValueList.Text = "Value List";
            this.rbValueList.UseVisualStyleBackColor = true;
            this.rbValueList.CheckedChanged += new System.EventHandler(this.valueSource_CheckedChanged);
            // 
            // rbRandom
            // 
            this.rbRandom.AutoSize = true;
            this.rbRandom.Checked = true;
            this.rbRandom.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbRandom.ForeColor = System.Drawing.Color.White;
            this.rbRandom.Location = new System.Drawing.Point(6, 18);
            this.rbRandom.Name = "rbRandom";
            this.rbRandom.Size = new System.Drawing.Size(81, 23);
            this.rbRandom.TabIndex = 176;
            this.rbRandom.TabStop = true;
            this.rbRandom.Text = "Random";
            this.rbRandom.UseVisualStyleBackColor = true;
            this.rbRandom.CheckedChanged += new System.EventHandler(this.valueSource_CheckedChanged);
            // 
            // gbValueRange
            // 
            this.gbValueRange.Controls.Add(this.label26);
            this.gbValueRange.Controls.Add(this.label27);
            this.gbValueRange.Controls.Add(this.nmMaxValue);
            this.gbValueRange.Controls.Add(this.nmMinValue);
            this.gbValueRange.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbValueRange.ForeColor = System.Drawing.Color.White;
            this.gbValueRange.Location = new System.Drawing.Point(107, 10);
            this.gbValueRange.Name = "gbValueRange";
            this.gbValueRange.Size = new System.Drawing.Size(148, 66);
            this.gbValueRange.TabIndex = 166;
            this.gbValueRange.TabStop = false;
            this.gbValueRange.Text = "Range";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(6, 38);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(72, 19);
            this.label26.TabIndex = 169;
            this.label26.Text = "Max Value";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label27.ForeColor = System.Drawing.Color.White;
            this.label27.Location = new System.Drawing.Point(6, 17);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 19);
            this.label27.TabIndex = 166;
            this.label27.Text = "Min Value";
            // 
            // nmMaxValue
            // 
            this.nmMaxValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nmMaxValue.Font = new System.Drawing.Font("Consolas", 8F);
            this.nmMaxValue.ForeColor = System.Drawing.Color.White;
            this.nmMaxValue.Hexadecimal = true;
            this.nmMaxValue.Location = new System.Drawing.Point(67, 38);
            this.nmMaxValue.Name = "nmMaxValue";
            this.nmMaxValue.Size = new System.Drawing.Size(70, 23);
            this.nmMaxValue.TabIndex = 168;
            this.nmMaxValue.Tag = "color:dark";
            this.nmMaxValue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nmMaxValue.ValueChanged += new System.EventHandler(this.nmMaxValue_ValueChanged);
            // 
            // nmMinValue
            // 
            this.nmMinValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nmMinValue.Font = new System.Drawing.Font("Consolas", 8F);
            this.nmMinValue.ForeColor = System.Drawing.Color.White;
            this.nmMinValue.Hexadecimal = true;
            this.nmMinValue.Location = new System.Drawing.Point(67, 13);
            this.nmMinValue.Name = "nmMinValue";
            this.nmMinValue.Size = new System.Drawing.Size(70, 23);
            this.nmMinValue.TabIndex = 167;
            this.nmMinValue.Tag = "color:dark";
            this.nmMinValue.ValueChanged += new System.EventHandler(this.nmMinValue_ValueChanged);
            // 
            // gbLimiterList
            // 
            this.gbLimiterList.Controls.Add(this.cbLimiterInverted);
            this.gbLimiterList.Controls.Add(this.rbLimiterNone);
            this.gbLimiterList.Controls.Add(this.rbLimiterExecute);
            this.gbLimiterList.Controls.Add(this.label7);
            this.gbLimiterList.Controls.Add(this.rbLimiterFirstExecute);
            this.gbLimiterList.Controls.Add(this.rbLimiterGenerate);
            this.gbLimiterList.Controls.Add(this.cbLimiterList);
            this.gbLimiterList.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbLimiterList.ForeColor = System.Drawing.Color.White;
            this.gbLimiterList.Location = new System.Drawing.Point(300, 186);
            this.gbLimiterList.Name = "gbLimiterList";
            this.gbLimiterList.Size = new System.Drawing.Size(134, 143);
            this.gbLimiterList.TabIndex = 181;
            this.gbLimiterList.TabStop = false;
            this.gbLimiterList.Text = "Limiter List";
            // 
            // cbLimiterInverted
            // 
            this.cbLimiterInverted.AutoSize = true;
            this.cbLimiterInverted.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbLimiterInverted.ForeColor = System.Drawing.Color.White;
            this.cbLimiterInverted.Location = new System.Drawing.Point(9, 43);
            this.cbLimiterInverted.Name = "cbLimiterInverted";
            this.cbLimiterInverted.Size = new System.Drawing.Size(82, 23);
            this.cbLimiterInverted.TabIndex = 183;
            this.cbLimiterInverted.Text = "Inverted";
            this.cbLimiterInverted.UseVisualStyleBackColor = true;
            this.cbLimiterInverted.CheckedChanged += new System.EventHandler(this.cbLimiterInverted_CheckedChanged);
            // 
            // rbLimiterNone
            // 
            this.rbLimiterNone.AutoSize = true;
            this.rbLimiterNone.Checked = true;
            this.rbLimiterNone.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbLimiterNone.ForeColor = System.Drawing.Color.White;
            this.rbLimiterNone.Location = new System.Drawing.Point(9, 76);
            this.rbLimiterNone.Name = "rbLimiterNone";
            this.rbLimiterNone.Size = new System.Drawing.Size(63, 23);
            this.rbLimiterNone.TabIndex = 187;
            this.rbLimiterNone.TabStop = true;
            this.rbLimiterNone.Text = "None";
            this.rbLimiterNone.UseVisualStyleBackColor = true;
            this.rbLimiterNone.CheckedChanged += new System.EventHandler(this.limiterTime_CheckedChanged);
            // 
            // rbLimiterExecute
            // 
            this.rbLimiterExecute.AutoSize = true;
            this.rbLimiterExecute.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbLimiterExecute.ForeColor = System.Drawing.Color.White;
            this.rbLimiterExecute.Location = new System.Drawing.Point(9, 123);
            this.rbLimiterExecute.Name = "rbLimiterExecute";
            this.rbLimiterExecute.Size = new System.Drawing.Size(76, 23);
            this.rbLimiterExecute.TabIndex = 186;
            this.rbLimiterExecute.Text = "Execute";
            this.rbLimiterExecute.UseVisualStyleBackColor = true;
            this.rbLimiterExecute.CheckedChanged += new System.EventHandler(this.limiterTime_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(6, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 19);
            this.label7.TabIndex = 185;
            this.label7.Text = "Limiter Time";
            // 
            // rbLimiterFirstExecute
            // 
            this.rbLimiterFirstExecute.AutoSize = true;
            this.rbLimiterFirstExecute.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbLimiterFirstExecute.ForeColor = System.Drawing.Color.White;
            this.rbLimiterFirstExecute.Location = new System.Drawing.Point(9, 108);
            this.rbLimiterFirstExecute.Name = "rbLimiterFirstExecute";
            this.rbLimiterFirstExecute.Size = new System.Drawing.Size(106, 23);
            this.rbLimiterFirstExecute.TabIndex = 184;
            this.rbLimiterFirstExecute.Text = "First Execute";
            this.rbLimiterFirstExecute.UseVisualStyleBackColor = true;
            this.rbLimiterFirstExecute.CheckedChanged += new System.EventHandler(this.limiterTime_CheckedChanged);
            // 
            // rbLimiterGenerate
            // 
            this.rbLimiterGenerate.AutoSize = true;
            this.rbLimiterGenerate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbLimiterGenerate.ForeColor = System.Drawing.Color.White;
            this.rbLimiterGenerate.Location = new System.Drawing.Point(9, 92);
            this.rbLimiterGenerate.Name = "rbLimiterGenerate";
            this.rbLimiterGenerate.Size = new System.Drawing.Size(86, 23);
            this.rbLimiterGenerate.TabIndex = 183;
            this.rbLimiterGenerate.Text = "Generate";
            this.rbLimiterGenerate.UseVisualStyleBackColor = true;
            this.rbLimiterGenerate.CheckedChanged += new System.EventHandler(this.limiterTime_CheckedChanged);
            // 
            // cbLimiterList
            // 
            this.cbLimiterList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbLimiterList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLimiterList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLimiterList.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbLimiterList.ForeColor = System.Drawing.Color.White;
            this.cbLimiterList.FormattingEnabled = true;
            this.cbLimiterList.Location = new System.Drawing.Point(9, 18);
            this.cbLimiterList.Name = "cbLimiterList";
            this.cbLimiterList.Size = new System.Drawing.Size(115, 25);
            this.cbLimiterList.TabIndex = 87;
            this.cbLimiterList.Tag = "color:dark";
            this.cbLimiterList.SelectedIndexChanged += new System.EventHandler(this.cbLimiterList_SelectedIndexChanged);
            // 
            // cbClearRewind
            // 
            this.cbClearRewind.AutoSize = true;
            this.cbClearRewind.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbClearRewind.ForeColor = System.Drawing.Color.White;
            this.cbClearRewind.Location = new System.Drawing.Point(6, 35);
            this.cbClearRewind.Name = "cbClearRewind";
            this.cbClearRewind.Size = new System.Drawing.Size(130, 23);
            this.cbClearRewind.TabIndex = 182;
            this.cbClearRewind.Text = "Clear on Rewind";
            this.cbClearRewind.UseVisualStyleBackColor = true;
            this.cbClearRewind.CheckedChanged += new System.EventHandler(this.cbClearRewind_CheckedChanged);
            // 
            // cbLoopUnit
            // 
            this.cbLoopUnit.AutoSize = true;
            this.cbLoopUnit.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbLoopUnit.ForeColor = System.Drawing.Color.White;
            this.cbLoopUnit.Location = new System.Drawing.Point(9, 90);
            this.cbLoopUnit.Name = "cbLoopUnit";
            this.cbLoopUnit.Size = new System.Drawing.Size(166, 23);
            this.cbLoopUnit.TabIndex = 183;
            this.cbLoopUnit.Text = "Loop Generated Units";
            this.cbLoopUnit.UseVisualStyleBackColor = true;
            this.cbLoopUnit.CheckedChanged += new System.EventHandler(this.cbLoopUnit_CheckedChanged);
            // 
            // gbStepSettings
            // 
            this.gbStepSettings.Controls.Add(this.label11);
            this.gbStepSettings.Controls.Add(this.nmTilt);
            this.gbStepSettings.Controls.Add(this.cbLoopUnit);
            this.gbStepSettings.Controls.Add(this.label9);
            this.gbStepSettings.Controls.Add(this.label10);
            this.gbStepSettings.Controls.Add(this.nmDelay);
            this.gbStepSettings.Controls.Add(this.nmLifetime);
            this.gbStepSettings.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbStepSettings.ForeColor = System.Drawing.Color.White;
            this.gbStepSettings.Location = new System.Drawing.Point(15, 186);
            this.gbStepSettings.Name = "gbStepSettings";
            this.gbStepSettings.Size = new System.Drawing.Size(154, 113);
            this.gbStepSettings.TabIndex = 188;
            this.gbStepSettings.TabStop = false;
            this.gbStepSettings.Text = "Modifiers";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(6, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 19);
            this.label11.TabIndex = 191;
            this.label11.Text = "Tilt";
            // 
            // nmTilt
            // 
            this.nmTilt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nmTilt.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.nmTilt.ForeColor = System.Drawing.Color.White;
            this.nmTilt.Location = new System.Drawing.Point(75, 63);
            this.nmTilt.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nmTilt.Minimum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            -2147483648});
            this.nmTilt.Name = "nmTilt";
            this.nmTilt.Size = new System.Drawing.Size(70, 25);
            this.nmTilt.TabIndex = 190;
            this.nmTilt.Tag = "color:dark";
            this.nmTilt.ValueChanged += new System.EventHandler(this.nmTilt_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(6, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 19);
            this.label9.TabIndex = 188;
            this.label9.Text = "Lifetime";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(6, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 19);
            this.label10.TabIndex = 189;
            this.label10.Text = "Delay";
            // 
            // nmDelay
            // 
            this.nmDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nmDelay.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.nmDelay.ForeColor = System.Drawing.Color.White;
            this.nmDelay.Location = new System.Drawing.Point(75, 38);
            this.nmDelay.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nmDelay.Name = "nmDelay";
            this.nmDelay.Size = new System.Drawing.Size(70, 25);
            this.nmDelay.TabIndex = 187;
            this.nmDelay.Tag = "color:dark";
            this.nmDelay.ValueChanged += new System.EventHandler(this.nmDelay_ValueChanged);
            // 
            // nmLifetime
            // 
            this.nmLifetime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nmLifetime.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.nmLifetime.ForeColor = System.Drawing.Color.White;
            this.nmLifetime.Location = new System.Drawing.Point(75, 13);
            this.nmLifetime.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.nmLifetime.Name = "nmLifetime";
            this.nmLifetime.Size = new System.Drawing.Size(70, 25);
            this.nmLifetime.TabIndex = 185;
            this.nmLifetime.Tag = "color:dark";
            this.nmLifetime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmLifetime.ValueChanged += new System.EventHandler(this.nmLifetime_ValueChanged);
            // 
            // gbCheckBoxes
            // 
            this.gbCheckBoxes.Controls.Add(this.cbLockUnits);
            this.gbCheckBoxes.Controls.Add(this.cbClearRewind);
            this.gbCheckBoxes.Controls.Add(this.nmMaxInfinite);
            this.gbCheckBoxes.Controls.Add(this.label1);
            this.gbCheckBoxes.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbCheckBoxes.ForeColor = System.Drawing.Color.White;
            this.gbCheckBoxes.Location = new System.Drawing.Point(175, 186);
            this.gbCheckBoxes.Name = "gbCheckBoxes";
            this.gbCheckBoxes.Size = new System.Drawing.Size(118, 113);
            this.gbCheckBoxes.TabIndex = 189;
            this.gbCheckBoxes.TabStop = false;
            this.gbCheckBoxes.Text = "Misc";
            // 
            // gbStoreTime
            // 
            this.gbStoreTime.Controls.Add(this.rbStoreFirstExecute);
            this.gbStoreTime.Controls.Add(this.rbStoreImmediate);
            this.gbStoreTime.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbStoreTime.ForeColor = System.Drawing.Color.White;
            this.gbStoreTime.Location = new System.Drawing.Point(85, 10);
            this.gbStoreTime.Name = "gbStoreTime";
            this.gbStoreTime.Size = new System.Drawing.Size(104, 55);
            this.gbStoreTime.TabIndex = 0;
            this.gbStoreTime.TabStop = false;
            this.gbStoreTime.Text = "Start Storing";
            // 
            // rbStoreFirstExecute
            // 
            this.rbStoreFirstExecute.AutoSize = true;
            this.rbStoreFirstExecute.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbStoreFirstExecute.ForeColor = System.Drawing.Color.White;
            this.rbStoreFirstExecute.Location = new System.Drawing.Point(6, 33);
            this.rbStoreFirstExecute.Name = "rbStoreFirstExecute";
            this.rbStoreFirstExecute.Size = new System.Drawing.Size(106, 23);
            this.rbStoreFirstExecute.TabIndex = 181;
            this.rbStoreFirstExecute.Text = "First Execute";
            this.rbStoreFirstExecute.UseVisualStyleBackColor = true;
            this.rbStoreFirstExecute.CheckedChanged += new System.EventHandler(this.storeTime_CheckedChanged);
            // 
            // rbStoreImmediate
            // 
            this.rbStoreImmediate.AutoSize = true;
            this.rbStoreImmediate.Checked = true;
            this.rbStoreImmediate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbStoreImmediate.ForeColor = System.Drawing.Color.White;
            this.rbStoreImmediate.Location = new System.Drawing.Point(6, 16);
            this.rbStoreImmediate.Name = "rbStoreImmediate";
            this.rbStoreImmediate.Size = new System.Drawing.Size(95, 23);
            this.rbStoreImmediate.TabIndex = 180;
            this.rbStoreImmediate.TabStop = true;
            this.rbStoreImmediate.Text = "Immediate";
            this.rbStoreImmediate.UseVisualStyleBackColor = true;
            this.rbStoreImmediate.CheckedChanged += new System.EventHandler(this.storeTime_CheckedChanged);
            // 
            // rbStoreSame
            // 
            this.rbStoreSame.AutoSize = true;
            this.rbStoreSame.Checked = true;
            this.rbStoreSame.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbStoreSame.ForeColor = System.Drawing.Color.White;
            this.rbStoreSame.Location = new System.Drawing.Point(6, 17);
            this.rbStoreSame.Name = "rbStoreSame";
            this.rbStoreSame.Size = new System.Drawing.Size(63, 23);
            this.rbStoreSame.TabIndex = 180;
            this.rbStoreSame.TabStop = true;
            this.rbStoreSame.Text = "Same";
            this.rbStoreSame.UseVisualStyleBackColor = true;
            this.rbStoreSame.CheckedChanged += new System.EventHandler(this.storeAddress_CheckedChanged);
            // 
            // rbStoreRandom
            // 
            this.rbStoreRandom.AutoSize = true;
            this.rbStoreRandom.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbStoreRandom.ForeColor = System.Drawing.Color.White;
            this.rbStoreRandom.Location = new System.Drawing.Point(6, 34);
            this.rbStoreRandom.Name = "rbStoreRandom";
            this.rbStoreRandom.Size = new System.Drawing.Size(81, 23);
            this.rbStoreRandom.TabIndex = 181;
            this.rbStoreRandom.Text = "Random";
            this.rbStoreRandom.UseVisualStyleBackColor = true;
            this.rbStoreRandom.CheckedChanged += new System.EventHandler(this.storeAddress_CheckedChanged);
            // 
            // gbStoreType
            // 
            this.gbStoreType.Controls.Add(this.rbStoreStep);
            this.gbStoreType.Controls.Add(this.rbStoreOnce);
            this.gbStoreType.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbStoreType.ForeColor = System.Drawing.Color.White;
            this.gbStoreType.Location = new System.Drawing.Point(195, 10);
            this.gbStoreType.Name = "gbStoreType";
            this.gbStoreType.Size = new System.Drawing.Size(100, 55);
            this.gbStoreType.TabIndex = 183;
            this.gbStoreType.TabStop = false;
            this.gbStoreType.Text = "Store Type";
            // 
            // rbStoreStep
            // 
            this.rbStoreStep.AutoSize = true;
            this.rbStoreStep.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbStoreStep.ForeColor = System.Drawing.Color.White;
            this.rbStoreStep.Location = new System.Drawing.Point(6, 33);
            this.rbStoreStep.Name = "rbStoreStep";
            this.rbStoreStep.Size = new System.Drawing.Size(101, 23);
            this.rbStoreStep.TabIndex = 181;
            this.rbStoreStep.Text = "Continuous";
            this.rbStoreStep.UseVisualStyleBackColor = true;
            this.rbStoreStep.CheckedChanged += new System.EventHandler(this.storeType_CheckedChanged);
            // 
            // rbStoreOnce
            // 
            this.rbStoreOnce.AutoSize = true;
            this.rbStoreOnce.Checked = true;
            this.rbStoreOnce.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.rbStoreOnce.ForeColor = System.Drawing.Color.White;
            this.rbStoreOnce.Location = new System.Drawing.Point(6, 16);
            this.rbStoreOnce.Name = "rbStoreOnce";
            this.rbStoreOnce.Size = new System.Drawing.Size(62, 23);
            this.rbStoreOnce.TabIndex = 180;
            this.rbStoreOnce.TabStop = true;
            this.rbStoreOnce.Text = "Once";
            this.rbStoreOnce.UseVisualStyleBackColor = true;
            this.rbStoreOnce.CheckedChanged += new System.EventHandler(this.storeType_CheckedChanged);
            // 
            // gbBackupSource
            // 
            this.gbBackupSource.Controls.Add(this.rbStoreRandom);
            this.gbBackupSource.Controls.Add(this.gbStoreType);
            this.gbBackupSource.Controls.Add(this.rbStoreSame);
            this.gbBackupSource.Controls.Add(this.gbStoreTime);
            this.gbBackupSource.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.gbBackupSource.ForeColor = System.Drawing.Color.White;
            this.gbBackupSource.Location = new System.Drawing.Point(122, 12);
            this.gbBackupSource.Name = "gbBackupSource";
            this.gbBackupSource.Size = new System.Drawing.Size(312, 73);
            this.gbBackupSource.TabIndex = 180;
            this.gbBackupSource.TabStop = false;
            this.gbBackupSource.Text = "Store Source";
            // 
            // btnResetConfig
            // 
            this.btnResetConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnResetConfig.FlatAppearance.BorderSize = 0;
            this.btnResetConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetConfig.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnResetConfig.ForeColor = System.Drawing.Color.Black;
            this.btnResetConfig.Location = new System.Drawing.Point(175, 305);
            this.btnResetConfig.Name = "btnResetConfig";
            this.btnResetConfig.Size = new System.Drawing.Size(118, 24);
            this.btnResetConfig.TabIndex = 190;
            this.btnResetConfig.TabStop = false;
            this.btnResetConfig.Tag = "color:light";
            this.btnResetConfig.Text = "Reset Config";
            this.btnResetConfig.UseVisualStyleBackColor = false;
            this.btnResetConfig.Click += new System.EventHandler(this.btnResetConfig_Click);
            // 
            // pnTopBar
            // 
            this.pnTopBar.BackColor = System.Drawing.Color.Gray;
            this.pnTopBar.Controls.Add(this.btnCustomTemplateSaveAs);
            this.pnTopBar.Controls.Add(this.btnCustomTemplateLoad);
            this.pnTopBar.Controls.Add(this.btnCustomTemplateSave);
            this.pnTopBar.Controls.Add(this.cbSelectedTemplate);
            this.pnTopBar.Controls.Add(this.label2);
            this.pnTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnTopBar.Name = "pnTopBar";
            this.pnTopBar.Size = new System.Drawing.Size(471, 51);
            this.pnTopBar.TabIndex = 191;
            this.pnTopBar.Tag = "color:normal";
            // 
            // btnCustomTemplateSaveAs
            // 
            this.btnCustomTemplateSaveAs.BackColor = System.Drawing.Color.Firebrick;
            this.btnCustomTemplateSaveAs.FlatAppearance.BorderSize = 0;
            this.btnCustomTemplateSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomTemplateSaveAs.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnCustomTemplateSaveAs.ForeColor = System.Drawing.Color.Black;
            this.btnCustomTemplateSaveAs.Location = new System.Drawing.Point(339, 11);
            this.btnCustomTemplateSaveAs.Name = "btnCustomTemplateSaveAs";
            this.btnCustomTemplateSaveAs.Size = new System.Drawing.Size(64, 30);
            this.btnCustomTemplateSaveAs.TabIndex = 193;
            this.btnCustomTemplateSaveAs.TabStop = false;
            this.btnCustomTemplateSaveAs.Tag = "";
            this.btnCustomTemplateSaveAs.Text = "Save as";
            this.btnCustomTemplateSaveAs.UseVisualStyleBackColor = false;
            this.btnCustomTemplateSaveAs.Visible = false;
            this.btnCustomTemplateSaveAs.Click += new System.EventHandler(this.btnCustomTemplateSaveAs_Click);
            // 
            // btnCustomTemplateLoad
            // 
            this.btnCustomTemplateLoad.BackColor = System.Drawing.Color.Orange;
            this.btnCustomTemplateLoad.FlatAppearance.BorderSize = 0;
            this.btnCustomTemplateLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomTemplateLoad.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnCustomTemplateLoad.ForeColor = System.Drawing.Color.Black;
            this.btnCustomTemplateLoad.Location = new System.Drawing.Point(278, 11);
            this.btnCustomTemplateLoad.Name = "btnCustomTemplateLoad";
            this.btnCustomTemplateLoad.Size = new System.Drawing.Size(55, 30);
            this.btnCustomTemplateLoad.TabIndex = 192;
            this.btnCustomTemplateLoad.TabStop = false;
            this.btnCustomTemplateLoad.Tag = "";
            this.btnCustomTemplateLoad.Text = "Load";
            this.btnCustomTemplateLoad.UseVisualStyleBackColor = false;
            this.btnCustomTemplateLoad.Visible = false;
            this.btnCustomTemplateLoad.Click += new System.EventHandler(this.btnCustomTemplateLoad_Click);
            // 
            // btnCustomTemplateSave
            // 
            this.btnCustomTemplateSave.BackColor = System.Drawing.Color.LightGray;
            this.btnCustomTemplateSave.Enabled = false;
            this.btnCustomTemplateSave.FlatAppearance.BorderSize = 0;
            this.btnCustomTemplateSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomTemplateSave.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnCustomTemplateSave.ForeColor = System.Drawing.Color.DimGray;
            this.btnCustomTemplateSave.Location = new System.Drawing.Point(409, 11);
            this.btnCustomTemplateSave.Name = "btnCustomTemplateSave";
            this.btnCustomTemplateSave.Size = new System.Drawing.Size(50, 30);
            this.btnCustomTemplateSave.TabIndex = 191;
            this.btnCustomTemplateSave.TabStop = false;
            this.btnCustomTemplateSave.Tag = "";
            this.btnCustomTemplateSave.Text = "Save";
            this.btnCustomTemplateSave.UseVisualStyleBackColor = false;
            this.btnCustomTemplateSave.Visible = false;
            this.btnCustomTemplateSave.Click += new System.EventHandler(this.btnCustomTemplateSave_Click);
            // 
            // cbSelectedTemplate
            // 
            this.cbSelectedTemplate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbSelectedTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectedTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectedTemplate.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cbSelectedTemplate.ForeColor = System.Drawing.Color.White;
            this.cbSelectedTemplate.FormattingEnabled = true;
            this.cbSelectedTemplate.Items.AddRange(new object[] {
            "Nightmare Engine",
            "Hellgenie Engine",
            "Distortion Engine",
            "Freeze Engine",
            "Pipe Engine",
            "Vector Engine"});
            this.cbSelectedTemplate.Location = new System.Drawing.Point(12, 20);
            this.cbSelectedTemplate.Name = "cbSelectedTemplate";
            this.cbSelectedTemplate.Size = new System.Drawing.Size(211, 25);
            this.cbSelectedTemplate.TabIndex = 168;
            this.cbSelectedTemplate.Tag = "color:dark";
            this.cbSelectedTemplate.SelectedIndexChanged += new System.EventHandler(this.cbSelectedTemplate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 167;
            this.label2.Text = "Selected Template:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.gbUnitSource);
            this.panel1.Controls.Add(this.btnClearActive);
            this.panel1.Controls.Add(this.btnResetConfig);
            this.panel1.Controls.Add(this.gbValueSource);
            this.panel1.Controls.Add(this.gbCheckBoxes);
            this.panel1.Controls.Add(this.gbBackupSource);
            this.panel1.Controls.Add(this.gbStepSettings);
            this.panel1.Controls.Add(this.gbLimiterList);
            this.panel1.Location = new System.Drawing.Point(12, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 340);
            this.panel1.TabIndex = 192;
            this.panel1.Tag = "color:normal";
            // 
            // RTC_CustomEngineConfig_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(471, 413);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnTopBar);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RTC_CustomEngineConfig_Form";
            this.Tag = "color:dark";
            this.Text = "Custom Engine Config";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RTC_CustomEngineConfig_Form_FormClosing);
            this.Load += new System.EventHandler(this.RTC_CustomEngineConfig_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxInfinite)).EndInit();
            this.gbUnitSource.ResumeLayout(false);
            this.gbUnitSource.PerformLayout();
            this.gbValueList.ResumeLayout(false);
            this.gbValueSource.ResumeLayout(false);
            this.gbValueSource.PerformLayout();
            this.gbValueRange.ResumeLayout(false);
            this.gbValueRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmMinValue)).EndInit();
            this.gbLimiterList.ResumeLayout(false);
            this.gbLimiterList.PerformLayout();
            this.gbStepSettings.ResumeLayout(false);
            this.gbStepSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTilt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmLifetime)).EndInit();
            this.gbCheckBoxes.ResumeLayout(false);
            this.gbCheckBoxes.PerformLayout();
            this.gbStoreTime.ResumeLayout(false);
            this.gbStoreTime.PerformLayout();
            this.gbStoreType.ResumeLayout(false);
            this.gbStoreType.PerformLayout();
            this.gbBackupSource.ResumeLayout(false);
            this.gbBackupSource.PerformLayout();
            this.pnTopBar.ResumeLayout(false);
            this.pnTopBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion
		public System.Windows.Forms.CheckBox cbLockUnits;
		private System.Windows.Forms.Button btnClearActive;
		public System.Windows.Forms.NumericUpDown nmMaxInfinite;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gbUnitSource;
		private System.Windows.Forms.RadioButton rbUnitSourceStore;
		private System.Windows.Forms.RadioButton rbUnitSourceValue;
		private System.Windows.Forms.GroupBox gbValueList;
		public System.Windows.Forms.ComboBox cbValueList;
		private System.Windows.Forms.GroupBox gbValueSource;
		private System.Windows.Forms.RadioButton rbValueList;
		private System.Windows.Forms.RadioButton rbRandom;
		private System.Windows.Forms.RadioButton rbRange;
		private System.Windows.Forms.GroupBox gbLimiterList;
		private System.Windows.Forms.RadioButton rbLimiterExecute;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RadioButton rbLimiterFirstExecute;
		private System.Windows.Forms.RadioButton rbLimiterGenerate;
		public System.Windows.Forms.ComboBox cbLimiterList;
		public System.Windows.Forms.CheckBox cbClearRewind;
		public System.Windows.Forms.CheckBox cbLoopUnit;
		private System.Windows.Forms.RadioButton rbLimiterNone;
		private System.Windows.Forms.GroupBox gbStepSettings;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		public System.Windows.Forms.NumericUpDown nmDelay;
		public System.Windows.Forms.NumericUpDown nmLifetime;
		private System.Windows.Forms.GroupBox gbCheckBoxes;
		private System.Windows.Forms.Label label11;
		public System.Windows.Forms.NumericUpDown nmTilt;
		private System.Windows.Forms.GroupBox gbStoreTime;
		private System.Windows.Forms.RadioButton rbStoreFirstExecute;
		private System.Windows.Forms.RadioButton rbStoreImmediate;
		private System.Windows.Forms.RadioButton rbStoreRandom;
		private System.Windows.Forms.RadioButton rbStoreSame;
		private System.Windows.Forms.GroupBox gbStoreType;
		private System.Windows.Forms.RadioButton rbStoreStep;
		private System.Windows.Forms.RadioButton rbStoreOnce;
		private System.Windows.Forms.GroupBox gbBackupSource;
		private System.Windows.Forms.GroupBox gbValueRange;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label27;
		public NumericUpDownHexFix nmMaxValue;
		public NumericUpDownHexFix nmMinValue;
		public System.Windows.Forms.CheckBox cbLimiterInverted;
		private System.Windows.Forms.Button btnResetConfig;
		private System.Windows.Forms.Panel pnTopBar;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCustomTemplateSaveAs;
		private System.Windows.Forms.Button btnCustomTemplateLoad;
		private System.Windows.Forms.Button btnCustomTemplateSave;
		public System.Windows.Forms.ComboBox cbSelectedTemplate;
		private System.Windows.Forms.Label label2;
	}
}