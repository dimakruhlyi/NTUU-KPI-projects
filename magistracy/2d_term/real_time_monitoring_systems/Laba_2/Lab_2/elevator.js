module.exports = class Elevator {
    static BUSY_STATE = "BUSY";
    static FREE_STATE = "FREE";
    static UP_DIRECTION = "UP";
    static DOWN_DIRECTION = "DOWN";

    static MAX_PASSENGERS_COUNT = 3;
    static FIRST_FLOOR = 1;
    static MAX_FLOOR = 5;

    passengersInElevator = [];
    passengersQueues = {
        1: [],
        2: [],
        3: [],
        4: [],
        5: [],
    };
    state = {
        state: Elevator.FREE_STATE,
        currentFloor: 1,
        direction: Elevator.UP_DIRECTION,
    };

    passengerRequest(passenger){
        this._addPassengerToQueue(passenger);
            if (this._isFree()){
                this._goToFloorWithoutPassengers(passenger.startFloor);
                if (passenger.direction == Elevator.UP_DIRECTION) this._goUp();
                if (passenger.direction == Elevator.DOWN_DIRECTION) this._goDown();
                return;
        }
    }

    _isFree(){return this.state.state == Elevator.FREE_STATE}
    _isFull(){return this.passengersInElevator.length >= Elevator.MAX_PASSENGERS_COUNT}
    _addPassengerToQueue(passenger){ this.passengersQueues[passenger.startFloor].push(passenger)}

    _goDown(){
        if (this.state.currentFloor == Elevator.FIRST_FLOOR) throw new Error('You are on the first floor already');
        this.state.state = Elevator.BUSY_STATE;
        this.state.direction = Elevator.DOWN_DIRECTION;

        const passengerWithSameDirection = this.passengersQueues[this.state.currentFloor].filter(p => p.direction == Elevator.DOWN_DIRECTION);

        this._addPassengerToElevator(passengerWithSameDirection);
        const arrivedPassengers = this.passengersInElevator.filter(p => p.destinationFloor == this.state.currentFloor);

        this._printArrivedPassengers(arrivedPassengers);
        this._removeArrivedPassengers();

        this._printElevatorState();
        this.state.currentFloor -= 1;

        if (this.state.currentFloor == Elevator.FIRST_FLOOR){
            this.state.state = Elevator.FREE_STATE;
            return;
        }else{
            this._goDown();
        }
    }

    _goUp(){
        if (this.state.currentFloor == Elevator.MAX_FLOOR) throw new Error('You are on the last floor already');
        this.state.state = Elevator.BUSY_STATE;
        this.state.direction = Elevator.UP_DIRECTION;

        const passengerWithSameDirection = this.passengersQueues[this.state.currentFloor].filter(p => p.direction == Elevator.UP_DIRECTION);

        this._addPassengersToElevator(passengerWithSameDirection);
        const arrivedPassengers = this.passengersInElevator.filter(p => p.destination == this.state.currentFloor);
        this._printArrivedPassengers(arrivedPassengers);
        this._removeArrivedPassengers();

        this._printElevatorState();
        this.state.currentFloor += 1;

        if (this.state.currentFloor == Elevator.MAX_FLOOR){
            this.state.state = Elevator.FREE_STATE;
        }else{
            this._goUp();
        }
    }

    _addPassengersToElevator(passengerWithSameDirection){
        const freePlaces = Elevator.MAX_PASSENGERS_COUNT - this.passengersInElevator.length;
        const newPassengers = passengerWithSameDirection.slice(0, freePlaces);

        this.passengersInElevator = this.passengersInElevator.concat(newPassengers);
        this._removePassengersFromQueue(newPassengers);
    }

    _removeArrivedPassengers(){
        this.passengersInElevator = this.passengersInElevator.filter(p => p.destinationFloor != this.state.currentFloor);
    }

    _removePassengersFromQueue(passengers){
        passengers.forEach(pas =>{
            this.passengersQueues[pas.startFloor] = this.passengersQueues[pas.startFloor].filter(p => p.id != pas.id);
            pas.arrived = true;
            pas.startFloor = this.state.currentFloor;
            this._printStartingPassenger(pas);
        })
    }
};
