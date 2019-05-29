namespace SyllableCounter
{
    interface IRecord
    {
        int Id { get; set; }
        int ClassifierGuess { get; set; }
        int UserReport { get; set; }
        string Word { get; set; }
        int WrittenMethodGuess { get; set; }
        bool WrittenMethodCorrect { get; }
        bool ClassifierCorrect { get; }
    }
}