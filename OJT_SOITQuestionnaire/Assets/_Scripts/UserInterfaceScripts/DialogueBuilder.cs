using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBuilder : MonoBehaviour
{
    [SerializeField] private GameEvent sendDialogue;
    [SerializeField] private GameEvent sendData;
    [SerializeField] private string[] lines;
    private Vector2[] scores;
    private int num = 0;

    // Start is called before the first frame update
    public void Initialize(Component sender, object data)
    {
        if (data != null)
        {
            scores = (Vector2[])data;
        }

        switch(num)
        {
            case 0:
                TestResultsDialogue();
                break;

            case 1:
                CourseDialogue();
                break;

            case 2:
                ContactAndInfoDialogue();
                break;
        }
        
    }

    public void getNum(Component sender, object data)
    {
        num = (int)data;

        Initialize(sender, null);
    }

    void TestResultsDialogue()
    {
        int linesScriptLength = 8;
        lines = new string[linesScriptLength];

        string course1 = GameResultsDisplay.getCategory((int)scores[0].x);
        int course1Score = (int)scores[0].y;
        string course2 = GameResultsDisplay.getCategory((int)scores[1].x);
        int course2Score = (int)scores[1].y;
        string lastCourse = GameResultsDisplay.getCategory((int)scores[4].x);
        int lastCourseScore = (int)scores[4].y;
        int course3Score = (int)scores[2].y;
        int course4Score = (int)scores[3].y;

        float total = scores[0].y + scores[1].y + scores[2].y + scores[3].y + scores[4].y;
        float mean = (total) / 5;
        float median = scores[2].y;
        float course1ToMeanDiff = course1Score - mean;
        float course1ToCourse2Diff = course1Score - course2Score;
        float course1ScorePecent = (course1Score / total) * 100;
        float course2ScorePecent = (course2Score / total) * 100;
        float course3ScorePecent = (course3Score / total) * 100;
        float course4ScorePecent = (course4Score / total) * 100;
        float course5ScorePecent = (lastCourseScore / total) * 100;


        lines[0] = "The results are in!";
        lines[1] = " ";
        lines[2] = "You’re a " + course1 + " major!";
        lines[3] = "Scoring a " + course1Score.ToString() + ", " + course1ToMeanDiff.ToString("0.##") + " points off the average.";
        lines[4] = "Your second highest course is " + course2 + " with a score of " + course2Score.ToString();
        lines[5] = "That's a " + course1ToCourse2Diff.ToString("0.##") + " point difference from your top scoring course.";
        lines[6] = "Your lowest was " + lastCourse + " with a score of " + lastCourseScore.ToString();
        lines[7] = " ";


        float[] data = new float[10];
        data[0] = total;
        data[1] = mean;
        data[2] = median;
        data[3] = course1ToMeanDiff;
        data[4] = course1ToCourse2Diff;
        data[5] = course1ScorePecent;
        data[6] = course2ScorePecent;
        data[7] = course3ScorePecent;
        data[8] = course4ScorePecent;
        data[9] = course5ScorePecent;


        sendData.Raise(this, data);

        sendDialogue.Raise(this, lines);
    }

    void CourseDialogue()
    {
        int linesScriptLength = 5;
        lines = new string[linesScriptLength];

        switch ((Category)scores[0].x)
        {
            case Category.CS:

                lines[0] = " ";

                lines[0] = "Computer Science delves into the complex behaviors of computers, understanding the theory behind software to innovative ways of utilizing them in the real world.";
                lines[1] = "It challenges its students to design complex algorithms and solve computing problems through complex hands-on lab activities.";
                lines[2] = "In CS, you will learn data structures and algorithms, artificial intelligence, machine learning, web development, and much more.";
                lines[3] = "Our CS program offers specializations in Intelligent Systems, Software Engineering, and Application Development.";

                break;

            case Category.IT:

                lines[0] = " ";

                lines[0] = "Information Technology explores the information age of today’s world, managing the vast and versatile technological field with efficient hardware and software solutions.";
                lines[1] = "It empowers its students with skills necessary to manage, process, and exchange information securely over the network through practical hands-on training.";
                lines[2] = "In IT, you will learn networking and cloud computing, IT support and troubleshooting, database management, and much more.";
                lines[3] = "Our IT program offers specializations in Computer Network and Security, Cybersecurity, Application Development, and Enterprise Data Management.";

                break;

            case Category.IS:

                lines[0] = " ";

                lines[0] = "Information System utilizes technology to drive business success, creating value through an effective and efficient streamlining of business processes.";
                lines[1] = "It molds its students to become business technology experts, developing strong technical skills to implement computing-based solutions in the management of information systems.";
                lines[2] = "In IS, you will learn to leverage technology for business process analysis, business intelligence, planning, data management, and much more.";
                lines[3] = "Our IS program offers specializations in Business Analytics, Enterprise Resource Planning, Enterprise Data Management, IT Audit, and IT Service Management.";

                break;

            case Category.EMC:

                lines[0] = " ";

                lines[0] = "Entertainment and Multimedia Computing dives into the captivating capabilities of human creativity plus cutting-edge technology, creating experiences that entertain, educate, and inspire.";
                lines[1] = "It inspires its students to unleash their creativity, designing various entertainment media, and build video game project prototypes to solve technical gaming challenges.";
                lines[2] = "In EMC, you will learn digital art and animation, game design, user experience design, game physics programming, and much more.";
                lines[3] = "Our EMC program mainly specializes in Game Design and Development";

                break;

            case Category.DS:

                lines[0] = " ";

                lines[0] = "Data Science investigates the trends and patterns hidden within large sets of data, extracting insights to make data-driven decisions.";
                lines[1] = "It equips its students with in-demand skills to leverage opportunities in data and strategically use statistics to analyze all available information to come to an informed conclusion.";
                lines[2] = "In DS, you will learn data analysis and visualization, statistical modeling, machine learning, and much more.";
                lines[3] = "Our DS program is highly specialized resulting in a more focused approach.";

                break;

            default:

                break;

        }

        lines[4] = " For more information, please feel free to visit the official Mapua website, or contact our university’s admission office";

        sendDialogue.Raise(this, lines);
    }

    void ContactAndInfoDialogue()
    {
        int linesScriptLength = 2;
        lines = new string[linesScriptLength];

        lines[0] = "";

        lines[1] = "Feel free to take a screenshot of the data as reference if you so desire.";

        sendDialogue.Raise(this, lines);
    }

    public void OutroDialogue()
    {
        int linesScriptLength = 7;
        lines = new string[linesScriptLength];

        lines[0] = "Remember, these results are only a suggestions,";
        lines[1] = "so if I managed to help you with your final decision,";
        lines[2] = "then that's great!";
        lines[3] = "if not, then I hope you’re still happy with what ever you decide.";
        lines[4] = "Well, got to go! Hope to see you again next time! BYE!";
        lines[5] = " ";
        lines[6] = " ";

        sendDialogue.Raise(this, lines);

    }

}
