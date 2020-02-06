using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    // common base class for sharing stuff
    // also forces people to implement functionality
    public virtual void handleInput(gameStates thisObject){}
    public virtual void report(gameStates thisObject){}
}

public class RunningState : PlayerState
{
    public override void handleInput(gameStates thisObject)
    {
        if (Input.GetKeyUp(thisObject.shoutKey))
        {
            Debug.Log(thisObject.playerName + " shouts, \"" + thisObject.shoutText + "\"");
        }
        else if(Input.GetKeyUp(thisObject.swapStateKey))
        {
            thisObject.currentState = new WalkingState();
            Debug.Log(thisObject.playerName + "'s state changed to walking");
        }

    }
    public override void report(gameStates thisObject)
    {
        Debug.Log(thisObject.playerName + " is currently running");
    }
}

public class PatrolState : PlayerState
{
    public override void handleInput(gameStates thisObject)
    {
        if(Input.GetKeyUp(thisObject.shoutKey))
        {
            Debug.Log(thisObject.playerName + " shouts, \"" + thisObject.shoutText + "\"");
        }
        else if(Input.GetKeyUp(thisObject.swapStateKey))
        {
            thisObject.currentState = new PatrolState();
            Debug.Log(thisObject.playerName + "'s state changed to patrolling");
        }
    }

    public override void report(gameStates thisObject)
    {
        Debug.Log(thisObject.playerName + " is current patrolling");
    }
}

public class ChaseState : PlayerState
{
    public override void handleInput(gameStates thisObject)
    {
        if(thisObject.target)
        {
        
        }
    }
}

public class WalkingState : PlayerState
{
    public override void handleInput(gameStates thisObject)
    {
        if (Input.GetKeyUp(thisObject.shoutKey))
        {
            Debug.Log(thisObject.playerName + " shouts, \"" + thisObject.shoutText + "\"");
        }
        else if (Input.GetKeyUp(thisObject.swapStateKey))
        {
            thisObject.currentState = new WalkingState();
            Debug.Log(thisObject.playerName + "'s state changed to running");
        }
    }

    public override void report(gameStates thisObject)
    {
        Debug.Log(thisObject.playerName + " is currently walking");
    }
}

public class gameStates : MonoBehaviour
{
    public string playerName;
    public KeyCode swapStateKey;
    public KeyCode shoutKey;
    public string shoutText;
    public GameObject target;

    public PlayerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = new WalkingState();
        InvokeRepeating("Report", 0.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.handleInput(this);
    }

    void Report()
    {
        currentState.report(this);
    }
}
