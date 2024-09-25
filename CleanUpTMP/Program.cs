namespace CleanUpTMP
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CleanUpTMP.exe <directory_path> <duration> [scan_subdirectories]");
                return;
            }

            string directoryPath = args[0];
            string duration = args[1];
            bool scanSubdirectories = args.Length > 2 && args[2].ToLower() == "true";

            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Error: The directory '{directoryPath}' does not exist.");
                return;
            }

            DateTime cutoffDate;
            try
            {
                cutoffDate = ParseDuration(duration);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            CleanTemporaryFiles(directoryPath, cutoffDate, scanSubdirectories);
        }

        private static DateTime ParseDuration(string duration)
        {
            char unit = duration[^1]; // Last character
            string numberPart = duration[0..^1]; // All except last character

            if (!int.TryParse(numberPart, out int number))
            {
                throw new FormatException("Error: The duration must be a number followed by a valid unit (d, w, m, y).");
            }

            return unit switch
            {
                'd' => DateTime.Now.AddDays(-number),
                'w' => DateTime.Now.AddDays(-number * 7),
                'm' => DateTime.Now.AddMonths(-number),
                'y' => DateTime.Now.AddYears(-number),
                _ => throw new FormatException("Error: Invalid unit. Use d (days), w (weeks), m (months), or y (years).")
            };
        }

        private static void CleanTemporaryFiles(string directoryPath, DateTime cutoffDate, bool scanSubdirectories)
        {
            try
            {
                var files = Directory.GetFiles(directoryPath, "*.tmp", scanSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    if (fileInfo.LastAccessTime < cutoffDate)
                    {
                        Console.WriteLine($"Deleting: {fileInfo.FullName} (Last accessed: {fileInfo.LastAccessTime})");
                        File.Delete(file);
                    }
                }

                Console.WriteLine("Cleanup complete.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
