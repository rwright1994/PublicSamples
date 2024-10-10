public class Student implements Comparable<Student>{

    private String name;
    private double cGPA;

    public Student(String name, double cGPA){
        this.name = name;
        this.cGPA = cGPA;
    }

    public int compareTo(Student student){
        if(this.cGPA > student.cGPA){
            return 1;
        }else if(this.cGPA < student.cGPA){
            return -1;
        }else{
            return 0;
        }
    }

    public String getName(){
        return this.name;
    }

    public void setName(String name){
        this.name = name;
    }

    public double getCGPA(){
        return this.cGPA;
    }

    public void setCGPA(double cGPA){
        this.cGPA = cGPA;
    }

    @Override
    public String toString(){
        return "Name = " +this.name + " , Cummulative GPA:" + this.cGPA;
    }

}