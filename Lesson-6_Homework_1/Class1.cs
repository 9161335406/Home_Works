using System.Diagnostics;
using System;

namespace LessonHomework_6_1
{
    internal static class process1
    {
        internal static void KillId(int id)
        {
            Process p1 = Process.GetProcessById(id);
            p1.Kill();
        }
        internal static void KillName(string name)
        {
            foreach (Process p2 in Process.GetProcessesByName(name))
            {
                p2.Kill();
            }

        }
    }
}