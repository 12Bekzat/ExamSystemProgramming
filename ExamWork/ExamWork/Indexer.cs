using System;

namespace ExamWork
{
    public class Indexer
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; } 
    }
}