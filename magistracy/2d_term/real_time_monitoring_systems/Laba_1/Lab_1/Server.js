module.exports = class Server {
    static BUSY_STATE = "BUSY"
    static FREE_STATE = "FREE"

    CHECK_INTERVAL = 100;

    clients = {};
    clientsQueue = [];

    state = {
        processingClientId: null
    }

    init() {
        setInterval(() => this.processClient(), this.CHECK_INTERVAL);
    }
    
    addClient(c) { this.clients[c.id] = c; }
    isFree() { return !!this.state.isProcessing }

    addToQueue(c) { this.clientsQueue.push(c) }

    async processClient() {
        if ( this.state.processingClientId || !this.clientsQueue.length) return;
        
        const clientToProcess = this.clientsQueue.shift();

        this.state.processingClientId = clientToProcess.id;
        await new Promise(( res, rej ) => setTimeout(res, Math.random() * 10000));
        this.state.processingClientId = null;

        console.log(`processed task from client ${clientToProcess.id}`);
        console.log(this.clientsQueue.length ?  `tasks in queue - ${this.clientsQueue.length}` : 'all tasks completed')
    }

    clientRequest(id) {
        this.addToQueue(this.clients[id]);
    }
}