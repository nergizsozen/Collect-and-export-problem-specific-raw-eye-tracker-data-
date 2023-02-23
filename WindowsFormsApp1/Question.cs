using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Question
    {
        public static List<Question> questions = new List<Question>();

        public String text;
        public String option1;
        public String option2;
        public String option3;
        public String option4;
        public String option5;
        public String selectedOption;
        public Nullable<DateTime> selectionTime=null;
        public DateTime questionViewTime;

        public Question(String text, String option1, String option2, String option3, String option4,String option5)
        {
            this.text = text;
            this.option1 = option1;
            this.option2 = option2;
            this.option3 = option3;
            this.option4 = option4;
            this.option5 = option5;
        }
        public void logViewAction()
        {
            this.questionViewTime = DateTime.Now;

        }
        public void setAnswer(String selectedOption)
        {
            this.selectedOption = selectedOption;
            this.selectionTime = DateTime.Now;
        }


        public static void initializWarmupQuestions()
        {
            questions.Clear();
            questions.Add(new Question("wQuestion 1: \n\nWhat has to be done to assess a loan application’s eligibility?",
                                        "a.	Credit history is checked, then loan risk is assessed. ",
                                        "b.	The property is appraised.",
                                        "c.	Credit history is checked and loan risk is assessed in parallel with appraising the property.",
                                        "d.	Either checking the credit history or appraising the property is enough for assessment.",
                                        "e.            I don't know"));
            questions.Add(new Question("wQuestion 2: \n\nWhich of the following action sequences is possible during one execution of the activity diagram presented on the left?",
                                        "a.	Receive Loan Application--> Check Credit History--> Assess Loan Risk--> Reject application.",
                                        "b.	Receive Loan Application--> Appraise Property--> Assess Loan Risk--> Reject application.",
                                        "c. Receive Loan Application--> Check Credit History--> Assess Loan Risk--> Appraise property--> Prepare acceptance pack.",
                                        "d.	Receive Loan Application--> Check Credit History--> Assess Loan Risk--> Appraise property--> Prepare acceptance pack--> Reject application.",
                                        "e.            I don't know"));
        }
        public static void initializeQuestions()
        {
            questions.Clear();
            questions.Add(new Question("Question 1: \n\nIf the Requestor receives a request for missing information, how many times must the Administrator have sent a request for missing information?",
                                        "a.	Zero or more times", 
                                        "b.	Zero times and not more than that",
                                        "c.	At most once",
                                        "d.	At least once",
                                        "e.            I don't know"));
            questions.Add(new Question("Question 2: \n\nWhat happens to the received service order when it does not meet the definition of a complaint? ",
                                        "a.	The Administrator sends a request for missing information",
                                        "b.	After documentation and informing the appropriate business entity, the process ends",
                                        "c.	The complaint process terminates without further actions",
                                        "d.	Hazardous situations have to be considered before the case can be closed",
                                        "e.            I don't know"));
            questions.Add(new Question("Question 3: \n\nTo whom the closed complaint record will be sent? ",
                                        "a.            Requestor",
                                        "b.	Administrator",
                                        "c.	Investigator",
                                        "d.	Multidisciplinary team",
                                        "e.            I don't know"));
            questions.Add(new Question("Question 4: \n\nWho is responsible for checking a similar complaint exists?  ",
                                        "a.	Requestor",
                                        "b.	Administrator",
                                        "c.	Investigator",
                                        "d.	Multidisciplinary team",
                                        "e.            I don't know"));
            questions.Add(new Question("Question 5: \n\nWhich of the following set of tasks should be completed before performing task corrections?   ",
                                        "a.	Only the site corrections and taken actions must be identified.",
                                        "b.	Either already available solutions or unavailabe known solutions must be identified.",
                                        "c.	Site corrections, taken actions, already available solutions and unavailable known solutions must be identified.",
                                        "d.	Taken actions, available solutions, unavailable but known solutions and site corrections must be simultaneously identified.",
                                        "e.            I don't know"));
            questions.Add(new Question("Question 6: \n\nWhich record is sent from administrator to requestor? ",
                                        "a.	Risk Assessment",
                                        "b.	Closed Complaint Record",
                                        "c.	Complaint Feedback",
                                        "d.	None of the Above",
                                        "e.            I don't know")); 
            questions.Add(new Question("Question 7: \n\nWho will document the rationale for the closure of a low hazard coded complaint?  ",
                                        "a.	Requestor ",
                                        "b.	Administrator",
                                        "d.	Investigator",
                                        "e.	Multidisciplinary team",
                                        "e.            I don't know"));
            questions.Add(new Question("Question 8: \n\nIf the complaint anayzed has a need, how many times does the Investigator assign a Technical Investigator to the complaint?",
                                        "a.	Zero or more times",
                                        "b.	Zero times and not more than that",
                                        "c.	At most once",
                                        "d.	Exactly once ",
                                        "e.            I don't know"));
          
        }
    }
}
