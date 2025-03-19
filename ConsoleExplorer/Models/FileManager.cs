namespace ConsoleExplorer.Models
{
    abstract class FileManager
    {
        public abstract void ReadFile(string filePath);
        public abstract void WriteFile(string filePath);
        public abstract void CreateFile(string filePath);
        public abstract void DeleteFile(string filePath);
        public abstract void CopyFile(string filePath);
        public abstract void MoveFile(string filePath);
        public abstract void SearchFile(string filePath, string input);
    }
}
