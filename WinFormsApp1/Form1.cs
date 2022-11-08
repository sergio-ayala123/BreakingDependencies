namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public interface IFormDependancy
        { 
            public void Show(string message);
            public string btnCalculate_Click(object sender, EventArgs s);
        }

        public class FormDependancy : IFormDependancy
        {
            IFormDependancy Iform;
            public FormDependancy()
            {

            }
            public FormDependancy(IFormDependancy Iform)
            {
                this.Iform = Iform;
            }

            public string btnCalculate_Click(object sender, EventArgs s )
            {
                return "button Clicked";
            }

            public void Show(string message)
            {
                

                MessageBox.Show(message);
            }
        }


        public void btnCalculate_Click(object sender, EventArgs e)
        {
            FormDependancy form = new FormDependancy();
            if (txtName.Text.Length == 0)
            {
                form.Show("You have to enter a name");
                return;
            }

            if (numBalance.Value < 10_000 || numBalance.Value > 1_000_000)
            {
                form.Show("Must be between 10k and 1MM");
                return;
            }

            if (File.Exists("authkey.txt") is false)
            {
                form.Show("Missing authorization key");
                return;
            }

            lblResults.Text = (numBalance.Value * numInterestRate.Value).ToString("c");
        }
    }
}