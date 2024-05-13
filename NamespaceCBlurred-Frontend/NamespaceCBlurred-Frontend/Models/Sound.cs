namespace NamespaceCBlurred_Frontend.Models
{
    public enum SoundType
    {
        DRUMS,
        INSTRUMENT,
        FX,
        VOICE
    }

    public class Sound
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public SoundType Type { get; set; }
        public string SoundFilePath { get; set; } = string.Empty;
    }
}
