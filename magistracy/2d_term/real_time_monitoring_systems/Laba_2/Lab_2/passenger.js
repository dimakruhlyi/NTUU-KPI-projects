const { getRandomArbitrary} = require('./utils');
const Elevator = require('./Elevator');

module.exports = class Passenger{
    constructor(elevator, id) {
        this.elevator = elevator;
        this.id = id;

        this.name = `client-${this.id}`;

        this.destinationFloor = null;
        this.startFloor = this._calculateDestinationFloor();
        this.direction = null;
        this.arrived = true;

        this._checkIsArrived();
    };

    CHECK_IS_ARRIVED_INTERVAL = 100;

    _checkIsArrived() {
        setInterval(() => { if (this.arrived) {this._goToFloor() }}, this.CHECK_IS_ARRIVED_INTERNAL);
    }

    _goToFloor(){
        this.destinationFloor = this._calculateDestinationFloor();
        this.direction = this.startFloor > this.destinationFloor ? Elevator.DOWN_DIRECTION : Elevator.UP_DIRECTION;
        this.arrived = false;

        setTimeout(() => this.elevator.passengerRequest(this), math.random * 1000);
    }

    _setFloor(destinationFloor){
        this.startFloor = destinationFloor;
    }

    _calculateDestinationFloor(){
        return getRandomArbitrary(Elevator.FIRST_FLOOR, Elevator.MAX_FLOOR);
    }

};
