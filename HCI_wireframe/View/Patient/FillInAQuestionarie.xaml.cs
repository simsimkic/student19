using Class_diagram.Contoller;
using Class_diagram.Model.Patient;
using Class_diagram.Repository;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.View.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace HCI_wireframe
{
    /// <summary>
    /// Interaction logic for FillInAQuestionarie.xaml
    /// </summary>
    public partial class FillInAQuestionarie : UserControl
    {
        public class ListaDoktoriIme
        {
           
            public String DoctorName { get; set; }

            public ListaDoktoriIme()
            {
            }

        }
       
        int mark { get; set; }

        public QuestionController questionController;
        public DoctorController doctorController;
        public List<Question> _questionList { get; set; }
        public List<DoctorUser> listDoctors { get; set; }
        public FillInAQuestionarie()
        {
            InitializeComponent();

            this.DataContext = this;
            doctorController = new DoctorController();
            questionController = new QuestionController();
            listDoctors = doctorController.GetAll();

            List<ListaDoktoriIme> listDoctorsBinding = new List<ListaDoktoriIme>();
            foreach (DoctorUser d in listDoctors)
            {
                StringBuilder l = new StringBuilder();
                l.Append(d.FirstName + " ");
                l.Append(d.SecondName + " ");
                l.Append(d.ID);
                ListaDoktoriIme a = new ListaDoktoriIme();
                a.DoctorName = l.ToString();
                listDoctorsBinding.Add(a);

            }

            doctorCombo.ItemsSource = listDoctorsBinding;
           
            QuestionList = questionController.GetAll();
        }
        public List<Question> QuestionList
        {
            get { return _questionList; }
            set
            {
                _questionList = value;
                OnPropertyChanged("QuestionList");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string strPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(strPropertyName));
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            doctorCombo.Focus();
        }

     
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.B)
            {
                var s = new FirstPage();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.H)
            {
                MessageBox.Show(

                    "- Use CTRL + B to return to the first page of the application.\n" +
                      "- Use  ARROW DOWN to select doctor from checkbox.\n" +
                    "- Use TAB to select table.\n" +
                    "- Use AAROWS to move within field in table.\n" +
                    "- Use TAB to focus wanted mark.\n" +
                    "- Use SPACE to select wanted mark.\n" +

                    "- Use  CTRL + O  to select menu bar.\n" +
                   
                    "- Use ENTER/SPACE to close this message.\n", "HELP");
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.LeftCtrl)
            {
                if (doctorCombo.IsFocused)
                {
                    confirmButton.Focus();
                }
                else if (confirmButton.IsFocused)
                {
                    backButton.Focus();
                }
                else if (helpButton.IsFocused)
                {
                    doctorCombo.Focus();
                }
            }
           
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.RightCtrl)
            {
                if (confirmButton.IsFocused)
                {
                    doctorCombo.Focus();
                }
                else if (backButton.IsFocused)
                {
                    confirmButton.Focus();
                }

                else if (doctorCombo.IsFocused)
                {
                    helpButton.Focus();
                }
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.O)
            {

                File_Name.Focus();


            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Q )
            {
                var s = new AccountSettings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.W)
            {
                var s = new Settings();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
          
            
            
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.K)
            {
                var s = new Help();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.A )
            {
                var s = new AskAQuestion();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.F )
            {
                var s = new FillInAQuestionarie();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.D )
            {
                string sMessageBoxText = "Are you sure you want to log out?";
                string sCaption = "Log out";

                MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
                MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

                MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

                switch (rsltMessageBox)
                {
                    case MessageBoxResult.Yes:
                        var s = new PatientMainWindow();
                        s.Show();
                        break;

                    case MessageBoxResult.No:

                        break;

                    case MessageBoxResult.Cancel:

                        break;
                }
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.Z)
            {
                
                    var s = new MyAppointments();
                    gridMain.Children.Clear();
                    gridMain.Children.Add(s);
                
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.X)
            {
                var s = new MedicalHistory();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.L)
            {
                var s = new MedicalTherapyOnAWeeklyBasis();
                s.Show();
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.V)
            {
                var s = new EmergencyPhoneNumbers();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.N )
            {
                var s = new Notification();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);
            }
            else if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.M)
            {
                var s = new MakeAnAppointment();
                gridMain.Children.Clear();
                gridMain.Children.Add(s);

            }


        }

        private void backButton_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ToolTip tt = (ToolTip)(sender as Control).ToolTip;
            //Places the Tooltip under the control rather than at the mouse position
            tt.PlacementTarget = (UIElement)sender;
            tt.Placement = PlacementMode.Right;
            tt.PlacementRectangle = new Rect(0, (sender as Control).Height, 0, 0);
            //Shows tooltip if KeyboardFocus is within.
            tt.IsOpen = (sender as Control).IsKeyboardFocusWithin;
        }

        private void confirmButton_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void confirmButton_Click(object sender, RoutedEventArgs e)
        {
           
           
            ListaDoktoriIme name = (ListaDoktoriIme)doctorCombo.SelectedValue;
            if (name == null)
            {
                MessageBox.Show("Please choose the doctor!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                return;
            }
            

           
            else
            {
                String imeDr = name.DoctorName;

                String[] delovi = imeDr.Split(' ');

                int idDoktor = int.Parse(delovi[2]);

                DoctorUser doktorUpitnik = doctorController.GetByID(idDoktor);
             

                StringBuilder sb = new StringBuilder();
                sb.Append("Questionarie: \n");
                foreach(Question q in QuestionList)
                {
                    sb.Append(q.Name + "  /  mark:  " + q.answer + "\n");
                }
                String upitnik = sb.ToString();
                Console.WriteLine(upitnik);
                if (doktorUpitnik.specialNotifications == null)
                {
                    doktorUpitnik.specialNotifications = new List<String>();
                }
                doktorUpitnik.specialNotifications.Add(upitnik);
                doctorController.Update(doktorUpitnik);
                
              
                MessageBox.Show("Thank you!\nQuestionarie is successfully sent.");
            }
        }

        private void helpButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(

                  "- Use CTRL + B to return to the first page of the application.\n" +
                    "- Use  ARROW DOWN to select doctor from checkbox.\n" +
                  "- Use TAB to select table.\n" +
                  "- Use AAROWS to move within field in table.\n" +
                  "- Use TAB to focus wanted mark.\n" +
                  "- Use SPACE to select wanted mark.\n" +

                  "- Use  CTRL + O  to select menu bar.\n" +
                  "- Use  ENTER  to select button.\n" +
                  "- Use ENTER/SPACE to close this message.\n", "HELP");
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var s = new FirstPage();
            gridMain.Children.Clear();
            gridMain.Children.Add(s);
        }


        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            Question ss = (Question)questionarieGrid.Items.GetItemAt(questionarieGrid.SelectedIndex);

            var radioButton = sender as RadioButton;
            if (radioButton == null)
                return;
            int intIndex = Convert.ToInt32(radioButton.Content.ToString());
            ss.answer = radioButton.Content.ToString();
         
           
        }
    }
}
