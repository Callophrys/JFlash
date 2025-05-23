namespace JFlash
{
    public class GroupFiles
    {
        public bool expanded { get; set; }
        public HashSet<string> files { get; set; } = []; 
    }
}