using System.Runtime.InteropServices;

namespace AAAPrintScreen
{
	internal class WindowsAPI
    {
        /// <summary>
		/// 设置指定窗口的显示状态
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="nCmdShow"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}
