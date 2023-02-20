using JobApplicant.Model;
using JobApplicant.Services;

namespace JobApplicant
{
    public class ApplicationEvaluator
    {
        private readonly int age = 18;
        private readonly int expericen = 15;
        private List<string> techStack = new() { "c#", "rabbit", "microser","visual studio" };
        private IIdentyValidator ıdenty;

        public ApplicationEvaluator(IIdentyValidator ıdenty)
        {
            this.ıdenty = ıdenty;
        }

        public ApplicationResult Evaluate(JobApplicant.Model.JobApplicantt form)
        {
            if (form.Applicant.Age < age)
                return ApplicationResult.AutoReject;

            form.validation = form.Applicant.Age > 50 ? validation.detailedi : validation.quic;

            if (ıdenty.location != "Istanbul")
            {
                return ApplicationResult.TransferredToCTO;
            }

            var con = ıdenty.checkconnect();
            var valid = ıdenty.IsValid(form.Applicant.Tc);

            if (!valid)
            {
                return ApplicationResult.TransferredToHr;
            }
            var sr = GetStachRate(form.TechStackList);
            if (sr<25)
            {
                return ApplicationResult.AutoReject;
            }

            if (sr >75 && form.YearsOfExperience> expericen)
            {
                return ApplicationResult.AutoAccepted;
            }
            return ApplicationResult.AutoAccepted;
        }

        private int GetStachRate(List<string> tec)
        {
            var count = tec.Where(i => techStack.Contains(i, StringComparer.OrdinalIgnoreCase)).Count();

            return count / techStack.Count * 100;
        }

        

    }
    public enum ApplicationResult
    {
        AutoReject,
        TransferredToHr,
        TransferredToLead,
        TransferredToCTO,
        AutoAccepted
    }

}