using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExamWork
{
    public class StringNumber
    {
        private object syncObject = new object();

        public string Text { get; set; } = String.Empty;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void AddNum(object num)
        {
            lock (syncObject)
            {
                Text += num.ToString() + ' ';
            }
        }
    }
}
