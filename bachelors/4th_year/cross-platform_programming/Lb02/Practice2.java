import stanford.karel.*;

public class Practice2 extends Karel{

	public void run(){
		Lab_2_task1();
		//Lab_2_task2();
		//Lab_2_task3();	
	}

	public void Lab_2_task1() {
	   for (int i = 0; i < 5; i++) {
	      movePut();
	   	}
	    turnRight();
	    for (int i = 0; i < 2; i++) {
	      movePut();
	    }
	    turnRightMove();
	    turnLeftMove();
	    turnRight();
	    putBeeper();
	    for (int i = 0; i < 3; i++) {
	      movePut();
	    }
	    turnRightMove();
	    turnLeftMove();
	    turnRight();
	    putBeeper();
	    for (int i = 0; i < 2; i++) {
	      movePut();
	    }
	    turn180();
	    for (int i = 0; i < 3; i++) {
	      move();
	    }
	}
	
	
	public void Lab_2_task2() {
		goToBeeper();
		pickBeeper();
		goToStartPlace();
	}
	private void goToBeeper () {
		turnRightMove();
		turnLeftMove();
		move();
		move();
	}
	private void goToStartPlace () {
		turn180();
		move();
		move();
		turnRightMove();
		turnLeftMove();
		turn180();
	}
	
	
	public void Lab_2_task3() {
		while (true) {
		      turnLeft();
		      goAndPutToWall();
		      if (rightIsBlocked()) {
		        break;
		      }
		      turnRight();
		      for (int i = 0; i < 4; i++) {
		        move();
		      }
		      turnRight();
		      goAndPutToWall();
		      if (leftIsBlocked()) {
		        break;
		      }
		      turnLeft();
		      for (int i = 0; i < 4; i++) {
		        move();
		      }
		    }
	}
	private void goAndPutToWall () {
	    if (noBeepersPresent()) {
	      putBeeper();
	    }
	    while (frontIsClear()) {
	      move();
	      if (noBeepersPresent()) {
	        putBeeper();
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
 