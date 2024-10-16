using Unity.VisualScripting;

public class State {

    private string StateName;
    private int StateNumber;

//Create state objects that can track given state information;
    public State(string StateName, int StateNumber){
        this.StateName = StateName;
        this.StateNumber = StateNumber;
    }


//***********************
// ACCESSOR METHODS
//***********************
    public string getStateName(){
        return this.StateName;
    }

    public void setStateName(string newName){
        this.StateName = newName;
    }

    public int getStateNumber(){
        return this.StateNumber;
    }

    public void setStateNumber(int newVal){
        this.StateNumber = newVal;
    }
}
