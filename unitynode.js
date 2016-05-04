var io = require('socket.io').listen(8080);

io.on('connection', function (socket) {
  console.log('Hello!');
  socket.send('connect.');
  socket.emit('emit', 'emit.');

  socket.on('message', function (data) {
    console.log('message data is ... ' + data);
  });

  socket.on('emit', function (data) {
    console.log('emit data is ... ' + data);
  });

  socket.on('disconnect', function () {
    console.log('disconnect.');
  });
});