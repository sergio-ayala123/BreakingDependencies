using ClassLibrary1;
using Moq;
using WinFormsApp1;
using static WinFormsApp1.Form1;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]

        public void CountButtonClick()
        {
            FormTests form = new FormTests("You have to enter a name");
            form.btnCalculate_Click(null, null);

            Assert.That(() => form.Message == "You have to enter a name");
        }

        [Test]
        public void NumBalanceError()
        {
            FormTests form = new FormTests("Must be between 10k and 1MM");
            form.btnCalculate_Click(null, null);
            Assert.That(() => form.Message == "Must be between 10k and 1MM");
        }
    }
    public class FormTests: IFormDependancy
    {
        Form1 form = new Form1();
        public string Message { get; set; }

        public FormTests()
        {

        }
        public FormTests(string message)
        {
            Show(message);
        }


        public void Show(string message)
        {
            Message = message;
        }

        public string btnCalculate_Click(object sender, EventArgs s)
        {
            return "button clicked";
        }
    }
}