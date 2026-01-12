using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            int col1 = 35;
            int col2 = 75;

            void Col()
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("+" + new string('-', col1) + "+" + new string('-', col2) + "+");
                Console.ResetColor();
            }

            void Row(string left, string right, bool isHeader = false)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|");
                
                if (isHeader)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(left.PadRight(col1));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(left.PadRight(col1));
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("|");

                if (isHeader)
                {
                    Console.Write(right.PadRight(col2));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(right.PadRight(col2));
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("|");
                Console.ResetColor();
            }

            Col();
            Row("MÔI TRƯỜNG HỆ ĐIỀU HÀNH", "", true);
            Col();
            Row("Hệ điều hành", Environment.OSVersion.ToString());
            Row("Nền tảng 64-bit", Environment.Is64BitOperatingSystem.ToString());
            Row("Tên máy", Environment.MachineName);
            Row("Người dùng hiện tại", Environment.UserName);
            Row("Thư mục hệ thống", Environment.SystemDirectory);
            Col();

            Row("TÀI NGUYÊN HỆ THỐNG", "", true);
            Col();
            Row("Số vi xử lý logic", Environment.ProcessorCount.ToString());
            Row("Kích thước trang bộ nhớ", $"{Environment.SystemPageSize} bytes");
            Row("Thời gian chạy ", $"{Environment.TickCount / 60000} phút");
            Col();

            Row("HỆ THỐNG LƯU TRỮ", "", true);
            Col();

            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (!drive.IsReady) continue;

                double total = drive.TotalSize / (1024.0 * 1024 * 1024);
                double free = drive.AvailableFreeSpace / (1024.0 * 1024 * 1024);

                Row($"Ổ đĩa {drive.Name}", $"{free:F2} GB trống / {total:F2} GB ({drive.DriveFormat})");
            }

            Col();

            Row("THÔNG TIN RUNTIME & TIẾN TRÌNH", "", true);
            Col();
            Row("Phiên bản .NET Runtime", Environment.Version.ToString());
            Row("Thư mục hiện tại", Environment.CurrentDirectory);
            Row("ID tiến trình ", Environment.ProcessId.ToString());
            Row("Bộ nhớ đang dùng ", $"{GC.GetTotalMemory(false) / 1024:N0} KB");
            Row("Dòng lệnh", Environment.CommandLine);
            Col();
        }
    }
}
