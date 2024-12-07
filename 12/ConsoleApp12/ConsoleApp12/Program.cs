using System;
using System.IO;
using System.IO.Compression;

namespace Lab12
{
    public static class SDVLog
    {
        private static readonly string LogFilePath = "sdvlogfile.txt";

        static SDVLog()
        {
            if (!File.Exists(LogFilePath))
            {
                File.Create(LogFilePath).Close();
            }
        }

        public static void WriteLog(string action, string details)
        {
            try
            {
                string logEntry = $"{DateTime.Now:G} | {action} | {details}";
                File.AppendAllLines(LogFilePath, new[] { logEntry });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в лог: {ex.Message}");
            }
        }

        public static void ReadLogs()
        {
            try
            {
                if (File.Exists(LogFilePath))
                {
                    string[] logs = File.ReadAllLines(LogFilePath);
                    foreach (var log in logs)
                    {
                        Console.WriteLine(log);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения логов: {ex.Message}");
            }
        }
        public static void SearchLogs(string keyword)
        {
            try
            {
                if (File.Exists(LogFilePath))
                {
                    string[] logs = File.ReadAllLines(LogFilePath);
                    var results = logs.Where(log => log.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

                    Console.WriteLine($"Найдено записей: {results.Count}");
                    foreach (var log in results)
                    {
                        Console.WriteLine(log);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка поиска в логах: {ex.Message}");
            }
        }

        public static void SearchLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                if (File.Exists(LogFilePath))
                {
                    string[] logs = File.ReadAllLines(LogFilePath);
                    var results = logs.Where(log =>
                    {
                        if (DateTime.TryParse(log.Split('|')[0].Trim(), out DateTime logTime))
                        {
                            return logTime >= startDate && logTime <= endDate;
                        }
                        return false;
                    }).ToList();

                    Console.WriteLine($"Найдено записей: {results.Count}");
                    foreach (var log in results)
                    {
                        Console.WriteLine(log);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка поиска в логах: {ex.Message}");
            }
        }

        public static int CountLogs()
        {
            try
            {
                if (File.Exists(LogFilePath))
                {
                    return File.ReadAllLines(LogFilePath).Length;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка подсчета записей: {ex.Message}");
            }

            return 0;
        }

        public static void KeepLogsForCurrentHour()
        {
            try
            {
                if (File.Exists(LogFilePath))
                {
                    string[] logs = File.ReadAllLines(LogFilePath);
                    DateTime currentHour = DateTime.Now.Date.AddHours(DateTime.Now.Hour);

                    var filteredLogs = logs.Where(log =>
                    {
                        if (DateTime.TryParse(log.Split('|')[0].Trim(), out DateTime logTime))
                        {
                            return logTime >= currentHour && logTime < currentHour.AddHours(1);
                        }
                        return false;
                    }).ToList();

                    File.WriteAllLines(LogFilePath, filteredLogs);
                    Console.WriteLine($"Оставлено записей за текущий час: {filteredLogs.Count}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка удаления записей: {ex.Message}");
            }
        }
    }


    public class SDVDiskInfo
    {
        DriveInfo[] drives;
        public SDVDiskInfo() 
        {
            try
            {
                drives = DriveInfo.GetDrives();
                SDVLog.WriteLog("SDVdiskInfo", "Successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("SDVdiskInfo", "Error");
            }
        }
        public void availableSpace()
        {
            try
            {
                foreach (DriveInfo drive in drives)
                {
                    Console.WriteLine($"Имя диска: {drive.Name}, свободное пространство: {drive.TotalFreeSpace}");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("availableSpace", "Error");
            }
        }

        public void fileSystem()
        {
            try
            {
                foreach(DriveInfo drive in drives)
                {
                    Console.WriteLine($"Имя диска: {drive.Name}, Файловая система: {drive.DriveFormat}");
                    SDVLog.WriteLog("FileSystem", "Successfully");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("FileSystem", "Error");
            }
        }
        
        public void displayDisksInfo()
        {
            try
            {
                foreach(DriveInfo drive in drives)
                {
                    Console.WriteLine($"Имя диска: {drive.Name}");
                    Console.WriteLine($"Объем диска: {drive.TotalSize}");
                    Console.WriteLine($"Свободное место: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка тома: {drive.VolumeLabel}");
                    SDVLog.WriteLog("dispalyDisksInfo", "Successfully");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("dispalyDisksInfo", "Error");

            }
        }
    }
    public class SDVFileInfo
    {
        FileInfo file = new FileInfo("C\\лабы\\Мущук\\ООП\\OOP-3sem\\12");

        public SDVFileInfo(string filePath)
        {
            try
            {
                file = new FileInfo(filePath);
                SDVLog.WriteLog("SDVFileInfo", $"{file.FullName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("SDVFileInfo", "Error");
            }
        }
        public void fullPath()
        {
            try
            {
                if (!file.Exists)
                    throw new InvalidOperationException("Файл не был инициализирован.");

                Console.WriteLine($"Полный путь: {file.FullName}");
                SDVLog.WriteLog("FullPath", $"{file.FullName}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("FullPath", "Error");
            }
        }

        public void dispalyFileFeature()
        {
            try
            {
                if (!file.Exists)
                    throw new InvalidOperationException("Файл не был инициализирован.");

                Console.WriteLine($"Имя файла: {file.Name}");
                Console.WriteLine($"Размер: {file.Length}");
                Console.WriteLine($"Расширение: {file.Extension}");
                SDVLog.WriteLog("dispalyFileFeature", $"{file.FullName}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("dispalyFileFeature", "Error");
            }
        }

        public void displayDateInfo()
        {
            try
            {
                if (!file.Exists)
                    throw new InvalidOperationException("Файл не был инициализирован.");

                Console.WriteLine($"Дата создания: {file.CreationTime}");
                Console.WriteLine($"Дата изменения: {file.LastWriteTime}");
                SDVLog.WriteLog("displayDateInfo", $"{file.FullName}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("displayDateInfo", "Error");
            }
        }
    }
    public class SDVDirInfo
    {
        DirectoryInfo directoryInfo = new DirectoryInfo("C\\лабы\\Мущук\\ООП");

        public SDVDirInfo(string filePath)
        {
            try
            {
                directoryInfo = new DirectoryInfo(filePath);
                SDVLog.WriteLog("SDVDirInfo", $"{directoryInfo.FullName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("SDVDirInfo", "Error");
            }
           
        }

        public void filesCountInDir()
        {
            try
            {
                if (!directoryInfo.Exists)
                {
                    throw new InvalidOperationException("Директория не найдена");
                }

                Console.WriteLine($"Количество файлов: {directoryInfo.GetFiles().Length}");
                SDVLog.WriteLog("filesCountInDir", $"{directoryInfo.FullName}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("filesCountInDir", "Error");
            }
        }

        public void creationTime()
        {
            try
            {
                if (!directoryInfo.Exists)
                {
                    throw new InvalidOperationException("Директория не найдена");
                }

                Console.WriteLine($"Время создания: {directoryInfo.CreationTime}");
                SDVLog.WriteLog("creationTime", $"{directoryInfo.FullName}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("creationTime", "Error");
            }
        }
        public void subdirCount()
        {
            try
            {
                if (!directoryInfo.Exists)
                {
                    throw new InvalidOperationException("Директория не найдена");
                }

                Console.WriteLine($"Количество поддиректориев: {directoryInfo.GetDirectories().Length}");
                SDVLog.WriteLog("subdirCount", $"{directoryInfo.FullName}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("subdirCount", "Error");
            }
        }
        public void parentsDir()
        {
            try
            {
                if (!directoryInfo.Exists)
                {
                    throw new InvalidOperationException("Директория не найдена");
                }

                Console.WriteLine("Родительские директории: ");
                
                var parent = directoryInfo.Parent;
                while (parent != null)
                {
                    Console.WriteLine($"- {parent.FullName}");
                    parent = parent.Parent;
                }
                SDVLog.WriteLog("parentsDir", $"{directoryInfo.FullName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("parentsDir", "Error");
            }
        }


    }
    public class SDVFileManager
    {
        public void InspectDrive(string drivePath = "C:\\")
        {
            try
            {
                string inspectDir = Path.Combine(drivePath, "SDVInspect");

                if (Directory.Exists(inspectDir))
                {
                    Directory.Delete(inspectDir, true);
                }

                Directory.CreateDirectory(inspectDir);

                string logFile = Path.Combine(inspectDir, "sdvdirinfo.txt");
                File.WriteAllLines(logFile, Directory.GetFileSystemEntries(drivePath));

                string copyPath = logFile.Replace(".txt", "Copy.txt");

                if (File.Exists(copyPath))
                {
                    File.Delete(copyPath);
                }

                File.Copy(logFile, copyPath);
                File.Delete(logFile);
                SDVLog.WriteLog("InspectDrive", $"Создана директория: {inspectDir}, файл: {copyPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("InspectDrive", "Error");

            }
        }

        public void ArchiveFiles(string sourceDir, string archiveDir)
        {
            try
            {
                string archiveFile = Path.Combine(archiveDir, "archive.zip");

                if (File.Exists(archiveFile))
                {
                    File.Delete(archiveFile);
                }

                ZipFile.CreateFromDirectory(sourceDir, archiveFile);
                SDVLog.WriteLog("ArchiveFiles", $"Создан архив: {archiveFile} из файлов в {sourceDir}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("ArchiveFiles", "Error");
            }
        }

        public void ExtractArchive(string archivePath, string extractDir)
        {
            try
            {
                if (Directory.Exists(extractDir))
                {
                    Directory.Delete(extractDir, true);
                }

                ZipFile.ExtractToDirectory(archivePath, extractDir);
                SDVLog.WriteLog("ExtractArchive", $"Архив извлечён в {extractDir}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("ExtractArchive", "Error");
            }
        }

        public void CopyFilesWithExtension(string sourceDir, string targetDir, string extension)
        {
            try
            {
                if (!Directory.Exists(targetDir))
                {
                    Directory.CreateDirectory(targetDir);
                }

                string[] files = Directory.GetFiles(sourceDir, $"*{extension}", SearchOption.TopDirectoryOnly);

                foreach (var file in files)
                {
                    string destFile = Path.Combine(targetDir, Path.GetFileName(file));

                    if (File.Exists(destFile))
                    {
                        File.Delete(destFile);
                    }

                    File.Copy(file, destFile, overwrite: true);
                    SDVLog.WriteLog("CopyFilesWithExtension", $"Копирован файл: {file} в {destFile}");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("CopyFilesWithExtension", "Error");
            }
        }

        public void MoveDirectory(string sourceDir, string targetDir)
        {
            try
            {
                string destPath = Path.Combine(targetDir, Path.GetFileName(sourceDir));

                if (Directory.Exists(destPath))
                {
                    Directory.Delete(destPath, true);
                }

                Directory.Move(sourceDir, destPath);
                SDVLog.WriteLog("MoveDirectory", $"Директория перемещена из {sourceDir} в {targetDir}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                SDVLog.WriteLog("MoveDirectory", "Error");
            }
        }
    }


    public class OOP 
    { 
        static void Main()
        {
            SDVDiskInfo diskInfo = new SDVDiskInfo();
            diskInfo.availableSpace();
            diskInfo.fileSystem();
            diskInfo.displayDisksInfo();

            SDVFileInfo fileInfo = new SDVFileInfo("..\\..\\..\\..\\FILE1.txt");
            fileInfo.fullPath();
            fileInfo.dispalyFileFeature();
            fileInfo.displayDateInfo();



            string drivePath = "C:\\"; 
            string inspectDir = Path.Combine(drivePath, "SDVInspect");
            string filesDir = Path.Combine(drivePath, "SDVFiles");
            string archiveDir = Path.Combine(drivePath, "Archives");
            string extractDir = Path.Combine(drivePath, "ExtractedFiles");
            string fileExtension = ".txt"; 

            SDVFileManager fileManager = new SDVFileManager();
            fileManager.InspectDrive("C:\\");

            fileManager.CopyFilesWithExtension("C:\\Для лабы", filesDir, fileExtension);
        
            fileManager.MoveDirectory(filesDir, inspectDir);

            fileManager.ArchiveFiles(inspectDir, archiveDir);

            string archivePath = Path.Combine(archiveDir, "archive.zip");
            fileManager.ExtractArchive(archivePath, extractDir);

            SDVLog.ReadLogs();
            SDVLog.SearchLogs("2аврвар");
            SDVLog.SearchLogs("FileSystem");
            DateTime startDate = DateTime.Now.AddMinutes(-10);
            DateTime endDate = DateTime.Now;
            SDVLog.SearchLogsByDateRange(startDate, endDate);

            int logCount = SDVLog.CountLogs();
            Console.WriteLine($"Количество записей в логе: {logCount}");
            SDVLog.KeepLogsForCurrentHour();
            SDVLog.ReadLogs();

        }
    }

}

