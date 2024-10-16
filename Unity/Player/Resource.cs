
public class Resource 
{

  public int _id{get;}
  private string name;

  public double amount{get;set;}
  public double tickRate{get;set;}
  
  public Resource(int id, string name, double tickRate){
    _id = id;
    this.name = name;
    this.amount = 0;
    this.tickRate = tickRate;
  }

  public int getID(){
    return _id;
  }

  public string getName(){
    return name;
  }

  public void tickResource(){
    amount += tickRate;
  }
}
