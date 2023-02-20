namespace JobApplicant.Model
{
    public class JobApplicantt
    {
        public Applicant Applicant { get; set; }
        public int YearsOfExperience { get; set; }
        public List<string> TechStackList { get; set; }
        public validation validation { get; set; }

    }

    public enum validation
    {
        detailedi,

        quic
    }

}
