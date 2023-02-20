using JobApplicant;
using JobApplicant.Model;
using JobApplicant.Services;
using Moq;
using static JobApplicant.ApplicationEvaluator;

namespace job.test
{
    public class ApplacationTest
    {

        [Test]

        public void Application_withUnderAGe_TransferredAutoReject()
        {
            //Arrange
            var mok = new Mock<IIdentyValidator>();
            mok.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            var eval = new ApplicationEvaluator(mok.Object);
            var form = new JobApplicantt()
            {

                Applicant = new Applicant() { Age=17,Tc = "" },

            };
            //Action
             var appResult=eval.Evaluate(form);
            //Assert

            Assert.AreEqual(appResult, ApplicationResult.AutoReject);
        }

        [Test]

        public void Application_withnoTech_TransferredAutoReject()
        {
            //Arrange
            var mok = new Mock<IIdentyValidator>(MockBehavior.Loose);
            mok.Setup(i => i.location).Returns("Istanbul");
            mok.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            var eval = new ApplicationEvaluator(mok.Object);
            var form = new JobApplicantt()
            {

                Applicant = new Applicant() { Age = 19,Tc=""},
                TechStackList = new List<string>() { ""},


            };
            //Action
            var appResult = eval.Evaluate(form);
            //Assert

            Assert.AreEqual(appResult, ApplicationResult.AutoReject);
        }

        [Test]

        public void Application_withexpup75_TransferredAutoAccept()
        {
            //Arrange
            var mok = new Mock<IIdentyValidator>(MockBehavior.Loose);
            mok.Setup(i => i.location).Returns("Istanbul");
            mok.Setup(i => i.IsValid(It.IsAny<string>())).Returns(true);
            var eval = new ApplicationEvaluator(mok.Object);
            var form = new JobApplicantt()
            {

                Applicant = new Applicant() { Age = 19, Tc = "" },
                TechStackList = new List<string>() { "c#", "rabbit", "microser", "visual studio" },
                YearsOfExperience = 18

            };
            //Action
            var appResult = eval.Evaluate(form);
            //Assert

            Assert.AreEqual(appResult, ApplicationResult.AutoAccepted);
        }
        [Test]
        public void Application_withInvalidTc_TransferredTOHR()
        {
            //Arrange
            var mok = new Mock<IIdentyValidator>();
            mok.Setup(i => i.location).Returns("Istanbul");
            mok.Setup(i => i.IsValid(It.IsAny<string>())).Returns(false);
            var eval = new ApplicationEvaluator(mok.Object);
            var form = new JobApplicantt()
            {

                Applicant = new Applicant() { Age = 19, Tc = "" },
          

            };
            //Action
            var appResult = eval.Evaluate(form);
            //Assert

            Assert.AreEqual(appResult, ApplicationResult.TransferredToHr);
        }
        [Test]
        public void Application_withLocation_TransferredTOCto()
        {
            //Arrange
            var mok = new Mock<IIdentyValidator>();
            mok.Setup(i => i.location).Returns("dd");
            var eval = new ApplicationEvaluator(mok.Object);
            var form = new JobApplicantt()
            {

                Applicant = new Applicant() { Age = 19, Tc = "" },


            };
            //Action
            var appResult = eval.Evaluate(form);
            //Assert

            Assert.That( appResult, Is.EqualTo(ApplicationResult.TransferredToCTO));
        }

        [Test]
        public void Application_withagebigger50_TransferredTOdtail()
        {
            //Arrange
            var mok = new Mock<IIdentyValidator>();
       
            var eval = new ApplicationEvaluator(mok.Object);
            var form = new JobApplicantt()
            {

                Applicant = new Applicant() { Age = 59, Tc = "" },


            };
            //Action
            var appResult = eval.Evaluate(form);
            //Assert

            Assert.That(form.validation, Is.EqualTo(validation.detailedi));
        }
    }
}