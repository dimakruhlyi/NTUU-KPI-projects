import stanford.karel.*;

public class Practice2 extends Karel{

	public void run(){
		Lab_3_task1();
		//Lab_3_task2();
	
	}

	public void Lab_3_task1() {
		int pass = 0;
		moveAndPickToWall();
		pass = 1;
		
		while (true) {
			if (facingEast() && leftIsClear()) {
				turnLeftMove();
				turnLeft();
				moveAndPickToWall();
				pass = 1;
			} else if (facingWest() && rightIsClear()) {
				turnRightMove();
				turnRight();
				moveAndPickToWall();
				pass = 1;
			} else {
				if (pass == 2) {
					turn180();
					moveToWall();
					break;
				}
				turn180();
				moveToWall();
				pass = 2;
			}
		}
	}
	
	public void Lab_3_task2() {
		int pass = 0;
		turnLeft();
		moveAndPickToWall();
		pass = 1;
		
		while (true) {
			if (facingSouth() && leftIsClear()) {
				turnLeftMove();
				turnLeft();
				moveAndPickToWall();
				pass = 1;
			} else if (facingNorth() && rightIsClear()) {
				turnRightMove();
				turnRight();
				moveAndPickToWall();
				pass = 1;
			} else {
				if (pass == 2) {
					turnRight();
					break;
				}
				turn180();
				moveToWall();
				pass = 2;
			}
		}
		turn180();
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
 