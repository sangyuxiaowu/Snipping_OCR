using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OCR_PrintScreen
{
    /// <summary>
    /// 快捷键注册注销管理
    /// </summary>
    internal static class Hotkey
    {

        // message
        private const int WM_HOTKEY = 786;

        //区分不同的快捷键
        private static int keyid = 10;

        //每一个key对应一个处理函数
        private static Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();

        public delegate void HotKeyCallBackHanlder();


        /// <summary> 
        /// 注册快捷键 
        /// </summary> 
        /// <param name="hWnd">持有快捷键窗口的句柄</param> 
        /// <param name="fsModifiers">组合键</param> 
        /// <param name="vk">快捷键的虚拟键码</param> 
        /// <param name="callBack">回调函数</param> 
        public static void Regist(IntPtr hWnd, HotkeyModifiers fsModifiers, Keys vk, HotKeyCallBackHanlder callBack)
        {
            int num = keyid++;
            if (!WindowsAPI.RegisterHotKey(hWnd, num, fsModifiers, vk))
            {
                throw new Exception("点击继续可以使用，但是软件的快捷键将不会生效！");
            }
            keymap[num] = callBack;
        }

        /// <summary> 
        /// 注销快捷键 
        /// </summary> 
        /// <param name="hWnd">持有快捷键窗口的句柄</param> 
        /// <param name="callBack">回调函数</param> 
        public static void UnRegist(IntPtr hWnd, HotKeyCallBackHanlder callBack)
        {
            foreach (KeyValuePair<int, HotKeyCallBackHanlder> keyValuePair in keymap)
            {
                if (keyValuePair.Value == callBack)
                {
                    WindowsAPI.UnregisterHotKey(hWnd, keyValuePair.Key);
                }
            }
        }

        /// <summary> 
        /// 快捷键消息处理 
        /// </summary> 
        public static void ProcessHotKey(Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                int key = m.WParam.ToInt32();
                HotKeyCallBackHanlder hotKeyCallBackHanlder;
                if (keymap.TryGetValue(key, out hotKeyCallBackHanlder))
                {
                    hotKeyCallBackHanlder();
                }
            }
        }


    }

    /// <summary>
    /// 组合控制键
    /// </summary>
    public enum HotkeyModifiers
    {
        MOD_ALT = 1,
        MOD_CONTROL,
        MOD_SHIFT = 4,
        MOD_WIN = 8,
        MOD_CONTROL_ALT = 3
    }
}
