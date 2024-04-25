using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace SimpleNotepad
{
	[PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
	[Guid(SimpleNotepadPackage.PackageGuidString)]
	[ProvideMenuResource("Menus.ctmenu", 1)]
	[ProvideToolWindow(typeof(MemoWindow))]
	public sealed class SimpleNotepadPackage : AsyncPackage
	{
		public const string PackageGuidString = "e8f0414c-c2f9-4d6c-bb53-28544c907558";

		private uint _solutionEventsCookie;
		public IVsSolution Solution;

		#region Package Members

		protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
		{
			await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
		    await MemoWindowCommand.InitializeAsync(this);

			//솔루션 이벤트 등록
			Solution = await GetServiceAsync(typeof(SVsSolution)) as IVsSolution;
		    if (Solution != null)
		    {
			    var solutionEventsHandler = new SolutionEventsHandler();
			    Solution.AdviseSolutionEvents(solutionEventsHandler, out _solutionEventsCookie);
			}
		    

		}



		#endregion


		protected override void Dispose(bool disposing)
		{
			try
			{
				if (Solution != null && _solutionEventsCookie != 0)
				{
					// 솔루션 이벤트 핸들러 등록 해제
					Solution.UnadviseSolutionEvents(_solutionEventsCookie);
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
	}
}
