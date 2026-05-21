using System;
using System.Collections.Generic;

namespace JournalApp
{
    public class PromptGenerator
    {
        private List<string> _Prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What am I grateful for today?",
            "What did I learn today?",
            "How can I improve tomorrow based on today?",
            "What made me smile today?",
            "What challenge did I overcome today?"
        };
        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_Prompts.Count);
            return _Prompts[index];
        }
    }
}