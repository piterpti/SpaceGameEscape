using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour {

    public static int TASKS_HACK_COMPUTER = 1;
    public static int TASKS_GO_TO_THE_ROOM = 2;
    public static int DESTROY_CHESTS = 3;
    public static int CHESTS_DESTROYED = 4;
    public static int SECOND_DOORS_OPEN = 5;
    public static int THROUH_CORRIDOR = 6;
    public static int NEXT_SIDE = 7;



    public static Text objectiveText;

    private string[] OBJECTIVES = { "Find way to disable lasers",
                                        "Hack computer to open doors at the end of the corridor",
                                        "Go through the corridor",
                                        "Hmm.. Try to destroy this chests!",
                                        "Find 2nd floor like this to open next door!",
                                        "Go through open doors",
                                        "Try to overcome obstacles and turn it off!",
                                        "Now, try get to the next side"
                                                                };
    private string [] GRATZ = { "Congratulations!", "Done!", "Gratz!", "Yeah!", "Good", "Nice!", "Awesome!" };
    private bool taskChange = true;
    private int taskNumber = 0;

	void Start () {
        objectiveText = GameObject.Find("ObjectiveText").GetComponent<Text>();
	}
	
	void Update () {
        if (taskChange)
        {
            objectiveText.text = OBJECTIVES[taskNumber];
            taskChange = false;
        }
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
        yield return new WaitForSeconds(3f);
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
