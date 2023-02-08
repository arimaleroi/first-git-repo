using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_3Chernysh
{
    public delegate void NotifyDelegate(Newspapers newspapers);
    internal class Post
    {
        public event NotifyDelegate Notify;

        private List<Newspapers> news = new List<Newspapers>();

        public void Subscribe(Newspapers newspapers)
        {
            news.Add(newspapers);
            Notify(newspapers);
        }

        public void UnSubscribe(Newspapers newspapers)
        {
            news.Remove(newspapers);
            Notify(newspapers);
        }

        public void Send(Newspapers newspapers)
        {
            if (news.Any(n => n.NameOfNewspaper == newspapers.NameOfNewspaper))
            {
                Notify(newspapers);
            }
        }
    }
}
