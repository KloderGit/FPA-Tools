using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionsEntityClassLibrary
{
    public class Questionare
    {
        List<Chapter> _Chapters = new List<Chapter>();
        List<Quest> _Quests = new List<Quest>();

        public Questionare()
        {
            LoadChapter();
        }

        public List<Chapter> getChapters()
        {
            return _Chapters.ToList<Chapter>();
        }
        public List<Chapter> getChapters(int _chapter)
        {
            return _Chapters.Where(c => c.Id == _chapter).ToList<Chapter>();
        }
        public List<Chapter> getChapters(Chapter _chapter)
        {
            return _Chapters.Where(c => c.Id == _chapter.Id).ToList<Chapter>();
        }

        public List<Quest> getChapterQuests(Chapter _chapter)
        {
            if (!(_Quests.Count > 0))
            {
                LoadQuests();
            }
            return _Quests.Where(q => q.Chapter_Id == _chapter.Id).ToList<Quest>();
        }

        public void LoadQuests()
        {
            using (QuestionsContext db = new QuestionsContext())
            {
                _Quests = db.Quests.Include("Answers").ToList<Quest>();
            }
        }

        public void LoadChapter()
        {
            using (QuestionsContext db = new QuestionsContext())
            {
                _Chapters = db.Chapters.Include("Variants.QuestItems.Quest").ToList<Chapter>();
            }
        }
    }
}
