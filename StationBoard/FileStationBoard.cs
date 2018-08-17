using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using StationBoard.Models;

namespace StationBoard
{
    public class FileStationBoard : IStationBoard
    {
        private string _scheduledFile;
        private string _announcementsFile;
        private bool _rewriteContents;
        private int _scheduleLength;

        public FileStationBoard(string announcementsFile, string scheduleFile, int scheduleLength, bool rewriteContents = true)
        {
            _announcementsFile = announcementsFile;
            _scheduledFile = scheduleFile;
            _rewriteContents = rewriteContents;
            _scheduleLength = scheduleLength;
        }
        
        public void Announce(string message)
        {
            ClearFileIfNecessary(_announcementsFile);
            WriteContentToFile(_announcementsFile, message);
        }

        public void ShowNextArrivals(IEnumerable<string> arrivals)
        {
            ClearFileIfNecessary(_scheduledFile);
            WriteContentToFile(_scheduledFile, arrivals.Take(_scheduleLength).ToArray());
        }

        private void ClearFileIfNecessary(string filePath)
        {
            if (_rewriteContents)
            {
                File.Delete(filePath);
                File.Create(filePath).Close();
            }
        }

        private void WriteContentToFile(string path, params string[] contents)
        {
            using (var fs = File.OpenWrite(path))
            {
                foreach (var line in contents)
                {
                    var buffer = Encoding.UTF8.GetBytes(line+Environment.NewLine);
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Flush();
                }
            }
        }
    }
}