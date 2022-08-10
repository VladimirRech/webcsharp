namespace study_schedule_api.Classes
{
    public class StudyTask
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        public bool Removed { get; set; }
        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }
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