namespace ITI_Project.DTO
{
    public class InstractorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? HourRate { get; set; }
        public int? Salary { get; set; }
        public string Address { get; set; }

        public List<string> DepartmentNames { get; set; }= new List<string>();
        public List<string> Courses { get; set; }= new List<string>();
    }
}
