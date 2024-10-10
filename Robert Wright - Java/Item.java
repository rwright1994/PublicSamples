package Assignment3;

// ****************************
//  Item.java
//  Author: Robbie Wright (Robert Wright)
// 
// Represents an expense item object for MyExpense.java
// ****************************


public class Item{

    private String description;
    private double amount;


    // -----------------------------------------------------------------
    // Constructor
    // -----------------------------------------------------------------
    public Item(String descrption, double amount){
        this.description = descrption;
        this.amount = amount;
    }

    // -----------------------------------------------------------------
    // Accessor
    // -----------------------------------------------------------------
    public String getDescription() {
        return this.description;
    }

    // -----------------------------------------------------------------
    // Mutator
    // -----------------------------------------------------------------
    public void setDescription(String description){
        this.description = description;
    }

    // -----------------------------------------------------------------
    // Accessor
    // -----------------------------------------------------------------
    public double getAmount(){
        return this.amount;
    }

    // -----------------------------------------------------------------
    // Mutator
    // -----------------------------------------------------------------
    public void setAmount(double amount){
        this.amount = amount;
    }

    // -----------------------------------------------------------------
    // toString() Override 
    // -----------------------------------------------------------------
    @Override
    public String toString(){
        return (this.description + " " + this.amount);
    }
}