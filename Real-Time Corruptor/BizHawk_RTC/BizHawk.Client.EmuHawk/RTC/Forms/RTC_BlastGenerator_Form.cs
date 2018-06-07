﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace RTC
{
	// 0  dgvBlastLayerReference
	// 1  dgvRowDirty
	// 2  dgvEnabled
	// 3  dgvDomain
	// 4  dgvPrecision
	// 5  dgvType
	// 6  dgvMode
	// 7  dgvStepSize
	// 8  dgvStartAddress
	// 9  dgvEndAddress
	// 10  dgvParam1
	// 11  dgvParam2

	//TYPE = BLASTUNITTYPE
	//MODE = GENERATIONMODE

	public partial class RTC_BlastGenerator_Form : Form
	{
		private enum BlastGeneratorColumn
		{
			dgvBlastLayerReference,
			dgvRowDirty,
			dgvEnabled,
			dgvDomain,
			dgvPrecision,
			dgvType,
			dgvMode,
			dgvStepSize,
			dgvStartAddress,
			dgvEndAddress,
			dgvParam1,
			dgvParam2
		}

		public static BlastLayer currentBlastLayer = null;
		private bool openedFromBlastEditor = false;
		private StashKey sk = null;
		private ContextMenuStrip cms = new ContextMenuStrip();
		private bool initialized = false;
		private bool CurrentlyUpdating = false;

		public RTC_BlastGenerator_Form()
		{
			InitializeComponent();
		}

		private void RTC_BlastGeneratorForm_Load(object sender, EventArgs e)
		{
			this.dgvBlastGenerator.MouseClick += new System.Windows.Forms.MouseEventHandler(dgvBlastGenerator_MouseClick);
			this.dgvBlastGenerator.CellValueChanged += new DataGridViewCellEventHandler(dgvBlastGenerator_CellValueChanged);

			RTC_Core.SetRTCColor(RTC_Core.generalColor, this);
		}

		public void LoadNoStashKey()
		{
			RefreshDomains();
			AddDefaultRow();
			PopulateModeCombobox(dgvBlastGenerator.Rows[0]);
			openedFromBlastEditor = false;
			btnSendTo.Text = "Send to Stash";
			initialized = true;

			this.Show();
		}

		public void LoadStashkey(StashKey _sk)
		{
			if (_sk == null)
				return;

			sk = (StashKey)_sk.Clone();
			sk.BlastLayer = new BlastLayer();

			RefreshDomains();
			AddDefaultRow();
			PopulateModeCombobox(dgvBlastGenerator.Rows[0]);
			openedFromBlastEditor = true;
			btnSendTo.Text = "Send to Blast Editor";
			initialized = true;

			this.Show();
		}

		private void AddDefaultRow()
		{

			//Add an empty row and populate with default values
			dgvBlastGenerator.Rows.Add();
			int lastrow = dgvBlastGenerator.RowCount - 1;
			//Set up the DGV based on the current state of Bizhawk
			(dgvBlastGenerator.Rows[lastrow].Cells["dgvRowDirty"]).Value = true;
			(dgvBlastGenerator.Rows[lastrow].Cells["dgvEnabled"]).Value = true;
			(dgvBlastGenerator.Rows[lastrow].Cells["dgvPrecision"] as DataGridViewComboBoxCell).Value = (dgvBlastGenerator.Rows[0].Cells["dgvPrecision"] as DataGridViewComboBoxCell).Items[0];
			(dgvBlastGenerator.Rows[lastrow].Cells["dgvType"] as DataGridViewComboBoxCell).Value = (dgvBlastGenerator.Rows[0].Cells["dgvType"] as DataGridViewComboBoxCell).Items[0];

			PopulateDomainCombobox(dgvBlastGenerator.Rows[lastrow]);
			PopulateModeCombobox(dgvBlastGenerator.Rows[lastrow]);
			// (dgvBlastGenerator.Rows[lastrow].Cells["dgvMode"] as DataGridViewComboBoxCell).Value = (dgvBlastGenerator.Rows[0].Cells["dgvMode"] as DataGridViewComboBoxCell).Items[0];

			//For some reason, setting the minimum on the DGV to 1 doesn't change the fact it inserts with a count of 0
			(dgvBlastGenerator.Rows[lastrow].Cells["dgvStepSize"]).Value = 1;

		}

		private bool PopulateDomainCombobox(DataGridViewRow row)
		{
			int temp = dgvDomain.Items.Count;
			string currentValue = "";
			if ((row.Cells["dgvDomain"] as DataGridViewComboBoxCell).Value != null)
				currentValue = (row.Cells["dgvDomain"] as DataGridViewComboBoxCell).Value.ToString();

			//So this combobox is annoying. You need to have something selected or else the dgv throws up
			//The (bad) solution I'm using is to insert a row at the beginning as a holdover until it's re-populated, then removing that row.

			dgvDomain.Items.Insert(0, "NONE");
			(row.Cells["dgvDomain"] as DataGridViewComboBoxCell).Value = (dgvBlastGenerator.Rows[0].Cells["dgvDomain"] as DataGridViewComboBoxCell).Items[0];

			for (int i = temp; i > 0; i--)
				dgvDomain.Items.RemoveAt(1);

			string[] domains = RTC_MemoryDomains.MemoryInterfaces.Keys.Concat(RTC_MemoryDomains.VmdPool.Values.Select(it => it.ToString())).ToArray();

			foreach (string domain in domains)
			{
				dgvDomain.Items.Add(domain);
			}

			if (dgvDomain.Items.Contains(currentValue))
			{
				(row.Cells["dgvDomain"] as DataGridViewComboBoxCell).Value = currentValue;
			}
			else
				(row.Cells["dgvDomain"] as DataGridViewComboBoxCell).Value = (dgvBlastGenerator.Rows[0].Cells["dgvDomain"] as DataGridViewComboBoxCell).Items[1];

			dgvDomain.Items.Remove("NONE");

			return false;
		}

		private void PopulateModeCombobox(DataGridViewRow row)
		{
			int temp = dgvMode.Items.Count;

			//So this combobox is annoying. You need to have something selected or else the dgv throws up
			//The (bad) solution I'm using is to insert a row at the beginning as a holdover until it's re-populated, then removing that row.

			dgvMode.Items.Insert(0, "NONE");
			(row.Cells["dgvMode"] as DataGridViewComboBoxCell).Value = (dgvBlastGenerator.Rows[0].Cells["dgvMode"] as DataGridViewComboBoxCell).Items[0];


			for (int i = temp; i > 0 ; i--)
				dgvMode.Items.RemoveAt(1);

			switch (row.Cells["dgvType"].Value.ToString())
			{
				case "BlastByte":
					foreach (BGBlastByteModes type in Enum.GetValues(typeof(BGBlastByteModes)))
					{
						dgvMode.Items.Add(type.ToString());
					}
					break;
				case "BlastCheat":
					foreach (BGBlastCheatModes type in Enum.GetValues(typeof(BGBlastCheatModes)))
					{
						dgvMode.Items.Add(type.ToString());
					}
					break;
				case "BlastPipe":
					foreach (BGBlastPipeModes type in Enum.GetValues(typeof(BGBlastPipeModes)))
					{
						dgvMode.Items.Add(type.ToString());
					}
					break;
			}
			(row.Cells["dgvMode"] as DataGridViewComboBoxCell).Value = (dgvBlastGenerator.Rows[0].Cells["dgvMode"] as DataGridViewComboBoxCell).Items[1];
			dgvMode.Items.Remove("NONE");

		}

		private void btnJustCorrupt_Click(object sender, EventArgs e)
		{
			BlastLayer bl = GenerateBlastLayers();
			(bl.Clone() as BlastLayer).Apply();
		}

		private void btnLoadCorrupt_Click(object sender, EventArgs e)
		{
			if (sk == null)
			{
				StashKey psk = RTC_StockpileManager.getCurrentSavestateStashkey();
				if (psk == null)
				{
					RTC_Core.StopSound();
					MessageBox.Show("Could not perform the CORRUPT action\n\nEither no Savestate Box was selected in the Savestate Manager\nor the Savetate Box itself is empty.");
					RTC_Core.StartSound();
					return;
				}
				sk = (StashKey)psk.Clone();
			}

			StashKey newSk = (StashKey)sk.Clone();
			newSk.BlastLayer = (BlastLayer)GenerateBlastLayers(true).Clone();

			GC.Collect();
			GC.WaitForPendingFinalizers();

			newSk.Run();
		}

		private void btnSendTo_Click(object sender, EventArgs e)
		{
			if(sk == null)
			{
				StashKey psk = RTC_StockpileManager.getCurrentSavestateStashkey();
				if (psk == null)
				{
					RTC_Core.StopSound();
					MessageBox.Show("Could not perform the CORRUPT action\n\nEither no Savestate Box was selected in the Savestate Manager\nor the Savetate Box itself is empty.");
					RTC_Core.StartSound();
					return;
				}
				sk = (StashKey)psk.Clone();
			}

			StashKey newSk = (StashKey)sk.Clone();
			newSk.BlastLayer = (BlastLayer)GenerateBlastLayers(true).Clone();

			if (openedFromBlastEditor)
			{
				if(RTC_Core.beForm != null)
				{
					RTC_Core.beForm.ImportBlastLayer(newSk.BlastLayer);
				}
			}
			else
			{
				RTC_StockpileManager.StashHistory.Add(newSk);
				RTC_Core.ghForm.RefreshStashHistory();
				RTC_Core.ghForm.dgvStockpile.ClearSelection();
				RTC_Core.ghForm.lbStashHistory.ClearSelected();

				RTC_Core.ghForm.DontLoadSelectedStash = true;
				RTC_Core.ghForm.lbStashHistory.SelectedIndex = RTC_Core.ghForm.lbStashHistory.Items.Count - 1;
			}		

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}


		private void cbUseHex_CheckedChanged(object sender, EventArgs e)
		{
			updownNudgeEndAddress.Hexadecimal = cbUseHex.Checked;
			updownNudgeStartAddress.Hexadecimal = cbUseHex.Checked;
			updownNudgeParam1.Hexadecimal = cbUseHex.Checked;
			updownNudgeParam2.Hexadecimal = cbUseHex.Checked;

			foreach (DataGridViewColumn column in dgvBlastGenerator.Columns)
			{
				if (column.CellType.Name == "DataGridViewNumericUpDownCell")
				{
					DataGridViewNumericUpDownColumn _column = column as DataGridViewNumericUpDownColumn;
					_column.Hexadecimal = cbUseHex.Checked;
				}
			}

		}

		private void dgvBlastGenerator_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (!initialized || dgvBlastGenerator == null)
				return;


			if (!CurrentlyUpdating)
			{
				CurrentlyUpdating = true;
				dgvBlastGenerator.Rows[e.RowIndex].Cells["dgvRowDirty"].Value = true;

				if ((BlastGeneratorColumn)e.ColumnIndex == BlastGeneratorColumn.dgvType)
				{
					PopulateModeCombobox(dgvBlastGenerator.Rows[e.RowIndex]);
				}
			}

			CurrentlyUpdating = false;
		}

		private void dgvBlastGenerator_MouseClick(object sender, MouseEventArgs e)
		{
			int currentMouseOverColumn = dgvBlastGenerator.HitTest(e.X, e.Y).ColumnIndex;
			int currentMouseOverRow = dgvBlastGenerator.HitTest(e.X, e.Y).RowIndex;

			if (e.Button == MouseButtons.Left)
			{
				if (currentMouseOverRow == -1)
				{
					dgvBlastGenerator.EndEdit();
					dgvBlastGenerator.ClearSelection();
				}
			}
			/*
			else if (e.Button == MouseButtons.Right)
			{
				//Column header
				if (currentMouseOverRow == -1)
				{
					cmsBlastEditor.Items.Clear();
					PopulateColumnHeaderContextMenu(currentMouseOverColumn);
					cmsBlastEditor.Show(dgvBlastLayer, new Point(e.X, e.Y));
				}
			}
				*/
		}

		public BlastLayer GenerateBlastLayers(bool useStashkey = false)
		{
			BlastLayer bl = new BlastLayer();

			if (useStashkey)
			{
				//If opened from engine config, use the GH state
				if (!openedFromBlastEditor)
				{
					StashKey psk = RTC_StockpileManager.getCurrentSavestateStashkey();
					if (psk == null)
					{
						RTC_Core.StopSound();
						MessageBox.Show("The Glitch Harvester could not perform the CORRUPT action\n\nEither no Savestate Box was selected in the Savestate Manager\nor the Savetate Box itself is empty.");
						RTC_Core.StartSound();
						return null;
					}
					sk = (StashKey)psk.Clone();
				}
				sk.RunOriginal();
			}

			foreach (DataGridViewRow row in dgvBlastGenerator.Rows)
			{
				if ((bool)row.Cells["dgvRowDirty"].Value == true)
				{
					BlastGeneratorProto proto = CreateProtoFromRow(row);
					row.Cells["dgvBlastLayerReference"].Value = proto.GenerateBlastLayer();
					bl.Layer.AddRange(((BlastLayer)row.Cells["dgvBlastLayerReference"].Value).Layer);
					row.Cells["dgvRowDirty"].Value = true;
				}
				else
				{
					bl.Layer.AddRange(((BlastLayer)row.Cells["dgvBlastLayerReference"].Value).Layer);
				}
			}
			return bl;
		}

		private BlastGeneratorProto CreateProtoFromRow(DataGridViewRow row)
		{
				string domain = row.Cells["dgvDomain"].Value.ToString();
				string type = row.Cells["dgvType"].Value.ToString();
				string mode = row.Cells["dgvMode"].Value.ToString();
				int precision = GetPrecisionSizeFromName(row.Cells["dgvPrecision"].Value.ToString());
				int stepSize = Convert.ToInt32(row.Cells["dgvStepSize"].Value);
				long startAddress = Convert.ToInt64(row.Cells["dgvStartAddress"].Value);
				long endAddress = Convert.ToInt64(row.Cells["dgvEndAddress"].Value);
				long param1 = Convert.ToInt64(row.Cells["dgvParam1"].Value);
				long param2 = Convert.ToInt64(row.Cells["dgvParam2"].Value);

				return new BlastGeneratorProto(type, domain, mode, precision, stepSize, startAddress, endAddress, param1, param2);
		}


		private string GetPrecisionNameFromSize(int precision)
		{
			switch (precision)
			{
				case 1:
					return "8-bit";

				case 2:
					return "16-bit";

				case 4:
					return "32-bit";

				default:
					return null;
			}
		}

		private int GetPrecisionSizeFromName(string precision)
		{
			switch (precision)
			{
				case "8-bit":
					return 1;

				case "16-bit":
					return 2;

				case "32-bit":
					return 4;

				default:
					return -1;
			}
		}

		private void btnAddRow_Click(object sender, EventArgs e)
		{
			AddDefaultRow();
		}

		private void btnNudgeStartAddressUp_Click(object sender, EventArgs e)
		{
			nudgeParams("dgvStartAddress", updownNudgeStartAddress.Value);
		}
		private void btnNudgeStartAddressDown_Click(object sender, EventArgs e)
		{
			nudgeParams("dgvStartAddress", updownNudgeStartAddress.Value, true);
		}
		private void btnNudgeEndAddressUp_Click(object sender, EventArgs e)
		{
			nudgeParams("dgvEndAddress", updownNudgeEndAddress.Value);
		}
		private void btnNudgeEndAddressDown_Click(object sender, EventArgs e)
		{
			nudgeParams("dgvEndAddress", updownNudgeEndAddress.Value, true);
		}
		private void btnNudgeParam1Up_Click(object sender, EventArgs e)
		{
			nudgeParams("dgvParam1", updownNudgeParam1.Value);
		}
		private void btnNudgeParam1Down_Click(object sender, EventArgs e)
		{
			nudgeParams("dgvParam1", updownNudgeParam1.Value, true);
		}
		private void btnNudgeParam2Up_Click(object sender, EventArgs e)
		{
			nudgeParams("dgvParam2", updownNudgeParam2.Value);
		}
		private void btnNudgeParam2Down_Click(object sender, EventArgs e)
		{
			nudgeParams("dgvParam2", updownNudgeParam2.Value, true);
		}


		private void nudgeParams(string column, decimal amount, bool shiftDown = false)
		{
			if (shiftDown)
				foreach (DataGridViewRow selected in dgvBlastGenerator.SelectedRows)
				{
					if ((Convert.ToDecimal(selected.Cells[column].Value) - amount) >= 0)

						selected.Cells[column].Value = Convert.ToDecimal(selected.Cells[column].Value) - amount;
					else
						selected.Cells[column].Value = 0;
				}
			else
			{

				foreach (DataGridViewRow selected in dgvBlastGenerator.SelectedRows)
				{

					decimal max = (selected.Cells[column] as DataGridViewNumericUpDownCell).Maximum;

					if ((Convert.ToDecimal(selected.Cells[column].Value) - amount) <= max)
						selected.Cells[column].Value = Convert.ToDecimal(selected.Cells[column].Value) + amount;
					else
						selected.Cells[column].Value = max;
				}
			}
		}

		private void btnHideSidebar_Click(object sender, EventArgs e)
		{
			if (btnHideSidebar.Text == "▶")
			{
				panelSidebar.Visible = false;
				btnHideSidebar.Text = "◀";
			}
			else
			{
				panelSidebar.Visible = true;
				btnHideSidebar.Text = "▶";
			}
		}
		private void RefreshDomains()
		{
			foreach(DataGridViewRow row in dgvBlastGenerator.Rows)
				PopulateDomainCombobox(row);
		}

		private void btnRefreshDomains_Click(object sender, EventArgs e)
		{
			RefreshDomains();
		}

	}
}