using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Diagnostics;
using RTCV.CorruptCore;
using static RTCV.UI.UI_Extensions;
using RTCV.NetCore.StaticTools;

namespace RTCV.UI
{
	public partial class RTC_SettingsReroll_Form : Form, IAutoColorize
	{

		public RTC_SettingsReroll_Form()
		{
			InitializeComponent();

			cbRerollAddress.CheckedChanged += cbRerollAddress_CheckedChanged;
			cbRerollSourceAddress.CheckedChanged += cbRerollSourceAddress_CheckedChanged;

			UICore.SetRTCColor(UICore.GeneralColor, this);
			Load += RTC_SettingRerollForm_Load;
		}

		private void RTC_SettingRerollForm_Load(object sender, EventArgs e)
		{
			cbRerollAddress.Checked = CorruptCore.CorruptCore.RerollAddress;
			cbRerollSourceAddress.Checked = CorruptCore.CorruptCore.RerollSourceAddress;
		}

		private void cbRerollSourceAddress_CheckedChanged(object sender, EventArgs e)
		{
			CorruptCore.CorruptCore.RerollSourceAddress = cbRerollSourceAddress.Checked;
			RTCV.NetCore.Params.SetParam("REROLL_SOURCEADDRESS", cbRerollSourceAddress.Checked.ToString());
		}

		private void cbRerollAddress_CheckedChanged(object sender, EventArgs e)
		{
			CorruptCore.CorruptCore.RerollAddress = cbRerollAddress.Checked;
			RTCV.NetCore.Params.SetParam("REROLL_ADDRESS", cbRerollAddress.Checked.ToString());
		}
	}
}