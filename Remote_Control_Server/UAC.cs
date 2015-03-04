using System;
using System.Windows.Forms;
using System.Security.Principal;
using System.Diagnostics;

public class UAC
{
    public static void ByPass()
    {
        WindowsIdentity identity = WindowsIdentity.GetCurrent();
        WindowsPrincipal principal = new WindowsPrincipal(identity);
        if (principal.IsInRole(WindowsBuiltInRole.Administrator) == false)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = "cmd.exe";
            processInfo.Arguments = "/c start \"\" \"" + Application.ExecutablePath + "\"";
            processInfo.Verb = "runas";
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            try
            {
                Process.Start(processInfo);
            }
            catch (Exception)
            {
                //Probably the user canceled the UAC window
                MessageBox.Show("获取管理员权限失败！你可能无法控制某些窗口的鼠标键盘操作。", "提示");
                return;
            }
            Environment.Exit(0);
        }
    }
}
