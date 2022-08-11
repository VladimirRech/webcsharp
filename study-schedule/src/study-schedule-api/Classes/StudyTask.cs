using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace study_schedule_api.Classes
{
    [Table("tasks")]
    public class StudyTask
    {
        [Required]
        [Column("ID")]
        public int Id { get; set; }
        [Column("CREATION_DATE")]
        public DateTime CreationDate { get; set; }
        [Column("UPDATE_DATE")]
        public DateTime UpdateDate { get; set; }
        
        [Required]
        [Column("TITLE")]
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        [Column("REMOVED")]
        public bool Removed { get; set; }
        [Column("NOTES")]
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
        [Column("DUE_DATE")]
        public DateTime? DueDate { get; set; }

        // fields
        private string _Title;
        private string _Notes;

        public StudyTask()
        {
            _Title = string.Empty;
            _Notes = string.Empty;
        }
    }
}