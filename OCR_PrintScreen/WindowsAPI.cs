using System.Runtime.InteropServices;

namespace OCR_PrintScreen
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

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="hWnd">要定义热键的窗口的句柄</param>
        /// <param name="id">定义热键ID（不能与其它ID重复）</param>
        /// <param name="fsModifiers">标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效</param>
        /// <param name="vk">定义热键的内容</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, HotkeyModifiers fsModifiers, Keys vk);

        /// <summary>
        /// 释放热键
        /// </summary>
        /// <param name="hWnd">要取消热键的窗口的句柄</param>
        /// <param name="id">要取消热键的ID</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
    }
}
