namespace study_schedule_api.Classes
{
    public class StudyClassResponse
    {
        public StudyTask StudyClass { get; set; }
        public string Message { get; set; }

        public StudyClassResponse()
        {
            StudyClass = new StudyTask();
            Message = string.Empty;
        }
    }
}