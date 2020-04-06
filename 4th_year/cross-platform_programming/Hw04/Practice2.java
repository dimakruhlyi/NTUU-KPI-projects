import stanford.karel.*;

public class Practice2 extends Karel{

	public void run(){
		Hw4_task1();
		//Hw4_task2();
		
	}
	public void Hw4_task1() {
		while (true) {
			move();
			if (noBeepersPresent()) {
				turnLeft();
				move();
				while (beepersPresent()) {
					pickBeeper();
				}
				turn180();
				move();
				move();
				while (beepersPresent()) {
					pickBeeper();
				}
				turn180();
				move();
				turnRight();
			}
			move();
			if (frontIsBlocked()) {
				break;
			}
		}
	}
	
	public void Hw4_task2() {
		int i = moveAndPutToWall();
		while (true) {        
			i -= 2;
			if (i <= 0) {
				moveToWall();
				break;
			}
			turnLeftMove();
			turnLeft();
			for (int j = 0; j < i; j++) {
				movePut();
			}
			i -= 2;
			if (i <= 0) {
				moveToWall();
				break;
			}
			turnRightMove();
			turnRight();
			for (int j = 0; j < i; j++) {
				movePut();
			}
		}
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
 