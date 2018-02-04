using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Nice little static sub to easily expand/decompress a ZIP file
// Added by Xavier Flix 9/22/2011

namespace System.IO.Compression
{
    public partial class ZipStorer
    {
        public static void UnZip(string fileName) {
            ZipStorer zip = ZipStorer.Open(fileName, IO.FileAccess.Read);
            List<ZipStorer.ZipFileEntry> dir = zip.ReadCentralDir();

            IO.FileInfo fi = new IO.FileInfo(fileName);
            IO.DirectoryInfo di = new IO.DirectoryInfo(fi.FullName.Replace(fi.Extension, ""));

            if(!di.Exists) di.Create();
            
            foreach(ZipStorer.ZipFileEntry entry in dir) {
                zip.ExtractFile(entry, IO.Path.Combine(di.FullName, entry.FilenameInZip));
            }
            zip.Close();
        }
    }
}
