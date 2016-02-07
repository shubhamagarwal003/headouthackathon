var express = require('express');
var app = express();
var fs= require('fs');

var city = ['new york', 'los angeles', 'las vegas'];
var texts =[
	{
		'city' : 'new york',
		'fact' : 'New York is a state in the Northeastern United States and is the United States 27th-most extensive, fourthnmost populous, and seventh most densely populated state.New York is bordered by New Jersey and Pennsylvania to the south and Connecticut,Massachusetts, and Vermont to the east.' 
	},
	{
		'city' : 'los angeles',
		'text' : 'Los Angeles officially the City of Los Angeles and often known by its initials L.A., is the second-largest city in the United States after New York City, the most populous city in the U.S. state of California, and the county seat of Los Angeles County.It is also home for Hollywood.'
	},
	{
		'city' : 'las vegas',
		'text' : 'Las Vegas officially the City of Las Vegas andoften known as simply Vegas, is a city in the United States, the most populous city in the state of Nevada, the county seat of Clark County, and the city proper of the Las Vegas Valley.'
	}
];

app.use(express.static(__dirname + '/images'));

app.get('/', function(req, res){
 	res.sendStatus(200);
});

app.get('/api/images', function(req, res){
	var query = req.query.term;
	var result = [];
	var dbResult='';
	if (query){
		if (query=="new york"){
			dbResult = 'new_york';
		} else if(query == "los angeles"){
			dbResult= 'los_angeles';
		} else if (query== "las vegas"){
			dbResult = 'las_vegas';
		}
		
		if(dbResult!=null){
			var files = fs.readdirSync(__dirname + '/images/'+dbResult);
			for (var i in files){
				result.push('/images/'+dbResult+'/'+files[i]);
			}
			res.json(result);
		} else {
			res.json({
				'message' : 'No result found'
			});
		}
	}
});

app.get('/images', function(req, res){
	var city = req.query.city;
	var image = req.query.image;
	var file = __dirname+ '/images/'+city+'/'+image;
	res.download(file);
});

app.get('/api/search', function(req, res){
	var query = req.query.term;
	res.sendStatus(query);
});

app.get('/api/facts', function(req, res){
	var city = req.query.city;
	for(var i =0;i<texts.length;i++){
		if(texts[i].city==city){
			return res.json(texts[i]);
		}
	}
});

app.listen(8080);
console.log('Server running on port 8080');
