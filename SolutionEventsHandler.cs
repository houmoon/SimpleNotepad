using System.IO;
using System.Windows;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace SimpleNotepad
{
	public class SolutionEventsHandler : IVsSolutionEvents
	{
		public int OnAfterOpenProject(IVsHierarchy pHierarchy, int fAdded)
		{
			return VSConstants.S_OK;
		}

		public int OnQueryCloseProject(IVsHierarchy pHierarchy, int fRemoving, ref int pfCancel)
		{
			return VSConstants.S_OK;
		}

		public int OnBeforeCloseProject(IVsHierarchy pHierarchy, int fRemoved)
		{
			return VSConstants.S_OK;
		}

		public int OnAfterLoadProject(IVsHierarchy pStubHierarchy, IVsHierarchy pRealHierarchy)
		{
			return VSConstants.S_OK;
		}

		public int OnQueryUnloadProject(IVsHierarchy pRealHierarchy, ref int pfCancel)
		{
			return VSConstants.S_OK;
		}

		public int OnBeforeUnloadProject(IVsHierarchy pRealHierarchy, IVsHierarchy pStubHierarchy)
		{
			return VSConstants.S_OK;
		}

		public int OnAfterOpenSolution(object pUnkReserved, int fNewSolution)
		{
			// 솔루션 열기 시 동작
			MemoWindow window = MemoWindowCommand.Instance.package.FindToolWindow(typeof(MemoWindow), 0, true) as MemoWindow;

			if (window != null)
			{
				window.LoadText();
			}

			return VSConstants.S_OK;
		}


		public int OnQueryCloseSolution(object pUnkReserved, ref int pfCancel)
		{
			return VSConstants.S_OK;
		}

		public int OnBeforeCloseSolution(object pUnkReserved)
		{
			// 솔루션 닫기 시 동작
			MemoWindow window = MemoWindowCommand.Instance.package.FindToolWindow(typeof(MemoWindow), 0, true) as MemoWindow;

			if (window != null)
			{
				window.SaveText();
			}

			return VSConstants.S_OK;
		}

		public int OnAfterCloseSolution(object pUnkReserved)
		{
			return VSConstants.S_OK;
		}

		// 이하 생략
	}
}