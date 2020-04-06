import stanford.karel.*;

public class Practice2 extends Karel{

	public void run(){
		Lab_1();	
	}
	public void Lab_1() {
		move();
		pickBeeper();
		turnLeft();
		move();move();move();move();
		turnRight();
		move();move();
		putBeeper();
		turn180();
		move();move();move();
		turnLeft();
		move();move();move();move();
		turnLeft();
 	}	
}
 