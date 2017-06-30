#!/bin/bash

unity="/Applications/Unity/Unity.app/Contents/MacOS/Unity"
curr=$(pwd)

echo "Build project from path ${curr}"

$unity -quit -batchmode -silent-crashes -projectPath "${curr}" -executeMethod Build.DoBuild -logFile /dev/stdout
