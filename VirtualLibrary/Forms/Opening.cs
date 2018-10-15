using System;
using System.Windows.Forms;
using VirtualLibrary.DataSources.Data;
using VirtualLibrary.Helpers;
using VirtualLibrary.Presenters;
using VirtualLibrary.Repositories;

namespace VirtualLibrary.Forms
{
    public partial class Opening : Form
    {
        private readonly FaceRecognitionLogin _faceRecognitionLoginForm;
        private readonly Registration _registrationForm;
        private readonly Login _loginForm;
        private TakenBookPresenter _takenBookPresenter;
        private ILibraryData _libraryData;
        private IInputValidator _validator;
        private IExceptionLogger _exceptionLogger;


        public Opening(TakenBookPresenter takenBookPresenter, ILibraryData libraryData, IInputValidator validator, IExceptionLogger exceptionLogger)
        {
            InitializeComponent();

            _takenBookPresenter = takenBookPresenter;
            _libraryData = libraryData;
            _validator = validator;
            _exceptionLogger = exceptionLogger;
            _faceRecognitionLoginForm = new FaceRecognitionLogin(takenBookPresenter, libraryData, _exceptionLogger);
            _registrationForm = new Registration(_libraryData, _validator);
            _loginForm = new Login(_takenBookPresenter, _libraryData);
        }

        private void Label2_Click(object sender, EventArgs e)
        {
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            Hide();
            _registrationForm.ShowDialog();
            Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _loginForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            _faceRecognitionLoginForm.Init();
            _faceRecognitionLoginForm.ShowDialog();
        }

        private void Opening_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StaticDataSource.CurrLanguage = "LT";
            Hide();
            new Opening(_takenBookPresenter, _libraryData, _validator, _exceptionLogger).ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            StaticDataSource.CurrLanguage = "EN";
           
        }
    }
}