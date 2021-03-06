package OOP_Advanced_Classes.Encapsulation;

import com.sun.javafx.scene.EnteredExitedHandler;
import sun.misc.Perf;

import java.util.*;

public class EncapsulationClassTest {
private Scanner scan;
    public EncapsulationClassTest(){
    this.scan = new Scanner(System.in);
    }


    //Salary increase task
    //---------------------------------------------------------------
    public void salaryIncrease(){
    int numberPersons = Integer.parseInt(this.scan.nextLine());
    Person[] persons = new Person[numberPersons];
    String[] getPersonData;
    Person personToCreate;
    for(int i=0;i<persons.length;i++){
        try{
            getPersonData = this.scan.nextLine().split("\\s+");
            personToCreate = new Person(getPersonData[0],Integer.valueOf(getPersonData[1]),Double.valueOf(getPersonData[2]));
            persons[i] = personToCreate;
        }catch(IllegalArgumentException exc){
            System.out.println(exc.getMessage());
        }
    }
    double percentageIncrease = Double.parseDouble(scan.nextLine());
    for(Person person:persons){
        person.increaseSalary(percentageIncrease);
        System.out.println(person);
    }
    this.scan.close();
    }
    //-----------------------------------------------------------------


    //FootballTeamGenerator task
//-----------------------------------------------------------------
    public void footballTeamGenerator(){
        HashMap<String,FootballTeam> currentTeams = new HashMap<>();
    String enterCommand = this.scan.nextLine();
    String[] splitCommand;
    while(!enterCommand.equalsIgnoreCase("End")){
        splitCommand = enterCommand.split(";");
        this.executeFootballTeamCommand(currentTeams,splitCommand);
        enterCommand = this.scan.nextLine();
    }
    this.scan.close();
    }
    private void executeFootballTeamCommand(HashMap<String,FootballTeam>teams,String...command){

    switch(command[0]){
        case "Team":
            if(!doesTeamExist(command[1],teams)){
                try{
                    teams.put(command[1],new FootballTeam(command[1]));
                }catch(IllegalAccessError exc){
                    System.out.println(exc.getMessage());
                }
            }
            break;
        case "Add":
            if(this.doesTeamExist(command[1],teams)){
                try{
                    //entering stats in array for more clear look
                    int[] stats = {Integer.valueOf(command[3]),Integer.valueOf(command[4])
                    ,Integer.valueOf(command[5]),Integer.valueOf(command[6]),Integer.valueOf(command[7])};

                    //adding and creating a new player object if there is invalid data an exception will appear
                    teams.get(command[1]).addPlayer(new FootballPlayer(command[2],stats[0],stats[1],stats[2]
                    ,stats[3],stats[4]));
                }catch(IllegalArgumentException exc){
                    System.out.println(exc.getMessage());
                }
            }else{
                System.out.printf("Team %s does not exist.",command[1]);
            }
            break;
        case "Remove":
            if(this.doesTeamExist(command[1],teams)) {
                try{
                    teams.get(command[1]).removePlayer(command[2]);
                }catch(IllegalArgumentException exc){
                    System.out.println(exc.getMessage());
                }

            }else{
            System.out.printf("Team %s does not exist",command[1]);
            }
            break;
        case "Rating":
            if(doesTeamExist(command[1],teams)){
                System.out.println(teams.get(command[1]).getRating());
            }else{
                System.out.printf("Team %s does not exist",command[1]);
            }
            break;
    }
    }

    private boolean doesTeamExist(String name, HashMap<String,FootballTeam>teams){
        if(teams.containsKey(name)){
            return true;
        }else{
            return false;
        }
    }
    //-----------------------------------------------------------------------------------

    //Phone Tasks
    public void phoneTask(){
        String name = "Iphone 4";
        SmartPhone phone = new SmartPhone(name);
        String[] phones = this.scan.nextLine().split("\\s+");
        String[] links  = this.scan.nextLine().split("\\s+");

        for(String number:phones){
            try{
                System.out.println(phone.call(number));
            }catch(IllegalArgumentException exc){
                System.out.println(exc.getMessage());
            }
        }

        for(String link:links){
            try{
                System.out.println(phone.browse(link));
            }catch(IllegalArgumentException exc){
                System.out.println(exc.getMessage());
            }
        }
    }
//------------------------------------------------------------------------------------------

    //FoodShortagePersonTask
    //-------------------------------------------------------------------------------------
    public void foodShortageTask(){
        //Enter number of people objects to create.
        System.out.print("Enter number people");
        int numberPeople = Integer.parseInt(scan.nextLine());

        //Different Object type.
        Rebel currentRebel;
        Citizen currentCitizen;

        //the collection to store them its map since we are looking by names in the final
        HashMap<String,FoodShortagePerson> currentPeople = new HashMap<String,FoodShortagePerson>();

        String enterData;
        String[] splitData;

        //create number of objects
        for(int i=0;i<numberPeople;i++){
            System.out.print("Enter person data: ");
            enterData = this.scan.nextLine();   //enter object  parameters separated by space
            splitData = enterData.split("\\+"); //get the parameters

            //check which object to create.
            switch(splitData.length){

                //Citizen creation
                case 4:
                    try{
                        if(!currentPeople.containsKey(splitData[0])){
                            currentCitizen = new Citizen(splitData[0],Integer.valueOf(splitData[1]),splitData[2],
                                    splitData[3]);
                            currentPeople.put(splitData[0],currentCitizen);
                        }
                    }catch(IllegalArgumentException exc){
                        System.out.println(exc.getMessage());
                    }
                    break;

                    //Rebel creation
                case 3:
                    try{
                        if(!currentPeople.containsKey(splitData[0])){
                            currentRebel = new Rebel(splitData[0],Integer.valueOf(splitData[1]),splitData[2]);
                            currentPeople.put(splitData[0],currentRebel);
                        }
                    }catch(IllegalArgumentException exc){
                        System.out.println(exc.getMessage());
                    }
                    break;
                default:
                    break;
            }
        }

        //Enter names until End is entered and for each name call the buyFood Method.
        System.out.print("Enter name: ");
        String enterName = this.scan.nextLine();
        while(!enterName.equalsIgnoreCase("End")){
            if(currentPeople.containsKey(enterName)){
                currentPeople.get(enterName).buyFood();
            }
            System.out.print("Enter name: ");
            enterName = this.scan.nextLine();
        }

        //print total food bought
        int totalFood =0;       //the old fashioned way
        for(Map.Entry<String,FoodShortagePerson> currentPerson:currentPeople.entrySet()){
            totalFood+= currentPerson.getValue().getFood();
        }
        System.out.println(totalFood);
    }


    //---------------------------------------------------------------------------------

}
