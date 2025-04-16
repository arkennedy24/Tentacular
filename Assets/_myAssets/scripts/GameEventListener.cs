using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
    public GameEvent Event;
    public UnityEvent Response;

    //Wake up and get added to the event 
    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    //when turned off, unregister with event
    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    //when used, activate on every listener
    public void OnEventCalled()
    {
        Response.Invoke();
    }



}
