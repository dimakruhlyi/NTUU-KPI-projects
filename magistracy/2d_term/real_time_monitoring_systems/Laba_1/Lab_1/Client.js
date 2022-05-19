module.exports = class Client {
    constructor(server, id) {
        this.server = server;
        this.id = id;

        this.init();
    }

    SERVER_REQUEST_INTERVAL = 15000;

    init() {
        this.startTaskProcessing();
    }

    startTaskProcessing() {
        setInterval(() => {
            setTimeout(() => this.server.clientRequest(this.id), Math.random() * 10000)
        }, this.SERVER_REQUEST_INTERVAL);
    }
}