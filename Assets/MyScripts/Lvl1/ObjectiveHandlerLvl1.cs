using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectiveHandlerLvl1 : MonoBehaviour
{
    public static int GO_THROUGH_CORRIDOR = 1;
    public static int MAYOMA_DESTROY_CHEST = 2;
    public static int VENTILATION = 3;
    public static int OPEN_DOORS = 4;
    public static int FINAL_OBJ = 5;

    

    public static Text objectiveText;

    private string[] OBJECTIVES = {"Use Sciencist ability to hack 1st computer",
                                    "Go through corridor",
                                    "Mayoma can destroy chests!\nTry his ability!",
                                    "Catwoman can crouch\nNow try her ability!",
                                    "Open the doors for others",
                                    "Go all characters to the elevator doors"
                                                                };
    private string[] GRATZ = { "Congratulations!", "Done!", "Gratz!", "Yeah!", "Good", "Nice!", "Awesome!" };
    private bool taskChange = true;
    private bool temporaryText = false;
    private bool firstTime = true;
    private int taskNumber = 0;

    void Start()
    {
        objectiveText = GameObject.Find("ObjectiveText").GetComponent<Text>();
    }

    void Update()
    {
        if (taskChange)
        {
            objectiveText.text = OBJECTIVES[taskNumber];
            taskChange = false;
        }

        if (temporaryText && Input.GetKeyDown(KeyCode.Escape))
        {
            resumetPreviousText();
            temporaryText = false;
        }

        if (firstTime)
        {
            GameObject[] chests = GameObject.FindGameObjectsWithTag("ChestToDestroy");
            if (chests.Length < 2)
            {
                nextTask(VENTILATION);
                firstTime = false;
            }
        }
    }

    public void setTempText(string text)
    {
        objectiveText.text = text;
        temporaryText = true;
    }

    public void resumetPreviousText()
    {
        objectiveText.text = OBJECTIVES[taskNumber];
    }

    public void nextTask(int task)
    {
        if (task <= taskNumber)
            return;
        StartCoroutine(showGratz(task));
    }

    IEnumerator showGratz(int nextTask)
    {
        objectiveText.color = Color.green;
        objectiveText.text = GRATZ[Random.Range(0, GRATZ.Length)];
        yield return new WaitForSeconds(1.5f);
        objectiveText.color = Color.red;
        taskNumber = nextTask;
        taskChange = true;
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.CHESTS_DESTROYED);
    }

}
