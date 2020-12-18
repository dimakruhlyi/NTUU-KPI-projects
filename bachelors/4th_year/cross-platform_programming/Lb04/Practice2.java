import stanford.karel.*;

public class Practice2 extends Karel{

	public void run(){
		Lab_4();
		
	}
	
	public void Lab_4() {
		int i = (int)(moveToWall() / 2 - 0.5);
		turn180();
		for (int j = 0; j < i; j++) {
			move();
		}
		putBeeper();
	}
	
	public void turnLeftMove() {
		turnLeft();
		move();
	}
	
	public void turnRightMove() {
		turnRight();
		move();
	}
	
	public void movePut() {
		move();
		putBeeper();
	}
	
	public void turnRight() {
		for(int i = 0; i < 3; i++) {
			turnLeft();
		}
	}
	
	public void turn180() {
		for(int i = 0; i < 2; i++) {
			turnLeft();
		}
	}
	
	public int moveToWall () {
		int i = 1;
		while (frontIsClear()) {
			move();
			i++;
		}
		i++;
		return i;
	}
	
	public void moveAndPickToWall () {
		if (beepersPresent()) {
			pickBeeper();
		}
		while (frontIsClear()) {
			move();
			if (beepersPresent()) {
				pickBeeper();
			}
		}
	}
	
	public int moveAndPutToWall () {
		int i = 0;
		if (noBeepersPresent()) {
			putBeeper();
			i++;
			
		}
		while (frontIsClear()) {
			move();
			if (noBeepersPresent()) {
				putBeeper();
				i++;
			}
		}
		return i;
	}
}
 