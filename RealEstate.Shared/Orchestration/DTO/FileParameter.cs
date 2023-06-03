#nullable disable
using System.Reflection;

namespace RealEstate.Shared.Orchestration.DTO
{
    public class FileParameter
    {
        public byte[] File { get; }
        public string FileName { get; }
        public string ContentType { get; }
        public FileParameter(byte[] file) : this(file, null) { }
        public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
        public FileParameter(byte[] file, string filename, string contenttype)
        {
            File = file;
            FileName = filename;
            ContentType = contenttype;
        }

        public static FileParameter FromManifestResource(Assembly assembly, string resourcePath)
        {
            Stream resourceAsStream = assembly.GetManifestResourceStream(resourcePath);
            byte[] resourceAsBytearray;
            using (MemoryStream ms = new MemoryStream())
            {
                resourceAsStream.CopyTo(ms);
                resourceAsBytearray = ms.ToArray();
            }

            string assemblyBaseName = assembly.GetName().Name;
            string fileLocalName = resourcePath.Replace(assemblyBaseName + ".", "");

            return new FileParameter(resourceAsBytearray, fileLocalName);
        }
    }
}
