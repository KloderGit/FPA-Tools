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

        public List<Chapter> getChaptersOriginal() {

            List<Chapter> items = new List<Chapter>();

            using (QuestionsContext db = new QuestionsContext())
            {
                try
                {
                    //db.Database.Log = Console.Write;

                    items = db.Chapters.Include("Variants.QuestItems.Quest").Include("Quests").ToList<Chapter>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return items;
        }

        public List<Chapter> getChapters(int _chapter)
        {
            return _Chapters.Where(c => c.Id == _chapter).ToList<Chapter>();
        }

        public List<Chapter> getChaptersOriginal(int _chapterId)
        {

            List<Chapter> items = new List<Chapter>();

            using (QuestionsContext db = new QuestionsContext())
            {
                try
                {
                    db.Database.Log = Console.Write;

                    items = db.Chapters.Include("Variants.QuestItems.Quest").Include("Quests").Where(ch => ch.Id == _chapterId).ToList<Chapter>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return items;
        }

        public List<Chapter> getChapters(Chapter _chapter)
        {
            return _Chapters.Where(c => c.Id == _chapter.Id).ToList<Chapter>();
        }

        public List<Chapter> getChaptersOriginal(Chapter _chapter)
        {

            List<Chapter> items = new List<Chapter>();

            using (QuestionsContext db = new QuestionsContext())
            {
                try
                {
                    db.Database.Log = Console.Write;

                    items = db.Chapters.Include("Variants.QuestItems.Quest").Include("Quests").Where(ch => ch.Id == _chapter.Id).ToList<Chapter>();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return items;
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

        public bool editChapter(Chapter _chapter)
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

        public bool removeChapter(Chapter _chapter)
        {
            using (QuestionsContext db = new QuestionsContext())
            {
                try
                {
                    db.Database.Log = Console.Write;

                    db.Chapters.Attach(_chapter);
                    //db.Entry(_chapter).State = System.Data.Entity.EntityState.Deleted;
                    db.Chapters.Remove(_chapter);
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

        public bool addChapter(Chapter _chapter)
        {

            using (QuestionsContext db = new QuestionsContext())
            {
                try
                {
                    db.Database.Log = Console.Write;

                    db.Chapters.Attach(_chapter);
                    db.Entry(_chapter).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    LoadChapter();
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

        public bool editVariant(Variant _variant) {
            _variant.Modify = DateTime.Now;

            using (QuestionsContext db = new QuestionsContext())
            {
                try
                {
                    db.Database.Log = Console.Write;

                    db.Variants.Attach(_variant);
                    db.Entry(_variant).State = System.Data.Entity.EntityState.Modified;
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

        public bool addVariant(Variant _variant) {

            using (QuestionsContext db = new QuestionsContext()) {
                try
                {
                    db.Database.Log = Console.Write;

                    db.Variants.Attach(_variant);
                    db.Entry(_variant).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    LoadChapter();
                    return true;
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        public bool removeVariant(Variant _variant) {
            using (QuestionsContext db = new QuestionsContext()) {
                try
                {
                    db.Database.Log = Console.Write;

                    db.Variants.Attach(_variant);
                    db.Entry(_variant).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }



    }
}
