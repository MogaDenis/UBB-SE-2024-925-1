using NamespaceCBlurred.Data.Models;

namespace NamespaceCBlurred.Business.Models
{
    public class SoundForAddUpdateModel
    {
        public string Name { get; set; } = null!;
        public SoundType Type { get; set; }
        public string SoundFilePath { get; set; } = null!;
    }
}
