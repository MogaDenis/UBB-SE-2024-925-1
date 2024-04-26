namespace NamespaceCBlurred.Data.Models
{
    public enum SoundType
    {
        DRUMS,
        INSTRUMENT,
        FX,
        VOICE
    };

    public class Sound
    {
        public Sound(int id, string name, SoundType type, string soundFilePath = "")
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.SoundFilePath = soundFilePath;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public SoundType Type { get; set; }
        public string SoundFilePath { get; set; }
    }
}