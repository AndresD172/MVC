namespace eCommerce.Utils
{
    public class FileUtils
    {
        public static string WriteImage(string filePath, IFormFileCollection files)
        {
            string filename = Guid.NewGuid().ToString();
            string extension = Path.GetExtension(files[0].FileName);

            using (FileStream fileStream = new FileStream(Path.Combine(filePath, filename + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            };

            return filename + extension;
        }
    }
}
