using System;

public class GazeData
{
    private static String DELIMITER = ";";
    public DateTime currentTime;
    public long timestamp;
    public double gazeX;
    public double gazeY;
    public float leftPupilDiameter;
    public float rightPupilDiameter;
    public int questionId;
    public String partipicantId="";
    public DateTime questionViewTime;
    public Nullable<DateTime> answerTime = null;
    public String selectedOption;

    public String ToCSVLine()
    {
        String str = currentTime.ToString("MM/dd/yyyy HH:mm:ss.FFF") + DELIMITER;
        str += timestamp + DELIMITER;
        str += gazeX + DELIMITER;
        str += gazeY + DELIMITER;
        str += leftPupilDiameter + DELIMITER;
        str += rightPupilDiameter + DELIMITER;
        str += questionId + DELIMITER;
        str += "\""+partipicantId + DELIMITER;
        str += (questionViewTime!=null?questionViewTime.ToString("MM/dd/yyyy HH:mm:ss.FFF"):"") + DELIMITER;
        str += (answerTime!=null?answerTime?.ToString("MM/dd/yyyy HH:mm:ss.FFF"):"") + DELIMITER;
        str += selectedOption + DELIMITER;

        return str;
    }

    public static String HEADER_LINE = "CurrentTime;Timestamp;GazeX;GazeY;L-PupilDiameter;R-PupilDiameter;QuestionId;ParticipantId;QuestionViewTime;AnswerTime;SelectedOption\n";


}
