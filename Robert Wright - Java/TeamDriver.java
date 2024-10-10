
import java.util.Collections;

public class TeamDriver {
    

   
    public static void main(String[] args) {
        
        // Create student list with a size 10.
        Team<Student> teamOne = new Team<Student>(10);

        // Create student Objs
        Student bobby = new Student("Bobby", 3.66);
        Student mike = new Student("Mike", 4.0);
        Student janice = new Student("Janice", 3.37);
        Student tim = new Student("Tim", 3.87);
        Student terry = new Student("Terry", 2.4);
        Student lucy = new Student("Lucy", 3.00);
        Student amanda = new Student("Amanda", 4.0);
        Student liz = new Student("Liz", 3.51);
        Student rob = new Student("Rob", 2.89);
        Student tony = new Student("Tony", 3.69);
     
        // add students to list.
        teamOne.addToTeam(bobby);
        teamOne.addToTeam(mike);
        teamOne.addToTeam(janice);
        teamOne.addToTeam(tim);
        teamOne.addToTeam(terry);
        teamOne.addToTeam(lucy);
        teamOne.addToTeam(amanda);
        teamOne.addToTeam(liz);
        teamOne.addToTeam(rob);
        teamOne.addToTeam(tony);
        

        System.out.println("The following students would like to join the competition team:");
        System.out.println(teamOne.toString());
        System.out.println("Total number of students: "+ teamOne.getNumberOfMembers());

        System.out.println("Students who do not meet the GPA requirement.");

        // Remove students that don't meet CGAP Requirement.
        teamOne.removeStudentsWithCGPA();

        System.out.println("\nStudents who have fulfilled the cGPA requirement (3.67):");
        System.out.println(teamOne.toString());

        System.out.println("The following candidate who submitted the application last has been removed from the list:");
        System.out.print("Removed -> ");
        teamOne.removeFromTeam();
       
        System.out.println("\nCandidates sorted by cGPA in decending order:");

        // Sorts collection with the student comparable interface, i.e. CompareTo();
        Collections.sort(teamOne.getTeamMembers(), Collections.reverseOrder());

        // print results after sorting.
         if(teamOne.hasNoMemeber()){
            System.out.println("No candidates selected!");
        }else{
            System.out.println(teamOne.toString());
        }



        // Case 2
        System.out.println("------ Case Two ------");

        // Create secoond team
        Team<Student> teamTwo = new Team<Student>(3);

        // Create students
        Student jancy = new Student("Jancy", 3.66);
        Student peter = new Student("Peter", 3.0);
        Student tracy = new Student("Tracy", 3.33);

        // Add students to list.
        teamTwo.addToTeam(jancy);
        teamTwo.addToTeam(peter);
        teamTwo.addToTeam(tracy);


        System.out.println("The following students would like to join the competition team:");
        System.out.println(teamTwo.toString());
        System.out.println("Total number of students: " + teamTwo.getNumberOfMembers());

        // Remove students that don't meet CGAP Requirement.
        teamTwo.removeStudentsWithCGPA();

        System.out.println("\nStudents who have fulfilled the cGPA requirement (3.67):");

       // print results after sorting.
        if(teamTwo.hasNoMemeber()){
            System.out.println("No candidates selected!");
        }else{
            System.out.println(teamTwo.toString());
        }

        System.out.println("\nThe following candidate who submitted the application last has been removed from the list:");
        teamTwo.removeFromTeam();

        System.out.println("\nCandidates sorted by cGPA in decending order:");
        Collections.sort(teamTwo.getTeamMembers());
        System.out.println(teamTwo.toString());
 
    }
}
