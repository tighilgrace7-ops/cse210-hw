using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }
        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("The journal is empty.");
                return;
            }
            Console.WriteLine("/n=== Your Journal ===/n");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
        
        public void SaveToFile(string filename)
        {
            
            try
            {
                using (StreamWriter outputFile = new StreamWriter(filename))
                {
                    foreach (Entry entry in _entries)
                    {
                        string date = EscapeCsv(entry._date);
                        string Prompt = EscapeCsv(entry._promptText);
                        string text = EscapeCsv(entry._entryText);

                        outputFile.WriteLine($"{date},{Prompt},{text}");
                    }
                }
                Console.WriteLine($"✅ Journal successfully saved to {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving file: {ex.Message}");
            }
        }

        public void LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"❌ File '{filename}' not found.");
                return;
            }
            try
            {
                _entries.Clear();

                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    List<string> parts = parseCsvLine(line);

                    if (parts.Count >=3)
                    {
                        Entry entry = new Entry
                        {
                            _date = parts[0],
                            _promptText = parts[1],
                            _entryText = parts[2]
                        };
                        _entries.Add(entry);
                    }
                }
                Console.WriteLine($"✅ Journal loaded successfully from {filename} ({_entries.Count} entries)");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading file: {ex.Message}");
            }
        }

        private string EscapeCsv(string field)
        {
            if (string.IsNullOrEmpty(field)) return "\"\"";
            if (field.Contains(",")|| field.Contains("\"")|| field.Contains("\n"))
            {
                return $"\"{field.Replace("\"", "\"\"")}\"";
            }
            return field;
        }

        private List<string> parseCsvLine(string line)
        {
            List<string> fields = new List<string>();
            bool inQuotes = false;
            string currentField ="";

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ',' && !inQuotes)
                {
                    fields.Add(currentField);
                    currentField = "";
                }
                else
                {
                    currentField += c;
                }
            }
            fields.Add(currentField);

            return fields;
        }
    }
}
