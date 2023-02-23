using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tobii.Research;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private Boolean warmupMode = true;
        int currentQuestionIndex;
        public Form1()
        {
            InitializeComponent();
            bmpnModelPictureBox.Visible = false;
            warmUpPictureBox.Visible = false;
            pictureBox1.Visible = false;
            button5.Visible = false;
            startwarning();
           
        }
        public void startwarning()
        {
            InitializeComponent();
            pictureBox1.Visible = true;
            button5.Visible = true;
            bmpnModelPictureBox.Visible = false;
            warmUpPictureBox.Visible = false;
            richTextBox2.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
            richTextBox4.Visible = false;
            richTextBox5.Visible = false;
            richTextBox6.Visible = false;
        }

        public void startWarmup()
        {
            currentQuestionIndex = 0;
            InitializeComponent();
            pictureBox1.Visible = false;
            button5.Visible = false;
            initializeEyeTracker();
            participantId = DateTime.Now.ToString("yyyyMMddHHmmss");
            label2.Text = participantId;
          
           
            Question.initializWarmupQuestions();
            changeQuestion();
            bmpnModelPictureBox.Visible = false;
            
            richTextBox2.Visible = true;
            radioButton1.Visible = true;
            radioButton2.Visible = true;
            radioButton3.Visible = true;
            radioButton4.Visible = true;
            radioButton5.Visible = true;
            richTextBox1.Visible = true;
            richTextBox3.Visible = true;
            richTextBox4.Visible = true;
            richTextBox5.Visible = true;
            richTextBox6.Visible = true;
            warmUpPictureBox.Visible = true;
          
            button3.Visible = true;
        }
        private IEyeTracker myEyeTracker;
        float width = 0;
        float height = 0;
        private String participantId = "";
        private static List<string> linesGaze = new List<string>();
        //int currentQuestionIndex = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Log("Eye tracking started");
            width = Screen.PrimaryScreen.Bounds.Width;
            height = Screen.PrimaryScreen.Bounds.Height;
            startRecord();
        }
        private void Log(String message)
        {
          
        }

        private void initializeEyeTracker()
        {
            Log("\nSearching for all eye trackers");
            EyeTrackerCollection eyeTrackers = EyeTrackingOperations.FindAllEyeTrackers();
            foreach (IEyeTracker eyeTracker in eyeTrackers)
            {
                Log(eyeTracker.Address + " " + eyeTracker.DeviceName + " " + eyeTracker.Model + " " + eyeTracker.SerialNumber + " " + eyeTracker.FirmwareVersion);
            }
            myEyeTracker = eyeTrackers.First();
            string license = @"license_key_IS404-100107526013.dat";
            ApplyLicense(myEyeTracker, license);
        }

        private void ApplyLicense(IEyeTracker eyeTracker, string licensePath)
        {
            // Create a collection with the license.
            var licenseCollection = new LicenseCollection(
                new System.Collections.Generic.List<LicenseKey>
                {
           new LicenseKey(System.IO.File.ReadAllBytes(licensePath))
                });
            // See if we can apply the license.
            FailedLicenseCollection failedLicenses;
            if (eyeTracker.TryApplyLicenses(licenseCollection, out failedLicenses))
            {
                Log(
                    "Successfully applied license from " + licensePath + " on eye tracker with serial number " + eyeTracker.SerialNumber);
            }
            else
            {
                Log(
                    "Failed to apply license from " + licensePath + " on eye tracker with serial number " + eyeTracker.SerialNumber);
            }
            // Clear any applied license.
            //eyeTracker.ClearAppliedLicenses();
        }

        public void startRecord()
        {
            warmUpPictureBox.Visible = false;

            currentQuestionIndex = 0;
            myEyeTracker.GazeDataReceived += MyEyeTracker_GazeDataReceived;

            Question.initializeQuestions();

            changeQuestion();
            

            //button4.Visible = true;
            button1.Enabled = false;
            button2.Enabled = true;

        }

        private void setAnswer(String selectedOption)
        {
            List<Question> allQuestions = Question.questions;
            Question question = allQuestions[currentQuestionIndex];
            question.setAnswer(selectedOption);
        }

        private void switchToTestMode()
        {
            width = Screen.PrimaryScreen.Bounds.Width;
            height = Screen.PrimaryScreen.Bounds.Height;

            //startRecord();

            richTextBox2.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;
            radioButton4.Visible = false;
            radioButton5.Visible = false;
            richTextBox1.Visible = false;
            richTextBox3.Visible = false;
            richTextBox4.Visible = false;
            richTextBox5.Visible = false;
            richTextBox6.Visible = false;
            pictureBox1.Visible = false;
            button5.Visible = false;

            if (System.Windows.Forms.MessageBox.Show
            ("WARM UP ACTIVITY IS OVER\nNOW YOU WILL START THE ACTUAL TEST.", "YES",
            System.Windows.Forms.MessageBoxButtons.YesNo,
            System.Windows.Forms.MessageBoxIcon.Question)
            == System.Windows.Forms.DialogResult.Yes)
            // Do stuff after 'YES is clicked'
            {
                warmupMode = false;
                warmUpPictureBox.Visible = false;
                bmpnModelPictureBox.Visible = true;
                myEyeTracker.GazeDataReceived += MyEyeTracker_GazeDataReceived;
                participantId = DateTime.Now.ToString("yyyyMMddHHmmss");
                currentQuestionIndex = 0;
                label2.Text = participantId;
                Question.initializeQuestions();
                changeQuestion();


                //button4.Visible = true;
                button1.Enabled = false;
                button2.Enabled = true;
                richTextBox2.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton3.Visible = true;
                radioButton4.Visible = true;
                radioButton5.Visible = true;
                richTextBox1.Visible = true;
                richTextBox3.Visible = true;
                richTextBox4.Visible = true;
                richTextBox5.Visible = true;
                richTextBox6.Visible = true;

            }


        }
        private void changeQuestion()
        {
            if (warmupMode && (currentQuestionIndex == Question.questions.Count))
            {
                switchToTestMode();
            }
            List<Question> allQuestions = Question.questions;
            Question question = allQuestions[currentQuestionIndex];
            richTextBox2.Text = question.text;
            richTextBox1.Text = question.option1;
            richTextBox3.Text = question.option2;
            richTextBox4.Text = question.option3;
            richTextBox5.Text = question.option4;
            richTextBox6.Text = question.option5;

            if (!warmupMode)
            {
                if (currentQuestionIndex == allQuestions.Count - 1)
                {
                    button3.Enabled = false;
         
                }
                
                else 
                {
                    button3.Enabled = true;
                }
            }
            

            if (currentQuestionIndex == 0)
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }

            if (question.selectedOption == "A")
            {
                radioButton1.Checked = true;
            }
            else if (question.selectedOption == "B")
            {
                radioButton2.Checked = true;
            }
            else if (question.selectedOption == "C")
            {
                radioButton3.Checked = true;
            }
            else if (question.selectedOption == "D")
            {
                radioButton4.Checked = true;
            }
            else if (question.selectedOption == "E")
            {
                radioButton5.Checked = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;


            }
            question.logViewAction();
        }

        private void nextQuestion()
        {
            currentQuestionIndex++;
            changeQuestion();
        }

        private void previousQuestion()
        {
            currentQuestionIndex--;
            changeQuestion();
        }

        private Question currentQuestion()
        {
            return Question.questions[currentQuestionIndex];
        }

        public void pauseRecord()
        {
            myEyeTracker.GazeDataReceived -= MyEyeTracker_GazeDataReceived;
        
            button1.Enabled = true;
            button2.Enabled = false;

        }


        private void MyEyeTracker_GazeDataReceived(object sender, GazeDataEventArgs e)
        {
                    
                    // Write the data to the console.
            double x = e.LeftEye.GazePoint.PositionOnDisplayArea.X;
            double y = e.LeftEye.GazePoint.PositionOnDisplayArea.Y;
            Log(string.Format("Gaze point at ({0:0.0}, {1:0.0}) @{2:0}", x, y, e.SystemTimeStamp));
            GazeData gazeData = new GazeData();
            gazeData.currentTime = DateTime.Now;
            gazeData.timestamp = e.SystemTimeStamp;
            gazeData.gazeX = x * width;
            gazeData.gazeY = y * height;
            gazeData.leftPupilDiameter = e.LeftEye.Pupil.PupilDiameter;
            gazeData.rightPupilDiameter = e.RightEye.Pupil.PupilDiameter;
            gazeData.questionId = currentQuestionIndex+1;
            gazeData.partipicantId = participantId;
            gazeData.selectedOption = currentQuestion().selectedOption;
            gazeData.questionViewTime = currentQuestion().questionViewTime;
            gazeData.answerTime = currentQuestion().selectionTime;
            linesGaze.Add(gazeData.ToCSVLine());
            }
            
        

        internal void Dispose()
        {
            myEyeTracker.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pauseRecord();
            saveFiles();

            MessageBox.Show("THANK YOU!\n YOU HAVE COMPLETED THE EXPERIMENT.");
            
        }


        public void saveFiles(int recordingSpeed = 0)
        {
            string gazeFilename = participantId + "-gazes.csv";

           
            //Write the headers
            File.WriteAllText(gazeFilename, GazeData.HEADER_LINE);
            //Write the files
            File.AppendAllLines(gazeFilename, linesGaze);
   
            //Write the files
            string answersFileName = participantId + "-answers.csv";

            File.WriteAllText(answersFileName, "Question;Answer;View Time;Answer Time\n");
           
           
                int questionId = 1;
       
                foreach (Question question in Question.questions)
                {
                        File.AppendAllText(answersFileName, string.Format("{0};{1};{2};{3}\n", questionId, question.selectedOption, question.questionViewTime, question.selectionTime));
                         questionId++;
                }
        }   

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true || radioButton3.Checked == true || radioButton4.Checked == true || radioButton5.Checked == true)
            {
                nextQuestion();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            previousQuestion();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                setAnswer("A");
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked && currentQuestionIndex==7)
                MessageBox.Show("YOU HAVE COMPLETED THE EXPERIMENT.\nDO NOT CLICK ON ANYTHING AND CALL THE EXPERIMENTER"); 
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                setAnswer("B");
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked && currentQuestionIndex == 7)
                MessageBox.Show("YOU HAVE COMPLETED THE EXPERIMENT.\nDO NOT CLICK ON ANYTHING AND CALL THE EXPERIMENTER");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
                setAnswer("C");
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked && currentQuestionIndex == 7)
                MessageBox.Show("YOU HAVE COMPLETED THE EXPERIMENT.\nDO NOT CLICK ON ANYTHING AND CALL THE EXPERIMENTER");
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
                setAnswer("D");
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked && currentQuestionIndex == 7)
                MessageBox.Show("YOU HAVE COMPLETED THE EXPERIMENT.\nDO NOT CLICK ON ANYTHING AND CALL THE EXPERIMENTER");
        }

        private void radioButton5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
                setAnswer("E");
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked && currentQuestionIndex == 7)
                MessageBox.Show("YOU HAVE COMPLETED THE EXPERIMENT.\nDO NOT CLICK ON ANYTHING AND CALL THE EXPERIMENTER");
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           
            this.Location = new Point(0, //should be (0,0)
                          0);
            this.TopMost = true;
            this.StartPosition = FormStartPosition.Manual;

            Font currentFont = richTextBox2.SelectionFont;
            /*richTextBox2.Font = new Font(currentFont.FontFamily, 10new size);
            currentFont = richTextBox1.Font;*/

            richTextBox1.Font = new Font(currentFont.FontFamily, 12/*new size*/);
            currentFont = richTextBox3.Font;

            richTextBox3.Font = new Font(currentFont.FontFamily, 12/*new size*/);
            currentFont = richTextBox4.Font;

            richTextBox4.Font = new Font(currentFont.FontFamily, 12/*new size*/);
            currentFont = richTextBox5.Font;

            richTextBox5.Font = new Font(currentFont.FontFamily, 12/*new size*/);
            currentFont = richTextBox6.Font;

            richTextBox6.Font = new Font(currentFont.FontFamily, 12/*new size*/);
            currentFont = richTextBox1.Font;
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible  = false;
            button5.Visible = false;
            startWarmup();
        }
    }
}
