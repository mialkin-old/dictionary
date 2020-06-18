#!/bin/bash
docker run -d -it -p 5001:80 -v ~/SQLite-files:/app/SQLite-files --rm --name dictionary mialkin/dictionary:2.0