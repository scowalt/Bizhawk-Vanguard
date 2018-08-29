﻿using BizHawk.Client.Common;
using BizHawk.Emulation.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RTC
{
	public static class RTC_MemoryDomains
	{

		public static volatile Dictionary<string, MemoryInterface> MemoryInterfaces = new Dictionary<string, MemoryInterface>();
		public static volatile Dictionary<string, MemoryInterface> VmdPool = new Dictionary<string, MemoryInterface>();

		public static string MainDomain = null;
		public static bool BigEndian { get; set; }
		public static int WordSize { get; set; }

		public static WatchSize WatchSize
		{
			get
			{
				return (WatchSize)WordSize;
			}
		}

		public static string[] SelectedDomains = new string[] { };
		public static string[] lastSelectedDomains = new string[] { };

		public static string[] getSelectedDomains()
		{
			return SelectedDomains;
		}

		public static void UpdateSelectedDomains(string[] _domains, bool sync = false)
		{
			SelectedDomains = _domains;
			lastSelectedDomains = _domains;

			if (NetCoreImplementation.isStandalone)
				NetCoreImplementation.SendCommandToBizhawk(new RTC_Command(CommandType.REMOTE_DOMAIN_SETSELECTEDDOMAINS) { objectValue = SelectedDomains }, sync);

			Console.WriteLine($"{NetCoreImplementation.RemoteRTC?.expectedSide} -> Selected {_domains.Count().ToString()} domains \n{string.Join(" | ", _domains)}");
		}

		public static void ClearSelectedDomains()
		{
			lastSelectedDomains = SelectedDomains;

			SelectedDomains = new string[] { };

			if (NetCoreImplementation.isStandalone)
				NetCoreImplementation.SendCommandToBizhawk(new RTC_Command(CommandType.REMOTE_DOMAIN_SETSELECTEDDOMAINS) { objectValue = SelectedDomains });

			Console.WriteLine($"{NetCoreImplementation.RemoteRTC?.expectedSide} -> Cleared selected domains");
		}

		public static string[] GetBlacklistedDomains()
		{
			// Returns the list of Domains that can't be rewinded and/or are just not good to use

			List<string> domainBlacklist = new List<string>();

			string systemName;

			if (NetCoreImplementation.isStandalone)
				systemName = (string)NetCoreImplementation.SendCommandToBizhawk(new RTC_Command(CommandType.REMOTE_DOMAIN_SYSTEM), true);
			else
				systemName = Global.Game.System.ToString().ToUpper();

			switch (systemName)
			{
				case "NES":     //Nintendo Entertainment system

					domainBlacklist.Add("System Bus");
					domainBlacklist.Add("PRG ROM");
					domainBlacklist.Add("PALRAM"); //Color Memory (Useless and disgusting)
					domainBlacklist.Add("CHR VROM"); //Cartridge
					domainBlacklist.Add("Battery RAM"); //Cartridge Save Data
					domainBlacklist.Add("FDS Side"); //ROM data for the FDS. Sadly uncorruptable.
					break;

				case "GB":      //Gameboy
				case "GBC":     //Gameboy Color
					domainBlacklist.Add("ROM"); //Cartridge
					domainBlacklist.Add("System Bus");
					domainBlacklist.Add("OBP"); //SGB dummy domain doesn't do anything in sameboy
					domainBlacklist.Add("BGP");  //SGB dummy domain doesn't do anything in sameboy
					domainBlacklist.Add("BOOTROM"); //Sameboy SGB Bootrom
					break;

				case "SNES":    //Super Nintendo

					domainBlacklist.Add("CARTROM"); //Cartridge
					domainBlacklist.Add("APURAM"); //SPC700 memory
					domainBlacklist.Add("CGRAM"); //Color Memory (Useless and disgusting)
					domainBlacklist.Add("System Bus"); // maxvalue is not representative of chip (goes ridiculously high)
					domainBlacklist.Add("SGB CARTROM"); // Supergameboy cartridge

					if (RTC_MemoryDomains.MemoryInterfaces.ContainsKey("SGB CARTROM"))
					{
						domainBlacklist.Add("VRAM");
						domainBlacklist.Add("WRAM");
						domainBlacklist.Add("CARTROM");
					}

					break;

				case "N64":     //Nintendo 64
					domainBlacklist.Add("System Bus");
					domainBlacklist.Add("PI Register");
					domainBlacklist.Add("EEPROM");
					domainBlacklist.Add("ROM");
					domainBlacklist.Add("SI Register");
					domainBlacklist.Add("VI Register");
					domainBlacklist.Add("RI Register");
					domainBlacklist.Add("AI Register");
					break;

				case "PCE":     //PC Engine / Turbo Grafx
				case "SGX":     //Super Grafx
					domainBlacklist.Add("ROM");
					domainBlacklist.Add("System Bus"); //BAD THINGS HAPPEN WITH THIS DOMAIN
					domainBlacklist.Add("System Bus (21 bit)");
					break;

				case "GBA":     //Gameboy Advance
					domainBlacklist.Add("OAM");
					domainBlacklist.Add("BIOS");
					domainBlacklist.Add("PALRAM");
					domainBlacklist.Add("ROM");
					domainBlacklist.Add("System Bus");
					break;

				case "SMS":     //Sega Master System
					domainBlacklist.Add("System Bus"); // the game cartridge appears to be on the system bus
					domainBlacklist.Add("ROM");
					break;

				case "GG":      //Sega GameGear
					domainBlacklist.Add("System Bus"); // the game cartridge appears to be on the system bus
					domainBlacklist.Add("ROM");
					break;

				case "SG":      //Sega SG-1000
					domainBlacklist.Add("System Bus");
					domainBlacklist.Add("ROM");
					break;

				case "32X_INTERIM":
				case "GEN":     //Sega Genesis and CD
					domainBlacklist.Add("MD CART");
					domainBlacklist.Add("CRAM"); //Color Ram
					domainBlacklist.Add("VSRAM"); //Vertical scroll ram. Do you like glitched scrolling? Have a dedicated domain...
					domainBlacklist.Add("SRAM"); //Save Ram
					domainBlacklist.Add("BOOT ROM"); //Genesis Boot Rom
					domainBlacklist.Add("32X FB"); //32X Sprinkles
					domainBlacklist.Add("CD BOOT ROM"); //Sega CD boot rom
					domainBlacklist.Add("S68K BUS");
					domainBlacklist.Add("M68K BUS");
					break;

				case "PSX":     //Sony Playstation 1
					domainBlacklist.Add("BiosROM");
					domainBlacklist.Add("PIOMem");
					break;

				case "A26":     //Atari 2600
					domainBlacklist.Add("System Bus");
					break;

				case "A78":     //Atari 7800
					domainBlacklist.Add("System Bus");
					break;

				case "LYNX":    //Atari Lynx
					domainBlacklist.Add("Save RAM");
					domainBlacklist.Add("Cart B");
					domainBlacklist.Add("Cart A");
					break;

				case "WSWAN":   //Wonderswan
					domainBlacklist.Add("ROM");
					break;

				case "Coleco":  //Colecovision
					domainBlacklist.Add("System Bus");
					break;

				case "VB":      //Virtualboy
					domainBlacklist.Add("ROM");
					break;

				case "SAT":     //Sega Saturn
					domainBlacklist.Add("Backup RAM");
					domainBlacklist.Add("Boot Rom");
					domainBlacklist.Add("Backup Cart");
					domainBlacklist.Add("VDP1 Framebuffer"); //Sprinkles
					domainBlacklist.Add("VDP2 CRam"); //VDP 2 color ram (pallettes)
					domainBlacklist.Add("Sound Ram"); //90% chance of killing the audio
					break;

				case "INTV": //Intellivision
					domainBlacklist.Add("Graphics ROM");
					domainBlacklist.Add("System ROM");
					domainBlacklist.Add("Executive Rom"); //??????
					break;

				case "APPLEII": //Apple II
					domainBlacklist.Add("System Bus");
					break;

				case "C64":     //Commodore 64
					domainBlacklist.Add("System Bus");
					domainBlacklist.Add("1541 Bus");
					break;

				case "PCECD":   //PC-Engine CD / Turbo Grafx CD
				case "TI83":    //Ti-83 Calculator
				case "SGB":     //Super Gameboy
				case "DGB":
					break;

					//TODO: Add more domains for cores like gamegear, atari, turbo graphx
			}
			return domainBlacklist.ToArray();
		}

		private static bool CheckNesHeader(string filename)
		{
			byte[] buffer = new byte[4];
			using (Stream fs = File.OpenRead(filename))
			{
				fs.Read(buffer, 0, buffer.Length);
			}
			if (!buffer.SequenceEqual(Encoding.ASCII.GetBytes("NES\x1A")))
				return false;
			return true;
		}

		public static RomParts GetRomParts(string thisSystem, string romFilename)
		{
			RomParts rp = new RomParts();

			switch (thisSystem.ToUpper())
			{
				case "NES":     //Nintendo Entertainment System

					//There's no easy way to discern NES from FDS so just check for the domain name
					if (RTC_MemoryDomains.MemoryInterfaces.ContainsKey("PRG ROM"))
						rp.PrimaryDomain = "PRG ROM";
					else
					{
						rp.Error = "Unfortunately, Bizhawk doesn't support editing the ROM (FDS Side) domain of FDS games. Maybe in a future version...";
						break;
					}

					if (RTC_MemoryDomains.MemoryInterfaces.ContainsKey("CHR VROM"))
						rp.SecondDomain = "CHR VROM";
					//Skip the first 16 bytes if there's an iNES header
					if (CheckNesHeader(romFilename))
						rp.SkipBytes = 16;
					break;

				case "SNES":    //Super Nintendo
					if (RTC_MemoryDomains.MemoryInterfaces.ContainsKey("SGB CARTROM")) //BSNES SGB Mode
						rp.PrimaryDomain = "SGB CARTROM";
					else
					{
						rp.PrimaryDomain = "CARTROM";

						long filesize = new System.IO.FileInfo(romFilename).Length;

						if (filesize % 1024 != 0)
							rp.SkipBytes = 512;
					}

					break;

				case "LYNX":    //Atari Lynx
					rp.PrimaryDomain = "Cart A";
					rp.SkipBytes = 64;
					break;

				case "N64":     //Nintendo 64
				case "GB":      //Gameboy
				case "GBC":     //Gameboy Color
				case "SMS":     //Sega Master System
				case "GBA":     //Game Boy Advance
				case "PCE":     //PC Engine
				case "GG":      //Game Gear
				case "SG":      //SG-1000
				case "SGX":     //PC Engine SGX
				case "WSWAN":   //Wonderswan
				case "VB":      //Virtualboy
				case "NGP":     //Neo Geo Pocket
					rp.PrimaryDomain = "ROM";
					break;

				case "GEN":     // Sega Genesis
					if (RTC_MemoryDomains.MemoryInterfaces.ContainsKey("MD CART"))  //If it's regular Genesis or 32X
					{
						rp.PrimaryDomain = "MD CART";

						if (romFilename.ToUpper().Contains(".SMD"))
							rp.SkipBytes = 512;
					}
					else
					{    //If it's in Sega CD mode
						rp.Error = "Unfortunately, Bizhawk doesn't support editing the ISOs while it is running. Maybe in a future version...";
					}
					break;

				case "PCFX":    //PCFX
				case "PCECD":   //PC Engine CD
				case "SAT":     //Sega Saturn
				case "PSX":     //Playstation
					rp.Error = "Unfortunately, Bizhawk doesn't support editing the ISOs while it is running. Maybe in a future version...";
					break;
				default:
					rp.Error = "The RTC devs haven't added support for this system. Go yell at them to make it work.";
					break;
			}

			return rp;
		}

		public static void RefreshDomains(bool clearSelected = true)
		{
			if (Global.Emulator is NullEmulator)
				return;

			object[] returns;


			Guid token = RTC_NetCore.HugeOperationStart();
			if (!NetCoreImplementation.isStandalone)
				returns = (object[])GetInterfaces();
			else
				returns = (object[])NetCoreImplementation.SendCommandToBizhawk(new RTC_Command(CommandType.REMOTE_DOMAIN_GETDOMAINS), true);

			RTC_NetCore.HugeOperationEnd(token);

			if (returns == null)
			{
				Console.WriteLine($"{NetCoreImplementation.RemoteRTC.expectedSide} -> RefreshDomains() FAILED");
				return;
			}

			if (clearSelected)
				ClearSelectedDomains();

			if (NetCoreImplementation.isStandalone)
			{
				MemoryInterfaces.Clear();

				foreach (MemoryInterface mi in (MemoryInterface[])returns[0])
					if (!MemoryInterfaces.ContainsKey(mi.ToString()))
						MemoryInterfaces.Add(mi.ToString(), mi);

				MainDomain = (string)returns[1];
				WordSize = MemoryInterfaces[MainDomain].WordSize;
				BigEndian = MemoryInterfaces[MainDomain].BigEndian;
			}
		}

		public static object GetInterfaces()
		{
			Console.WriteLine($"{NetCoreImplementation.RemoteRTC?.expectedSide.ToString()} -> getInterfaces()");

			MemoryInterfaces.Clear();


			foreach (MemoryDomainProto proto in (MemoryDomainProto[])RTC_EmuCore.spec["domains"])
			{
				var mdp = new MemoryDomainProxy(proto);

				if(proto.Main)
				{
					MainDomain = proto.Name;
					WordSize = proto.WordSize;
					BigEndian = proto.BigEndian;
				}

				MemoryInterfaces.Add(mdp.Name, mdp);
			}

			return new object[] { MemoryInterfaces.Values.ToArray(), MainDomain };
		}

		public static void Clear()
		{
			MemoryInterfaces.Clear();

			lastSelectedDomains = SelectedDomains;
			SelectedDomains = new string[] { };

			if (!S.ISNULL<RTC_EngineConfig_Form>())
				S.GET<RTC_MemoryDomains_Form>().lbMemoryDomains.Items.Clear();
		}

		public static MemoryDomainProxy GetProxy(string domain, long address)
		{
			if (MemoryInterfaces.Count == 0)
				RefreshDomains();

			if (MemoryInterfaces.ContainsKey(domain))
			{
				MemoryInterface mi = MemoryInterfaces[domain];
				return (MemoryDomainProxy)mi;
			}
			else if (VmdPool.ContainsKey(domain))
			{
				MemoryInterface mi = VmdPool[domain];
				if (mi is VirtualMemoryDomain vmd)
					return GetProxy(vmd.GetRealDomain(address), vmd.GetRealAddress(address));
			}
			return null;
		}

		public static MemoryInterface GetInterface(string _domain)
		{
			if (MemoryInterfaces.Count == 0)
				RefreshDomains();

			if (MemoryInterfaces.ContainsKey(_domain))
				return MemoryInterfaces[_domain];

			if (VmdPool.ContainsKey(_domain))
				return VmdPool[_domain];

			return null;
		}

		public static void UnFreezeAddress(long address)
		{
			if (address >= 0)
			{
				// TODO: can't unfreeze address 0??
				Global.CheatList.RemoveRange(
					Global.CheatList.Where(x => x.Contains(address)).ToList());
			}
		}

		public static long GetRealAddress(string domain, long address)
		{
			if (domain.Contains("[V]"))
			{
				MemoryInterface mi = VmdPool[domain];
				VirtualMemoryDomain vmd = ((VirtualMemoryDomain)mi);
				return vmd.GetRealAddress(address);
			}
			else
				return address;
		}

		public static string GetRealDomain(string domain, long address)
		{
			if (domain.Contains("[V]"))
			{
				MemoryInterface mi = VmdPool[domain];
				VirtualMemoryDomain vmd = ((VirtualMemoryDomain)mi);
				return vmd.GetRealDomain(address);
			}
			else
				return domain;
		}

		public static void GenerateVmdFromStashkey(StashKey sk)
		{
			VmdPrototype proto = new VmdPrototype(sk.BlastLayer);
			AddVMD(proto);

			S.GET<RTC_VmdPool_Form>().RefreshVMDs();
		}

		public static void AddVMD(VmdPrototype proto) => AddVMD(proto.Generate());

		public static void AddVMD(VirtualMemoryDomain VMD)
		{
			RTC_MemoryDomains.VmdPool[VMD.ToString()] = VMD;

			if (NetCoreImplementation.isStandalone)
			{
				var token = RTC_NetCore.HugeOperationStart();

				NetCoreImplementation.SendCommandToBizhawk(new RTC_Command(CommandType.REMOTE_DOMAIN_VMD_ADD) { objectValue = VMD.Proto }, true);

				RTC_NetCore.HugeOperationEnd(token);
			}

			if (!NetCoreImplementation.isRemoteRTC)
				S.GET<RTC_MemoryDomains_Form>().RefreshDomainsAndKeepSelected();
		}

		public static void RemoveVMD(VirtualMemoryDomain VMD) => RemoveVMD(VMD.ToString());

		public static void RemoveVMD(string vmdName)
		{
			if (RTC_MemoryDomains.VmdPool.ContainsKey(vmdName))
			{
				RTC_MemoryDomains.VmdPool.Remove(vmdName);
				NetCoreImplementation.SendCommandToBizhawk(new RTC_Command(CommandType.REMOTE_DOMAIN_VMD_REMOVE) { objectValue = vmdName }, true);
			}

			if (!NetCoreImplementation.isRemoteRTC)
				S.GET<RTC_MemoryDomains_Form>().RefreshDomainsAndKeepSelected();
		}

		public static void RenameVMD(VirtualMemoryDomain VMD) => RenameVMD(VMD.ToString());

		public static void RenameVMD(string vmdName)
		{
			if (!RTC_MemoryDomains.VmdPool.ContainsKey(vmdName))
				return;

			RTC_EmuCore.StopSound();
			string name = "";
			string value = "";
			if (RTC_Extensions.GetInputBox("BlastLayer to VMD", "Enter the new VMD name:", ref value) == DialogResult.OK)
			{
				name = value.Trim();
				RTC_EmuCore.StartSound();
			}
			else
			{
				RTC_EmuCore.StartSound();
				return;
			}

			if (string.IsNullOrWhiteSpace(name))
				name = RTC_CorruptCore.GetRandomKey();

			VirtualMemoryDomain VMD = (VirtualMemoryDomain)RTC_MemoryDomains.VmdPool[vmdName];

			RemoveVMD(VMD);
			VMD.Name = name;
			VMD.Proto.VmdName = name;
			AddVMD(VMD);
		}

		public static void generateActiveTableDump(string domain, string key)
		{
			var token = RTC_NetCore.HugeOperationStart("LAZY");
			MemoryInterface mi = MemoryInterfaces[domain];

			byte[] dump = mi.GetDump();

			File.WriteAllBytes(RTC_EmuCore.rtcDir + "\\MEMORYDUMPS\\" + key + ".dmp", dump.ToArray());
			RTC_NetCore.HugeOperationEnd(token);
		}

		public static byte[] GetDomainData(string domain)
		{
			MemoryInterface mi;

			mi = domain.Contains("[V]") ? VmdPool[domain] : MemoryInterfaces[domain];

			return mi.GetDump();
		}
	}

	public class RomParts
	{
		public string Error = null;
		public string PrimaryDomain = null;
		public string SecondDomain = null;
		public int SkipBytes = 0;
	}

	[Serializable]
	public abstract class MemoryInterface
	{
		public abstract long Size { get; set; }
		public int WordSize { get; set; }
		public string Name { get; set; }
		public bool BigEndian { get; set; }

		public abstract byte[] GetDump();

		public abstract byte[] PeekBytes(long startAddress, long endAddress, bool bigEndian);

		public abstract byte PeekByte(long address);

		public abstract void PokeByte(long address, byte value);
	}

	[XmlInclude(typeof(BlastLayer))]
	[XmlInclude(typeof(BlastUnit))]
	[Serializable]
	public class VmdPrototype
	{
		public string VmdName { get; set; }
		public string GenDomain { get; set; }
		public bool BigEndian { get; set; }
		public int WordSize { get; set; }
		public long PointerSpacer { get; set; }

		public long Padding { get; set; }

		public List<long> addSingles = new List<long>();
		public List<long> removeSingles = new List<long>();

		public List<long[]> addRanges = new List<long[]>();
		public List<long[]> removeRanges = new List<long[]>();

		public BlastLayer SuppliedBlastLayer = null;

		public VmdPrototype()
		{
		}

		public VmdPrototype(BlastLayer bl)
		{
			VmdName = RTC_CorruptCore.GetRandomKey();
			GenDomain = "Hybrid";

			BlastUnit bu = bl.Layer[0];
			MemoryInterface mi = RTC_MemoryDomains.GetInterface(bu.Domain);
			BigEndian = mi.BigEndian;
			WordSize = mi.WordSize;
			SuppliedBlastLayer = bl;
		}

		public VirtualMemoryDomain Generate()
		{
			try
			{
				VirtualMemoryDomain VMD = new VirtualMemoryDomain
				{
					Proto = this,
					Name = VmdName,
					BigEndian = BigEndian,
					WordSize = WordSize
				};


				if (SuppliedBlastLayer != null)
				{
					VMD.AddFromBlastLayer(SuppliedBlastLayer);
					return VMD;
				}

				int addressCount = 0;
				for (int i = 0; i < Padding; i++)
				{
					VMD.PointerDomains.Add(GenDomain);
					VMD.PointerAddresses.Add(i);
				}

				foreach (long[] range in addRanges)
				{
					long start = range[0];
					long end = range[1];

					for (long i = start; i < end; i++)
					{
						if (!IsAddressInRanges(i, removeSingles, removeRanges))
							if (PointerSpacer == 1 || addressCount % PointerSpacer == 0)
							{
								//VMD.MemoryPointers.Add(new Tuple<string, long>(Domain, i));
								VMD.PointerDomains.Add(GenDomain);
								VMD.PointerAddresses.Add(i);
							}

						addressCount++;
					}
				}

				foreach (long single in addSingles)
				{
					//VMD.MemoryPointers.Add(new Tuple<string, long>(Domain, single));
					VMD.PointerDomains.Add(GenDomain);
					VMD.PointerAddresses.Add(single);
					addressCount++;
				}

				return VMD;
			}
			catch (Exception ex)
			{
				if (ex is OverflowException)
				{
					MessageBox.Show("Your VMD has overflowed! VMDs have a limit of 2GB due to technical limitations.\nIf your VMD isn't greater than 2147483647 addresses long, contact the devs with the following exception.\n\n" + ex.ToString());
				}
				else
				{
					MessageBox.Show("Something went wrong when generating the VMD! Send this error to the RTC devs with instructions on what caused it.\n\n" + ex.ToString());
				}

				return null;
			}
		}

		public bool IsAddressInRanges(long address, List<long> singles, List<long[]> ranges)
		{
			if (singles.Contains(address))
				return true;

			foreach (long[] range in ranges)
			{
				long start = range[0];
				long end = range[1];

				if (address >= start && address < end)
					return true;
			}

			return false;
		}
	}

	[Serializable]
	public class VirtualMemoryDomain : MemoryInterface
	{
		//public List<MemoryPointer> MemoryPointers = new List<MemoryPointer>();
		//public List<Tuple<string, long>> MemoryPointers = new List<Tuple<string, long>>();
		public List<string> PointerDomains = new List<string>();

		public List<long> PointerAddresses = new List<long>();
		public VmdPrototype Proto;

		public override long Size { get => PointerDomains.Count;
			set { } }

		public void AddFromBlastLayer(BlastLayer bl)
		{
			if (bl == null)
				return;

			foreach (BlastUnit bu in bl.Layer)
			{
				//MemoryPointers.Add(new MemoryPointer(bu.Domain, bu.Address));
				//MemoryPointers.Add(new Tuple<string, long>(bu.Domain, bu.Address));
				PointerDomains.Add(bu.Domain);
				PointerAddresses.Add(bu.Address);
			}
		}

		public string GetRealDomain(long address)
		{
			if (address < 0 || address > PointerDomains.Count)
				return null;

			return PointerDomains[(int)address];
		}

		public long GetRealAddress(long address)
		{
			if (address < 0 || address > PointerAddresses.Count || address < Proto.Padding)
				return 0;
			return PointerAddresses[(int)address];
		}

		public byte[] ToData()
		{
			VirtualMemoryDomain VMD = this;

			using (MemoryStream serialized = new MemoryStream())
			{
				BinaryFormatter binaryFormatter = new BinaryFormatter();
				binaryFormatter.Serialize(serialized, VMD);

				using (MemoryStream input = new MemoryStream(serialized.ToArray()))
				using (MemoryStream output = new MemoryStream())
				{
					using (GZipStream zip = new GZipStream(output, CompressionMode.Compress))
					{
						input.CopyTo(zip);
					}

					return output.ToArray();
				}
			}
		}

		public static VirtualMemoryDomain FromData(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			using (MemoryStream output = new MemoryStream())
			{
				using (GZipStream zip = new GZipStream(input, CompressionMode.Decompress))
				{
					zip.CopyTo(output);
				}

				var binaryFormatter = new BinaryFormatter();

				using (MemoryStream serialized = new MemoryStream(output.ToArray()))
				{
					VirtualMemoryDomain VMD = (VirtualMemoryDomain)binaryFormatter.Deserialize(serialized);
					return VMD;
				}
			}
		}

		public override string ToString()
		{
			return "[V]" + Name;
			//Virtual Memory Domains always start with [V]
		}

		public override byte[] GetDump()
		{
			return PeekBytes(0, Size);
		}

		public override byte[] PeekBytes(long startAdress, long endAddress, bool raw = true)
		{
			//endAddress is exclusive
			List<byte> data = new List<byte>();
			for (long i = startAdress; i < endAddress; i++)
				data.Add(PeekByte(i));

			if (raw || BigEndian)
				return data.ToArray();
			else
				return data.ToArray().FlipBytes();
		}

		
		public override byte PeekByte(long address)
		{
			if (address < this.Proto.Padding)
				return (byte)0;
			string targetDomain = GetRealDomain(address);
			long targetAddress = GetRealAddress(address);
			//We use MDPs here as we have to extract the real address and domain from the VMD
			MemoryDomainProxy mdp = RTC_MemoryDomains.GetProxy(targetDomain, targetAddress);

			return mdp?.PeekByte(targetAddress) ?? 0;
		}

		public override void PokeByte(long address, byte value)
		{
			if (address < this.Proto.Padding)
				return;

			string targetDomain = GetRealDomain(address);
			long targetAddress = GetRealAddress(address);
			//We use MDPs here as we have to extract the real address and domain from the VMD
			MemoryDomainProxy mdp = RTC_MemoryDomains.GetProxy(targetDomain, targetAddress);

			mdp?.PokeByte(targetAddress, value);
		}
	}

	/*
    [Serializable]
    [XmlType("MP")]
    public class MemoryPointer
    {
        [XmlElement("D")]
        public string DomainData { get; set; }
        [XmlIgnore]
        public string Domain { get { return (IsEnabled ? DomainData : ""); }}
        [XmlElement("A")]
        public long AddressData { get; set; }
        [XmlIgnore]
        public long Address { get { return (IsEnabled ? AddressData : 0); } }
        [XmlElement("E")]
        public bool IsEnabled { get; set; }

        public MemoryPointer(string _domain, long _address)
        {
            DomainData = _domain;
            AddressData = _address;
            IsEnabled = true;
        }

        public MemoryPointer()
        {
        }

        public override string ToString()
        {
            return $"[{(IsEnabled ? "x" : " ")}] {DomainData}({AddressData})";

            //Gives: [x] ROM(123)
        }
    }
    */

	[Serializable]
	public class MemoryDomainProto
	{
		public bool Main = false;

		public long Size = 0;
		public int WordSize = 1;
		public string Name = "UNASSIGNED";
		public bool BigEndian = true;
	}

	[Serializable]
	public class MemoryDomainProxy : MemoryInterface
	{
		[NonSerialized]
		public MemoryDomainProto proto = null;

		public override long Size { get; set; }

		public MemoryDomainProxy(MemoryDomainProto _proto)
		{
			proto = _proto;


			Name = proto.ToString();
			Size = proto.Size;
			WordSize = proto.WordSize;
			BigEndian = proto.BigEndian;
		}

		public override string ToString()
		{
			return Name;
		}

		public void Detach()
		{
			proto = null;
		}

		public override byte[] GetDump()
		{
			return PeekBytes(0, Size);
		}

		public override byte[] PeekBytes(long startAddress, long endAddress, bool raw = true)
		{
			//endAddress is exclusive
			List<byte> data = new List<byte>();
			for (long i = startAddress; i < endAddress; i++)
				data.Add(PeekByte(i));

			if(raw || BigEndian)
				return data.ToArray();
			else
				return data.ToArray().FlipBytes();
		}


		public override byte PeekByte(long address)
		{
			//change this to a local router call

			if (proto == null)
				return (byte)NetCoreImplementation.SendCommandToBizhawk(new RTC_Command(CommandType.REMOTE_DOMAIN_PEEKBYTE) { objectValue = new object[] { Name, address } }, true);
			else
				return proto.PeekByte(address);
		}

		public override void PokeByte(long address, byte value)
		{
			//change this to a local router call

			if (proto == null)
				NetCoreImplementation.SendCommandToBizhawk(new RTC_Command(CommandType.REMOTE_DOMAIN_POKEBYTE) { objectValue = new object[] { Name, address, value } });
			else
				proto.PokeByte(address, value);
		}
	}


}
