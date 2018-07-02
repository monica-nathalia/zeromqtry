echo off
cd /d %~dp0

start "Publisher" cmd /T:8E /k Pub.exe -b tcp://127.0.0.1:5000 -m "template1.json";"template2.json";"template3.json";"template4.json";"template5.json" -x 5 -d 1000
start "Subscriber 1" cmd /T:8E /k Sub.exe -c tcp://127.0.0.1:5000 -d 0