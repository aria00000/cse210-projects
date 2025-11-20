using System;

public class Scripture
{
    private List<Word> _words;
    private Reference _reference;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }



    }

    public void HideWords()
    {
        Random random = new Random();
        int index = random.Next(_words.Count);
        _words[index].Hide();
    }

    public string GetRenderedText()
    {
        string display = _reference.Display() + "\n\n";
        foreach (Word word in _words)
        {
            display += word.GetRenderedText() + " ";
        }
        return display;
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if(!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

        public void ShowOneWord()
    {
        List<Word> hiddenWords = new List<Word>();
        foreach(Word word in _words)
        {
            if(word.IsHidden())
            {
                hiddenWords.Add(word);
            }
        }

        if (hiddenWords.Count > 0)
        {
            Random random = new Random();
            int index = random.Next(hiddenWords.Count);
            hiddenWords[index].Show();
        }

    }



}