namespace _153505_Kiselev_Lab4
{
    internal class FileService : IFileService<ArtObject>
    {
        public IEnumerable<ArtObject> ReadFile(string fileName)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(@fileName, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    yield return new ArtObject(reader.ReadString(), reader.ReadInt32(), reader.ReadBoolean());
                }
            }
        }

        public void SaveData(IEnumerable<ArtObject> data, string fileName)
        {
            try
            {
                WritingToFile(data, fileName);
            }
            catch (IOException)
            {
                File.Delete(fileName);

                WritingToFile(data, fileName);
            }
        }

        private void WritingToFile(IEnumerable<ArtObject> data, string @fileName)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.CreateNew)))
            {
                foreach (var item in data)
                {
                    writer.Write(item.Name);
                    writer.Write(item.DateOfCreation);
                    writer.Write(item.Available);
                }
            }
        }
    }
}
