namespace TodoMinimalApi.Models
{
    public class Todo : BaseModel
    {
        public string? Title { get; set; }
        public bool Completed { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
