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

        public List<QuestItem> GetVariantQuest(Variant _variant)
        {
            Chapter ch = _variant.Chapter;
            Variant vr = ch.Variants.Where(i => i.Id == _variant.Id).FirstOrDefault<Variant>();
            return vr.QuestItems.ToList<QuestItem>();
        }

        public List<QuestItem> GetChildren(Variant _variant) {
            return GetVariantQuest(_variant);
        }

        public List<Quest> GetChildren(Chapter _chapter)
        {           
            return getChapterQuests(_chapter);
        }

 
    }
}
