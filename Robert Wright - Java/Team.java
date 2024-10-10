import java.util.ArrayList;


public class Team<T> {
    
    private static int DEFAULT_CAPACITY = 10;
    private T mostRecentMember;
    private ArrayList<T> teamMembers;


    public Team(){
        this(DEFAULT_CAPACITY);
    }

    public Team(int capacity){
        // create new team here
        this.teamMembers = new ArrayList<T>(DEFAULT_CAPACITY);
    }

    // add a team member to the array and update most recently added
    // member.
    public void addToTeam(T member){
      if(teamMembers.size() < DEFAULT_CAPACITY){
        teamMembers.add(member);
        mostRecentMember = member;
      }else{
        System.out.println("Sorry, there is no more room on the team!");
      }
    }

       // Removes the last member who joined the team.
    public boolean removeFromTeam(){
        
        // If the list is empty print msg return null.
        if(teamMembers.isEmpty()){
            System.out.println("No candidate in the list.");
            return false;
        // Return member at end of the list.
        }else{
            if(mostRecentMember != null){
                teamMembers.remove(mostRecentMember);
                System.out.println(mostRecentMember.toString());
                mostRecentMember = null;
            }else{
                System.out.println("No candidate in list.");
            }
          
            return true;
        }
    }

    // Removes a member of type T.
    public T removeFromTeam(T member){
      if(teamMembers.isEmpty()){
        System.out.println("No team members to remove...");
        return null;
      }else{
        if(member == mostRecentMember){
            mostRecentMember = null;
        }
        teamMembers.remove(member);
        return member;
      }
    }

    // Return the number of team members.
    public int getNumberOfMembers(){
        return teamMembers.size();
    }

    // returns if the list has any members.
    public boolean hasNoMemeber(){
        if(teamMembers.size() == 0){
            return true;
        }else{
            return false;
        }
    }

    // removes stuidents with a cGPA less than 3.67.
    // ensures encapsulation.
    public void removeStudentsWithCGPA(){
        for(int i = teamMembers.size()-1; i >= 0; i--){
            Student student = (Student) teamMembers.get(i);
            if(student.getCGPA() < 3.67){
               teamMembers.remove(i);
                System.out.println("Removed -> " + student.toString());
            }
        }
    }

    // If there are no members return default message, otherwise print team list
    @Override
    public String toString(){
        if(teamMembers.isEmpty()){
            return "No candidates in the list.";
        }else{
            StringBuilder sb = new StringBuilder();
            teamMembers.forEach((member) -> {
                Student student = (Student) member;
                sb.append("Name = " +student.getName() + ", Cummulative GPA: " + student.getCGPA() + "\n");
            });
            return sb.toString();
        }
    }

    // Return the list of teamMembers for manipulation.
    public ArrayList<T> getTeamMembers(){
        return teamMembers;
    }

  
}   
