using Unity.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager {

 
    private State currentState;
    
    private List<IStateObserver> Observers = new List<IStateObserver>();
    public StateManager(){
        currentState = new State("Main Menu", 0);
    }

    public State getCurrentState(){
        return currentState;
    }

    public void setState(State newState){
        this.currentState = newState;  
        NotifyStateChanged();
    }

    public void Subscribe(IStateObserver observer){
        Observers.Add(observer);
    }

    public void Unsubscribe (IStateObserver observer){
        Observers.Remove(observer);
    }

    private void NotifyStateChanged(){
        if(Observers.Count != 0){
            foreach(var observer in Observers){
                observer.OnStateChanged(currentState);
            }
        }
    }
}


