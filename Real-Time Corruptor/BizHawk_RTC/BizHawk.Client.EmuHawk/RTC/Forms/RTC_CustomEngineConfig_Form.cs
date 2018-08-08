﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTC
{
	public partial class RTC_CustomEngineConfig_Form : Form
	{

		private bool updatingMinMax = false;

		public RTC_CustomEngineConfig_Form()
		{
			InitializeComponent();

			//Do this here as if it's stuck into the designer, it keeps defaulting out
			cbValueList.DataSource = RTC_Core.ValueListBindingSource;
			cbLimiterList.DataSource = RTC_Core.LimiterListBindingSource;

		}


		private void RTC_CustomEngineConfig_Form_Load(object sender, EventArgs e)
		{
			


			if (RTC_Core.ValueListBindingSource.Count > 0)
			{
				cbValueList_SelectedIndexChanged(cbValueList, null);
			}
			if (RTC_Core.LimiterListBindingSource.Count > 0)
			{
				cbLimiterList_SelectedIndexChanged(cbLimiterList, null);
			}
		}

		private void nmMaxInfinite_ValueChanged(object sender, EventArgs e)
		{
			RTC_StepActions.SetMaxLifetimeBlastUnits(Convert.ToInt32(nmMaxInfinite.Value));
		}

		private void rbUnitSourceValue_CheckedChanged(object sender, EventArgs e)
		{
			if (rbUnitSourceValue.Checked)
				RTC_CustomEngine.Source = BlastUnitSource.VALUE;
		}

		private void rbUnitSourceStore_CheckedChanged(object sender, EventArgs e)
		{
			if(rbUnitSourceStore.Checked)
				RTC_CustomEngine.Source = BlastUnitSource.STORE;
		}

		private void rbRandom_CheckedChanged(object sender, EventArgs e)
		{
			if (rbRandom.Checked)
				RTC_CustomEngine.ValueSource = CustomValueSource.RANDOM;
		}

		private void rbValueList_CheckedChanged(object sender, EventArgs e)
		{
			if (rbValueList.Checked)
				RTC_CustomEngine.ValueSource = CustomValueSource.VALUELIST;
		}

		private void rbRange_CheckedChanged(object sender, EventArgs e)
		{
			if (rbRange.Checked)
				RTC_CustomEngine.ValueSource = CustomValueSource.RANGE;
		}

		private void rbStoreImmediate_CheckedChanged(object sender, EventArgs e)
		{
			if (rbStoreImmediate.Checked)
				RTC_CustomEngine.StoreTime = ActionTime.IMMEDIATE;
		}

		private void rbStoreFirstExecute_CheckedChanged(object sender, EventArgs e)
		{
			if (rbStoreFirstExecute.Checked)
				RTC_CustomEngine.StoreTime = ActionTime.PREEXECUTE;
		}

		private void rbStoreRandom_CheckedChanged(object sender, EventArgs e)
		{
			if (rbStoreRandom.Checked)
				RTC_CustomEngine.StoreAddress = CustomStoreAddress.RANDOM;
		}

		private void rbStoreSame_CheckedChanged(object sender, EventArgs e)
		{
			if (rbStoreSame.Checked)
				RTC_CustomEngine.StoreAddress = CustomStoreAddress.SAME;
		}

		private void rbStoreOnce_CheckedChanged(object sender, EventArgs e)
		{
			if (rbStoreOnce.Checked)
				RTC_CustomEngine.StoreType = StoreType.ONCE;
		}

		private void rbStoreStep_CheckedChanged(object sender, EventArgs e)
		{
			if (rbStoreStep.Checked)
				RTC_CustomEngine.StoreType = StoreType.CONTINUOUS;
		}

		private void nmMaxValue_ValueChanged(object sender, EventArgs e)
		{
			//We don't want to trigger this if it caps when stepping downwards
			if (updatingMinMax)
				return;
			long value = Convert.ToInt64(nmMaxValue.Value);


			switch (RTC_Core.CurrentPrecision)
			{
				case 1:
					RTC_CustomEngine.MaxValue8Bit = value;
					break;
				case 2:
					RTC_CustomEngine.MaxValue16Bit = value;
					break;
				case 4:
					RTC_CustomEngine.MaxValue32Bit = value;
					break;
			}
		}

		private void nmMinValue_ValueChanged(object sender, EventArgs e)
		{
			//We don't want to trigger this if it caps when stepping downwards
			if (updatingMinMax)
				return;
			long value = Convert.ToInt64(nmMinValue.Value);

			switch (RTC_Core.CurrentPrecision)
			{
				case 1:
					RTC_CustomEngine.MinValue8Bit = value;
					break;
				case 2:
					RTC_CustomEngine.MinValue16Bit = value;
					break;
				case 4:
					RTC_CustomEngine.MinValue32Bit = value;
					break;
			}
		}

		private void cbLockUnits_CheckedChanged(object sender, EventArgs e)
		{
			RTC_StepActions.LockExecution = cbLockUnits.Checked;
		}

		private void cbClearRewind_CheckedChanged(object sender, EventArgs e)
		{
			RTC_StepActions.ClearStepActionsOnRewind(cbClearRewind.Checked);
		}

		private void cbLoopUnit_CheckedChanged(object sender, EventArgs e)
		{
			RTC_CustomEngine.Loop = cbLoopUnit.Checked;
		}

		private void cbValueList_SelectedIndexChanged(object sender, EventArgs e)
		{
			RTC_CustomEngine.ValueList = (MD5)cbValueList.SelectedValue;
		}

		private void cbLimiterList_SelectedIndexChanged(object sender, EventArgs e)
		{
			RTC_CustomEngine.LimiterList = (MD5)cbLimiterList.SelectedValue;
		}

		private void rbLimiterNone_CheckedChanged(object sender, EventArgs e)
		{
			RTC_CustomEngine.UseLimiterList = (!rbLimiterNone.Checked);
		}
		private void rbLimiterGenerate_CheckedChanged(object sender, EventArgs e)
		{
			if (rbLimiterGenerate.Checked)
				RTC_CustomEngine.LimiterTime = ActionTime.GENERATE;
		}

		private void rbLimiterFirstExecute_CheckedChanged(object sender, EventArgs e)
		{
			if (rbLimiterFirstExecute.Checked)
				RTC_CustomEngine.LimiterTime = ActionTime.PREEXECUTE;
		}

		private void rbLimiterExecute_CheckedChanged(object sender, EventArgs e)
		{
			if (rbLimiterExecute.Checked)
				RTC_CustomEngine.LimiterTime = ActionTime.EXECUTE;

		}


		private void btnClearActive_Click(object sender, EventArgs e)
		{
			RTC_StepActions.ClearStepBlastUnits();
		}


		public void UpdateMinMaxBoxes(int precision)
		{
			updatingMinMax = true;
			switch (precision)
			{
				case 1:
					nmMinValue.Maximum = byte.MaxValue;
					nmMaxValue.Maximum = byte.MaxValue;

					nmMinValue.Value = RTC_CustomEngine.MinValue8Bit;
					nmMaxValue.Value = RTC_CustomEngine.MaxValue8Bit;
					break;

				case 2:
					nmMinValue.Maximum = UInt16.MaxValue;
					nmMaxValue.Maximum = UInt16.MaxValue;
									   
					nmMinValue.Value = RTC_CustomEngine.MinValue16Bit;
					nmMaxValue.Value = RTC_CustomEngine.MaxValue16Bit;
					break;
				case 4:
					nmMinValue.Maximum = UInt32.MaxValue;
					nmMaxValue.Maximum = UInt32.MaxValue;

					nmMinValue.Value = RTC_CustomEngine.MinValue32Bit;
					nmMaxValue.Value = RTC_CustomEngine.MaxValue32Bit;

					break;
			}
			updatingMinMax = false;
		}

		private void nmLifetime_ValueChanged(object sender, EventArgs e)
		{
			RTC_CustomEngine.Lifetime = Convert.ToInt32(nmLifetime.Value);
		}

		private void nmDelay_ValueChanged(object sender, EventArgs e)
		{
			RTC_CustomEngine.Delay = Convert.ToInt32(nmDelay.Value);
		}
	}
}
