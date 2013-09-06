#!/bin/sh
HOST=192.168.0.159:8282
curl -X POST http://$HOST/register/ -d {"group":"testgroup","user":"magnus"} 
curl -X POST http://$HOST/deregister/ -d {"group":"testgroup","user":"magnus"} 
