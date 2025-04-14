using System;
using System.IO;

namespace MidnightCommander.Managers
{
    public class DriveManager
    {
        public DriveManager()
        {

        }
        public long GetDriveCapacity()
        {
            DriveInfo drive = new DriveInfo("C");
            return drive.TotalSize / (1024 * 1024 * 1024);
        }
        public long GetDriveUsedCapacity()
        {
            DriveInfo drive = new DriveInfo("C");
            return (drive.TotalSize - drive.AvailableFreeSpace) / (1024 * 1024 * 1024);
        }
        public long GetDriveUsedPercentage()
        {
            DriveInfo drive = new DriveInfo("C"); 
            return ((drive.TotalSize - drive.AvailableFreeSpace) / drive.TotalSize) * 100;

        }
        public string DrawDriveInfo()
        {
            return $" {GetDriveUsedCapacity()}G / {GetDriveCapacity()}G ({GetDriveUsedPercentage()}%)";
        }
    }
}