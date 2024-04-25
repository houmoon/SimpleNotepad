using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace SimpleNotepad
{
	/// <summary>
	/// This class implements the tool window exposed by this package and hosts a user control.
	/// </summary>
	/// <remarks>
	/// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
	/// usually implemented by the package implementer.
	/// <para>
	/// This class derives from the ToolWindowPane class provided from the MPF in order to use its
	/// implementation of the IVsUIElementPane interface.
	/// </para>
	/// </remarks>
	[Guid("6c7eb564-5582-4307-9838-9ede38daa61f")]
	public class MemoWindow : ToolWindowPane
	{

		public void LoadText()
		{
			((MemoWindowControl)Content)?.LoadText();
		}

		public void SaveText()
		{
			((MemoWindowControl)Content)?.SaveText();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MemoWindow"/> class.
		/// </summary>
		public MemoWindow() : base(null)
		{
			this.Caption = "Memo";

			// This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
			// we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
			// the object returned by the Content property.
			this.Content = new MemoWindowControl();
		}
	}
}
