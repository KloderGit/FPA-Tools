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

        //  --------------------------------------------------------------------------
        //  Темы ---------------------------------------------------------------------
        #region Выборка из Chapter
        //  --------------------------------------------------------------------------
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
            return _chapter.Quests.ToList<Quest>();
        }

        public void LoadChapter()
        {
            using (QuestionsContext db = new QuestionsContext())
            {
                try
                {
                   //db.Database.Log = Console.Write;

                    _Chapters = db.Chapters.Include("Variants.QuestItems.Quest").Include("Quests").ToList<Chapter>();
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
                
            }
        }

        public bool saveChapter(Chapter _chapter)
        {

            _chapter.Modify = DateTime.Now;

            using (QuestionsContext db = new QuestionsContext())
            {
                db.Database.Log = Console.Write;
                db.Chapters.Attach(_chapter);
                db.Entry(_chapter).State = System.Data.Entity.EntityState.Modified;

                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        //  --------------------------------------------------------------------------
        #endregion
        //  Темы Конец ---------------------------------------------------------------
        //  --------------------------------------------------------------------------

        public List<QuestItem> GetVariantQuest(Variant _variant)
        {
            //Chapter ch = _variant.Chapter;
            //Variant vr = ch.Variants.Where(i => i.Id == _variant.Id).FirstOrDefault<Variant>();
            return _variant.QuestItems.ToList<QuestItem>();
        }

        public List<QuestItem> GetChildren(Variant _variant) {
            return GetVariantQuest(_variant);
        }

        public List<Quest> GetChildren(Chapter _chapter)
        {           
            return getChapterQuests(_chapter);
        }

        public bool saveVariant(Variant _variant) {
            _variant.Modify = DateTime.Now;

            using (QuestionsContext db = new QuestionsContext())
            {
                db.Database.Log = Console.Write;
                db.Variants.Attach(_variant);
                db.Entry(_variant).State = System.Data.Entity.EntityState.Modified;

                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }



    }
}
