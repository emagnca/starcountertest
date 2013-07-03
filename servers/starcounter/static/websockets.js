$(document).ready(function(){
	alert("in doc ready");
	if("WebSocket" in window){
	    alert("has websockets");
	}
	else{
	    alert("no websockets");
	}
    });