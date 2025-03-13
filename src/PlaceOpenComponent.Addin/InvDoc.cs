namespace PlaceOpenComponent
{
    public class InvDoc
    {
        public InvDoc(string name, string filePath, Image thumbnail)
        {
            FilePath = filePath;
            Name = name;
            Thumbnail = thumbnail;
        }
        public string Name { get; }
        public string FilePath { get; }
        public Image Thumbnail { get; }
    }
}
