namespace SyllableCounter
{
    public interface IRecord
    {
        int Id { get; set; }
        int ClassifierGuess { get; set; }
        int UserReport { get; set; }
        string Word { get; set; }
        int SimulatorGuess { get; set; }
        int WrittenMethodGuess { get; set; }
        bool SimulatorGuessCorrect { get; }
        bool WrittenMethodCorrect { get; }
        bool ClassifierCorrect { get; }
    }
}