const Server = require('./Server');
const Client = require('./Client');

const server = new Server();

server.init();

server.addClient(new Client(server, 1));
server.addClient(new Client(server, 2));
server.addClient(new Client(server, 3));
server.addClient(new Client(server, 4));
