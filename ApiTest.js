#!/usr/bin/env node

var http = require('http');

var count = 500;

while(count--)
{
    var start = Math.floor(new Date() / 1000);
    
    http.get(
	{
	    host: 'localhost',
        path: '/WebApiCore/values'
	}, 
	function(response) {
	    var body = '';
	    response.on('data', function(data) {
		body += data;
	    });
	    response.on('end', function() {
		var end = Math.floor(new Date() / 1000);

		var parsed = JSON.parse(body);
		console.log('Request finished in: ' + (end - start) + ' seconds.');
		console.log(body);
		console.log('-------------');
	    });
	}).on('error', function(err) {
		console.log('Error: ' + err.message);
	});	
}