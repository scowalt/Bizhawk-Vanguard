﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RTCV.NetCore
{
	public class Extensions
	{   /// <summary>
		/// Reference Article http://www.codeproject.com/KB/tips/SerializedObjectCloner.aspx
		/// Provides a method for performing a deep copy of an object.
		/// Binary Serialization is used to perform the copy.
		/// </summary>
		public static class ObjectCopier
		{
			/// <summary>
			/// Perform a deep Copy of the object.
			/// </summary>
			/// <typeparam name="T">The type of object being copied.</typeparam>
			/// <param name="source">The object instance to copy.</param>
			/// <returns>The copied object.</returns>
			public static T Clone<T>(T source)
			{
				if (!typeof(T).IsSerializable)
				{
					throw new ArgumentException("The type must be serializable.", "source");
				}

				// Don't serialize a null object, simply return the default for that object
				if (Object.ReferenceEquals(source, null))
				{
					return default(T);
				}

				IFormatter formatter = new BinaryFormatter();
				Stream stream = new MemoryStream();
				using (stream)
				{
					formatter.Serialize(stream, source);
					stream.Seek(0, SeekOrigin.Begin);
					return (T)formatter.Deserialize(stream);
				}
			}
		}

		public static class ConsoleHelper
		{
			static ConsoleCopy con;
			public static void CreateConsole(string path)
			{
				AllocConsole();
				ConsoleCopy con = new ConsoleCopy(path);

				//Disable the X button on the console window
				EnableMenuItem(GetSystemMenu(GetConsoleWindow(), false), SC_CLOSE, MF_DISABLED);
			}

			private static bool ConsoleVisible = true;
			public static void ShowConsole()
			{
				var handle = GetConsoleWindow();
				ShowWindow(handle, SW_SHOW);
				ConsoleVisible = true;
			}

			public static void HideConsole()
			{
				var handle = GetConsoleWindow();
				ShowWindow(handle, SW_HIDE);
				ConsoleVisible = false;
			}

			public static void ToggleConsole()
			{
				if (ConsoleVisible)
					HideConsole();
				else
					ShowConsole();
			}

			// P/Invoke required:
			internal const int SW_HIDE = 0;
			internal const int SW_SHOW = 5;

			internal const int SC_CLOSE = 0xF060;           //close button's code in Windows API
			internal const int MF_ENABLED = 0x00000000;     //enabled button status
			internal const int MF_GRAYED = 0x1;             //disabled button status (enabled = false)
			internal const int MF_DISABLED = 0x00000002;    //disabled button status

			private const UInt32 StdOutputHandle = 0xFFFFFFF5;
			[DllImport("kernel32.dll")]
			private static extern IntPtr GetStdHandle(UInt32 nStdHandle);
			[DllImport("kernel32.dll")]
			private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);
			[DllImport("kernel32")]
			static extern bool AllocConsole();
			[DllImport("kernel32.dll", SetLastError = true)]
			public static extern IntPtr GetConsoleWindow();
			[DllImport("user32.dll")]
			public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
			[DllImport("user32.dll")]
			public static extern IntPtr GetSystemMenu(IntPtr HWNDValue, bool isRevert);
			[DllImport("user32.dll")]
			public static extern int EnableMenuItem(IntPtr tMenu, int targetItem, int targetStatus);
			class ConsoleCopy : IDisposable
			{
				FileStream fileStream;
				StreamWriter fileWriter;
				TextWriter doubleWriter;
				TextWriter oldOut;

				class DoubleWriter : TextWriter
				{

					TextWriter one;
					TextWriter two;

					public DoubleWriter(TextWriter one, TextWriter two)
					{
						this.one = one;
						this.two = two;
					}

					public override Encoding Encoding
					{
						get { return one.Encoding; }
					}

					public override void Flush()
					{
						one.Flush();
						two.Flush();
					}

					public override void Write(char value)
					{
						one.Write(value);
						two.Write(value);
					}

				}

				public ConsoleCopy(string path)
				{
					oldOut = Console.Out;

					try
					{
						fileStream = File.Create(path);

						fileWriter = new StreamWriter(fileStream);
						fileWriter.AutoFlush = true;

						doubleWriter = new DoubleWriter(fileWriter, oldOut);
					}
					catch (Exception e)
					{
						Console.WriteLine("Cannot open file for writing");
						Console.WriteLine(e.Message);
						return;
					}
					Console.SetOut(doubleWriter);
					Console.SetError(doubleWriter);
				}

				public void Dispose()
				{
					Console.SetOut(oldOut);
					if (fileWriter != null)
					{
						fileWriter.Flush();
						fileWriter.Close();
						fileWriter = null;
					}
					if (fileStream != null)
					{
						fileStream.Close();
						fileStream = null;
					}
				}
			}
		}
	}
}
