namespace SyllableCounter
{
    interface ITrainingData
    {
        int Index { get; set; }
        int Phonemes { get; set; }
        int Syllables { get; set; }
        string Word { get; set; }
    }
}