using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public static class JPGDiskInfo
    {
        public static long DiskSize()
        {
            foreach (var driver in DriveInfo.GetDrives())
            {
                if(driver.IsReady)
                {
                    return driver.AvailableFreeSpace;
                }
            }
            return -1;
        }
        public static string FileSystemInfo()
        {
            foreach (var driver in DriveInfo.GetDrives())
            {
                if (driver.IsReady)
                {
                    return driver.DriveFormat;
                }
            }
            return "";
        }
        public static string DiskInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var driver in DriveInfo.GetDrives())
            {
                if (driver.IsReady)
                {
                    sb.Append("Name:");
                    sb.Append(driver.Name);
                    sb.Append(", Size:");
                    sb.Append(driver.TotalSize);
                    sb.Append(", FreeSize:");
                    sb.Append(driver.AvailableFreeSpace);
                    sb.Append(", Lable:");
                    sb.Append(driver.VolumeLabel);
                }
            }
            return sb.ToString();
        }
    }
}
