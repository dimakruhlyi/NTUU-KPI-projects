import stanford.karel.*;

public class Practice2 extends Karel{

	public void run(){
		Hw2_task1();
		//Hw2_task2();	
	}
	
	public void Hw2_task1() {
		while (frontIsClear() && noBeepersPresent()) {
		      move();
		    }
		    if (beepersPresent()) {
		      pickBeeper();
		      turn180();
		      moveToWall();
		    } else {
		      while (frontIsBlocked()) {
		      turnRightMove();
		      turnLeft();
		      }
		      move();
		      pickBeeper();
		      turn180();
		      moveToWall();
		      turnRight();
		      moveToWall();
		    }
		    turnRight();
	}

	
	public void Hw2_task2() {
		while (true) {
			moveToWall();
			if (blockedIntoFrontLeftRight()) break;
			turnLeft();
			moveToWall();
			if (blockedIntoFrontLeftRight()) break;
			turnLeft();
			moveToWall();
			if (blockedIntoFrontLeftRight()) break;
			turnRight();
			moveToWall();
			if (blockedIntoFrontLeftRight()) break;
			turnRight();
			moveToWall();
			if (blockedIntoFrontLeftRight()) break;
		}
	}
	private boolean blockedIntoFrontLeftRight() {
		return (frontIsBlocked() && leftIsBlocked() && rightIsBlocked());
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
 