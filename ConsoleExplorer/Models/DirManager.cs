namespace ConsoleExplorer.Models
{
    abstract class DirManager
    {
        public abstract void ReadDir(string dirPath);
        public abstract void CreateDir(string dirPath);
        public abstract void DeleteDir(string dirPath);
    }
}
