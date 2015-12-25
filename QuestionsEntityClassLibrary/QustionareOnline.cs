using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace QuestionsEntityClassLibrary
{
    public class QustionareOnline
    {
        QuestionsContext db;

        public QustionareOnline(){
            Connect();
            db.Chapters.Load();
            db.Programs.Load();
        }

        public bool Connect() {
            try
            {
                db = new QuestionsContext();
                return true;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public ObservableCollection<Chapter> getChapter() {
            return db.Chapters.Local;
        }

        public ObservableCollection<Program> getPrograms()
        {
            return db.Programs.Local;
        }

        public bool editChapter(Chapter _chapter) {
            bool result;
            try
            {
                _chapter.Modify = DateTime.Now;
                db.Entry(_chapter).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool addChapter(Chapter _chapter) {
            bool result;
            try
            {
                _chapter.Created = DateTime.Now;
                _chapter.Modify = DateTime.Now;
                db.Chapters.Add(_chapter);
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool removeChapter(Chapter _chapter) {
            bool result;
            try
            {
                db.Chapters.Remove(_chapter);
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }


        public bool editVariant(Variant _variant)
        {
            bool result;
            try
            {
                _variant.Modify = DateTime.Now;
                db.Entry(_variant).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool addVariant(Variant _variant)
        {
            bool result;
            try
            {
                _variant.Created = DateTime.Now;
                _variant.Modify = DateTime.Now;

                var ch = db.Chapters.Find(_variant.Chapter_Id);
                ch.Variants.Add(_variant);

                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool removeVariant(Variant _variant)
        {
            bool result;
            try
            {
                db.Variants.Remove(_variant);
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }



        public bool editQuest(Quest _quest) {
            bool result;
            try
            {
                db.Database.Log = Console.Write;
                _quest.Modify = DateTime.Now;
                db.Entry(_quest).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool addQuest(Quest _quest)
        {
            bool result;
            _quest.Created = DateTime.Now;
            _quest.Modify = DateTime.Now;
            try
            {
                db.Quests.Add(_quest);
                db.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool removeAnswers(IEnumerable<Answer> _list)
        {
            bool result;

            try
            {
                int i = _list.Count()-1;
                while (_list.Count() != 0) {
                    var it = _list.ElementAt(i);
                    db.Entry(it).State = EntityState.Deleted;
                    i--;
                }

                db.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool removeProgram(QuestProram _item)
        {
            bool result;

            try
            {
                db.QuestProrams.Remove(_item);
                //db.Entry(_item).State = EntityState.Deleted;

                db.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool removeQuests(List<Quest> _list)
        {
            bool result;

            try
            {
                db.Database.Log = Console.Write;
                //foreach (var item in _list)
                //{
                //    db.Quests.Remove(item);

                //    //db.Entry(item).State = EntityState.Deleted;
                //}

                db.Quests.RemoveRange(_list);
                db.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public bool removeQuestsItems(List<QuestItem> _list)
        {
            bool result;

            try
            {
                db.Database.Log = Console.Write;
                //foreach (var item in _list)
                //{
                //    db.Quests.Remove(item);

                //    //db.Entry(item).State = EntityState.Deleted;
                //}

                db.QuestItems.RemoveRange(_list);
                db.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            return result;
        }

        public void Reload(Chapter _chapter) {

            Console.WriteLine(_chapter.Text);
            db = new QuestionsContext();
        }

        //  namespace
    }
}
