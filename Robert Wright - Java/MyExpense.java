package Assignment3;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Scanner;


// ****************************
//  MyExpense.java
//  Author: Robbie Wright (Robert Wright)
// 
// Driver program that tracks expenses inputted by
// the user. Demonstrates error handling.
// ****************************

public class MyExpense {
    
    private static Item[] expenseItems = new Item[5];
    private final static int TABLE_LINE_LENGTH = 46;

    public static void main(String args[]){
          
        Scanner sc = new Scanner(System.in);
        BufferedReader fileReader;
        String readLine;
        String input;
        double totalExpenses = 0;
        int count = 0;

        // Attempt to open file
        try{
            
            fileReader = new BufferedReader(new FileReader("/Users/robert/Documents/Schoolwork/TRU Courses/Comp-1231-Programming-II/Assignments/Robert Wright - ID# - T00740376 - Assignment #3/Assignment3/expense.txt"));

            try{

               printHeading();

            //    Process data file
                while( (readLine = fileReader.readLine()) != null){
                    
                    Item item = loadData(readLine);
                    
                    if(expenseItems[count] == null){
                        expenseItems[count] = item;
                        count++;
                    }
        
                    // Print item to table
                    System.out.println(buildTable(item));
                
                }
                // close file reader and print footer.
                fileReader.close();
                printFooter();

                // promp user.
                prompt();

                // Process user input
                while(!(input = sc.nextLine()).equals("!")){
          
                    String splitInput[] = input.split("\t");   
                   
                    if( splitInput.length == 2){

                        // Attempt to process user input
                        try{

                            //Cast attempt
                            double parsedAmt = Double.parseDouble(splitInput[1]);

                            // Write new data to file if we are not out of bounds and casting passes
                            try{
                                
                                Item item = new Item(splitInput[0],parsedAmt);
                                expenseItems[count] = item;

                                System.out.println("Item added:" + item.getDescription() + " = "+ item.getAmount());

                                writeToFile(item);
                                count++;
                              
                            // Handle array out of bounds exception.
                            }catch(ArrayIndexOutOfBoundsException err){
                                System.out.println("Array out of bounds. Record Skipped...");
                            }

                        // If the user input an invalid number, handle exception.
                        }catch(NumberFormatException err){
                            System.out.println("Invalid number! Record Skipped...");
                        }
                    }

                    // Continue to prompt user until they exit application.
                    prompt();
                }

                // Provide updated information and print table heading.
                System.out.println("Below is the most up to date information on expenses");
                printHeading();
            
                // Add all expenses to total and print each item to the table.
                for(int i = 0; i < expenseItems.length; i ++){

                    if(expenseItems[i] !=null){
                        totalExpenses += expenseItems[i].getAmount();
                        System.out.println(buildTable(expenseItems[i]));
                    }
                
                }
                printFooter();
                System.out.println("Total Expenses \t\t\t\t" + String.format("%.2f", totalExpenses));

            // Throws error if there is a problem reading the data.
            }catch(IOException err){
                err.printStackTrace();
            }
            
        // Throw error if file is not found.
        }catch(FileNotFoundException err){
           err.printStackTrace();
        }  

        // Close scanner.
        sc.close();

    }

    
    // -----------------------------------------------------------------
    // prints prompt to console
    // -----------------------------------------------------------------
    private static void prompt(){
        System.out.print("Enter an item description followed by ONE [TAB] key and then the amount (or type \"!\" to exit): ");
    }

    // -----------------------------------------------------------------
    // Takes in a readLine argument from file reader and builds a new
    // item.
    // -----------------------------------------------------------------
    private static Item loadData(String readLine){
        String[] splitInput = readLine.split("\t");
        return new Item(splitInput[0], Double.parseDouble(splitInput[1]));
    }
 
    // -----------------------------------------------------------------
    // Writes item data to expense file.
    // -----------------------------------------------------------------
    private static void writeToFile(Item item) throws IOException{
        
        String dataToWrite = "\n" + item.getDescription() + "\t" + item.getAmount();

        FileWriter fw = new FileWriter("expense.txt",true);
        BufferedWriter bw = new BufferedWriter(fw);
        PrintWriter outFile = new PrintWriter(bw);

        outFile.print(dataToWrite);
        outFile.println();

        outFile.close();
        // Files.writeString(filePath, dataToWrite, StandardOpenOption.APPEND);

    }

    // -----------------------------------------------------------------
    // Builds an evenly formatted row given an item.
    // -----------------------------------------------------------------
    private static char[] buildTable(Item item){

        char[] tableLine = new char[TABLE_LINE_LENGTH];

                  String formattedNum = String.format("%.2f", item.getAmount());


                //   Builds char based on already proccessed chars.
            for(int j = 0; j < TABLE_LINE_LENGTH; j++){
                if(j < item.getDescription().length()){
                    tableLine[j] = item.getDescription().charAt(j);
                }else if( j >= item.getDescription().length() && j < (TABLE_LINE_LENGTH - formattedNum.length())){
                    tableLine[j] = ' ';
                }else{
                    tableLine[j] = formattedNum.charAt(j - (TABLE_LINE_LENGTH - formattedNum.length()));
                }
            }
            return tableLine;
        }
    
    // -----------------------------------------------------------------
    // Prints a formatted heading.
    // -----------------------------------------------------------------
    private static void printHeading(){
        System.out.println("----------------------------------------------------");
        System.out.println("    Descrption                          Amount      ");
        System.out.println("----------------------------------------------------");
    }

    // -----------------------------------------------------------------
    // Prints a footer.
    // -----------------------------------------------------------------
    private static void printFooter(){
        System.out.println("----------------------------------------------------");
    }
}
