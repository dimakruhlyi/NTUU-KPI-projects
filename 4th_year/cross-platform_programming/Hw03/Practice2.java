import stanford.karel.*;

public class Practice2 extends Karel{

	public void run(){
		Hw3();
		
	}
	
	public void Hw3() {
		int i = 0;
		int j = 0;
		while (true) {
			if (facingEast() && frontIsBlocked()) {
				if (leftIsBlocked()) {
					break;
				} else {
					turnLeftMove();
					turnLeft();
				}
			} else if (facingWest() && frontIsBlocked()) {
				if (rightIsBlocked()) {
					break;
				} else {
					turnRightMove();
					turnRight();
				}
			}
			while (true) {			
				if ((i + j) % 2 == 0) {
					putBeeper();
				}
				if (frontIsBlocked()) {
					break;
				}	
				move();
				j++;
			}
			i++;
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
 