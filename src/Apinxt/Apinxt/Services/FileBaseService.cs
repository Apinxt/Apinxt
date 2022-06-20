using Apinxt.Config;
using System.Text.Json;

namespace Apinxt.Services
{
    public class FileBaseService<TContent>
    {
        private readonly FileConfiguration _config;
        private readonly string _fileName;

        public string FileName { get { return _fileName; } }
        public string FileWithExtension
        {
            get
            {
                return $"{_fileName}.json";
            }
        }

        public string FullPathWithFileName
        {
            get
            {
                return Path.Combine(FullPath, $"{FileWithExtension}");
            }
        }

        public string FullPath
        {
            get
            {
                return _config.Path ?? Path.Combine(AppContext.BaseDirectory, "files");
            }
        }

        public FileBaseService(FileConfiguration config, string fileName)
        {
            _config = config;
            _fileName = fileName;
        }

        public async Task Save(TContent content)
        {
            if (!Directory.Exists(FullPath))
                Directory.CreateDirectory(FullPath);

            var contentBytes = JsonSerializer.SerializeToUtf8Bytes(content);
            await File.WriteAllBytesAsync(FullPathWithFileName, contentBytes);
        }


        public async Task<TContent?> Load()
        {
            var content = await File.ReadAllBytesAsync(FullPathWithFileName);

            if (content is null)
                return default;

            return JsonSerializer.Deserialize<TContent>(content);
        }
    }
}
