
var URI = "http://localhosst";

function setCookie(name,value,days) {
    if(days) {
	var date = new Date();
              date.setTime(date.getTime()+(days*24*60*60*1000));
              var expires = "; expires="+date.toGMTString();
    }
    else var expires = "";
    document.cookie = name+"="+value+expires+"; path=/";
}

function getCookie(name,defval) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for(var i=0;i < ca.length;i++) {
	var c = ca[i];
	while (c.charAt(0)==' ') c = c.substring(1,c.length);
	if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
    }
    return defval;
}


$(window).bind("beforeunload", function() {
	setCookie('cooked_lat', map.getCenter().getLatitude());
	setCookie('cooked_lon', map.getCenter().getLongitude());
	setCookie('cooked_zoom', map.getZoomLevel());
    });


MQA.EventUtil.observe(window, 'load', function() {
	var ltt = 59.367; //getCookie('cooked_lat', 59.367);
	var lon = 17.966; //getCookie('cooked_lon', 17.966);
	var zoom = 11; //getCookie('cooked_zoom', 11);
	
	var options={
	    elt:document.getElementById('map'),
	    zoom:zoom,                           
	    latLng:{lat:ltt, 
		    lng:lon},   
	    mtype:'map'                      
	};
	
	map = new MQA.TileMap(options);
        
	MQA.withModule('largezoom', function() {
	        map.addControl(
			       new MQA.LargeZoom(),
			       new MQA.MapCornerPlacement(MQA.MapCorner.TOP_LEFT, new MQA.Size(5,5))
			       );
	    });
	
	
	MQA.withModule('mousewheel', function() {
                map.enableMouseWheelZoom();
            });
	
	MQA.withModule('viewoptions', function() {
	        map.addControl(
			       new MQA.ViewOptions()
			       );
	    });
	
	MQA.withModule('geolocationcontrol', function() {    
		map.addControl(
			       new MQA.GeolocationControl()
			       );
		
            });
    });

	  function handleObject(report, pois){
	      if(report["solved"] == "False"){
		  var poi = new MQA.Poi( { lat:report['latitude'], lng:report['longitude'] } );
		  htmlInfo = report['description'];
		  htmlInfo += "<br><br><a href=\"" + "http://tl1.emagnca.webfactional.com" + report['image']  + "\">Foto</a>"; 
		  poi.setRolloverContent(report['name']);
		  poi.setInfoContentHTML(htmlInfo);
		  pois.add(poi); 
	      }
	  }

function getRemoteObjects(pois){
    $.getJSON(URI + "/art/v1/allreports",
	      function(data) {
		  $.each(data, function(i, report){
			  var repo = new Array(); 
			  $.each(report, function(key, val){
				  repo[key] = val;
			      }); 
			  handleObject(repo, pois);
		      });
	      });
}

function getRemoteData(){
    var pois = new MQA.ShapeCollection();
    getRemoteObjects(pois);
    window.map.removeAllShapes();
    window.map.addShapeCollection(pois);
    window.map.bestFit();
    document.getElementById("text").value=new Date().toTimeString().substring(0,9);
}


var isUpdating = 0;
var timeout;

function update(){
    if(isUpdating){
	getRemoteData();
	timeout = setTimeout("update()",60000);
    }
}

function toggleUpdate(){
    var button = document.getElementById('button');
    if(!isUpdating){ 
	isUpdating = 1;
	button.value="Stoppa automatisk uppdatering";
	update();
    }
    else{
	isUpdating = 0;
	clearTimeout(timeout);
	button.value="Starta automatisk uppdatering";
    }
}
