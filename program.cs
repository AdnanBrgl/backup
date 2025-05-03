using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace TIA_Backup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectFolder = @"C:\Users\MSI\Desktop\automation_task";
            string backupFolder = @"D:\TIA_Backups";
            int maxBackups = 10;
            string logFile = Path.Combine(backupFolder, "yedek_log.txt");
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            string backupFile = Path.Combine(backupFolder, $"TIAProjectBackup_{timestamp}.zip");

            try
            {
                if (!Directory.Exists(backupFolder))
                    Directory.CreateDirectory(backupFolder);

                if (Directory.Exists(projectFolder))
                {
                    ZipFile.CreateFromDirectory(projectFolder, backupFile);
                    Console.WriteLine($"✅ Yedekleme tamamlandı: {backupFile}");
                    File.AppendAllText(logFile, $"[{DateTime.Now}] ✅ Yedekleme tamamlandı: {backupFile}{Environment.NewLine}");
                }
                else
                {
                    string msg = $"❌ Proje klasörü bulunamadı: {projectFolder}";
                    Console.WriteLine(msg);
                    File.AppendAllText(logFile, $"[{DateTime.Now}] {msg}{Environment.NewLine}");
                    return;
                }

                var backups = new DirectoryInfo(backupFolder)
                    .GetFiles("TIAProjectBackup_*.zip")
                    .OrderByDescending(f => f.CreationTime)
                    .ToList();

                if (backups.Count > maxBackups)
                {
                    var toDelete = backups.Skip(maxBackups);
                    foreach (var file in toDelete)
                    {
                        try
                        {
                            file.Delete();
                            Console.WriteLine($"🗑 Silindi: {file.FullName}");
                            File.AppendAllText(logFile, $"[{DateTime.Now}] 🗑 Silindi: {file.FullName}{Environment.NewLine}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"❌ Silinemedi: {file.FullName} - {ex.Message}");
                            File.AppendAllText(logFile, $"[{DateTime.Now}] ❌ Silinemedi: {file.FullName} - {ex.Message}{Environment.NewLine}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Hata oluştu: {ex.Message}");
                File.AppendAllText(logFile, $"[{DateTime.Now}] ❌ Genel hata: {ex.Message}{Environment.NewLine}");
            }
        }
    }
}
