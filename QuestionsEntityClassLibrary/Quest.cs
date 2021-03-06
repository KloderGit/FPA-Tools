//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuestionsEntityClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quest()
        {
            this.Answers = new HashSet<Answer>();
            this.QuestItems = new HashSet<QuestItem>();
            this.QuestProrams = new HashSet<QuestProram>();
        }
    
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime Modify { get; set; }
        public string Editor { get; set; }
        public Nullable<int> Chapter_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Chapter Chapter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestItem> QuestItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestProram> QuestProrams { get; set; }
    }
}
